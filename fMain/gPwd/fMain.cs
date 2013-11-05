using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll;
using System.IO;
using System.Security.Cryptography;
using com.sbs.dll.utilites;

namespace com.sbs.gui.gPwd
{
    public partial class fMain : Form
    {
        byte[] bSourceFile;
        string strPwd;
        byte[] rgbKey;
        long indexAE;

        StringBuilder sb = new StringBuilder();

        localServer lServer = new localServer();
        mainServer mServer = new mainServer();

        public fMain()
        {
            InitializeComponent();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                createFile();
                updateFileLogo();
            }
            catch (Exception exc) {
                if (File.Exists(GValues.mdfPath)) File.Delete(GValues.mdfPath);
                uMessage.Show("Неудалось создать файл", exc, SystemIcons.Information); 
            }

            uMessage.Show("Файл конфигураций создан.", SystemIcons.Information); 
            
        }

        private void updateFileLogo()
        {
            string strPwd = textBox_key.Text;
            strPwd = strPwd.PadRight(32, '0');

            try
            {
                using (FileStream fs = File.Open(GValues.logoPath, FileMode.Open, FileAccess.ReadWrite))
                {
                    fs.SetLength(indexAE + strPwd.Length);
                    fs.Seek(indexAE, SeekOrigin.Current);
                    fs.Write(System.Text.Encoding.ASCII.GetBytes(strPwd), 0, strPwd.Length);
                    fs.Flush();
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private void createFile()
        {
            StreamWriter sWriter;
            string strError = "Заполнены не все обязательные поля:";

            #region проверка данных

            lServer.Server = textBox_localSQlServer.Text.Trim();
            lServer.BD = textBox_localDB.Text.Trim();
            lServer.User = textBox_localUser.Text.Trim();
            lServer.Pwd = textBox_localPWD.Text.Trim();

            mServer.Server = textBox_mainSQLServer.Text.Trim();
            mServer.BD = textBox_mainDB.Text.Trim();
            mServer.User = textBox_mainUser.Text.Trim();
            mServer.Pwd = textBox_mainPWD.Text.Trim();

            if (lServer.Server.Length == 0) strError += Environment.NewLine + "- Локальный сервер (SQL Server)";
            if (lServer.BD.Length == 0) strError += Environment.NewLine + "- Локальный сервер (BD)";
            if (lServer.User.Length == 0) strError += Environment.NewLine + "- Локальный сервер (Пользователь)";
            if (lServer.Pwd.Length == 0) strError += Environment.NewLine + "- Локальный сервер (Пароль)";

            if (mServer.Server.Length == 0) strError += Environment.NewLine + "- Головной сервер (SQL Server)";
            if (mServer.BD.Length == 0) strError += Environment.NewLine + "- Головной сервер (BD)";
            if (mServer.User.Length == 0) strError += Environment.NewLine + "- Головной сервер (Пользователь)";
            if (mServer.Pwd.Length == 0) strError += Environment.NewLine + "- Головной сервер (Пароль)";

            if (!strError.Equals("Заполнены не все обязательные поля:"))
            {
                MessageBox.Show(strError, GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            #endregion

            if (File.Exists(GValues.mdfPath)) File.Delete(GValues.mdfPath);

            try
            {
                using (FileStream fs = File.Create(GValues.mdfPath))
                {
                    Rijndael RijndaelAlg = Rijndael.Create();
                    RijndaelAlg.KeySize = 256;
                    RijndaelAlg.BlockSize = 128;
                    RijndaelAlg.Mode = System.Security.Cryptography.CipherMode.CFB;
                    RijndaelAlg.Padding = System.Security.Cryptography.PaddingMode.ISO10126;
                    CryptoStream cStream = new CryptoStream(fs,
                                                            RijndaelAlg.CreateEncryptor(rgbKey, GValues.rgbIV),
                                                            CryptoStreamMode.Write);
                    sWriter = new StreamWriter(cStream, Encoding.GetEncoding(1251));

                    sb.AppendLine(lServer.Server);
                    sb.AppendLine(lServer.BD);
                    sb.AppendLine(lServer.User);
                    sb.AppendLine(lServer.Pwd);

                    sb.AppendLine(mServer.Server);
                    sb.AppendLine(mServer.BD);
                    sb.AppendLine(mServer.User);
                    sb.AppendLine(mServer.Pwd);

                    sWriter.WriteLine(sb.ToString());

                    sWriter.Flush();

                    sWriter.Close();
                }

            }
            catch (Exception exc)
            {
                throw exc;
            }

        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fMain_Shown(object sender, EventArgs e)
        {
            try
            {
                readFile();
            }
            catch// (Exception exc)
            {
                //uMessage.Show("Ошибка чтения", exc, SystemIcons.Information);
                //groupBox1.Enabled = false;
                //groupBox2.Enabled = false;
                //groupBox3.Enabled = false;
                //panel1.Enabled = false;
            }
        }

        private void readFile()
        {
            bSourceFile = File.ReadAllBytes(GValues.logoPath);
            /*
                00 00 00 00 49 45 4e 44 ae 42 60 82
                ........... I  E  N  D  ...........
            */
            indexAE = Array.LastIndexOf(bSourceFile, (byte)174) + 4; // 174 - "ae"

            for(long i = indexAE; i < bSourceFile.Length; i++)
            {
                strPwd += Encoding.ASCII.GetString(new byte[] { (byte)bSourceFile.GetValue(i) });
            }

            strPwd = strPwd.PadRight(32, '0');

            rgbKey = Encoding.ASCII.GetBytes(strPwd);

            textBox_key.Text = strPwd;
        }

        class localServer
        {
            public string Server { get; set; }
            public string BD { get; set; }
            public string User { get; set; }
            public string Pwd { get; set; }
        }

        class mainServer
        {
            public string Server { get; set; }
            public string BD { get; set; }
            public string User { get; set; }
            public string Pwd { get; set; }
        }
    }
}
