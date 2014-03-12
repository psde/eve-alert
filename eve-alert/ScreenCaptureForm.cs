using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using evealert.Properties;

namespace evealert
{
    public partial class ScreenCaptureForm : Form
    {
        private ScreenCaptureAlert alert;

        private float aspectRatio = 1.0f;
        private Point oldPosition;
        private bool drag = false;
        private bool selectRegion;
        private Point selectRegionStart;

        public ScreenCaptureForm(ScreenCaptureAlert alert)
        {
            InitializeComponent();
            this.Icon = Resources.evealert;

            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            this.alert = alert;

            for (int i = 0; i <= 9; i++)
            {
                int percent = (i + 1) * 10;
                ToolStripMenuItem button = new ToolStripMenuItem();
                button.Name = "launchMenuButton";
                button.Text = percent + "%";
                button.Click += (s, e) => alert.setOpacity(percent);
                this.menuOpacity.DropDownItems.Add(button);
            }

            if (alert.selectedRegion.Width > 0)
            {
                this.menuSelectRegion.Enabled = false;
                this.menuResetRegion.Enabled = true;
            }
        }

        public void showScreenshot(Bitmap image)
        {
            aspectRatio = (float)image.Height / (float)image.Width;
            pictureBox.Invoke(new MethodInvoker(delegate()
                {
                    if (pictureBox.Image != null)
                    {
                        pictureBox.Image.Dispose();
                    }
                    pictureBox.Image = image;
                    this.forceAspectRatio();
                })
            );
        }

        public void setOpacity(int opacity)
        {
            this.Opacity = (float)opacity / 100.0; 
            for (int i = 0; i <= 9; i++)
            {
                ((ToolStripMenuItem)this.menuOpacity.DropDownItems[i]).Checked = (i == (opacity - 1) / 10);
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drag = true;
                if (selectRegion)
                {
                    selectRegionStart = e.Location;
                }
                else
                {
                    oldPosition = new Point(Cursor.Position.X - this.Left, Cursor.Position.Y - this.Top);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                Point location = new Point(e.Location.X + this.Top, e.Location.Y + this.Left);
                if (selectRegion)
                {
                    selectRegion = false;
                }
                else
                {
                    contextMenuStrip.Show(Cursor.Position);
                }
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                if (selectRegion)
                {
                    Console.Out.WriteLine(new Point(System.Windows.Forms.Cursor.Position.X - this.Left, System.Windows.Forms.Cursor.Position.Y - this.Top));
                }
                else
                {
                    this.Left = System.Windows.Forms.Cursor.Position.X - oldPosition.X;
                    this.Top = System.Windows.Forms.Cursor.Position.Y - oldPosition.Y;
                }
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
            if (selectRegion)
            {
                float h = (float)pictureBox.Image.Height / (float)pictureBox.Height;
                float w = (float)pictureBox.Image.Width / (float)pictureBox.Width;

                Point topLeft = new Point((int)(selectRegionStart.X * w), (int)(selectRegionStart.Y * h));
                Point bottomRight = new Point((int)(e.Location.X * w), (int)(e.Location.Y * h));

                if (bottomRight.X < topLeft.X)
                {
                    int tmp = bottomRight.X;
                    bottomRight.X = topLeft.X;
                    topLeft.X = tmp;
                }

                if (bottomRight.Y < topLeft.Y)
                {
                    int tmp = bottomRight.Y;
                    bottomRight.Y = topLeft.Y;
                    topLeft.Y = tmp;
                }

                Rectangle rect = new Rectangle(topLeft.X, topLeft.Y, bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y);

                Console.Out.WriteLine(rect);
                this.alert.setSelectedRetion(rect);

                selectRegion = false;
                this.menuSelectRegion.Enabled = false;
                this.menuResetRegion.Enabled = true;
            }
        }

        private void ScreenCaptureForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
                return;

            //Control control = (Control)sender;

            //Size newSize = new Size(control.Size.Width, (int)(control.Size.Width * aspectRatio));

            //if (newSize.Width < this.MinimumSize.Width)
            //    newSize.Width = this.MinimumSize.Width;

            //if (newSize.Width < this.MinimumSize.Height)
            //    newSize.Width = this.MinimumSize.Height;

            //control.Size = newSize;
            this.forceAspectRatio();
        }

        private void forceAspectRatio()
        {
            this.Size = new Size(this.Size.Width, (int)(this.Size.Width * aspectRatio));
        }
        
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0112) // WM_SYSCOMMAND
            {
                if (m.WParam == new IntPtr(0xF120)) // Restore event - SC_RESTORE from Winuser.h
                {
                    this.ShowInTaskbar = false;
                    this.Text = "";
                }
            }
        }

        public void setBorderless(bool enabled)
        {
            if(enabled)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                this.menuToggleBorder.Checked = true;
            }
            else
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                this.menuToggleBorder.Checked = false;
            }
        }

        private void menuMinimize_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Minimized;
            this.Text = "ScreenCapture - " + this.alert.characterName;
        }

        private void menuSelectRegion_Click(object sender, EventArgs e)
        {
            selectRegion = true;
        }

        private void menuToggleBorder_Click(object sender, EventArgs e)
        {
            alert.setBorderless(this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.Sizable);
        }

        private void menuResetRegion_Click(object sender, EventArgs e)
        {
            this.alert.setSelectedRetion(new Rectangle(0, 0, 0, 0));
            this.menuSelectRegion.Enabled = true;
            this.menuResetRegion.Enabled = false;
        }
    }
}
