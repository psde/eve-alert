using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace evealert
{
    public partial class ScreenCaptureForm : Form
    {
        private ScreenCaptureAlert alert;

        private float aspectRatio = 1.0f;
        private Point oldPosition;
        private bool drag = false;
        private bool selectRegion;

        public ScreenCaptureForm(ScreenCaptureAlert alert)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
            this.alert = alert;
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
                })
            );
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drag = true;
                oldPosition = new Point(Cursor.Position.X - this.Left, Cursor.Position.Y - this.Top);
            }
            else if (e.Button == MouseButtons.Right)
            {
                Point location = new Point(e.Location.X + this.Top, e.Location.Y + this.Left);
                contextMenuStrip.Show(Cursor.Position);
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                this.Left = System.Windows.Forms.Cursor.Position.X - oldPosition.X;
                this.Top = System.Windows.Forms.Cursor.Position.Y - oldPosition.Y;
            }
        }

        private void ScreenCaptureForm_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            Size newSize = new Size(control.Size.Width, (int)(control.Size.Width * aspectRatio));

            if (newSize.Width < this.MinimumSize.Width)
                newSize.Width = this.MinimumSize.Width;

            if (newSize.Width < this.MinimumSize.Height)
                newSize.Width = this.MinimumSize.Height;

            control.Size = newSize;
        }

        private void menuMinimize_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void menuSelectRegion_Click(object sender, EventArgs e)
        {
            selectRegion = true;
        }

        private void menuToggleBorder_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.Sizable)
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            }
            else
            {
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            }
        }
    }
}
