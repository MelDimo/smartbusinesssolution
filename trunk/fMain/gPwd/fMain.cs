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
using System.Diagnostics;

namespace com.sbs.gui.gPwd
{
    public partial class fMain : Form
    {
        string fLog = @"C:\SBS\gPWD_log.txt";
        string fLogText = string.Empty;

        byte[] bSourceFile;
        string strPwd;
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
                uMessage.Show("Неудалось создать файл", exc, SystemIcons.Information);
                if (File.Exists(GValues.mdfPath)) File.Delete(GValues.mdfPath);
                return;
            }

            uMessage.Show("Файл конфигураций создан.", SystemIcons.Information); 
            
        }

        private void updateFileLogo()
        {
            string strPwd = textBox_key.Text;

            try
            {
                using (FileStream fs = File.Open(GValues.logoPath, FileMode.Open, FileAccess.ReadWrite))
                {
                    
                    fs.SetLength(indexAE + strPwd.Length);
                    fs.Seek(indexAE, SeekOrigin.Current);
                    fs.Write(System.Text.Encoding.UTF8.GetBytes(strPwd), 0, strPwd.Length);
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
            string strError = "Заполнены не все обязательные поля:";
            string strData;

            #region проверка данных

            strPwd = textBox_key.Text.Trim();

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

            if (strPwd.Length == 0) strError += Environment.NewLine + "- Ключ";

            if (!strError.Equals("Заполнены не все обязательные поля:"))
            {
                MessageBox.Show(strError, GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            #endregion

            if (File.Exists(GValues.mdfPath)) File.Delete(GValues.mdfPath);
            File.Create(GValues.mdfPath).Dispose();

            try
            {
                sb.AppendLine(lServer.Server);
                sb.AppendLine(lServer.BD);
                sb.AppendLine(lServer.User);
                sb.AppendLine(lServer.Pwd);

                sb.AppendLine(mServer.Server);
                sb.AppendLine(mServer.BD);
                sb.AppendLine(mServer.User);
                sb.AppendLine(mServer.Pwd);

                strData = Crypto.Encrypt(sb.ToString(), strPwd.PadRight(16, '0'));
                
                using (StreamWriter outfile = new StreamWriter(GValues.mdfPath))
                {
                    outfile.Write(strData);
                }

            }
            catch(Exception exc)
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
            if (!File.Exists(GValues.logoPath))
            {
                MessageBox.Show("Отсутствует ключевой файл, работа приложения не возможна");
                return;
            }

            if (!File.Exists(GValues.mdfPath))
            {
                bSourceFile = File.ReadAllBytes(GValues.logoPath);
                indexAE = bSourceFile.Length;
                return;
            }

            try
            {
                readFile();
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка чтения", exc, SystemIcons.Information);
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
                groupBox3.Enabled = false;
                panel1.Enabled = false;
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
            if (indexAE == 0) indexAE = bSourceFile.Length;

            for(long i = indexAE; i < bSourceFile.Length; i++)
            {
                strPwd += Encoding.UTF8.GetString(new byte[] { (byte)bSourceFile.GetValue(i) });
            }

            textBox_key.Text = strPwd;

            FileStream fs = new FileStream(GValues.mdfPath, FileMode.Open);

            StreamReader sReader = new StreamReader(fs, Encoding.GetEncoding(1251));
            string strData = sReader.ReadToEnd();

            sReader.Close();
            fs.Close();

            strData = Crypto.Decrypt(strData, strPwd.PadRight(16, '0'));

            string[] resultString = strData.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            lServer.Server = resultString[0];
            lServer.BD = resultString[1];
            lServer.User = resultString[2];
            lServer.Pwd = resultString[3];

            mServer.Server = resultString[4];
            mServer.BD = resultString[5];
            mServer.User = resultString[6];
            mServer.Pwd = resultString[7];

            textBox_localSQlServer.Text = lServer.Server;
            textBox_localDB.Text = lServer.BD;
            textBox_localUser.Text = lServer.User;
            textBox_localPWD.Text = lServer.Pwd;

            textBox_mainSQLServer.Text = mServer.Server;
            textBox_mainDB.Text = mServer.BD;
            textBox_mainUser.Text = mServer.User;
            textBox_mainPWD.Text = mServer.Pwd;
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

        private void button_executeDB_Click(object sender, EventArgs e)
        {
            string sPath = string.Empty;

            sPath = textBox_fileBD.Text;
            if (sPath.Length == 0)
            {
                MessageBox.Show("Выберите файл для выпонтения.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Вы уверены что хотете выполнить сценарий создания БД?", GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                != DialogResult.Yes) return;

            createDB(sPath);
        }

        private void createDB(string pPath)
        {
            if (File.Exists(fLog)) File.Delete(fLog);
            File.Create(fLog).Dispose(); ;

            string argument = string.Format(@" -S {0} -U {1} -P {2} -i ""{3}"" -o ""{4}""",
                        lServer.Server, lServer.User, lServer.Pwd, pPath, fLog);
            textBox_log.Text += argument;
            Process process = new Process();
            process.StartInfo.FileName = "sqlcmd.exe";
            process.StartInfo.Arguments = argument;
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.CreateNoWindow = false;
            process.Start();
            process.WaitForExit();

            fLogText = File.ReadAllText(fLog, Encoding.ASCII);
            textBox_log.Text = fLogText;
            textBox_log.Text += Environment.NewLine + argument;
        }

        private void button_browBD_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "*.sql|*.sql";
            ofd.Multiselect = false;
            ofd.InitialDirectory = Environment.CurrentDirectory;
            if(ofd.ShowDialog() != DialogResult.OK) return;

            textBox_fileBD.Text = ofd.FileName;
        }

        private void button_executeData_Click(object sender, EventArgs e)
        {

        }

    }
}
