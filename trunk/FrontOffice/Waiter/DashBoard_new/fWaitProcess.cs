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

        private ErrorInfo oError = new ErrorInfo();
        private DBaccess dbAccess = new DBaccess();
        private DTO_DBoard.Bill oBill;
        
        private string uname = DashboardEnvironment.gUser.name;
        RawPrinterHelper rawHelper = new RawPrinterHelper();

        private DataSet dsResult = new DataSet();

        private BackgroundWorker worThread;

        private string type;
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


                switch (GValues.isFiscal)
                {
                    case 1:
                        printBill_MiniFP6(dtOrder);
                        break;

                    default:
                        if (dtOrder.Rows.Count > 25) rawPrintBill(dtOrder);
                        else
                        {
                            printerName = GValues.billPrinter.Equals("default") ?
                                            (new System.Drawing.Printing.PrinterSettings()).PrinterName :
                                            dtOrder.Rows[0]["printerName"].ToString();

                            oError.msg = string.Format("reportPath: {0}; printerName: {1}", dtOrder.Rows[0]["reportPath"].ToString(), printerName);

                            repDoc = new ReportDocument();
                            repDoc.Load(dtOrder.Rows[0]["reportPath"].ToString());
                            repDoc.SetDataSource(dtOrder);
                            repDoc.PrintOptions.PrinterName = printerName;
                            repDoc.SetParameterValue("waiterName", uname);
                            for (int i = 0; i < GValues.branchBill; i++) repDoc.PrintToPrinter(0, false, 0, 0);
                            repDoc.Close();
                        }
                        break;
                }
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

        private void printBill_MiniFP6(DataTable dtOrder)
        {
            double totalSum = 0;
            bool retVal = false;

            MiniFP6 miniFP6 = new MiniFP6();

            foreach (DataRow dr in dtOrder.Rows)
            {
                retVal = miniFP6.Sale_(2, dr["carte_dishes"].ToString(), ((string)dr["name"]).Trim(), double.Parse(dr["xcount"].ToString()), double.Parse(dr["price"].ToString()), 6, true);
                if (!retVal)
                {
                    printBill_MiniFP6_Error();
                    return;
                }

                totalSum += double.Parse(dr["xcount"].ToString()) * double.Parse(dr["price"].ToString());
            }

            double xRemainder;

            if (totalSum <= 0)
            {
                printBill_MiniFP6_Error();
                return;
            }

            retVal = miniFP6.Pay_(2, totalSum, 3, true, out xRemainder);
            if (!retVal)
            {
                printBill_MiniFP6_Error();
                return;
            }
            for (int i = 1; i < GValues.branchBill; i++)
            {
                retVal = miniFP6.PrintCopy_(2);
                if (!retVal)
                {
                    printBill_MiniFP6_Error();
                    return;
                }
            }
        }

        private void printBill_MiniFP6_Error()
        {
            MiniFP6 miniFP6 = new MiniFP6();
            if (miniFP6.AnnulCheck_(2))
            {
                MessageBox.Show("Системе не удалось распечатать счет. Счет аннулирован в фискальном регистраторе.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                uMessage.Show("Системе не удалось распечатать счет. Счет не удалось аннулировть. " + Environment.NewLine +
                    "Проверьте соединения фискального регистратора и повторите попытку." + Environment.NewLine + Environment.NewLine +
                    "В случае повторного возникновения данного сообщения обратитесь к администратору.", SystemIcons.Information);
            }
            
            try
            {
                dbAccess.billCloseRollBack(GValues.DBMode, oBill);
            }
            catch (Exception exc)
            {
                uMessage.Show(string.Format("Не удалось откатить счет № {0}", oBill.numb), exc, SystemIcons.Information);
                return;
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
            sb.AppendLine(string.Format("Официант: {0}", uname));
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

            //RawPrinterHelper.SendStringToPrinter(printerAddress, sText);
            rawHelper.SendStringToPrinter(printerAddress, sText);
        }

        private void printDish()
        {
            if (GValues.printRunners == 0) return; 
            rawPrint(dsResult);
        }

        private void rawPrint(DataSet pDSResult)
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
            string sText;

            foreach (DataTable dt in pDSResult.Tables)
            {
                if (!int.TryParse(dt.TableName, out intTable)) continue;    // Отсекаем таблцу топингов

                sb = new StringBuilder();

                sb.Append(eClearBuffer);

                sb.AppendLine(string.Format("Счет {0}", oBill.numb));
                sb.AppendLine(string.Format("Столик {0}", oBill.table).PadLeft(rHeight - string.Format("Счет {0}", oBill.numb).Length, ' '));
                sb.AppendLine(string.Format("{0} ({1})", uname, DateTime.Now));
                sb.AppendLine("-".PadRight(rHeight, '-'));

                foreach (DataRow dr in dt.Rows)
                {
                    sDish = dr["name"].ToString();
                    if (dr["note"] != DBNull.Value){
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
                    Thread.Sleep(700);
                    pq.Refresh();
                }

                rawHelper.SendStringToPrinter(printerAddress, sText);
            }
        }

        private void fWaitProcess_Shown(object sender, EventArgs e)
        {
            worThread = new BackgroundWorker();
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
                WriteLog.write(string.Format("Не удалась печать бегунков.{0} \n StackTrace:{1}", exc.Message, exc.StackTrace));
                return;
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
