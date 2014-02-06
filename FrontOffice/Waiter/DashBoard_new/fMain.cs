using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using com.sbs.dll.utilites;

namespace com.sbs.gui.dashboard
{
    public partial class fMain : Form
    {
        private DBaccess dbAccess = new DBaccess();
        private int curScene = 0;

        public fMain()
        {
            InitializeComponent();

            createBillObject();
        }

        private void createBillObject()
        {
            Button btnBill;

            for (int i = 0; i < 5; i++ )
                foreach (Bill oBill in DashboardEnvironment.gBillList)
                {
                    btnBill = new Button();
                    //btnBill.BackColor = Color.FromArgb(255, 255, 196);
                    btnBill.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                    btnBill.UseVisualStyleBackColor = false;
                    btnBill.TextAlign = ContentAlignment.MiddleLeft;
                    btnBill.Height = 80;
                    btnBill.Width = 325;
                    btnBill.Click += new EventHandler(btnBill_Click);
                    btnBill.GotFocus += new EventHandler(btnBill_GotFocus);
                    btnBill.Text = "Счет № " + oBill.numb.ToString() + Environment.NewLine +
                                    "Столик: " + oBill.table.ToString() + Environment.NewLine +
                                    "Открыт: " + oBill.openDate.ToString() + Environment.NewLine;
                    btnBill.Tag = oBill;
                    flowLayoutPanel_currBills.Controls.Add(btnBill);
                }
        }

        void btnBill_GotFocus(object sender, EventArgs e)
        {
            try
            {
                dbAccess.getBillDishes("offline", (Bill)((Button)sender).Tag);
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
                return;
            }
        }

        void btnBill_Click(object sender, EventArgs e)
        {
            editBill((Bill)((Button)sender).Tag);
        }

        private void editBill(Bill pBill)
        {
            label_billsInfo.Text = "Счет № " + pBill.numb.ToString() + Environment.NewLine +
                                    "Столик: " + pBill.table.ToString() + Environment.NewLine +
                                    "Открыт: " + pBill.openDate.ToString() + Environment.NewLine;

            tabControl_left.SelectedTab = tabControl_left.TabPages[1];
        }

        private void fMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    Close();
                    break;
            }
        }

        private void changeFocus()
        {
            
        }

        
    }
}
