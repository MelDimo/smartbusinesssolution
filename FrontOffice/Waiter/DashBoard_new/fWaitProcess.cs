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
        DBaccess dbAccess = new DBaccess();
        DTO_DBoard.Bill oBill;

        public string type;

        public fWaitProcess(string pType, DTO_DBoard.Bill pCurBill)
        {
            oBill = pCurBill;
            type = pType;

            InitializeComponent();
        }

        private void printBill()
        {
            DataTable dtResult = new DataTable();
            ReportDocument repDoc;

            if (oBill == null) { return; }
            
            dtResult = dbAccess.billClose("offline", oBill);

            if (dtResult.Rows.Count == 0) return;

            repDoc = new ReportDocument();
            repDoc.Load(dtResult.Rows[0]["reportPath"].ToString());
            repDoc.SetDataSource(dtResult);
            repDoc.SetParameterValue("waiterName", DashboardEnvironment.gUser.name);
            repDoc.PrintOptions.PrinterName = dtResult.Rows[0]["printerName"].ToString();
            repDoc.PrintToPrinter(1, false, 0, 0);
        }

        private void printDish()
        {
            DataTable dtResult = new DataTable();
            ReportDocument repDoc;

            dtResult = dbAccess.commitDish("offline", oBill);

            var results_1 = from myRow in dtResult.AsEnumerable()
                            where myRow.Field<int>("ref_printers_type") == 1 && myRow.Field<int>("ref_status") != 23
                            select myRow;
            if (results_1.Count() > 0) // есть позиции на принтер Кухни
            {
                repDoc = new ReportDocument();
                repDoc.Load(results_1.First().Field<string>("reportPath"));
                repDoc.SetDataSource(dtResult);
                repDoc.SetParameterValue("waiterName", DashboardEnvironment.gUser.name);
                repDoc.SetParameterValue("curDate", DateTime.Now);
                repDoc.SetParameterValue("billNumber", oBill.numb);
                repDoc.SetParameterValue("printersType", 1);
                repDoc.PrintOptions.PrinterName = results_1.First().Field<string>("printerName");
                repDoc.PrintToPrinter(1, false, 0, 0);

                MessageBox.Show("есть позиции на принтер Кухни;" + Environment.NewLine
                    + repDoc.PrintOptions.PrinterName);
            }

            var results_2 = from myRow in dtResult.AsEnumerable()
                            where myRow.Field<int>("ref_printers_type") == 2 && myRow.Field<int>("ref_status") != 23
                            select myRow;

            if (results_2.Count() > 0) // есть позиции на принтер Бара
            {
                repDoc = new ReportDocument();
                repDoc.Load(results_2.First().Field<string>("reportPath"));
                repDoc.SetDataSource(dtResult);
                repDoc.SetParameterValue("waiterName", DashboardEnvironment.gUser.name);
                repDoc.SetParameterValue("curDate", DateTime.Now);
                repDoc.SetParameterValue("billNumber", oBill.numb);
                repDoc.SetParameterValue("printersType", 2);
                repDoc.PrintOptions.PrinterName = results_2.First().Field<string>("printerName");
                repDoc.PrintToPrinter(1, false, 0, 0);

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
            }
            catch (Exception exc) { uMessage.Show("Не удалось закрыть счет.", exc, SystemIcons.Information); return; }
        }

        void printDish_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                printDish();
            }
            catch (Exception exc) { uMessage.Show("Не удалась печать бегунков.", exc, SystemIcons.Information); return; }
        }

        void runWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Close();
        }
    }
}
