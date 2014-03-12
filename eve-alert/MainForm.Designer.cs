namespace evealert
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listAccounts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupCharacterSettings = new System.Windows.Forms.GroupBox();
            this.buttonToggleAlert = new System.Windows.Forms.Button();
            this.checkEnabled = new System.Windows.Forms.CheckBox();
            this.buttonConfigureAlert = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonRemoveAlert = new System.Windows.Forms.Button();
            this.buttonAddAlert = new System.Windows.Forms.Button();
            this.listModules = new System.Windows.Forms.ListView();
            this.columnType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.textCharname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAddAccount = new System.Windows.Forms.Button();
            this.buttonRemoveAccount = new System.Windows.Forms.Button();
            this.listLog = new System.Windows.Forms.ListView();
            this.columnHeaderTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCritical = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMessage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.columnEnabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextNotify.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupCharacterSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextNotify;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "EVE Alert - Stopped";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextNotify
            // 
            this.contextNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripSeparator1,
            this.toolStripMenuItem2});
            this.contextNotify.Name = "contextNotify";
            this.contextNotify.Size = new System.Drawing.Size(169, 54);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(165, 6);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(168, 22);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(592, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.settingsToolStripMenuItem.Text = "Settings...";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(122, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // listAccounts
            // 
            this.listAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listAccounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listAccounts.FullRowSelect = true;
            this.listAccounts.HideSelection = false;
            this.listAccounts.Location = new System.Drawing.Point(12, 28);
            this.listAccounts.MultiSelect = false;
            this.listAccounts.Name = "listAccounts";
            this.listAccounts.Size = new System.Drawing.Size(118, 304);
            this.listAccounts.TabIndex = 5;
            this.listAccounts.UseCompatibleStateImageBehavior = false;
            this.listAccounts.View = System.Windows.Forms.View.Details;
            this.listAccounts.SelectedIndexChanged += new System.EventHandler(this.listAccounts_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Character";
            this.columnHeader1.Width = 86;
            // 
            // groupCharacterSettings
            // 
            this.groupCharacterSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCharacterSettings.Controls.Add(this.buttonToggleAlert);
            this.groupCharacterSettings.Controls.Add(this.checkEnabled);
            this.groupCharacterSettings.Controls.Add(this.buttonConfigureAlert);
            this.groupCharacterSettings.Controls.Add(this.button2);
            this.groupCharacterSettings.Controls.Add(this.buttonRemoveAlert);
            this.groupCharacterSettings.Controls.Add(this.buttonAddAlert);
            this.groupCharacterSettings.Controls.Add(this.listModules);
            this.groupCharacterSettings.Controls.Add(this.label5);
            this.groupCharacterSettings.Controls.Add(this.textCharname);
            this.groupCharacterSettings.Controls.Add(this.label4);
            this.groupCharacterSettings.Location = new System.Drawing.Point(137, 28);
            this.groupCharacterSettings.Name = "groupCharacterSettings";
            this.groupCharacterSettings.Size = new System.Drawing.Size(446, 304);
            this.groupCharacterSettings.TabIndex = 6;
            this.groupCharacterSettings.TabStop = false;
            this.groupCharacterSettings.Text = "Character Settings";
            // 
            // buttonToggleAlert
            // 
            this.buttonToggleAlert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonToggleAlert.Location = new System.Drawing.Point(258, 275);
            this.buttonToggleAlert.Name = "buttonToggleAlert";
            this.buttonToggleAlert.Size = new System.Drawing.Size(75, 23);
            this.buttonToggleAlert.TabIndex = 15;
            this.buttonToggleAlert.Text = "Toggle";
            this.buttonToggleAlert.UseVisualStyleBackColor = true;
            this.buttonToggleAlert.Click += new System.EventHandler(this.buttonToggleAlert_Click);
            // 
            // checkEnabled
            // 
            this.checkEnabled.AutoSize = true;
            this.checkEnabled.Location = new System.Drawing.Point(15, 49);
            this.checkEnabled.Name = "checkEnabled";
            this.checkEnabled.Size = new System.Drawing.Size(65, 17);
            this.checkEnabled.TabIndex = 14;
            this.checkEnabled.Text = "Enabled";
            this.checkEnabled.UseVisualStyleBackColor = true;
            this.checkEnabled.CheckedChanged += new System.EventHandler(this.checkEnabled_CheckedChanged);
            // 
            // buttonConfigureAlert
            // 
            this.buttonConfigureAlert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonConfigureAlert.Location = new System.Drawing.Point(96, 275);
            this.buttonConfigureAlert.Name = "buttonConfigureAlert";
            this.buttonConfigureAlert.Size = new System.Drawing.Size(75, 23);
            this.buttonConfigureAlert.TabIndex = 13;
            this.buttonConfigureAlert.Text = "Configure ...";
            this.buttonConfigureAlert.UseVisualStyleBackColor = true;
            this.buttonConfigureAlert.Click += new System.EventHandler(this.buttonConfigureAlert_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(358, 275);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // buttonRemoveAlert
            // 
            this.buttonRemoveAlert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemoveAlert.Location = new System.Drawing.Point(177, 275);
            this.buttonRemoveAlert.Name = "buttonRemoveAlert";
            this.buttonRemoveAlert.Size = new System.Drawing.Size(75, 23);
            this.buttonRemoveAlert.TabIndex = 11;
            this.buttonRemoveAlert.Text = "Remove";
            this.buttonRemoveAlert.UseVisualStyleBackColor = true;
            this.buttonRemoveAlert.Click += new System.EventHandler(this.buttonRemoveAlert_Click);
            // 
            // buttonAddAlert
            // 
            this.buttonAddAlert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddAlert.Location = new System.Drawing.Point(15, 275);
            this.buttonAddAlert.Name = "buttonAddAlert";
            this.buttonAddAlert.Size = new System.Drawing.Size(75, 23);
            this.buttonAddAlert.TabIndex = 9;
            this.buttonAddAlert.Text = "Add ...";
            this.buttonAddAlert.UseVisualStyleBackColor = true;
            this.buttonAddAlert.Click += new System.EventHandler(this.buttonAddAlert_Click);
            // 
            // listModules
            // 
            this.listModules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listModules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnType,
            this.columnEnabled,
            this.columnDesc});
            this.listModules.FullRowSelect = true;
            this.listModules.HideSelection = false;
            this.listModules.Location = new System.Drawing.Point(15, 85);
            this.listModules.MultiSelect = false;
            this.listModules.Name = "listModules";
            this.listModules.Size = new System.Drawing.Size(418, 184);
            this.listModules.TabIndex = 8;
            this.listModules.UseCompatibleStateImageBehavior = false;
            this.listModules.View = System.Windows.Forms.View.Details;
            this.listModules.SelectedIndexChanged += new System.EventHandler(this.listModules_SelectedIndexChanged);
            // 
            // columnType
            // 
            this.columnType.Text = "Type";
            // 
            // columnDesc
            // 
            this.columnDesc.Text = "Description";
            this.columnDesc.Width = 275;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Modules:";
            // 
            // textCharname
            // 
            this.textCharname.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textCharname.Location = new System.Drawing.Point(92, 23);
            this.textCharname.Name = "textCharname";
            this.textCharname.Size = new System.Drawing.Size(341, 20);
            this.textCharname.TabIndex = 6;
            this.textCharname.TextChanged += new System.EventHandler(this.textCharname_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Character:";
            // 
            // buttonAddAccount
            // 
            this.buttonAddAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAddAccount.Location = new System.Drawing.Point(12, 338);
            this.buttonAddAccount.Name = "buttonAddAccount";
            this.buttonAddAccount.Size = new System.Drawing.Size(33, 23);
            this.buttonAddAccount.TabIndex = 12;
            this.buttonAddAccount.Text = "+";
            this.buttonAddAccount.UseVisualStyleBackColor = true;
            this.buttonAddAccount.Click += new System.EventHandler(this.buttonAddAccount_Click);
            // 
            // buttonRemoveAccount
            // 
            this.buttonRemoveAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRemoveAccount.Location = new System.Drawing.Point(51, 338);
            this.buttonRemoveAccount.Name = "buttonRemoveAccount";
            this.buttonRemoveAccount.Size = new System.Drawing.Size(33, 23);
            this.buttonRemoveAccount.TabIndex = 13;
            this.buttonRemoveAccount.Text = "-";
            this.buttonRemoveAccount.UseVisualStyleBackColor = true;
            this.buttonRemoveAccount.Click += new System.EventHandler(this.buttonRemoveAccount_Click);
            // 
            // listLog
            // 
            this.listLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTime,
            this.columnHeaderCritical,
            this.columnHeaderTitle,
            this.columnHeaderMessage});
            this.listLog.FullRowSelect = true;
            this.listLog.Location = new System.Drawing.Point(137, 338);
            this.listLog.MultiSelect = false;
            this.listLog.Name = "listLog";
            this.listLog.Size = new System.Drawing.Size(218, 110);
            this.listLog.TabIndex = 16;
            this.listLog.UseCompatibleStateImageBehavior = false;
            this.listLog.View = System.Windows.Forms.View.Details;
            this.listLog.Visible = false;
            // 
            // columnHeaderTime
            // 
            this.columnHeaderTime.Text = "Time";
            // 
            // columnHeaderCritical
            // 
            this.columnHeaderCritical.Text = "Critical";
            // 
            // columnHeaderTitle
            // 
            this.columnHeaderTitle.Text = "Title";
            // 
            // columnHeaderMessage
            // 
            this.columnHeaderMessage.Text = "Message";
            this.columnHeaderMessage.Width = 412;
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartStop.Location = new System.Drawing.Point(508, 338);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStartStop.TabIndex = 14;
            this.buttonStartStop.Text = "Start";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.Click += new System.EventHandler(this.buttonStartStop_Click);
            // 
            // columnEnabled
            // 
            this.columnEnabled.Text = "Enabled";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 373);
            this.Controls.Add(this.listLog);
            this.Controls.Add(this.buttonStartStop);
            this.Controls.Add(this.groupCharacterSettings);
            this.Controls.Add(this.listAccounts);
            this.Controls.Add(this.buttonRemoveAccount);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.buttonAddAccount);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.Text = "Eve-Alert";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.contextNotify.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupCharacterSettings.ResumeLayout(false);
            this.groupCharacterSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextNotify;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ListView listAccounts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupCharacterSettings;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textCharname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonRemoveAlert;
        private System.Windows.Forms.Button buttonAddAlert;
        private System.Windows.Forms.Button buttonAddAccount;
        private System.Windows.Forms.Button buttonRemoveAccount;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listModules;
        private System.Windows.Forms.ColumnHeader columnType;
        private System.Windows.Forms.ColumnHeader columnDesc;
        private System.Windows.Forms.Button buttonConfigureAlert;
        private System.Windows.Forms.ListView listLog;
        private System.Windows.Forms.ColumnHeader columnHeaderTime;
        private System.Windows.Forms.ColumnHeader columnHeaderCritical;
        private System.Windows.Forms.ColumnHeader columnHeaderTitle;
        private System.Windows.Forms.ColumnHeader columnHeaderMessage;
        private System.Windows.Forms.Button buttonStartStop;
        private System.Windows.Forms.CheckBox checkEnabled;
        private System.Windows.Forms.Button buttonToggleAlert;
        private System.Windows.Forms.ColumnHeader columnEnabled;
    }
}

