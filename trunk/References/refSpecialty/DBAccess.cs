using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using com.sbs.dll.utilites;
using com.sbs.dll;
using System.Data.SqlClient;

namespace com.sbs.gui.references.refspecialty
{
    public class DBAccess
    {
        SqlConnection con = null;
        SqlCommand command = null;

        private getReference oReference = new getReference();

        private DataTable dtResult;

        public DataTable data_get()
        {
            dtResult = new DataTable();

            dtResult = oReference.getSpecialty(GValues.DBMode);

            return dtResult;
        }
        
        public void data_add(Specialty pSpecialty)
        {
            try
            {
                con = new DBCon().getConnection(GValues.DBMode);

                con.Open();

                command = con.CreateCommand();
                command.CommandText = "INSERT INTO ref_specialty(name, ref_status) VALUES(@name, @refStatus)";
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pSpecialty.name;
                command.Parameters.Add("refStatus", SqlDbType.Int).Value = pSpecialty.refStatus;
                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
            
        }

        internal void data_del(int pId)
        {
            try
            {
                con = new DBCon().getConnection(GValues.DBMode);

                con.Open();

                command = con.CreateCommand();
                command.CommandText = "DELETE FROM ref_specialty WHERE id = @id";
                command.Parameters.Add("id", SqlDbType.Int).Value = pId;
                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        internal void data_edit(Specialty pSpecialty)
        {
            try
            {
                con = new DBCon().getConnection(GValues.DBMode);

                con.Open();

                command = con.CreateCommand();
                command.CommandText = "UPDATE ref_specialty SET name = @name, ref_status = @refStatus WHERE id = @id";

                command.Parameters.Add("id", SqlDbType.Int).Value = pSpecialty.id;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pSpecialty.name;
                command.Parameters.Add("refStatus", SqlDbType.Int).Value = pSpecialty.refStatus;
                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }
    }

    public class Specialty
    {
        public int id { get; set; }
        public string name { get; set; }
        public int refStatus { get; set; }
    }
}
