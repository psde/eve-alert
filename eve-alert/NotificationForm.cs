using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Timers;
using System.Runtime.InteropServices;

namespace eve_alert
{
    public partial class NotificationForm : Form
    {
        private Settings settings;

        protected override bool ShowWithoutActivation
        {
            get { return true; }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x00000008; //WS_EX_TOPMOST 
                return cp;
            }
        } 

        public NotificationForm(Settings settings)
        {
            InitializeComponent();
            this.settings = settings;
            this.labelCharname.Font = new Font(this.labelCharname.Font.FontFamily, settings.NotificationFontSize);
            this.labelText.Font = new Font(this.labelCharname.Font.FontFamily, settings.NotificationFontSize);
            this.Opacity = Convert.ToDouble(settings.NotificationOpacity) / 100.0;
            this.Show();
            this.Visible = false;
        }

        public void ShowNotification(int timeout, Color color, string title, string text)
        {
            this.timer.Stop();
            this.BackColor = color;
            this.labelText.Text = text;
            this.labelCharname.Text = title;
                        
            switch (settings.NotificationPosition)
            {
                default:
                case NotificationPosition.BottomRight:
                    this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
                    this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
                    break;
                case NotificationPosition.BottomLeft:
                    this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
                    this.Left = Screen.PrimaryScreen.WorkingArea.Left;
                    break;
                case NotificationPosition.TopLeft:
                    this.Top = Screen.PrimaryScreen.WorkingArea.Top;
                    this.Left = Screen.PrimaryScreen.WorkingArea.Left;
                    break;
                case NotificationPosition.TopRight:
                    this.Top = Screen.PrimaryScreen.WorkingArea.Top;
                    this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
                    break;
                case NotificationPosition.Center:
                    this.Top = Screen.PrimaryScreen.WorkingArea.Height / 2 - this.Height / 2;
                    this.Left = Screen.PrimaryScreen.WorkingArea.Width / 2 - this.Width / 2;
                    break;
            }

            this.Visible = true;
            
            if (timeout > 0)
            {
                this.timer.Interval = timeout;
                this.timer.Start();
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            this.timer.Stop();
            this.Invoke(new MethodInvoker(delegate()
            {
                this.Visible = false;
            }));
        }

        private void labelText_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void labelCharname_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void NotificationForm_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
