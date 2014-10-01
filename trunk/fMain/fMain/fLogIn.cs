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
using com.sbs.gui.main.Properties;

namespace com.sbs.gui.main
{
    public partial class fLogIn : Form
    {
        string[] xArg;

        public fLogIn(string[] arg)
        {
            xArg = arg;

            InitializeComponent();
            this.Text = GValues.prgNameFull;
            
            Settings set = new Settings();

            textBox_name.Text = set.lastLogin;
        }

        private void button_enter_Click(object sender, EventArgs e)
        {
            string uLogIn = textBox_name.Text.Trim();
            string uPwd = textBox_pwd.Text.Trim();

            if (!checkLogin(uLogIn, uPwd)) { uMessage.Show("Неверное имя пользователя или пароль", SystemIcons.Information); }
            else
            {
                Settings set = new Settings();
                set.lastLogin = uLogIn;
                set.Save();

                DialogResult = DialogResult.OK;
            }
        }

        private bool checkLogin(string pLogIn, string pPwd)
        {
            UserAuthorize uAuth = new UserAuthorize();
            return uAuth.checkLogin(pLogIn, pPwd);
        }

        //private void getUserInfoACL()
        //{
        //    dtResult = new DataTable();

        //    try
        //    {
        //        con = new DBCon().getConnection(GValues.DBMode);

        //        con.Open();
        //        command = con.CreateCommand();

        //        command.CommandText = " SELECT ua.user_acl_type, uat.name " +
        //                                " FROM users u " +
        //                                " INNER JOIN users_acl ua ON ua.users = u.id " +
        //                                " INNER JOIN users_acl_type uat ON uat.id = ua.user_acl_type " +
        //                                " WHERE u.id = @usersId " +
        //                                "       UNION " +
        //                                " SELECT ga.user_acl_type, uat.name " +
        //                                " FROM users_groups u " +
        //                                " INNER JOIN groups_acl ga ON ga.groups = u.groups " +
        //                                " INNER JOIN users_acl_type uat ON uat.id = ga.user_acl_type " +
        //                                " WHERE u.users = @usersId";

        //        command.Parameters.Add("usersId", SqlDbType.Int).Value = UsersInfo.UserId;

        //        using (SqlDataReader dr = command.ExecuteReader())
        //        {
        //            dtResult.Load(dr);
        //        }

        //        con.Close();
        //    }
        //    catch (Exception exc) { throw exc; }
        //    finally { if (con.State == ConnectionState.Open) con.Close(); }

        //    UsersInfo.Acl = new List<int>();

        //    for(int i = 0; i < dtResult.Rows.Count; i++)
        //    {
        //        UsersInfo.Acl.Add((int)dtResult.Rows[i]["user_acl_type"]);
        //    }
        //}
        
        private void fLogIn_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Control ctl;
                ctl = (Control)sender;
                ctl.SelectNextControl(ActiveControl, true, true, true, true);
            }
        }

        private void fLogIn_Shown(object sender, EventArgs e)
        {
            if (xArg.Count() == 2)
            {
                textBox_name.Text = xArg[0];
                textBox_pwd.Text = xArg[1];
                button_enter_Click(null, new EventArgs());
            }
        }
    }
}
