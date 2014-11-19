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
using com.sbs.dll.utilites;

namespace KillRemoteProcess
{
    public partial class fMain : Form
    {
        public decimal minValue = 0;
        public decimal maxValue = 100;
        public decimal stepValue = 1;
        public decimal Value = 0;

        private decimal nextVal = 0;

        MiniFP6 miniFP6 = null;

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
            //DTO_DBoard.Delivery oDelivery = new DTO_DBoard.Delivery();

            //oDelivery.deliveryClient.addr_korp.Equals(textBox_host.Text.Trim());

            fChooserItems fItems = new fChooserItems(new List<int>(), new List<int>());
            fItems.ShowDialog();
            return;

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            switch (keyData)
            {
                case Keys.Left:
                    break;

                case Keys.Right:
                    SendKeys.Send("+{TAB}");
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button_fiscalPrinter_Click(object sender, EventArgs e)
        {
            if (miniFP6.Sale_(2, "0", "Тестовый продукт", 2.5, 25.50, 6, true))
                MessageBox.Show("true");
            else
                MessageBox.Show("false");
        }

        private void button_Pay_Click(object sender, EventArgs e)
        {
            double xRemainder;

            if (miniFP6.Pay_(2, 63.75, 3, true, out xRemainder))
                MessageBox.Show("true");
            else
                MessageBox.Show("false");
        }

        private void button_Init_Click(object sender, EventArgs e)
        {
            miniFP6 = new MiniFP6();
        }

        private void button_PrinterState_Click(object sender, EventArgs e)
        {
            miniFP6 = new MiniFP6();

            if (miniFP6.PrinterState_(2, out miniFP6.State_)) MessageBox.Show(miniFP6.GetLastErr_());

            propertyGrid1.SelectedObject = miniFP6.State_;
        }

        private void button_GetLastErr_Click(object sender, EventArgs e)
        {
            MessageBox.Show(miniFP6.GetLastErr_());
        }

        private void button_setConfug_Click(object sender, EventArgs e)
        {
            
        }
    }
}
