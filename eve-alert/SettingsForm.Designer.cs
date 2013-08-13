namespace eve_alert
{
    partial class SettingsForm
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
            this.buttonClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numericOpacity = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericFontSize = new System.Windows.Forms.NumericUpDown();
            this.buttonTestNotification = new System.Windows.Forms.Button();
            this.radioBottomRight = new System.Windows.Forms.RadioButton();
            this.radioBottomLeft = new System.Windows.Forms.RadioButton();
            this.radioCenter = new System.Windows.Forms.RadioButton();
            this.radioTopRight = new System.Windows.Forms.RadioButton();
            this.radioTopLeft = new System.Windows.Forms.RadioButton();
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textSoundFile = new System.Windows.Forms.TextBox();
            this.checkStartStarting = new System.Windows.Forms.CheckBox();
            this.checkStartMinimized = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericOpacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFontSize)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose.Location = new System.Drawing.Point(276, 251);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.numericOpacity);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.numericFontSize);
            this.groupBox1.Controls.Add(this.buttonTestNotification);
            this.groupBox1.Controls.Add(this.radioBottomRight);
            this.groupBox1.Controls.Add(this.radioBottomLeft);
            this.groupBox1.Controls.Add(this.radioCenter);
            this.groupBox1.Controls.Add(this.radioTopRight);
            this.groupBox1.Controls.Add(this.radioTopLeft);
            this.groupBox1.Location = new System.Drawing.Point(9, 122);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 123);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notification";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Opacity:";
            // 
            // numericOpacity
            // 
            this.numericOpacity.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericOpacity.Location = new System.Drawing.Point(192, 91);
            this.numericOpacity.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericOpacity.Name = "numericOpacity";
            this.numericOpacity.Size = new System.Drawing.Size(59, 20);
            this.numericOpacity.TabIndex = 8;
            this.numericOpacity.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Font Size:";
            // 
            // numericFontSize
            // 
            this.numericFontSize.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericFontSize.Location = new System.Drawing.Point(66, 91);
            this.numericFontSize.Maximum = new decimal(new int[] {
            150,
            0,
            0,
            0});
            this.numericFontSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericFontSize.Name = "numericFontSize";
            this.numericFontSize.Size = new System.Drawing.Size(59, 20);
            this.numericFontSize.TabIndex = 6;
            this.numericFontSize.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            // 
            // buttonTestNotification
            // 
            this.buttonTestNotification.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTestNotification.Location = new System.Drawing.Point(259, 88);
            this.buttonTestNotification.Name = "buttonTestNotification";
            this.buttonTestNotification.Size = new System.Drawing.Size(76, 23);
            this.buttonTestNotification.TabIndex = 4;
            this.buttonTestNotification.Text = "Test";
            this.buttonTestNotification.UseVisualStyleBackColor = true;
            this.buttonTestNotification.Click += new System.EventHandler(this.buttonTestNotification_Click);
            // 
            // radioBottomRight
            // 
            this.radioBottomRight.AutoSize = true;
            this.radioBottomRight.Location = new System.Drawing.Point(135, 65);
            this.radioBottomRight.Name = "radioBottomRight";
            this.radioBottomRight.Size = new System.Drawing.Size(86, 17);
            this.radioBottomRight.TabIndex = 5;
            this.radioBottomRight.TabStop = true;
            this.radioBottomRight.Text = "Bottom Right";
            this.radioBottomRight.UseVisualStyleBackColor = true;
            // 
            // radioBottomLeft
            // 
            this.radioBottomLeft.AutoSize = true;
            this.radioBottomLeft.Location = new System.Drawing.Point(6, 65);
            this.radioBottomLeft.Name = "radioBottomLeft";
            this.radioBottomLeft.Size = new System.Drawing.Size(79, 17);
            this.radioBottomLeft.TabIndex = 4;
            this.radioBottomLeft.TabStop = true;
            this.radioBottomLeft.Text = "Bottom Left";
            this.radioBottomLeft.UseVisualStyleBackColor = true;
            // 
            // radioCenter
            // 
            this.radioCenter.AutoSize = true;
            this.radioCenter.Location = new System.Drawing.Point(81, 42);
            this.radioCenter.Name = "radioCenter";
            this.radioCenter.Size = new System.Drawing.Size(56, 17);
            this.radioCenter.TabIndex = 3;
            this.radioCenter.TabStop = true;
            this.radioCenter.Text = "Center";
            this.radioCenter.UseVisualStyleBackColor = true;
            // 
            // radioTopRight
            // 
            this.radioTopRight.AutoSize = true;
            this.radioTopRight.Location = new System.Drawing.Point(135, 19);
            this.radioTopRight.Name = "radioTopRight";
            this.radioTopRight.Size = new System.Drawing.Size(72, 17);
            this.radioTopRight.TabIndex = 2;
            this.radioTopRight.TabStop = true;
            this.radioTopRight.Text = "Top Right";
            this.radioTopRight.UseVisualStyleBackColor = true;
            // 
            // radioTopLeft
            // 
            this.radioTopLeft.AutoSize = true;
            this.radioTopLeft.Location = new System.Drawing.Point(6, 19);
            this.radioTopLeft.Name = "radioTopLeft";
            this.radioTopLeft.Size = new System.Drawing.Size(65, 17);
            this.radioTopLeft.TabIndex = 1;
            this.radioTopLeft.TabStop = true;
            this.radioTopLeft.Text = "Top Left";
            this.radioTopLeft.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(195, 251);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.textSoundFile);
            this.groupBox2.Controls.Add(this.checkStartStarting);
            this.groupBox2.Controls.Add(this.checkStartMinimized);
            this.groupBox2.Location = new System.Drawing.Point(9, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(342, 104);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stuff";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Attention sound:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(260, 68);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textSoundFile
            // 
            this.textSoundFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textSoundFile.Location = new System.Drawing.Point(96, 70);
            this.textSoundFile.Name = "textSoundFile";
            this.textSoundFile.Size = new System.Drawing.Size(158, 20);
            this.textSoundFile.TabIndex = 2;
            // 
            // checkStartStarting
            // 
            this.checkStartStarting.AutoSize = true;
            this.checkStartStarting.Location = new System.Drawing.Point(7, 43);
            this.checkStartStarting.Name = "checkStartStarting";
            this.checkStartStarting.Size = new System.Drawing.Size(135, 17);
            this.checkStartStarting.TabIndex = 1;
            this.checkStartStarting.Text = "Start alerting on startup";
            this.checkStartStarting.UseVisualStyleBackColor = true;
            // 
            // checkStartMinimized
            // 
            this.checkStartMinimized.AutoSize = true;
            this.checkStartMinimized.Location = new System.Drawing.Point(7, 20);
            this.checkStartMinimized.Name = "checkStartMinimized";
            this.checkStartMinimized.Size = new System.Drawing.Size(96, 17);
            this.checkStartMinimized.TabIndex = 0;
            this.checkStartMinimized.Text = "Start minimized";
            this.checkStartMinimized.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 285);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 310);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(370, 310);
            this.Name = "SettingsForm";
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericOpacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericFontSize)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericFontSize;
        private System.Windows.Forms.Button buttonTestNotification;
        private System.Windows.Forms.RadioButton radioBottomRight;
        private System.Windows.Forms.RadioButton radioBottomLeft;
        private System.Windows.Forms.RadioButton radioCenter;
        private System.Windows.Forms.RadioButton radioTopRight;
        private System.Windows.Forms.RadioButton radioTopLeft;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textSoundFile;
        private System.Windows.Forms.CheckBox checkStartStarting;
        private System.Windows.Forms.CheckBox checkStartMinimized;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericOpacity;

    }
}