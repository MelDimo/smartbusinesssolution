using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;

namespace com.sbs.gui.timetracking
{
    public partial class fMain : Form
    {
        private static DBaccess DbAccess = new DBaccess();
        curUser cUser;

        public fMain(curUser pCUser)
        {
            cUser = pCUser;

            InitializeComponent();

            fillData();
        }

        private void fillData()
        {
            label_fio.Text = cUser.fio;
            label_tabn.Text = cUser.tabn.ToString();
            label_dateIN.Text = cUser.datetimeIn.ToString();
            label_dateOUT.Text = cUser.datetimeOut.ToString();

            switch (cUser.curState)
            { 
                case 0:
                    button_out.Enabled = false;
                    label_dateOUT.Enabled = false;
                    break;

                case 1:
                    button_in.Enabled = false;
                    label_dateIN.Enabled = false;
                    button_out.Focus();
                    break;
            }
        }

        private void button_in_Click(object sender, EventArgs e)
        {
            if (changeState()) Close();
        }

        private void button_out_Click(object sender, EventArgs e)
        {
            if (changeState()) Close();
        }

        private bool changeState()
        {
            try
            {
                DbAccess.changeState("offline", cUser);
            }
            catch (Exception exc) { uMessage.Show("не удалось зарегистрировать." + Environment.NewLine + exc.Message, exc, SystemIcons.Information); return false; }
                        
            return true;
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
    }
}
