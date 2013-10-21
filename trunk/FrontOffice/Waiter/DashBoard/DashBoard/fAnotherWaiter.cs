using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;

namespace com.sbs.gui.DashBoard
{
    public partial class fAnotherWaiter : Form
    {
        private DBaccess DbAccess = new DBaccess();

        public int userId_from;
        public int billId;

        public fAnotherWaiter()
        {
            InitializeComponent();
        }

        private void fAnotherWaiter_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void fAnotherWaiter_Shown(object sender, EventArgs e)
        {
           
        }

        private void listBox_waiter_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Enter:
                    if (listBox_waiter.Items.Count == 0) return;

                    if (!moveBill()) DialogResult = DialogResult.Cancel;
                    DialogResult = DialogResult.OK;
                    break;
            }
        }

        private bool moveBill()
        {
            try
            {
                DbAccess.BillToAnotherWaiter("offline", billId, userId_from, (int)listBox_waiter.SelectedValue);
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information); return false; }
            return true;
        }
    }
}
