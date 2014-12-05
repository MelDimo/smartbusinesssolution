using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using com.sbs.dll;

namespace com.sbs.gui.main
{
    class DBaccess
    {
        private SqlConnection con = null;
        private SqlCommand command = null;
        //private SqlTransaction tx = null;

        private DataTable dtResult;

        public object[] createMenuLoadModules(string pDbType)
        {
            //MenuStrip mainMnu = new MenuStrip();
            List<string> modules = new List<string>();
            string xModulePath;

            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT mnu.id, mnu.id_parent, mnu.name, mnu.ref_menu_type, mnu.ref_modules, modules.fname, modules.assembly_name " +
                                        "   FROM users_menu umnu " +
                                        "   INNER JOIN menu mnu ON mnu.id = umnu.menu " +
                                        "   LEFT JOIN ref_modules modules ON modules.id = mnu.ref_modules " +
                                        " WHERE umnu.users = @users AND mnu.ref_status = @ref_status " +
                                        " UNION " +
                                        " SELECT 0, null, null, null, null, fname, NULL " +
                                        "   FROM ref_modules WHERE isGUI = 0 " +
                                        " UNION " +
                                        " SELECT 0, null, null, null, null, fname, NULL " +
                                        "   FROM ref_modules WHERE id = 44 " +
                                        " ORDER BY mnu.id_parent ";
                command.Parameters.Add("users", SqlDbType.Int).Value = UsersInfo.UserId;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = 1;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            foreach (DataRow dr in dtResult.Rows)
            {
                xModulePath = dr["fname"].ToString();
                
                if (xModulePath.Equals("")) continue;

                modules.Add(dr["fname"].ToString());
            }

            return new object[] { dtResult, modules };
        }

        public string[] getUserPwd(string pDbType, string pKey)
        {
            string[] sReturn = new string[] { string.Empty, string.Empty };

            dtResult = new DataTable();

            con = new DBCon().getConnection(pDbType);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT u.login, upwd_pwd.pwd " +
                                        " FROM users_pwd upwd " +
                                        " INNER JOIN users u ON u.id = upwd.users " +
                                        " INNER JOIN users_pwd upwd_pwd ON upwd_pwd.users = upwd.users AND upwd_pwd.users_pwd_type = 1 " +
                                        " WHERE upwd.pwd = @pwd ";

                command.Parameters.Add("pwd", SqlDbType.NVarChar).Value = pKey;

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

            sReturn[0] = dtResult.Rows[0]["login"].ToString();
            sReturn[1] = dtResult.Rows[0]["pwd"].ToString();

            return sReturn;
        }
    }
}
