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
using System.Data.SqlClient;
using System.Data.Common;

namespace com.sbs.gui.main
{
    public partial class fLogIn : Form
    {
        public fLogIn()
        {
            InitializeComponent();
            this.Text = GValues.prgNameFull;
        }

        private void button_enter_Click(object sender, EventArgs e)
        {
            string uLogIn = textBox_name.Text.Trim();
            string uPwd = textBox_pwd.Text.Trim();

            if (!checkLogin(uLogIn, uPwd)) { uMessage.Show("Неверное имя пользователя или пароль", SystemIcons.Information); }
            else { DialogResult = DialogResult.OK; this.Close(); }
        }

        private bool checkLogin(string pLogIn, string pPwd)
        {
            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = "SELECT id, fname, sname, lname FROM users WHERE login = @login AND pwd = @pwd";
                command.Parameters.Add("login", SqlDbType.NVarChar).Value = pLogIn;
                command.Parameters.Add("pwd", SqlDbType.NVarChar).Value = pPwd;
                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dt.Load(dr);
                }
                con.Close();
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка обращения к базе данных", exc, SystemIcons.Error);
                return false;
            }

            if(dt.Rows.Count > 0) 
                return true;
            return false;
        }
    }
}
