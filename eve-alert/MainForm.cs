using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace eve_alert
{
    public partial class MainForm : Form
    {
        private Settings settings;
        private string configdir;

        private NotificationForm notificationForm;

        private LogAlert logAlert = null;
        private GameLogAlert gameLogAlert = null;
        private bool enabled = false;

        public MainForm()
        {
            InitializeComponent();

            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/eve-alert/";
            configdir = appdata + "config.xml";
            if (Directory.Exists(appdata) == false)
            {
                Directory.CreateDirectory(appdata);
            }

            if (File.Exists(configdir) == false)
            {
                settings = new Settings();
                new SettingsForm(settings).ShowDialog();
                Settings.toXML(settings, configdir);
            }
            else
            {
                settings = Settings.fromXML(configdir);
            }

            this.textChannel.Text = settings.IntelChannel;
            this.textCharacter.Text = settings.CharacterName;
            this.textSystems.Text = String.Join(",", settings.SystemNames);

            if (settings.StartStarted)
            {
                this.toggleState();
            }

            notificationForm = new NotificationForm(settings);

            refreshContextMenu();
        }

        private void refreshContextMenu()
        {
            contextNotify.Items.Clear();

            // Test notification button
            ToolStripMenuItem testButton = new ToolStripMenuItem();
            testButton.Name = "test";
            testButton.Text = "Test Notification ...";
            testButton.Click += (e, s) => this.attention(DateTime.Now, true, "Test!", "This is just a quick test ...");
            contextNotify.Items.Add(testButton);

            contextNotify.Items.Add(new ToolStripSeparator());

            // Toggle button
            ToolStripMenuItem toggleMenuButton = new ToolStripMenuItem();
            toggleMenuButton.Name = "toggleMenuButton";
            toggleMenuButton.Text = (enabled ? "Stop" : "Start"); ;
            toggleMenuButton.Click += (e, s) => this.toggleState();
            contextNotify.Items.Add(toggleMenuButton);

            contextNotify.Items.Add(new ToolStripSeparator());

            // Exit button
            ToolStripMenuItem exitMenuButton = new ToolStripMenuItem();
            exitMenuButton.Name = "exitMenuButton";
            exitMenuButton.Text = "Exit";
            exitMenuButton.Click += (e, s) => this.Close();
            contextNotify.Items.Add(exitMenuButton);
        }

        private void refreshGui()
        {
            refreshContextMenu();

            this.groupSettings.Enabled = !enabled;
            if (enabled)
            {
                buttonStartStop.Text = "Stop";
                notifyIcon.Text = "EVE Alert - Running";
            }
            else
            {
                buttonStartStop.Text = "Start";
                notifyIcon.Text = "EVE Alert - Stopped";
            }
        }

        private void toggleState()
        {
            toggleState(!enabled);
        }

        private void toggleState(bool value)
        {
            enabled = value;

            refreshGui();
            saveSettings();

            if (enabled)
            {
                notificationForm = new NotificationForm(settings);
                List<string> systems = this.settings.SystemNames;
                logAlert = new LogAlert(attention, systems, this.settings.IntelChannel);
                logAlert.start();

                gameLogAlert = new GameLogAlert(attention, this.settings.CharacterName, "Dread".Split(new char[] { ',' }).ToList());
                gameLogAlert.start();
            }
            else
            {
                if (logAlert != null)
                    logAlert.stop();

                if (gameLogAlert != null)
                    gameLogAlert.stop();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Close?", "Closing...", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            notifyIcon.Visible = false;
            saveSettings();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void buttonStartStop_Click(object sender, EventArgs e)
        {
            toggleState();
            if (enabled)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void playAttentionSound()
        {
            try
            {
                new SoundPlayer(settings.SoundFileAttention).Play();
            }
            catch (Exception) { }
        }

        private void attention(DateTime time, bool important, string title, string message)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                if (important)
                    playAttentionSound();

                //notificationForm.ShowNotification(7500, (important ? Color.Red : Color.Green), title, message);
                (new NotificationForm(settings)).ShowNotification(7500, (important ? Color.Red : Color.Green), title, message);

                ListViewItem newItem = new ListViewItem(time.ToString("HH:MM:ss"));
                newItem.SubItems.Add(important.ToString());
                newItem.SubItems.Add(title);
                newItem.SubItems.Add(message);
                listLog.Items.Insert(0, newItem);
            }));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsForm(settings).ShowDialog();
            saveSettings();
            notificationForm = new NotificationForm(settings);
        }

        private void saveSettings()
        {
            settings.CharacterName = this.textCharacter.Text;
            settings.SystemNames = this.textSystems.Text.Split(new char[] { ',' }).ToList(); ;
            settings.IntelChannel = this.textChannel.Text;
            Settings.toXML(settings, configdir);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (settings.StartMinimized)
            {
                BeginInvoke(new MethodInvoker(delegate
                {
                    Hide();
                }));
            }
        }
    }
}
