namespace evealert
{
    partial class ScreenCaptureForm
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuSelectRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuResetRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToggleBorder = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMinimize = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuOpacity = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(106, 105);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSelectRegion,
            this.menuResetRegion,
            this.toolStripSeparator2,
            this.menuOpacity,
            this.menuToggleBorder,
            this.menuMinimize});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(155, 120);
            // 
            // menuSelectRegion
            // 
            this.menuSelectRegion.Name = "menuSelectRegion";
            this.menuSelectRegion.Size = new System.Drawing.Size(154, 22);
            this.menuSelectRegion.Text = "Select Region ...";
            this.menuSelectRegion.Click += new System.EventHandler(this.menuSelectRegion_Click);
            // 
            // menuResetRegion
            // 
            this.menuResetRegion.Enabled = false;
            this.menuResetRegion.Name = "menuResetRegion";
            this.menuResetRegion.Size = new System.Drawing.Size(154, 22);
            this.menuResetRegion.Text = "Reset Region";
            this.menuResetRegion.Click += new System.EventHandler(this.menuResetRegion_Click);
            // 
            // menuToggleBorder
            // 
            this.menuToggleBorder.Name = "menuToggleBorder";
            this.menuToggleBorder.Size = new System.Drawing.Size(154, 22);
            this.menuToggleBorder.Text = "Borderless";
            this.menuToggleBorder.Click += new System.EventHandler(this.menuToggleBorder_Click);
            // 
            // menuMinimize
            // 
            this.menuMinimize.Name = "menuMinimize";
            this.menuMinimize.Size = new System.Drawing.Size(154, 22);
            this.menuMinimize.Text = "Minimize";
            this.menuMinimize.Click += new System.EventHandler(this.menuMinimize_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(151, 6);
            // 
            // menuOpacity
            // 
            this.menuOpacity.Name = "menuOpacity";
            this.menuOpacity.Size = new System.Drawing.Size(154, 22);
            this.menuOpacity.Text = "Opacity";
            // 
            // ScreenCaptureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(106, 105);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox);
            this.Name = "ScreenCaptureForm";
            this.Opacity = 0.5D;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Resize += new System.EventHandler(this.ScreenCaptureForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuSelectRegion;
        private System.Windows.Forms.ToolStripMenuItem menuMinimize;
        private System.Windows.Forms.ToolStripMenuItem menuToggleBorder;
        private System.Windows.Forms.ToolStripMenuItem menuResetRegion;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuOpacity;
    }
}