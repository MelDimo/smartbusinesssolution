using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Management;
using System.Management.Instrumentation;
using com.sbs.dll;

namespace KillRemoteProcess
{
    public partial class fMain : Form
    {
        public decimal minValue = 0;
        public decimal maxValue = 100;
        public decimal stepValue = 1;
        public decimal Value = 0;

        private decimal nextVal = 0;

        public fMain()
        {
            InitializeComponent();

            textBox_UpDown.maxValue = 12;
            textBox_UpDown.minValue = 5;
        }

        private void button_terminate_Click(object sender, EventArgs e)
        {
            string hostName;
            string procName;

            hostName = textBox_host.Text;
            procName = textBox_procName.Text;

            ConnectionOptions con = new ConnectionOptions();
            con.Username = "remouteAdmin";
            con.Password = "123";

            ManagementScope scope = new ManagementScope(string.Format("\\\\{0}\\root\\cimv2", hostName), con);
            scope.Connect();

            ObjectQuery query = new ObjectQuery(string.Format("SELECT * FROM Win32_Process WHERE Name = '{0}'", procName));
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection objectCollection = searcher.Get();
            foreach (ManagementObject managementObject in objectCollection)
            {
                managementObject.InvokeMethod("Terminate", null);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DTO_DBoard.Delivery oDelivery = new DTO_DBoard.Delivery();

            oDelivery.deliveryClient.addr_korp.Equals(textBox_host.Text.Trim());

        }
    }
}
