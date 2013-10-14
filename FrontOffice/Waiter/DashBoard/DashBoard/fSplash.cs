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
using System.Diagnostics;

namespace com.sbs.gui.DashBoard
{
    public partial class fSplash : Form
    {
        private DBaccess DbAccess = new DBaccess();
        private DataSet ds;

        public fSplash()
        {
            InitializeComponent();

            this.BackgroundImage = com.sbs.dll.utilites.Properties.Resources.splash_1;

            ds = getReferences();
        }

        private bool mifareAccess()
        {
            fMIFare fMifare = new fMIFare();
            if (fMifare.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    Debug.Print(fMifare.keyId);
                    DbAccess.checkMifareWaiter("offline", fMifare.keyId);
                }
                catch (Exception exc) { uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information); return false; }
            }

            return true;
        }

        private DataSet getReferences()
        {
            DataTable dtCarte = new DataTable();
            DataTable dtDishesGroup = new DataTable();
            DataTable dtDishes = new DataTable();
            DataTable dtReports = new DataTable();

            try
            {
                dtCarte = DbAccess.getCarte("offline");
                dtDishesGroup = DbAccess.getDishesGroup("offline");
                dtDishes = DbAccess.getDishes("offline");
                dtReports = DbAccess.getReports("offline");
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information); }

            DataSet dsDishes = new DataSet();
            dsDishes.Tables.Add(dtCarte);
            dsDishes.Tables.Add(dtDishesGroup);
            dsDishes.Tables.Add(dtDishes);

            return dsDishes;
        }

        private void fSplash_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (GValues.openSeasonId == 0)
                    {
                        fSeason fseason = new fSeason();
                        if (fseason.ShowDialog() != DialogResult.OK) return;
                    }

                    switch (GValues.authortype)
                    {
                        case 1:
                            if (!mifareAccess()) { return; }
                            fMain fMain = new fMain(ds);
                            fMain.ShowDialog();
                            break;
                    }
                    break;

                case Keys.Back:
                    break;

                case Keys.Escape:
                    Close();
                    break;
            }
        }
    }
}
