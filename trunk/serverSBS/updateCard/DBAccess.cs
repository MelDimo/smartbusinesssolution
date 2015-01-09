using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using com.sbs.dll;
using System.Data;

namespace com.sbs.serverdll
{
    public class DBAccess_UpdateCard
    {
        private SqlConnection conMain = null;
        private SqlCommand commandMain = null;
        private SqlTransaction txMain = null;
        
        internal string updateCardHolders()
        {
            string errMsg = string.Empty;

            try
            {
                conMain = new SqlConnection(GValues.mainDBConStr);
                conMain.Open();
                commandMain = conMain.CreateCommand();

                commandMain.CommandText = "updateCardHolders";
                commandMain.CommandType = CommandType.StoredProcedure;

                errMsg = commandMain.ExecuteScalar() as string;

                conMain.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (conMain.State == ConnectionState.Open) conMain.Close(); }

            return errMsg;
        }
    }
}
