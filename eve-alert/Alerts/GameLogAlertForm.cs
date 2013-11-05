using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using evealert.Properties;

namespace evealert.Alerts
{
    public partial class GameLogAlertForm : Form
    {
        public GameLogAlertForm(List<string> keyWords)
        {
            InitializeComponent();
            this.Icon = Resources.evealert;

            this.textKeywords.Text = String.Join(",", keyWords);
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public List<String> getKeywords()
        {
            return this.textKeywords.Text.Split(new char[] { ',' }).ToList();
        }
    }
}
