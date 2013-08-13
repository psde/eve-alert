using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;
using evealert.Properties;

namespace evealert
{
    public partial class SettingsForm : Form
    {
        private Settings settings;
        public SettingsForm(Settings settings)
        {
            InitializeComponent();
            this.Icon = Resources.evealert;
            
            this.settings = settings;

            switch (settings.NotificationPosition)
            {
                default:
                case NotificationPosition.BottomRight:
                    this.radioBottomRight.Checked = true; break;
                case NotificationPosition.BottomLeft:
                    this.radioBottomLeft.Checked = true; break;
                case NotificationPosition.TopLeft:
                    this.radioTopLeft.Checked = true; break;
                case NotificationPosition.TopRight:
                    this.radioTopRight.Checked = true; break;
                case NotificationPosition.Center:
                    this.radioCenter.Checked = true; break;
            }

            this.numericFontSize.Value = Math.Max(Math.Min(settings.NotificationFontSize, this.numericFontSize.Maximum), this.numericFontSize.Minimum);
            this.numericOpacity.Value = Math.Max(Math.Min(settings.NotificationOpacity, this.numericFontSize.Maximum), this.numericFontSize.Minimum);
            this.textSoundFile.Text = settings.SoundFileAttention;
            this.checkStartMinimized.Checked = settings.StartMinimized;
            this.checkStartStarting.Checked = settings.StartStarted;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            try
            {
                openFileDialog.InitialDirectory = Path.GetDirectoryName(this.textSoundFile.Text);
            }
            catch (Exception) { }
            openFileDialog.Filter = "Sound File|*.wav";
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.textSoundFile.Text = openFileDialog.FileName;
            }
        }

        private void toSettings(Settings s)
        {
            s.NotificationFontSize = Convert.ToInt32(this.numericFontSize.Value);
            s.NotificationOpacity = Convert.ToInt32(this.numericOpacity.Value);
            s.SoundFileAttention = this.textSoundFile.Text;
            s.StartMinimized = this.checkStartMinimized.Checked;
            s.StartStarted = this.checkStartStarting.Checked;

            if (this.radioBottomLeft.Checked)
            {
                s.NotificationPosition = NotificationPosition.BottomLeft;
            }
            else if (this.radioBottomRight.Checked)
            {
                s.NotificationPosition = NotificationPosition.BottomRight;
            }
            else if (this.radioTopLeft.Checked)
            {
                s.NotificationPosition = NotificationPosition.TopLeft;
            }
            else if (this.radioTopRight.Checked)
            {
                s.NotificationPosition = NotificationPosition.TopRight;
            }
            else
            {
                s.NotificationPosition = NotificationPosition.Center;
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            toSettings(this.settings);
            this.Close();
        }

        private void buttonTestNotification_Click(object sender, EventArgs e)
        {
            Settings tempSettings = new Settings();
            toSettings(tempSettings);

            try
            {
                new SoundPlayer(tempSettings.SoundFileAttention).Play();
            }
            catch (Exception) { }

            new NotificationForm(tempSettings).ShowNotification(2000, Color.Green, "This is only a test message to see what this will actually look like.", "Just a test.");
        }
    }
}
