using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace com.sbs.dll.mailChecker
{
    class DBAccess
    {
        private DataTable dtResult;
        private SqlConnection con = null;
        private SqlCommand command = null;
        //private SqlTransaction tx = null;

        internal DataTable getMailClientConfig(string pDbType)
        {
            dtResult = new DataTable();
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT ring_name, maxMail, chkSec " +
                                        " FROM mailbox_config " +
                                        " WHERE users = @pUsers ";
                
                command.Parameters.Add("pUsers", SqlDbType.Int).Value = UsersInfo.UserId;

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) { con.Close(); } }

            return dtResult;
        }

        private byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[input.Length];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        internal void saveMailClientConfig(string pDbType, object[] oParam)
        {
            try
            {
                using (con = new DBCon().getConnection(pDbType))
                {
                    con.Open();
                    command = con.CreateCommand();

                    switch(oParam[3].ToString())
                    {
                        case "ADD":
                            command.CommandText = " INSERT INTO mailbox_config(users, ring_name, maxMail, chkSec) " +
                                                " VALUES(@users, @ring_name, @maxMail, @chkSec)";
                            break;
                        case "EDIT":
                            command.CommandText = " UPDATE mailbox_config SET ring_name = @ring_name, maxMail = @maxMail, chkSec = @chkSec " +
                                                    " WHERE users = @users";
                            break;
                    }

                    command.Parameters.Add("users", SqlDbType.Int).Value = UsersInfo.UserId;
                    command.Parameters.Add("ring_name", SqlDbType.NVarChar).Value = (string)oParam[0];
                    command.Parameters.Add("maxMail", SqlDbType.Int).Value = (int)oParam[1];
                    command.Parameters.Add("chkSec", SqlDbType.Int).Value = (int)oParam[2];

                    command.ExecuteNonQuery();

                    con.Close();
                }
            }
            catch (Exception exc) { throw exc; }
            
        }
    }
}
