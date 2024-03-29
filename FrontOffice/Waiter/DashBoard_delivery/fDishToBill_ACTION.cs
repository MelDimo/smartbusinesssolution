﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll;
using com.sbs.dll.utilites;

namespace com.sbs.gui.dashboard
{
    public partial class fDishToBill_ACTION : Form
    {
        private DTO_DBoard.Dish oDish;
        private DTO_DBoard.Bill oBill;

        DBaccess dbAccess = new DBaccess();

        Suppurt Supp = new Suppurt();

        public string returnCode = string.Empty;

        public fDishToBill_ACTION(DTO_DBoard.Bill pBill, DTO_DBoard.Dish pDish)
        {
            oBill = pBill;
            oDish = pDish;

            InitializeComponent();

            label_name.Text = oDish.name;

            button_closeBill.GotFocus += new EventHandler(button_closeBill_GotFocus);
            button_closeBill.LostFocus += new EventHandler(button_closeBill_LostFocus);

            button_refuse.GotFocus += new EventHandler(button_refuse_GotFocus);
            button_refuse.LostFocus += new EventHandler(button_refuse_LostFocus);
        }

        void button_refuse_LostFocus(object sender, EventArgs e)
        {
            button_refuse.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        void button_refuse_GotFocus(object sender, EventArgs e)
        {
            button_refuse.BackColor = Color.FromArgb(185, 209, 234);
        }

        void button_closeBill_LostFocus(object sender, EventArgs e)
        {
            button_closeBill.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        void button_closeBill_GotFocus(object sender, EventArgs e)
        {
            button_closeBill.BackColor = Color.FromArgb(185, 209, 234);
        }

        private void fDishToBill_ACTION_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void button_refuse_Click(object sender, EventArgs e)
        {
            int xPriv = 0;
            string xErrMessage = string.Empty;

            switch (oDish.refStatus)
            {
                case 23:        // Позиция в счете нового блюда
                    xPriv = 16; xErrMessage = "У Вас отсутствует привилегия на изменение количества блюда.";
                    break;

                case 24:        // Позиция была отправлена на изготовление
                    xPriv = 15; xErrMessage = "У Вас отсутствует привилегия на изменение количества блюда отправленного на изготовление.";
                    break;
            }

            // Проверяем привелегию отмены блюда
            if (!Supp.checkPrivileges(DashboardEnvironment.gUser.oUserACL, xPriv))
            {
                MessageBox.Show(xErrMessage, GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            fRefuse fref = new fRefuse();
            fref.trackBar_count.Minimum = 0;
            fref.trackBar_count.Maximum = int.Parse(oDish.count.ToString("F0"));
            fref.trackBar_count.Value = int.Parse(oDish.count.ToString("F0"));
            if(fref.ShowDialog() == DialogResult.Cancel) return;

            if (fref.trackBar_count.Value != oDish.count)
            {
                try
                {
                    refuseDish(fref.trackBar_count.Value);
                }
                catch (Exception exc) { uMessage.Show("Неудалось поместить блюда в хранилище.", exc, SystemIcons.Information); return; }
            }

            DialogResult = DialogResult.OK;
        }

        #region --------------------------------------------------------------------- Отказы ---------------------------------------------

        private void refuseDish(int pNewCount)  
        {
            dbAccess.dishRefuse(GValues.DBMode, oBill, oDish, pNewCount);
        }

        #endregion

        private void button_closeBill_Click(object sender, EventArgs e)
        {
            returnCode = "CLOSE_BILL";
            DialogResult = DialogResult.OK;
        }
    }
}
