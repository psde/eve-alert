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
    public partial class ChatLogAlertForm : Form
    {
        public ChatLogAlertForm(List<string> systems, String channel)
        {
            InitializeComponent();
            this.Icon = Resources.evealert;

            this.textChannel.Text = channel;
            this.textSystems.Text = String.Join(",", systems);
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public String getChannel()
        {
            return this.textChannel.Text.Trim();
        }

        public List<string> getSystems()
        {
            return this.textSystems.Text.Split(new char[] { ',' }).ToList().Select(x => x.Trim()).ToList(); //trim down whitespaces
        }
    }
}
