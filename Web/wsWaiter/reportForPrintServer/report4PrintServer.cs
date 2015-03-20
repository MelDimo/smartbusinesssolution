using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using com.sbs.dll;
using System.Data.SqlClient;
using System.Threading;
using com.sbs.dll.utilites;

namespace com.sbs.reportForPrintServer
{
    public class report4PrintServer
    {
        private SqlConnection con;
        private SqlCommand command = null;
        private SqlTransaction tx = null;

        private DataTable dtResult;

        public int commitDish(string pDbType, DTO_DBoard.Bill pBill, int season, int userId, string userName)
        {
            DataSet dsResult = new DataSet();

            try
            {
                con = new DBCon().getConnection(pDbType);

                con.Open();
                command = con.CreateCommand();

                tx = con.BeginTransaction();

                command.Transaction = tx;

                dsResult = printRunners(command, pBill); // Возвращаем перечень блюд для бегунка

                command.CommandText = "mobile_BillSetTable";
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Clear();
                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = season;
                command.Parameters.Add("pBillId", SqlDbType.Int).Value = pBill.id;
                command.Parameters.Add("pUserId", SqlDbType.Int).Value = userId;

                command.ExecuteNonQuery();

                command.CommandText = "DishToBill_changeStatus";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Clear();

                command.Parameters.Add("pBranch", SqlDbType.Int).Value = GValues.branchId;
                command.Parameters.Add("pSeason", SqlDbType.Int).Value = season;
                command.Parameters.Add("pBillId", SqlDbType.Int).Value = pBill.id;
                command.Parameters.Add("pUserId", SqlDbType.Int).Value = userId;
                command.Parameters.Add("pStatusId", SqlDbType.Int).Value = 24; // Позиция была отправлена на изготовление
                command.Parameters.Add("pDateStatus", SqlDbType.DateTime).Value = DateTime.Now;

                command.ExecuteNonQuery();


                tx.Commit();
                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) { tx.Rollback(); dtResult = null; con.Close(); } }

            return rawPrint(dsResult, pBill, userName);

        }

        private DataSet printRunners(SqlCommand command, DTO_DBoard.Bill pBill)
        {
            DataSet dsResult = new DataSet();

            DataTable tPrintersType = new DataTable();

            command.CommandText = " SELECT d.ref_printers_type " +
                                    " FROM bills_info bi " +
                                    " INNER JOIN carte_dishes d ON d.id = bi.carte_dishes " +
                                    " WHERE bi.bills = @bills AND bi.ref_status = @refStatus " +
                                    " GROUP BY d.ref_printers_type";

            command.CommandType = CommandType.Text;

            command.Parameters.Clear();

            command.Parameters.Add("refStatus", SqlDbType.Int).Value = 23;
            command.Parameters.Add("bills", SqlDbType.Int).Value = pBill.id;

            using (SqlDataReader sdr = command.ExecuteReader()) //------------------------- типы принтеров
            {
                tPrintersType.Load(sdr);
            }

            command.Parameters.Clear();
            command.CommandText = " SELECT bi.id," +
                                            " d.name, " +
                                            " b.numb, " +
                                            " sum(bi.xcount) AS xcount,  " +
                                            " rp.name AS printerName,  " +
                                            " rn.note " +
                                    " FROM bills_info bi " +
                                    " INNER JOIN carte_dishes d ON d.id = bi.carte_dishes " +
                                    " INNER JOIN bills b ON b.id = bi.bills " +
                                    " LEFT JOIN unit u ON u.branch = b.branch AND u.ref_printers_type = d.ref_printers_type " +
                                    " LEFT JOIN ref_printers rp ON rp.id = u.ref_printers " +
                                    " LEFT JOIN ref_reports rr ON rr.ref_printers_type = d.ref_printers_type " +
                                    " LEFT JOIN ref_notes rn ON rn.id = bi.ref_notes AND rn.ref_notes_type = 2 " +
                                    " WHERE bi.bills = @bills AND bi.ref_status = @refStatus AND d.ref_printers_type = @printersType " +
                                    " GROUP BY bi.id, d.name, b.numb, rp.name, rn.note";

            command.Parameters.Add("refStatus", SqlDbType.Int);
            command.Parameters.Add("printersType", SqlDbType.Int);
            command.Parameters.Add("bills", SqlDbType.Int);

            foreach (DataRow dr in tPrintersType.Rows)
            {
                command.Parameters["refStatus"].Value = 23;
                command.Parameters["printersType"].Value = (int)dr["ref_printers_type"];
                command.Parameters["bills"].Value = pBill.id;

                dtResult = new DataTable();

                using (SqlDataReader sdr = command.ExecuteReader()) //------------------------- Блюда
                {
                    dtResult.Load(sdr);
                    dtResult.TableName = dr["ref_printers_type"].ToString();
                    dsResult.Tables.Add(dtResult);
                }
            }

            command.Parameters.Clear();
            command.CommandText = " SELECT bi.id AS billsInfo," +
                                            " cd.name " +
                                    " FROM bills_info_toppings bitop " +
                                    " INNER JOIN bills_info bi ON bi.id = bitop.bills_info " +
                                    " INNER JOIN toppings_carte_dishes tcd ON tcd.id = bitop.toppings_carte_dishes " +
                                    " INNER JOIN carte_dishes cd ON cd.id = tcd.carte_dishes " +
                                    " WHERE bi.bills = @bills AND bi.ref_status = @refStatus AND bitop.isSelected = 1 " +
                                    " ORDER BY bi.id ";

            command.Parameters.Add("refStatus", SqlDbType.Int).Value = 23;
            command.Parameters.Add("bills", SqlDbType.Int).Value = pBill.id;

            dtResult = new DataTable();

            using (SqlDataReader sdr = command.ExecuteReader()) //------------------------- Топпинги
            {
                dtResult.Load(sdr);
                dtResult.TableName = "toppings";
                dsResult.Tables.Add(dtResult);
            }

            return dsResult;
        }

        private int rawPrint(DataSet pDSResult, DTO_DBoard.Bill pBill, string uname)
        {
            string eCentre = string.Empty + (char)27 + (char)97 + '1';
            string eLeft = string.Empty + (char)27 + (char)97 + '0';
            string eRight = string.Empty + (char)27 + (char)97 + '2';
            string eCut = string.Empty + (char)27 + (char)105;
            string eItalicOn = string.Empty + (char)27 + (char)73 + '1';
            string eItalicOff = string.Empty + (char)27 + (char)73 + '0';
            string eClearBuffer = string.Empty + (char)27 + '@';

            int rHeight = 48;
            StringBuilder sb = new StringBuilder();
            int intTable;
            string sDish = string.Empty;
            string printerAddress = string.Empty;
            byte[] bText;
            string sText = String.Empty;

            foreach (DataTable dt in pDSResult.Tables)
            {
                if (!int.TryParse(dt.TableName, out intTable)) continue;    // Отсекаем таблцу топингов

                sb = new StringBuilder();

                sb.Append(eClearBuffer);

                sb.AppendLine(string.Format("Счет {0}", pBill.numb));
                sb.AppendLine(string.Format("Столик {0}", pBill.table).PadLeft(rHeight - string.Format("Счет {0}", pBill.numb).Length, ' '));
                sb.AppendLine(string.Format("{0} ({1})", uname, DateTime.Now));
                sb.AppendLine("-".PadRight(rHeight, '-'));

                foreach (DataRow dr in dt.Rows)
                {
                    sDish = dr["name"].ToString();
                    if (dr["note"] != DBNull.Value)
                    {
                        sDish += "(" + dr["note"].ToString() + ")";
                    }

                    sb.AppendLine(sDish);
                    sb.AppendLine(dr["xcount"].ToString().PadLeft(rHeight, ' '));
                    pDSResult.Tables["toppings"].DefaultView.RowFilter = string.Format("billsInfo = {0}", dr["id"]);
                    foreach (DataRow dr1 in pDSResult.Tables["toppings"].Rows)
                    {
                        sb.AppendLine(" * " + dr["name"].ToString().PadLeft(rHeight, ' '));
                    }
                    sb.AppendLine();
                    printerAddress = dr["printerName"].ToString();
                }
                sb.AppendLine("-".PadRight(rHeight, '-'));
                sb.AppendLine(" ");
                sb.AppendLine(" ");
                sb.AppendLine(eCut);

                bText = Encoding.GetEncoding(866).GetBytes(sb.ToString());
                sText = Encoding.GetEncoding(1251).GetString(bText);

                Suppurt.printServer_addWatingRecords(GValues.branchId, printerAddress, sText, 1, 1);
            }

            return sText.Length;
        }
    }
}
