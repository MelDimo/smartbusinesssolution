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
            
            try
            {
                dtCarte = DbAccess.getCarte("offline");
                dtDishesGroup = DbAccess.getDishesGroup("offline");
                dtDishes = DbAccess.getDishes("offline");
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

                case Keys.F12:
                    if (GValues.openSeasonId == 0) // Рабочая место не авторизовалось в сменене либо нет открытой смены
                    {
                        MessageBox.Show("Нет открытых/авторизованных смен для текущего рабочего места.", GValues.prgNameFull, 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    fMIFare fmifare = new fMIFare();
                    if (fmifare.ShowDialog() != DialogResult.OK) return;

                    try
                    {
                        DbAccess.checkMifareWaiter("offline", fmifare.keyId);
                    }
                    catch (Exception exc) { uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information); return; }


                    if (e.Modifiers == Keys.Alt)    // Закрытие официантской смены
                    {
                        if (!UsersInfo.Acl.Contains(9)) // user_acl.id Закрытие смены официанта(Позволяет закрывать смену официанта)
                        {
                            MessageBox.Show(UsersInfo.UserName + ": Нет доступа к закрытию смены официанта.", GValues.prgNameFull,
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        fCloseSeason_Waiter fclosewaiter = new fCloseSeason_Waiter();
                        fclosewaiter.ShowDialog();
                    }
                    else                            // Закрытие основной смены
                    {
                        if (!UsersInfo.Acl.Contains(2)) // user_acl.id Закрытие смены официанта(Позволяет закрывать смену официанта)
                        {
                            MessageBox.Show(UsersInfo.UserName + ": Нет доступа к закрытию смены заведения.", GValues.prgNameFull,
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        fCloseSeason fcloseseasone = new fCloseSeason();
                        fcloseseasone.ShowDialog();
                    }
                    break;

                case Keys.Escape:
                    Close();
                    break;
            }
        }
    }
}
