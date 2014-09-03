using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.gui.dashboard;
using com.sbs.dll;
using com.sbs.dll.utilites;

namespace com.sbs.gui.dashboard
{
    public partial class fMain : Form
    {
        DBaccess dbAccess = new DBaccess();

        public fMain()
        {
            InitializeComponent();

            fillBills();
        }

        private void fMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    Close();
                    break;

                case Keys.Enter:
                    break;
            }
        }

        private void fillBills()
        {
            List<DTO_DBoard.Bill> lBills = new List<DTO_DBoard.Bill>();

            try
            {
                lBills = dbAccess.getBills(GValues.DBMode, DashboardEnvironment.gUser);
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
            }
        }
    }
}
