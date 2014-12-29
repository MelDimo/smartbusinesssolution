using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using com.sbs.dll;
using System.Data;

namespace com.sbs.serverdll
{
    class DBAccess_UpdateCard
    {
        private SqlConnection conMain = null;
        private SqlCommand commandMain = null;
        private SqlTransaction txMain = null;
        
        internal void updateCardHolders()
        {
        
            try
            {
                conMain = new SqlConnection(GValues.mainDBConStr);
                conMain.Open();
                commandMain = conMain.CreateCommand();

                commandMain.CommandText = "updateCardHolders"; 
                commandMain.CommandType = CommandType.StoredProcedure;

                commandMain.ExecuteNonQuery();

                conMain.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (conMain.State == ConnectionState.Open) conMain.Close(); }
        }
    }
}
