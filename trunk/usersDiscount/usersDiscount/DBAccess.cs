using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using com.sbs.dll;
using System.IO;

namespace com.sbs.gui.usersdiscount
{
    public class DBAccess
    {
        private SqlConnection con;
        private SqlCommand command;

        internal void data_add(string pDbType, DTO.DiscountInfo pDiscountInfo)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "INSERT INTO usersDiscount(fio, xkey, discount, ref_status, date_start, date_end, isExpDate, photo) " +
                                                    " VALUES(@fio, @xkey, @discount, @ref_status, @date_start, @date_end, @isExpDate, @photo)";

                command.Parameters.Add("fio", SqlDbType.NVarChar).Value = pDiscountInfo.fio;
                command.Parameters.Add("xkey", SqlDbType.NVarChar).Value = pDiscountInfo.xKey;
                command.Parameters.Add("discount", SqlDbType.Decimal).Value = pDiscountInfo.discount;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pDiscountInfo.refStatus;
                command.Parameters.Add("date_start", SqlDbType.Date).Value = pDiscountInfo.dateStart;
                command.Parameters.Add("date_end", SqlDbType.Date).Value = pDiscountInfo.isExpDate == 1 ? pDiscountInfo.dateEnd : (object)DBNull.Value;
                command.Parameters.Add("isExpDate", SqlDbType.Int).Value = pDiscountInfo.isExpDate;
                MemoryStream stream = new MemoryStream();
                pDiscountInfo.photo.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                command.Parameters.AddWithValue("@photo", stream.ToArray());
               
                

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        internal void data_edit(string pDbType, DTO.DiscountInfo pDiscountInfo)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "UPDATE usersDiscount " +
                                        " SET fio = @fio, " +
                                            " xkey = @xkey," +
                                            " discount = @discount," +
                                            " ref_status = @ref_status," +
                                            " date_start = @date_start, " +
                                            " date_end = @date_end," +
                                            " isExpDate = @isExpDate," +
                                            " photo = @photo" +
                                        " WHERE id = @id";

                command.Parameters.Add("id", SqlDbType.NVarChar).Value = pDiscountInfo.id;
                command.Parameters.Add("fio", SqlDbType.NVarChar).Value = pDiscountInfo.fio;
                command.Parameters.Add("xkey", SqlDbType.NVarChar).Value = pDiscountInfo.xKey;
                command.Parameters.Add("discount", SqlDbType.Decimal).Value = pDiscountInfo.discount;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = pDiscountInfo.refStatus;
                command.Parameters.Add("date_start", SqlDbType.Date).Value = pDiscountInfo.dateStart;
                command.Parameters.Add("date_end", SqlDbType.Date).Value = pDiscountInfo.isExpDate == 1 ? pDiscountInfo.dateEnd : (object)DBNull.Value;
                command.Parameters.Add("isExpDate", SqlDbType.Int).Value = pDiscountInfo.isExpDate;
                MemoryStream stream = new MemoryStream();
                pDiscountInfo.photo.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                command.Parameters.AddWithValue("@photo", stream.ToArray());

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }

        internal void data_del(string pDbType, int pId)
        {
            con = new DBCon().getConnection(pDbType);
            command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandText = "DELETE FROM usersDiscount " +
                                        " WHERE id = @id";

                command.Parameters.Add("id", SqlDbType.NVarChar).Value = pId;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }
        }
    }
}
