using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using com.sbs.dll;
using System.Windows.Forms;

namespace com.sbs.gui.timetracking
{
    class DBaccess
    {
        private DataTable dtResult = new DataTable();
        private SqlConnection con;
        private SqlCommand command = null;
        //private SqlTransaction tx = null;

        internal curUser getUserByMifire(string pDbType, string pKeyId)
        {
            curUser cUser = new curUser();

            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT u.id, u.tabn, u.lname + ' ' + u.fname + ' ' + u.sname as fio, tt.id as ttId, tt.datetime_in, tt.datetime_out" +
                                        " FROM users u " +
                                        " INNER JOIN users_pwd up ON up.users = u.id " +
                                        " LEFT JOIN timeTracking tt ON tt.users = u.id AND tt.branch = @branch " +
                                        " WHERE up.pwd = @pwd";

                command.Parameters.Add("pwd", SqlDbType.NVarChar).Value = pKeyId;
                command.Parameters.Add("branch", SqlDbType.Int).Value = GValues.branchId;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            switch (dtResult.Rows.Count)
            {
                case 0:
                    throw new Exception("Сотрудник не найден");

                case 1:
                    break;

                default:
                    throw new Exception("Найдено больше одного сотрудника удовлетворяющего параметрам.");
            }

            cUser.id = (int)dtResult.Rows[0]["id"];
            cUser.fio = dtResult.Rows[0]["fio"].ToString();
            cUser.tabn = dtResult.Rows[0]["tabn"].ToString();
            cUser.branch = GValues.branchId;
            if (dtResult.Rows[0]["datetime_in"].ToString().Length == 0)
            {
                cUser.curState = 0;
                cUser.ttId = 0;
            }
            else
            {
                if (dtResult.Rows[0]["datetime_out"].ToString().Length == 0)
                {
                    cUser.curState = 1;
                    cUser.ttId = (int)dtResult.Rows[0]["ttId"];
                }
                else cUser.curState = 2;
            }

            if (cUser.curState == 2)
            {
                if (MessageBox.Show("Сотрудник: " + cUser.fio + Environment.NewLine + "Регистрация ухода: " + dtResult.Rows[0]["datetime_out"].ToString()
                    + Environment.NewLine + Environment.NewLine + "Зарегистрировать новый приход?",
                    GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    cUser.curState = 0;
                    cUser.ttId = 0;
                }
                else
                    throw new Exception("Сотрудник: " + cUser.fio + Environment.NewLine + "Регистрация ухода: " + dtResult.Rows[0]["datetime_out"].ToString());

            }

            return cUser;
            
        }

        internal void changeState(string pDbType, curUser pCUser)
        {
            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                switch (pCUser.curState)
                { 
                    case 0:
                        command.CommandText = "INSERT INTO timeTracking(users, datetime_in, branch) VALUES (@users, @datetimeIn, @branch)";
                        command.Parameters.Add("users", SqlDbType.Int).Value = pCUser.id;
                        command.Parameters.Add("datetimeIn", SqlDbType.DateTime).Value = pCUser.datetimeIn;
                        command.Parameters.Add("branch", SqlDbType.Int).Value = pCUser.branch;
                        break;

                    case 1:
                        command.CommandText = "UPDATE timeTracking SET datetime_out = @datetimeOut WHERE id = @ttId";
                        command.Parameters.Add("datetimeOut", SqlDbType.DateTime).Value = pCUser.datetimeOut;
                        command.Parameters.Add("ttId", SqlDbType.Int).Value = pCUser.ttId;
                        break;
                }
                
                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        internal curUser getUserByLogIn(string pDbType, string pLogIn, string pPwd)
        {
            curUser cUser = new curUser();

            dtResult = new DataTable();

            int xId = 0; // id "рабочей" записи в dtResult

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "SELECT u.id, u.tabn, u.lname + ' ' + u.fname + ' ' + u.sname as fio, tt.id as ttId, tt.datetime_in, tt.datetime_out" +
                                        " FROM users u " +
                                        " INNER JOIN users_pwd up ON up.users = u.id " +
                                        " LEFT JOIN timeTracking tt ON tt.users = u.id AND tt.branch = @branch " +
                                        " AND (DATEADD(dd, 0, DATEDIFF(dd, 0, datetime_in)) = DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())) " +
	                                            " OR DATEADD(dd, 0, DATEDIFF(dd, 0, datetime_out)) = DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE())))" +
                                        " WHERE up.pwd = @pwd AND u.login = @login ";

                command.Parameters.Add("login", SqlDbType.NVarChar).Value = pLogIn;
                command.Parameters.Add("pwd", SqlDbType.NVarChar).Value = pPwd;
                command.Parameters.Add("branch", SqlDbType.Int).Value = GValues.branchId;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            switch (dtResult.Rows.Count)
            {
                case 0:
                    throw new Exception("Сотрудник не найден");

                case 1:
                    break;

                default:
                    for (int i = 0; i < dtResult.Rows.Count; i++)
                    {
                        if (dtResult.Rows[i]["datetime_in"].ToString().Length == 0
                            || dtResult.Rows[i]["datetime_out"].ToString().Length == 0)
                        {
                            xId = i;
                            break;
                        }
                    }
                    break;
            }

            cUser.id = (int)dtResult.Rows[xId]["id"];
            cUser.fio = dtResult.Rows[xId]["fio"].ToString();
            cUser.tabn = dtResult.Rows[xId]["tabn"].ToString();
            cUser.branch = GValues.branchId;

            if (dtResult.Rows[xId]["datetime_in"].ToString().Length == 0)
            {
                cUser.curState = 0;
                cUser.ttId = 0;
            }
            else
            {
                if (dtResult.Rows[xId]["datetime_out"].ToString().Length == 0)
                {
                    cUser.curState = 1;
                    cUser.ttId = (int)dtResult.Rows[xId]["ttId"];
                }
                else
                    cUser.curState = 2;
            }

            if (cUser.curState == 2)
            {
                if (MessageBox.Show("Сотрудник: " + cUser.fio + Environment.NewLine + "Регистрация ухода: " + dtResult.Rows[xId]["datetime_out"].ToString()
                    + Environment.NewLine + Environment.NewLine + "Зарегистрировать новый приход?",
                    GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    cUser.curState = 0;
                    cUser.ttId = 0;
                }
                else
                    throw new Exception("Сотрудник: " + cUser.fio + Environment.NewLine + "Регистрация ухода: " + dtResult.Rows[xId]["datetime_out"].ToString());

            }

            return cUser;
        }
    }

    public class curUser
    {
        public curUser()
        {
            datetimeIn = DateTime.Now;
            datetimeOut = DateTime.Now;
        }

        public int id { get; set; }
        public int ttId { get; set; }
        public string tabn { get; set; }
        public string fio { get; set; }
        public int branch { get; set; }
        /// <summary>
        /// Текущее состояние сотрудника в текущем заведении
        /// 0 - не отмечался в текущем заведении;
        /// 1 - открыта смена;
        /// 2 - закрыта смена; 
        /// </summary>
        public int curState { get; set; }
        public DateTime datetimeIn { get; set; }
        public DateTime datetimeOut { get; set; }
    }
}
