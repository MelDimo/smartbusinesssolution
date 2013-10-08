using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll;
using com.sbs.dll.utilites;

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

        private void fSplash_KeyUp(object sender, KeyEventArgs e)
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
            }
        }

        private bool mifareAccess()
        {
            fMIFare fMifare = new fMIFare();
            if (fMifare.ShowDialog() == DialogResult.OK) 
                return true;

            return false;
        }

        private DataSet getReferences()
        {
            DataTable dtCarte = new DataTable();
            DataTable dtDishesGroup = new DataTable();
            DataTable dtDishes = new DataTable();

            try
            {
                dtCarte = DbAccess.getCarte("offline");
                dtDishesGroup = DbAccess.getDishesGroup("offline");
                dtDishes = DbAccess.getDishes("offline");
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения данных.", exc, SystemIcons.Information); }

            DataSet dsDishes = new DataSet();
            dsDishes.Tables.Add(dtCarte);
            dsDishes.Tables.Add(dtDishesGroup);
            dsDishes.Tables.Add(dtDishes);

            return dsDishes;
        }
    }
}
