using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using com.sbs.dll;
using com.sbs.dll.utilites;

namespace com.sbs.gui.dashboard
{
    public partial class fWaitProcess : Form
    {
        class ErrorInfo
        {
            internal string msg = string.Empty;
        }

        ErrorInfo oError = new ErrorInfo();
        DBaccess dbAccess = new DBaccess();
        DTO_DBoard.Bill oBill;

        public string type;
        private bool fOk = false;

        public fWaitProcess(string pType, DTO_DBoard.Bill pCurBill)
        {
            oBill = pCurBill;
            type = pType;

            InitializeComponent();
        }

        private void printBill()
        {
            string printerName = string.Empty;
            DataTable dtResult = new DataTable();
            ReportDocument repDoc;

            if (oBill == null) { return; }

            dtResult = dbAccess.billClose(GValues.DBMode, oBill);

            if (dtResult.Rows.Count == 0) return;

            printerName = GValues.billPrinter.Equals("default") ? 
                                            (new System.Drawing.Printing.PrinterSettings()).PrinterName : 
                                            dtResult.Rows[0]["printerName"].ToString();

            oError.msg = string.Format("reportPath: {0}; printerName: {1}", dtResult.Rows[0]["reportPath"].ToString(), printerName);

            repDoc = new ReportDocument();
            repDoc.Load(dtResult.Rows[0]["reportPath"].ToString());
            repDoc.SetDataSource(dtResult);
            repDoc.SetParameterValue("waiterName", DashboardEnvironment.gUser.name);
            repDoc.PrintOptions.PrinterName = GValues.billPrinter.Equals("default") ? 
                                            (new System.Drawing.Printing.PrinterSettings()).PrinterName : 
                                            dtResult.Rows[0]["printerName"].ToString();
            
            for (int i = 0; i < GValues.branchBill; i++ ) repDoc.PrintToPrinter(1, false, 0, 0);
            repDoc.Close();
        }

        private void printDish()
        {
            DataSet dsResult = new DataSet();
            ReportDocument repDoc;

            dsResult = dbAccess.commitDish(GValues.DBMode, oBill);

            rawPrint(dsResult);
            return;

            foreach (DataRow dr in DashboardEnvironment.dtRefPrintersType.Rows)
            {
                var results = from myRow in dsResult.Tables["preorder"].AsEnumerable()
                                where myRow.Field<int>("ref_printers_type") == (int)dr["id"]// && myRow.Field<int>("ref_status") == 23
                                select myRow;

                if (results.Count() > 0)
                {
                    oError = new ErrorInfo();
                    oError.msg = string.Format("reportPath: {0}; printerName: {1}", results.First().Field<string>("reportPath"), results.First().Field<string>("printerName"));

                    repDoc = new ReportDocument();
                    repDoc.Load(results.First().Field<string>("reportPath"));
                    repDoc.SetDataSource(dsResult);// dsResult.Tables["preorder"]);
                    repDoc.SetParameterValue("waiterName", DashboardEnvironment.gUser.name);
                    repDoc.SetParameterValue("curDate", DateTime.Now);
                    repDoc.SetParameterValue("billNumber", oBill.numb);
                    repDoc.SetParameterValue("tableNumb", oBill.table);
                    repDoc.SetParameterValue("printersType", (int)dr["id"]);
                    repDoc.PrintOptions.PrinterName = results.First().Field<string>("printerName");
                    repDoc.PrintToPrinter(1, false, 0, 0);
                    repDoc.Close();
                }
            }
        }

        private void rawPrint(DataSet pDSResult)
        {
            string eCentre = string.Empty + (char)27 + (char)97 + "1";
            string eLeft = string.Empty + (char)27 + (char)97 + "0";
            string eRight = string.Empty + (char)27 + (char)97 + "2";
            string eCut = string.Empty + (char)27 + (char)105;
            string eItalicOn = string.Empty + (char)27 + (char)73 + "1";
            string eItalicOff = string.Empty + (char)27 + (char)73 + "0";

            int rHeight = 50;
            StringBuilder sb = new StringBuilder();
            int intTable;
            string sDish = string.Empty;
            string printerAddress = string.Empty;
            byte[] bText;
            string sText;

            foreach (DataTable dt in pDSResult.Tables)
            {
                if (!int.TryParse(dt.TableName, out intTable)) continue;    // Отсекаем таблцу топингов

                sb = new StringBuilder();

                sb.Append(string.Format("Счет {0}", oBill.numb));
                sb.AppendLine(string.Format("Столик {0}", oBill.table).PadLeft(rHeight - string.Format("Счет {0}", oBill.numb).Length, ' '));
                sb.AppendLine(string.Format("{0} ({1})", DashboardEnvironment.gUser.name, DateTime.Now));
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
                sb.AppendLine();
                sb.AppendLine();
                sb.AppendLine(eCut);

                bText = Encoding.GetEncoding(866).GetBytes(sb.ToString());
                sText = Encoding.GetEncoding(1251).GetString(bText);

                RawPrinterHelper.SendStringToPrinter(printerAddress, sText);
            }
        }

        private void fWaitProcess_Shown(object sender, EventArgs e)
        {
            BackgroundWorker worThread = new BackgroundWorker();
            worThread.RunWorkerCompleted += new RunWorkerCompletedEventHandler(runWorkerCompleted);

            switch (type)
            {
                case "PRINTBILL":
                    label_actionName.Text = "Печать счета, подождите...";
                    worThread.DoWork += new DoWorkEventHandler(printBill_DoWork);
                    break;

                case "PRINTDISH":
                    label_actionName.Text = "Печать бегунка, подождите...";
                    worThread.DoWork += new DoWorkEventHandler(printDish_DoWork);
                    break;
            }

            worThread.RunWorkerAsync();
        }

        void printBill_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                printBill();
                fOk = true;
            }
            catch (Exception exc) {
                uMessage.Show(string.Format("Не удалась печать счета.{0}", oError.msg), exc, SystemIcons.Information); DialogResult = DialogResult.Cancel;
            }
        }

        void printDish_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                printDish();
                fOk = true;
            }
            catch (Exception exc) { uMessage.Show(string.Format("Не удалась печать бегунков.{0}", oError.msg), exc, SystemIcons.Information); DialogResult = DialogResult.Cancel; }
        }

        void runWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (fOk) DialogResult = DialogResult.OK;
            else DialogResult = DialogResult.Cancel;
        }
    }
}
