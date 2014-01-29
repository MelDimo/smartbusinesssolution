using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll;
using System.Threading;
using System.Diagnostics;
using com.sbs.dll.utilites;

namespace com.sbs.gui.DashBoard
{
    public partial class fCloseSeason_Waiter : Form
    {
        int currentRow = 0;
        Waiter oWaiter;
        private DBaccess DbAccess = new DBaccess();

        object[] buffer = new object[1];

        public fCloseSeason_Waiter()
        {
            InitializeComponent();

            button_sumWaiterBack.BackgroundImage = com.sbs.dll.utilites.Properties.Resources.left_26;
        }

        void Button_Click(object sender, EventArgs e)
        {
            oWaiter = new Waiter();
            Button btn = sender as Button;
            oWaiter.WaiterId = int.Parse(btn.Name);
            oWaiter.WaiterName = btn.Text;

            loginPanelShow(oWaiter);
        }

        private void fCloseSeason_Waiter_Shown(object sender, EventArgs e)
        {
            DataTable dtWaiterInfo;
            tSStatusLabel_whoOpen.Text = GValues.openSeasonUserName;
            tSStatusLabel_whenOpen.Text = GValues.openSeasonDate;

            Button btn;
            try
            {
                dtWaiterInfo = DbAccess.getWaitersInfo("offline");
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information); return; }


            for (int i = 0; i <= 5; i++)
            {
                btn = new Button();
                btn.Click += new EventHandler(Button_Click);
                btn.Text = "Waiter_" + i;
                btn.Name = i.ToString();
                panel_waiter.Controls.Add(btn);
            }
        }

        private void loginPanelShow(Waiter oWaiter)
        {
            string keyId = "";

            panel_image.BackgroundImage = null;

            currentRow += 1;

            panel_logIn.BringToFront();
            panel_waiterSum.SendToBack();
            panel_waiterMain.SendToBack();

            panel_logIn.Left = panel_waiterMain.Left + panel_waiterMain.Width;
            while (true)
            {
                if (panel_logIn.Left != panel_waiterMain.Left)
                {
                    panel_logIn.Left--;
                }
                else break;
            }
            panel_image.BackgroundImage = com.sbs.dll.utilites.Properties.Resources.ACR122_logoNFC;
            panel_image.Refresh();

            Mifire oMifare = new Mifire();
            try
            {
                oMifare = new Mifire();
                keyId = oMifare.readMifire();
            }
            catch (Exception exc) { uMessage.Show("Ошибка взаимодействия с ридером" + Environment.NewLine + exc.Message, exc, SystemIcons.Information); DialogResult = DialogResult.Cancel; }

            #region Копируем UserInfo в AdminInfo (сохраняем данные статического класа. Коряво пиздец)
            UsersInfoCopy userInfoCopy = new UsersInfoCopy();
            userInfoCopy.getUserInfo();
            #endregion

            try
            {
                DbAccess.checkMifareWaiter("offline", keyId);
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information); return; }

            if (oWaiter.WaiterId != UsersInfo.UserId)
            {
                MessageBox.Show("Ошибка авторизации, несовпадение авторизационных данных");
                button_sumWaiterBack_Click(null, new EventArgs());
                return;
            }
            
            //Получаем информцию о сменах официанта
            //getBillsInfo(UsersInfo.UserId);

            #region Востанавливаем данные UserInfo из AdminInfo
            userInfoCopy.setUserInfo();
            #endregion
        }

        private void sumPanelShow(Waiter oWaiter)
        {
            currentRow += 1;

            panel_waiterSum.BringToFront();
            panel_waiterMain.SendToBack();
            panel_logIn.SendToBack();

            panel_waiterSum.Left = panel_waiterMain.Left + panel_waiterMain.Width;
            while (true)
            {
                if (panel_waiterSum.Left != panel_waiterMain.Left)
                {
                    panel_waiterSum.Left--;
                }
                else break;
            }
        }

        private void fCloseSeason_Waiter_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;

                case Keys.Back:
                    switch (currentRow)
                    {
                        case 0:
                            break;

                        case 1:
                            button_sumWaiterBack_Click(null, new EventArgs());
                            break;

                        case 2:
                            loginPanelShow(oWaiter);
                            break;

                        default:
                            break;
                    }
                    break;
            }
        }

        private void button_sumWaiterBack_Click(object sender, EventArgs e)
        {
            currentRow -= 1;

            panel_waiterSum.SendToBack();
            panel_waiterMain.BringToFront();
            panel_logIn.SendToBack();

            panel_waiterMain.Left = -1 * panel_logIn.Width;

            while (true)
            {
                if (panel_waiterMain.Left != panel_logIn.Left)
                {
                    panel_waiterMain.Left++;
                }
                else return;
            }
        }

        class Waiter
        {
            private int _waiterId;
            private string _waiterName;

            public string WaiterName
            {
                get { return _waiterName; }
                set { _waiterName = value; }
            }
            
            public int WaiterId
            {
                get { return _waiterId; }
                set { _waiterId = value; }
            }
        }

        /// <summary>
        /// Клас реализован по подобию UserInfo и полностью его дублирует.
        /// Возник в следствии того, что клас UserInfo статичен и метод checkMifareWaiter его переписывает,
        /// а это не допустимо.т.к в нем хранятся данные по Администратору который закрыватся официаниские смены
        /// </summary>
        class UsersInfoCopy
        {
            private int _userId;
            private string _userName;
            private string _userTabn;
            private int _postId;
            private List<int> _acl;

            public void getUserInfo()
            {
                _acl = UsersInfo.Acl;
                _postId = UsersInfo.PostId;
                _userName = UsersInfo.UserName;
                _userTabn = UsersInfo.UserTabn;
                _userId = UsersInfo.UserId;
            }

            public void setUserInfo()
            {
                UsersInfo.Acl = _acl;
                UsersInfo.PostId = _postId;
                UsersInfo.UserName = _userName;
                UsersInfo.UserTabn = _userTabn;
                UsersInfo.UserId = _userId;
            }
        }
    }
}
