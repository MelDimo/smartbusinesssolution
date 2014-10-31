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
using System.Threading;
using System.Diagnostics;
using System.Printing;

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
        DataSet dsResult = new DataSet();

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
            DataSet dsResult = new DataSet();
            DataTable dtOrder = new DataTable();
            DataTable dtDeliveryOrder = new DataTable();
            ReportDocument repDoc;

            if (oBill == null) { return; }

            dsResult = dbAccess.billClose(GValues.DBMode, oBill);

            if (dsResult.Tables["order"].Rows.Count > 0)
            {

                dtOrder = dsResult.Tables["order"];

                printerName = GValues.billPrinter.Equals("default") ?
                                                (new System.Drawing.Printing.PrinterSettings()).PrinterName :
                                                dtOrder.Rows[0]["printerName"].ToString();

                oError.msg = string.Format("reportPath: {0}; printerName: {1}", dtOrder.Rows[0]["reportPath"].ToString(), printerName);

                repDoc = new ReportDocument();
                repDoc.Load(dtOrder.Rows[0]["reportPath"].ToString());
                repDoc.SetDataSource(dtOrder);
                repDoc.SetParameterValue("waiterName", DashboardEnvironment.gUser.name);
                repDoc.PrintOptions.PrinterName = GValues.billPrinter.Equals("default") ?
                                                (new System.Drawing.Printing.PrinterSettings()).PrinterName :
                                                dtOrder.Rows[0]["printerName"].ToString();

                for (int i = 0; i < GValues.branchBill; i++)
                    if (dtOrder.Rows.Count > 25) rawPrintBill(dtOrder);
                    else repDoc.PrintToPrinter(0, false, 0, 0);

                repDoc.Close();
            }

            if (dsResult.Tables["deliveryOrder"].Rows.Count > 0)
            {
                dtDeliveryOrder = dsResult.Tables["deliveryOrder"];

                printerName = GValues.billPrinter.Equals("default") ?
                                                (new System.Drawing.Printing.PrinterSettings()).PrinterName :
                                                dtDeliveryOrder.Rows[0]["printerName"].ToString();

                oError.msg = string.Format("reportPath: {0}; printerName: {1}", dtDeliveryOrder.Rows[0]["reportPath"].ToString(), printerName);

                repDoc = new ReportDocument();
                repDoc.Load(dtDeliveryOrder.Rows[0]["reportPath"].ToString());
                repDoc.SetDataSource(dtDeliveryOrder);
                repDoc.SetParameterValue("billNumber", oBill.numb);
                repDoc.SetParameterValue("billDateTime", DateTime.Now.ToString());
                repDoc.PrintOptions.PrinterName = GValues.billPrinter.Equals("default") ?
                                                (new System.Drawing.Printing.PrinterSettings()).PrinterName :
                                                dtDeliveryOrder.Rows[0]["printerName"].ToString();

                for (int i = 0; i < GValues.branchBill; i++) repDoc.PrintToPrinter(1, false, 0, 0);
                repDoc.Close();
            }
        }

        private void rawPrintBill(DataTable dtOrder)
        {
            string eCentre = string.Empty + (char)27 + (char)97 + "1";
            string eLeft = string.Empty + (char)27 + (char)97 + "0";
            string eRight = string.Empty + (char)27 + (char)97 + "2";
            string eCut = string.Empty + (char)27 + (char)105;
            string eItalicOn = string.Empty + (char)27 + (char)73 + "1";
            string eItalicOff = string.Empty + (char)27 + (char)73 + "0";

            int rHeight = 48;
            StringBuilder sb = new StringBuilder();
            decimal totalSum = 0;
            string sDish = string.Empty;
            string printerAddress = string.Empty;
            byte[] bText;
            string sText;

            sb = new StringBuilder();

            sb.AppendLine("-".PadRight(rHeight, '-'));
            sb.AppendLine("Счет на оплату");
            sb.AppendLine("-".PadRight(rHeight, '-'));
            sb.AppendLine(string.Format("Официант: {0}", DashboardEnvironment.gUser.name));
            sb.AppendLine("-".PadRight(rHeight, '-'));

            foreach (DataRow dr in dtOrder.Rows)
            {
                sb.AppendLine(((string)dr["name"]).Trim());
                sb.AppendLine(string.Format("{0} x {1}", dr["xcount"], dr["price"]).PadLeft(rHeight, ' '));

                totalSum += decimal.Parse(dr["xcount"].ToString()) * decimal.Parse(dr["price"].ToString());

                printerAddress = dr["printerName"].ToString();
            }

            sb.AppendLine("-".PadRight(rHeight, '-'));
            sb.AppendLine(string.Format("Итого: {0}", totalSum).PadLeft(rHeight, ' '));

            sb.AppendLine(eCut);

            bText = Encoding.GetEncoding(866).GetBytes(sb.ToString());
            sText = Encoding.GetEncoding(1251).GetString(bText);

            RawPrinterHelper.SendStringToPrinter(printerAddress, sText);
        }

        private void printDish()
        {
            if (GValues.printRunners == 0) return; 
            rawPrint(dsResult);
        }

        private void rawPrint(DataSet pDSResult)
        {
            string eCentre = string.Empty + (char)27 + (char)97 + "1";
            string eLeft = string.Empty + (char)27 + (char)97 + "0";
            string eRight = string.Empty + (char)27 + (char)97 + "2";
            string eCut = string.Empty + (char)27 + (char)105;
            string eItalicOn = string.Empty + (char)27 + (char)73 + "1";
            string eItalicOff = string.Empty + (char)27 + (char)73 + "0";

            int rHeight = 48;
            StringBuilder sb = new StringBuilder();
            int intTable;
            string sDish = string.Empty;
            string printerAddress = string.Empty;
            byte[] bText;
            string sText;

            int xCount = 10; // число попыток печати;

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
                sb.AppendLine(" ");
                sb.AppendLine(" ");
                sb.AppendLine(eCut);

                bText = Encoding.GetEncoding(866).GetBytes(sb.ToString());
                sText = Encoding.GetEncoding(1251).GetString(bText);


                PrintServer myPrintServer = new PrintServer(@"\\" + printerAddress.Split('\\')[2]);
                PrintQueue pq = new PrintQueue(myPrintServer, printerAddress.Split('\\')[3]);
                while (pq.IsBusy)
                {
                    Thread.Sleep(500);
                    pq.Refresh();
                    xCount = xCount - 1;
                }

                if (xCount != 0) RawPrinterHelper.SendStringToPrinter(printerAddress, sText);

                #region Проверка печати
                //while (true) //Проверяем как завершилась печать. Если ошибочно повторям xCount раз.
                //{
                //    if ((RawPrinterHelper.dwError != 0 || RawPrinterHelper.dwWritten == 0) && xCount > 0)
                //    {
                //        Thread.Sleep(500);
                //        RawPrinterHelper.SendStringToPrinter(printerAddress, sText);
                //        xCount = xCount - 1;
                //    }
                //    else
                //    {
                //        if (xCount == 0) // так и не удалось распечатать 
                //        {
                //            WriteLog.write(string.Format("RawPrinterHelper.dwError: {0}" + Environment.NewLine +
                //                                            "RawPrinterHelper.dwWritten: {1}" + Environment.NewLine +
                //                                            "xCount: {2} ", RawPrinterHelper.dwError, RawPrinterHelper.dwWritten, xCount));
                //        }
                //        break;
                //    }
                //}
                #endregion

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

                    dsResult = dbAccess.commitDish(GValues.DBMode, oBill);

                    worThread.DoWork += new DoWorkEventHandler(printDish_DoWork);
                    break;
            }

            worThread.RunWorkerAsync();

            if ("PRINTDISH".Equals(type))
                DialogResult = DialogResult.OK; // не ожидаем печати бегунка
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
            catch (Exception exc) 
            {
                return;
                // Не ожидаем печети бегунка
                //uMessage.Show(string.Format("Не удалась печать бегунков.{0}", oError.msg), exc, SystemIcons.Information); DialogResult = DialogResult.Cancel; 
            }
        }

        void runWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            switch (type)
            {
                case "PRINTBILL":
                    if (fOk) DialogResult = DialogResult.OK;
                    else DialogResult = DialogResult.Cancel;
                    break;

                case "PRINTDISH":
                    break;
            }

            // Не ожидаем печети бегунка
            //if (fOk) DialogResult = DialogResult.OK;
            //else DialogResult = DialogResult.Cancel;
        }
    }
}
