﻿namespace ZeroKLobby.MicroLobby
{
    partial class SettingsTab
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbSafeMode = new System.Windows.Forms.CheckBox();
            this.btnDefaults = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.btnRapid = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbResy = new System.Windows.Forms.TextBox();
            this.tbResx = new System.Windows.Forms.TextBox();
            this.cbWindowed = new System.Windows.Forms.CheckBox();
            this.cbHwCursor = new System.Windows.Forms.CheckBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.logButton = new System.Windows.Forms.Button();
            this.helpButton = new System.Windows.Forms.Button();
            this.problemButton = new System.Windows.Forms.Button();
            this.cbMtEngine = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.propertyGrid1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(0, 212);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(559, 165);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zero-K lobby settings: (changes need restart)";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 16);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(553, 146);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_PropertyValueChanged);
            // 
            // btnDisplay
            // 
            this.btnDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDisplay.Location = new System.Drawing.Point(150, 103);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(89, 23);
            this.btnDisplay.TabIndex = 13;
            this.btnDisplay.Text = "Adv. Settings";
            this.btnDisplay.UseVisualStyleBackColor = true;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbMtEngine);
            this.panel1.Controls.Add(this.cbSafeMode);
            this.panel1.Controls.Add(this.btnDefaults);
            this.panel1.Controls.Add(this.btnRestart);
            this.panel1.Controls.Add(this.btnRapid);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbResy);
            this.panel1.Controls.Add(this.tbResx);
            this.panel1.Controls.Add(this.cbWindowed);
            this.panel1.Controls.Add(this.cbHwCursor);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.logButton);
            this.panel1.Controls.Add(this.helpButton);
            this.panel1.Controls.Add(this.problemButton);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnDisplay);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 380);
            this.panel1.TabIndex = 15;
            // 
            // cbSafeMode
            // 
            this.cbSafeMode.AutoSize = true;
            this.cbSafeMode.Location = new System.Drawing.Point(448, 56);
            this.cbSafeMode.Name = "cbSafeMode";
            this.cbSafeMode.Size = new System.Drawing.Size(77, 17);
            this.cbSafeMode.TabIndex = 36;
            this.cbSafeMode.Text = "Safe mode";
            this.cbSafeMode.UseVisualStyleBackColor = true;
            this.cbSafeMode.CheckedChanged += new System.EventHandler(this.cbSafeMode_CheckedChanged);
            // 
            // btnDefaults
            // 
            this.btnDefaults.Location = new System.Drawing.Point(257, 103);
            this.btnDefaults.Name = "btnDefaults";
            this.btnDefaults.Size = new System.Drawing.Size(75, 23);
            this.btnDefaults.TabIndex = 35;
            this.btnDefaults.Text = "Clear";
            this.btnDefaults.UseVisualStyleBackColor = true;
            this.btnDefaults.Click += new System.EventHandler(this.btnDefaults_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRestart.ForeColor = System.Drawing.Color.Red;
            this.btnRestart.Location = new System.Drawing.Point(69, 171);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(130, 23);
            this.btnRestart.TabIndex = 34;
            this.btnRestart.Text = "RESTART LOBBY";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Visible = false;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // btnRapid
            // 
            this.btnRapid.Location = new System.Drawing.Point(257, 171);
            this.btnRapid.Name = "btnRapid";
            this.btnRapid.Size = new System.Drawing.Size(75, 23);
            this.btnRapid.TabIndex = 33;
            this.btnRapid.Text = "Rapid";
            this.btnRapid.UseVisualStyleBackColor = true;
            this.btnRapid.Click += new System.EventHandler(this.btnRapid_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Tools:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Video resolution:";
            // 
            // tbResy
            // 
            this.tbResy.Location = new System.Drawing.Point(257, 56);
            this.tbResy.Name = "tbResy";
            this.tbResy.Size = new System.Drawing.Size(62, 20);
            this.tbResy.TabIndex = 29;
            this.tbResy.TextChanged += new System.EventHandler(this.settingsControlChanged);
            // 
            // tbResx
            // 
            this.tbResx.Location = new System.Drawing.Point(188, 56);
            this.tbResx.Name = "tbResx";
            this.tbResx.Size = new System.Drawing.Size(63, 20);
            this.tbResx.TabIndex = 28;
            this.tbResx.TextChanged += new System.EventHandler(this.settingsControlChanged);
            // 
            // cbWindowed
            // 
            this.cbWindowed.AutoSize = true;
            this.cbWindowed.Location = new System.Drawing.Point(17, 58);
            this.cbWindowed.Name = "cbWindowed";
            this.cbWindowed.Size = new System.Drawing.Size(77, 17);
            this.cbWindowed.TabIndex = 27;
            this.cbWindowed.Text = "Windowed";
            this.cbWindowed.UseVisualStyleBackColor = true;
            this.cbWindowed.CheckedChanged += new System.EventHandler(this.settingsControlChanged);
            // 
            // cbHwCursor
            // 
            this.cbHwCursor.AutoSize = true;
            this.cbHwCursor.Location = new System.Drawing.Point(338, 56);
            this.cbHwCursor.Name = "cbHwCursor";
            this.cbHwCursor.Size = new System.Drawing.Size(104, 17);
            this.cbHwCursor.TabIndex = 26;
            this.cbHwCursor.Text = "Hardware cursor";
            this.cbHwCursor.UseVisualStyleBackColor = true;
            this.cbHwCursor.CheckedChanged += new System.EventHandler(this.settingsControlChanged);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(342, 103);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(124, 23);
            this.btnBrowse.TabIndex = 25;
            this.btnBrowse.Text = "Open game data folder";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button5.Location = new System.Drawing.Point(94, 16);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 24;
            this.button5.Text = "Minimal";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Game details:";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button4.Location = new System.Drawing.Point(419, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 22;
            this.button4.Text = "Ultra";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button3.Location = new System.Drawing.Point(338, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 21;
            this.button3.Text = "High";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(257, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Text = "Medium";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(175, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Low";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // logButton
            // 
            this.logButton.Location = new System.Drawing.Point(20, 103);
            this.logButton.Name = "logButton";
            this.logButton.Size = new System.Drawing.Size(124, 23);
            this.logButton.TabIndex = 18;
            this.logButton.Text = "Show Diagnostic Log";
            this.logButton.UseVisualStyleBackColor = true;
            this.logButton.Click += new System.EventHandler(this.logButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(20, 142);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(86, 23);
            this.helpButton.TabIndex = 15;
            this.helpButton.Text = "Ask for Help";
            this.helpButton.UseVisualStyleBackColor = true;
            // 
            // problemButton
            // 
            this.problemButton.Location = new System.Drawing.Point(123, 142);
            this.problemButton.Name = "problemButton";
            this.problemButton.Size = new System.Drawing.Size(103, 23);
            this.problemButton.TabIndex = 17;
            this.problemButton.Text = "Report a Problem";
            this.problemButton.UseVisualStyleBackColor = true;
            this.problemButton.Click += new System.EventHandler(this.problemButton_Click);
            // 
            // cbMtEngine
            // 
            this.cbMtEngine.AutoSize = true;
            this.cbMtEngine.Location = new System.Drawing.Point(338, 79);
            this.cbMtEngine.Name = "cbMtEngine";
            this.cbMtEngine.Size = new System.Drawing.Size(193, 17);
            this.cbMtEngine.TabIndex = 37;
            this.cbMtEngine.Text = "Multithreaded engine (experimental)";
            this.cbMtEngine.UseVisualStyleBackColor = true;
            this.cbMtEngine.CheckedChanged += new System.EventHandler(this.cbMtEngine_CheckedChanged);
            // 
            // SettingsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SettingsTab";
            this.Size = new System.Drawing.Size(562, 380);
            this.Load += new System.EventHandler(this.SettingsTab_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Button btnDisplay;
        private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.Button logButton;
    private System.Windows.Forms.Button helpButton;
    private System.Windows.Forms.Button problemButton;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbResy;
        private System.Windows.Forms.TextBox tbResx;
        private System.Windows.Forms.CheckBox cbWindowed;
        private System.Windows.Forms.CheckBox cbHwCursor;
        private System.Windows.Forms.Button btnRapid;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Button btnDefaults;
        private System.Windows.Forms.CheckBox cbSafeMode;
        private System.Windows.Forms.CheckBox cbMtEngine;
    }
}
