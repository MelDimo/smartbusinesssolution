using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;
using com.sbs.dll;

namespace com.sbs.gui.users
{
    public partial class fPwd : Form
    {
        private DBaccess DbAccess = new DBaccess();
        private int retCode, hContext, hCard, Protocol;
        public int xUserId;

        public fPwd(DataTable pDtUsersPwd)
        {
            InitializeComponent();

            button_refresh.BackgroundImage = com.sbs.dll.utilites.Properties.Resources.refresh_26;
            
            textBox_login.Text = UsersInfo.LogIn;

            foreach (DataRow dr in pDtUsersPwd.Rows)
            { 
                switch(dr["users_pwd_type"].ToString())
                {
                    case "1":
                        textBox_pwd.Text = dr["pwd"].ToString();
                        break;

                    case "2":
                        textBox_cardID.Text = dr["pwd"].ToString();
                        break;
                }
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            string xCardID = textBox_cardID.Text.Trim();
            string xPwd = textBox_pwd.Text.Trim();
            string xLogIn = textBox_login.Text.Trim();

            string msg = "Не указаны след виды авторизации:";

            if (xPwd.Length == 0) msg += Environment.NewLine + "- Пароль;";
            if (xCardID.Length == 0) msg += Environment.NewLine + @"- Браслет\Карта (Mifare);";
            if (xLogIn.Length == 0)
            {
                MessageBox.Show("Не заполенено обязательное поле: " + Environment.NewLine + "- Имя учетной записи;" , GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                return;
            } 

            if(!msg.Equals("Не указаны след виды авторизации:"))
            {
                msg += Environment.NewLine + Environment.NewLine + "Все равно продолжить?";
                if(MessageBox.Show(msg, GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) return;
            }

            try{
                DbAccess.saveUsersPwd("offline", new object[] { xUserId, xCardID, xPwd, xLogIn });
            }catch(Exception exc){uMessage.Show("Неудалось сохранить данные", exc,SystemIcons.Information);}

            uMessage.Show("Данные сохранены.", SystemIcons.Information);
            DialogResult = DialogResult.OK;
        }

        private void connectToDevice()
        {

            retCode = ModWinsCard.SCardConnect(hContext, comboBox_listReaders.SelectedItem.ToString(), ModWinsCard.SCARD_SHARE_SHARED,
                                              ModWinsCard.SCARD_PROTOCOL_T0 | ModWinsCard.SCARD_PROTOCOL_T1, ref hCard, ref Protocol);

            switch(retCode)
            {
                case ModWinsCard.SCARD_S_SUCCESS:
                    break;

                case ModWinsCard.SCARD_W_REMOVED_CARD:
                    uMessage.Show("Поднесите браслет к устройству.", SystemIcons.Information);
                    return;

                default:
                    uMessage.Show("ErrorCode: " + retCode + Environment.NewLine + "ErrorMessage: " + ModWinsCard.GetScardErrMsg(retCode), SystemIcons.Information);
                    return;
            }

            ModWinsCard.SCARD_IO_REQUEST sioreq = new ModWinsCard.SCARD_IO_REQUEST();
            sioreq.dwProtocol = 0;// ModWinsCard.SCARD_PROTOCOL_T0; // SCARD_PROTOCOL_T1
            sioreq.cbPciLength = 8;

            ModWinsCard.SCARD_IO_REQUEST rioreq = new ModWinsCard.SCARD_IO_REQUEST();
            rioreq.dwProtocol = 0;// ModWinsCard.SCARD_PROTOCOL_T0; // SCARD_PROTOCOL_T1
            rioreq.cbPciLength = 8;

            byte[] receivebuffer = new byte[262];
            int sendbufferLen = 0;
            int receivebufferLen = 0;

            byte[] SendBuff = new byte[5];
            SendBuff[0] = 0xFF;                                      // CLA     
            SendBuff[1] = 0xCA;                                      // INS
            SendBuff[2] = 0x00;                                      // P1
            SendBuff[3] = 0x00;                                      // P2 : Block No.
            SendBuff[4] = 0x04;

            sendbufferLen = 0x05;
            receivebufferLen = 262;

            int retval = ModWinsCard.SCardTransmit(hCard, ref sioreq, ref SendBuff[0], sendbufferLen, ref rioreq, ref receivebuffer[0], ref receivebufferLen);

            switch (retval)
            {
                case ModWinsCard.SCARD_S_SUCCESS:
                    textBox_cardID.Text = "";
                    for (int i = 0; i <= receivebufferLen; i++)
                    {
                        textBox_cardID.Text += receivebuffer[i];
                    }
                    break;

                default:
                    uMessage.Show("ErrorCode: " + retval + Environment.NewLine + "ErrorMessage: " + ModWinsCard.GetScardErrMsg(retval), SystemIcons.Information);
                    break;
            }            

            ModWinsCard.SCardDisconnect(hContext, ModWinsCard.SCARD_LEAVE_CARD);
        }

        private void button_refresh_Click(object sender, EventArgs e)
        {
            connectToDevice();
        }

        private void tabControl_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((TabControl)sender).SelectedIndex != 1) return;

            string ReaderList = "" + Convert.ToChar(0);
            int indx;
            int pcchReaders = 0;
            string rName = "";

            retCode = ModWinsCard.SCardEstablishContext(ModWinsCard.SCARD_SCOPE_USER, 0, 0, ref hContext);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                uMessage.Show("Не удалось определить reader." + Environment.NewLine + "ErrorCode: " + retCode, SystemIcons.Information);
                return;
            }

            retCode = ModWinsCard.SCardListReaders(hContext, null, null, ref pcchReaders);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                uMessage.Show("Не удалось получить перечень reader-ов." + Environment.NewLine + "ErrorCode: " + retCode, SystemIcons.Information);
                return;
            }

            byte[] ReadersList = new byte[pcchReaders];

            // Fill reader list
            retCode = ModWinsCard.SCardListReaders(hContext, null, ReadersList, ref pcchReaders);

            if (retCode != ModWinsCard.SCARD_S_SUCCESS)
            {
                uMessage.Show("SCardListReaders Error: " + ModWinsCard.GetScardErrMsg(retCode), SystemIcons.Information);
                return;
            }

            rName = "";
            indx = 0;

            comboBox_listReaders.Items.Clear();

            //Convert reader buffer to string
            while (ReadersList[indx] != 0)
            {

                while (ReadersList[indx] != 0)
                {
                    rName = rName + (char)ReadersList[indx];
                    indx = indx + 1;
                }

                //Add reader name to list
                comboBox_listReaders.Items.Add(rName);
                rName = "";
                indx = indx + 1;

            }

            if (comboBox_listReaders.Items.Count > 0)
            {
                comboBox_listReaders.SelectedIndex = 0;
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void checkBox_showPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_showPwd.Checked) textBox_pwd.UseSystemPasswordChar = false;
            else textBox_pwd.UseSystemPasswordChar = true;
        }
    }
}
