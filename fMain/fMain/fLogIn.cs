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
            else { DialogResult = DialogResult.OK; }
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
                command.CommandText = "SELECT u.id, u.tabn, u.fname, u.sname, u.lname, u.org, u.branch, u.unit, u.ref_post, u.login " +
                                        " FROM users u " +
                                        " INNER JOIN users_pwd up ON up.users = u.id WHERE u.login = @login AND up.pwd = @pwd";
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

            if (dt.Rows.Count > 0)
            {
                UsersInfo.UserId = int.Parse(dt.Rows[0]["id"].ToString());
                UsersInfo.UserTabn = dt.Rows[0]["tabn"].ToString();
                UsersInfo.UserName = dt.Rows[0]["lname"].ToString() + " " + dt.Rows[0]["fname"].ToString() + " " + dt.Rows[0]["sname"].ToString();
                UsersInfo.PostId = int.Parse(dt.Rows[0]["ref_post"].ToString());
                UsersInfo.LogIn = dt.Rows[0]["login"].ToString();

                return true;
            }

            return false;
        }

        private void fLogIn_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Control ctl;
                ctl = (Control)sender;
                ctl.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }
    }
}
