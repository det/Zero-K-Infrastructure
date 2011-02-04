using System;
using System.Deployment.Application;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Xml.Serialization;
using LobbyClient;
using Microsoft.Win32;
using PlasmaShared;
using ZeroKLobby.MicroLobby;
using ZeroKLobby.Notifications;
using Application = System.Windows.Forms.Application;
using MessageBox = System.Windows.Forms.MessageBox;

namespace ZeroKLobby
{
  static class Program
  {
    static readonly object configLock = new object();
    static string ConfigDirectory;
    static NewVersionBar NewVersionBar;
    static Mutex mutex;
    public static AutoJoinManager AutoJoinManager;
    public static BattleBar BattleBar { get; private set; }
    public static BattleIconManager BattleIconManager { get; private set; }
    public static bool CloseOnNext;
    public static Config Conf = new Config();
    public static ConnectBar ConnectBar { get; private set; }
    public static PlasmaDownloader.PlasmaDownloader Downloader { get; private set; }
    public static FriendManager FriendManager;
    public static MainWindow MainWindow { get; private set; }
    public static ModStore ModStore { get; private set; }
    public static NotifySection NotifySection { get { return MainWindow.NotifySection; } }
    public static QuickMatchTracking QuickMatchTracker { get; private set; }
    public static SayCommandHandler SayCommandHandler { get; private set; }
    public static SpringPaths SpringPaths { get; private set; }
    public static SpringScanner SpringScanner { get; private set; }
    public static SpringieServer SpringieServer = new SpringieServer();
    public static string[] StartupArgs;
    public static string StartupPath = Path.GetDirectoryName(Path.GetFullPath(Application.ExecutablePath));
    public static TasClient TasClient { get; private set; }
    public static ToolTipHandler ToolTip;

    /// <summary>
    /// windows only: do we have admin token?
    /// </summary>
    public static bool IsAdmin()
    {
      return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
    }

    internal static void LoadConfig()
    {
      var configFilename = GetFullConfigPath();
      if (!File.Exists(configFilename))
      {
        // port old config      
        if (ApplicationDeployment.IsNetworkDeployed)
        {
          try {
            File.Move(Path.Combine(ApplicationDeployment.CurrentDeployment.DataDirectory, "SpringDownloaderConfig.xml"), configFilename);
          } catch { }
        }
      }

      if (File.Exists(configFilename)) {
        var xs = new XmlSerializer(typeof(Config));
        try
        {
          Conf = (Config)xs.Deserialize(new StringReader(File.ReadAllText(configFilename)));
          Conf.IsFirstRun = false;
        }
        catch (Exception ex)
        {
          Trace.TraceError("Error reading config file: {0}", ex);
          Conf = new Config();
          Conf.IsFirstRun = true;
        }
      }
      else Conf.IsFirstRun = true;

      Conf.UpdateFadeColor();
    }

    [STAThread]
    public static bool Main(string[] args)
    {
      try
      {
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.Listeners.Add(new LogTraceListener());

        if (Process.GetProcesses().Any(x => x.ProcessName.StartsWith("spring_"))) return false; // dont start if started from installer

        // if we started executable but clickonce link exists, runk through clickonce link
        if (!ApplicationDeployment.IsNetworkDeployed)
        {
          if (!Debugger.IsAttached)
          {
            var shortcutName = string.Concat(Environment.GetFolderPath(Environment.SpecialFolder.Programs), "\\Zero-K\\Zero-K.appref-ms");
            if (File.Exists(shortcutName))
            {
              Process.Start(shortcutName, String.Join("_divider_", args));
              return false;
            }
          }
        }
        else
        {
          // args to offline clickonce are passed in this special way
          try
          {
            var activationData = AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData;
            if (activationData != null && activationData.Length > 0) args = activationData[0].Split( new[] {"_divider_"}, StringSplitOptions.None);
          }
          catch (Exception ex)
          {
            Trace.TraceWarning("Failed to process clickonce arguments:{0}", ex);
          }
        }

        StartupArgs = args;

        Directory.SetCurrentDirectory(StartupPath);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        if (!Debugger.IsAttached)
        {
          AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
          Thread.GetDomain().UnhandledException += UnhandledException;
          Application.ThreadException += Application_ThreadException;
          Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        }

        // this sets default caching policy - webbrowser will use local cache if possible -> for loading images from web resources in wpf
        //HttpWebRequest.DefaultCachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);

        Utils.RegisterProtocol();
        if (ApplicationDeployment.IsNetworkDeployed) Trace.TraceInformation("Starting with version {0}", ApplicationDeployment.CurrentDeployment.CurrentVersion);
        else
        {
          if (Debugger.IsAttached) Trace.TraceInformation("Starting with debugging");
          else Trace.TraceError("Starting undeployed version!");
        }

        WebRequest.DefaultWebProxy = null;
        ThreadPool.SetMaxThreads(500, 2000);
        ServicePointManager.Expect100Continue = false;

        LoadConfig();

        Conf.ManualSpringPath = Conf.ManualSpringPath 
                                 ?? (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\spring.exe", "@", null) ?? (string)
                                Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\Spring", "DisplayIcon", null);

        SpringPaths = new SpringPaths(Conf.ManualSpringPath);
        if (Debugger.IsAttached) SpringPaths.Cache = Utils.MakePath(StartupPath, "cache");
        else SpringPaths.Cache = Utils.MakePath(SpringPaths.WritableDirectory, "cache", "SD");
        SpringPaths.MakeFolders();


        // if first started from web directly and not spring preinstalled -> limited mode
        if (Conf.IsFirstRun && (string.IsNullOrEmpty(SpringPaths.SpringVersion) || SpringPaths.UnitSyncDirectory.Contains("engine"))) {
          Conf.LimitedMode = true;
        }

        // set default join channels
        if (!Conf.JoinChannelsSetupDone)
        {
          if (Conf.LimitedMode)
          {
            Conf.AutoJoinChannels.Add(KnownGames.GetDefaultGame().Channel);
          }
          else
          {
            foreach (var game in KnownGames.List) Conf.AutoJoinChannels.Add(game.Channel);
            Conf.AutoJoinChannels.Add("main");
          }
          Conf.JoinChannelsSetupDone = true;
        }

        SaveConfig();

        SpringPaths.SpringVersionChanged += (s, e) =>
          {
            Conf.ManualSpringPath = Path.GetDirectoryName(SpringPaths.Executable);
            SaveConfig();
          };

        try
        {
          if (!Debugger.IsAttached)
          {
            mutex = new Mutex(false, "ZeroKLobby");
            if (!mutex.WaitOne((StartupArgs != null && StartupArgs.Length > 0) ? 200 : 10000, false))
            {
              if (args.Length > 0)
              {
                File.WriteAllLines(Utils.MakePath(SpringPaths.WritableDirectory, Config.IpcFileName), new string[] { string.Join(" ",args) });
                return false;
              }
              else
              {
                MessageBox.Show(
                  "Another copy of Zero-K lobby is still running"+
                  "\nMake sure the other lobby is closed (check task manager) before starting new one",
                  "There can be only one lobby running",
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Stop);
              }
              return false;
            }
          }
        }
        catch (AbandonedMutexException) {}

        FriendManager = new FriendManager();
        AutoJoinManager = new AutoJoinManager();

        SpringScanner = new SpringScanner(SpringPaths);
        SpringScanner.LocalResourceAdded += (s, e) => Trace.TraceInformation("New resource found: {0}", e.Item.InternalName);
        SpringScanner.LocalResourceRemoved += (s, e) => Trace.TraceInformation("Resource removed: {0}", e.Item.InternalName);

        SpringScanner.MapRegistered += (s, e) => Trace.TraceInformation("Map registered: {0}", e.MapName);
        SpringScanner.ModRegistered += (s, e) => Trace.TraceInformation("Mod registered: {0}", e.Data.Name);

        Downloader = new PlasmaDownloader.PlasmaDownloader(Conf, SpringScanner, SpringPaths);
        Downloader.DownloadAdded += (s, e) => Trace.TraceInformation("Download started: {0}", e.Data.Name);

        TasClient = new TasClient(TasClientInvoker,
                                  string.Format("ZK {0}",
                                                ApplicationDeployment.IsNetworkDeployed
                                                  ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
                                                  : Application.ProductVersion));

        SayCommandHandler = new SayCommandHandler(TasClient);

        // log, for debugging
        TasClient.Connected += (s, e) => Trace.TraceInformation("TASC connected");
        TasClient.LoginAccepted += (s, e) =>
          {
            Trace.TraceInformation("TASC login accepted");
            if (SpringPaths.SpringVersion != TasClient.ServerSpringVersion) Downloader.GetAndSwitchEngine(TasClient.ServerSpringVersion);
          };

        TasClient.LoginDenied += (s, e) => Trace.TraceInformation("TASC login denied");
        TasClient.ChannelJoined += (s, e) => Trace.TraceInformation("TASC channel joined: " + e.ServerParams[0]);
        TasClient.ConnectionLost += (s, e) => Trace.TraceInformation("Connection lost");
        // filter non-zk mods in limited mode
        if (Conf.LimitedMode)
        {
          TasClient.FilterBattleByMod += (s, e) =>
            {
              var game = KnownGames.GetGame(e.Data);
              if (game == null || !game.IsPrimary) e.Cancel = true;
            };
        }

        QuickMatchTracker = new QuickMatchTracking(TasClient, () => BattleBar.GetQuickMatchInfo());
        ConnectBar = new ConnectBar(TasClient);
        ModStore = new ModStore();
        ToolTip = new ToolTipHandler();

        Application.AddMessageFilter(ToolTip);

        MainWindow = new MainWindow();

        Application.AddMessageFilter(new ScrollMessageFilter());

        if (Conf.StartMinimized) MainWindow.WindowState = WindowState.Minimized;
        else MainWindow.WindowState = WindowState.Normal;

        BattleIconManager = new BattleIconManager(MainWindow);
        BattleBar = new BattleBar();
        NewVersionBar = new NewVersionBar();

        return true;
      }
      catch (Exception ex)
      {
        ErrorHandling.HandleException(ex, true);
        Trace.TraceError("Error in application:" + ex);
      }
      return false;
    }


    internal static void SaveConfig()
    {
      var configFilename = GetFullConfigPath();
      lock (configLock)
      {
        var xs = new XmlSerializer(typeof(Config));
        var sb = new StringBuilder();
        using (var stringWriter = new StringWriter(sb)) xs.Serialize(stringWriter, Conf);
        File.WriteAllText(configFilename, sb.ToString());
      }
    }

    public static void ShutDown()
    {
      try
      {
        if (!Debugger.IsAttached) mutex.ReleaseMutex();
      }
      catch {}
      if (ToolTip != null) ToolTip.Dispose();
      if (Downloader != null) Downloader.Dispose();
      if (SpringScanner != null) SpringScanner.Dispose();
      Thread.Sleep(5000);
    }


    static string GetFullConfigPath()
    {
      if (ConfigDirectory == null)
      {
        //detect configuration path once
        if (Debugger.IsAttached)
        {
          if (SpringPaths.IsDirectoryWritable(StartupPath))
          {
            //use startup path when on linux
            //or if startup path is writable on windows
            ConfigDirectory = StartupPath;
          }
          else
          {
            //if we are on windows and startup path isnt writable, use my documents/games/spring
            ConfigDirectory = SpringPaths.GetMySpringDocPath();
          }
        }
        else ConfigDirectory = SpringPaths.GetMySpringDocPath();
      }

      return Path.Combine(ConfigDirectory, Config.ConfigFileName);
    }


    static void TasClientInvoker(TasClient.Invoker a)
    {
      if (!CloseOnNext) MainWindow.Dispatcher.Invoke(a);
    }

    static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
      try
      {
        ErrorHandling.HandleException(e.Exception, true);
        Trace.TraceError("unhandled exception: {0}", e.Exception);
      }
      catch {}
    }

    static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
      try
      {
        ErrorHandling.HandleException((Exception)e.ExceptionObject, e.IsTerminating);
        Trace.TraceError("unhandled exception: {0}", e.ExceptionObject);
      }
      catch {}
    }


    static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
      try
      {
        ErrorHandling.HandleException((Exception)e.ExceptionObject, e.IsTerminating);
        Trace.TraceError("unhandled exception: {0}", e.ExceptionObject);
      }
      catch {}
    }
  }
}