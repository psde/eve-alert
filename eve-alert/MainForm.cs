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
using System.Diagnostics;
using evealert.Properties;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml;

namespace evealert
{
    public partial class MainForm : Form
    {
        public static AlertCallback alertCallback;

        private Settings settings;
        private string configdir;

        private Account selectedAccount;
        private AlertInterface selectedAlert;

        private NotificationForm notificationForm;

        private bool enabled = false;

        public MainForm()
        {
            MainForm.alertCallback = this.attention;

            InitializeComponent();
            this.Icon = Resources.evealert;

            string appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/eve-alert/";

            #if DEBUG
            configdir = appdata + "config_testing.xml";
            #else
            configdir = appdata + "config.xml";
            #endif

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

            if (settings.StartStarted)
            {
                this.toggleState();
            }

            notificationForm = new NotificationForm(settings);

            /*Account acc = new Account();
            acc.Charname = "TestAccount";
            acc.alertModules.Add(new ChatLogAlert(new List<string> {"Test1", "Test2" }, "Testchannel"));
            settings.Accounts.Add(acc);
            saveSettings();*/

            refreshAccounts();
            refreshContextMenu();
            refreshGui();
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

        private void refreshAccounts()
        {
            this.listAccounts.Items.Clear();

            foreach (Account account in settings.Accounts)
            {
                ListViewItem newItem = new ListViewItem(account.Charname);
                newItem.Tag = account;
                listAccounts.Items.Add(newItem);
            }
        }

        private void refreshGui()
        {
            refreshContextMenu();

            this.groupCharacterSettings.Enabled = !this.enabled;
            if (this.enabled)
            {
                buttonStartStop.Text = "Stop";
                notifyIcon.Text = "EVE Alert - Running";
            }
            else
            {
                buttonStartStop.Text = "Start";
                notifyIcon.Text = "EVE Alert - Stopped";
            }

            this.buttonAddAlert.Enabled = (selectedAccount != null);
            this.buttonRemoveAlert.Enabled = (selectedAlert != null);
            this.buttonConfigureAlert.Enabled = (selectedAlert != null);
            this.buttonToggleAlert.Enabled = (selectedAlert != null);

            this.buttonToggleAlert.Text = "Disable";
            if (selectedAlert != null && selectedAlert.Enabled == false)
            {
                this.buttonToggleAlert.Text = "Enable";
            }
        }

        private void selectAccount(Account acc)
        {
            this.selectedAccount = acc;
            selectAlert(null);

            this.listModules.Items.Clear();

            if (acc == null)
            {
                this.textCharname.Text = "";
                this.checkEnabled.Checked = false;
                return;
            }

            textCharname.Text = acc.Charname;
            this.checkEnabled.Checked = acc.Enabled;
            foreach(AlertInterface alert in acc.alertModules)
            {
                ListViewItem newItem = new ListViewItem(alert.GetName());
                newItem.SubItems.Add(alert.Enabled.ToString());
                newItem.SubItems.Add(alert.GetDescription());
                newItem.Tag = alert;
                listModules.Items.Add(newItem);
            }

            refreshGui();
        }

        private void selectAlert(AlertInterface alert)
        {
            this.selectedAlert = alert;

            refreshGui();
        }

        private void toggleState()
        {
            toggleState(!this.enabled);
        }

        private void toggleState(bool value)
        {
            this.enabled = value;

            refreshGui();
            saveSettings();

            if (this.enabled)
            {
                notificationForm = new NotificationForm(settings);
                foreach (Account acc in settings.Accounts)
                {
                    if (acc.Enabled == false)
                        continue;

                    foreach (AlertInterface alert in acc.alertModules)
                    {
                        if (alert.Enabled)
                        {
                            alert.start();
                        }
                    }
                }
            }
            else
            {
                foreach (Account acc in settings.Accounts)
                {
                    if (acc.Enabled == false)
                        continue;

                    foreach (AlertInterface alert in acc.alertModules)
                    {
                        if (alert.Enabled)
                        {
                            alert.stop();
                        }
                    }
                }
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

            toggleState(false);

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

        private void buttonAddAccount_Click(object sender, EventArgs e)
        {
            Account newAccount = new Account();
            newAccount.Charname = "New Account";
            settings.Accounts.Add(newAccount);
            //this.selectAccount(newAccount);
            refreshAccounts();
            refreshGui();
        }

        private void buttonRemoveAccount_Click(object sender, EventArgs e)
        {
            if (selectedAccount == null)
                return;

            DialogResult result = MessageBox.Show("Delete Account?", "Delete Account?", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                int index = settings.Accounts.FindIndex(foo => foo == selectedAccount);
                settings.Accounts.Remove(selectedAccount);
                selectAccount(null);
                refreshAccounts();
            }

            refreshGui();
        }

        private void listAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listAccounts.SelectedItems.Count != 1)
            {
                selectAccount(null);
                return;
            }
            selectAccount((Account)this.listAccounts.SelectedItems[0].Tag);
        }

        private void listModules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listModules.SelectedItems.Count != 1)
            {
                selectAlert(null);
                return;
            }

            selectAlert((AlertInterface)this.listModules.SelectedItems[0].Tag);
        }

        private void buttonAddAlert_Click(object sender, EventArgs e)
        {
            List<AlertFactoryInterface> alerts = new List<AlertFactoryInterface>();
            alerts.Add(ChatLogAlert.factory);
            alerts.Add(GameLogAlert.factory);
            alerts.Add(ScreenCaptureAlert.factory);

            NewAlert dialog = new NewAlert(alerts, selectedAccount.Charname);
            dialog.ShowDialog();
            if (dialog.newAlert != null)
            {
                selectedAccount.alertModules.Add(dialog.newAlert);
                selectAccount(selectedAccount);
            }
        }

        private void buttonConfigureAlert_Click(object sender, EventArgs e)
        {
            if (this.listModules.SelectedItems.Count != 1)
            {
                return;
            }

            AlertInterface alert = (AlertInterface)this.listModules.SelectedItems[0].Tag;
            int index = selectedAccount.alertModules.FindIndex(foo => foo == alert);
            selectedAccount.alertModules[index] = alert.getFactory().Modify(alert);
            selectAccount(selectedAccount);
        }

        private void buttonRemoveAlert_Click(object sender, EventArgs e)
        {
            if (this.listModules.SelectedItems.Count != 1)
            {
                return;
            }
            selectedAccount.alertModules.Remove((AlertInterface)this.listModules.SelectedItems[0].Tag);
            selectAlert(null);
            selectAccount(selectedAccount);
        }

        private void textCharname_TextChanged(object sender, EventArgs e)
        {
            if (selectedAccount == null || this.listAccounts.SelectedItems.Count != 1)
                return;

            selectedAccount.Charname = textCharname.Text;
            this.listAccounts.SelectedItems[0].Text = selectedAccount.Charname;
        }

        private void checkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (selectedAccount == null || this.listAccounts.SelectedItems.Count != 1)
                return;

            selectedAccount.Enabled = this.checkEnabled.Checked;
        }

        private void buttonToggleAlert_Click(object sender, EventArgs e)
        {
            if (this.listModules.SelectedItems.Count != 1)
            {
                return;
            }

            AlertInterface alert = (AlertInterface)this.listModules.SelectedItems[0].Tag;
            int index = selectedAccount.alertModules.FindIndex(foo => foo == alert);
            selectedAccount.alertModules[index].Enabled = !selectedAccount.alertModules[index].Enabled;
            selectAccount(selectedAccount);
        }
    }
}
