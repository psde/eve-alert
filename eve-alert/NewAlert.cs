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
    public partial class NewAlert : Form
    {
        private List<AlertFactoryInterface> alerts;
        private String charname;
        public AlertInterface newAlert = null;

        public NewAlert(List<AlertFactoryInterface> alerts, String charname)
        {
            InitializeComponent();
            this.Icon = Resources.evealert;

            this.alerts = alerts;
            this.charname = charname;

            foreach (AlertFactoryInterface factory in this.alerts)
            {
                this.comboAlerts.Items.Add(factory);
                if (this.comboAlerts.SelectedItem == null)
                {
                    this.comboAlerts.SelectedItem = factory;
                }
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (this.comboAlerts.SelectedItem == null)
            {
                return;
            }

            this.Hide();

            AlertFactoryInterface factory = (AlertFactoryInterface)comboAlerts.SelectedItem;
            newAlert = factory.Create(this.charname);
            this.Close();
        }
    }
}
