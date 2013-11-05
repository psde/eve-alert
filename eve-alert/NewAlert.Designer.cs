namespace evealert
{
    partial class NewAlert
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
            this.comboAlerts = new System.Windows.Forms.ComboBox();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboAlerts
            // 
            this.comboAlerts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboAlerts.FormattingEnabled = true;
            this.comboAlerts.Location = new System.Drawing.Point(12, 12);
            this.comboAlerts.Name = "comboAlerts";
            this.comboAlerts.Size = new System.Drawing.Size(179, 21);
            this.comboAlerts.TabIndex = 0;
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(116, 39);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(75, 23);
            this.buttonAccept.TabIndex = 1;
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.buttonAccept_Click);
            // 
            // NewAlert
            // 
            this.AcceptButton = this.buttonAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(203, 69);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.comboAlerts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewAlert";
            this.Text = "NewAlert";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboAlerts;
        private System.Windows.Forms.Button buttonAccept;
    }
}