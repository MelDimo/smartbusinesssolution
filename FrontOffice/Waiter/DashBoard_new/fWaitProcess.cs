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

        public bool retflag = false;

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

            try
            {
                dtResult = dbAccess.billClose("offline", oBill);
            }
            catch (Exception exc) { uMessage.Show("Не удалось закрыть счет.", exc, SystemIcons.Information); return; }

            if (dtResult.Rows.Count == 0) return;

            repDoc = new ReportDocument();
            repDoc.Load(dtResult.Rows[0]["reportPath"].ToString());
            repDoc.SetDataSource(dtResult);
            repDoc.SetParameterValue("waiterName", DashboardEnvironment.gUser.name);
            repDoc.PrintOptions.PrinterName = dtResult.Rows[0]["printerName"].ToString();
            repDoc.PrintToPrinter(1, false, 0, 0);

            Close();
        }

        private void printDish()
        {
            DataTable dtResult = new DataTable();
            ReportDocument repDoc;

            try
            {
                dtResult = dbAccess.commitDish("offline", oBill);
            }
            catch (Exception exc) { uMessage.Show("Не удалось исключить необработанные позиции.", exc, SystemIcons.Information); return; }

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

                retflag = true;
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

                retflag = true;
            }
        }

        private void fWaitProcess_Shown(object sender, EventArgs e)
        {
            switch (type)
            {
                case "PRINTBILL":
                    label_actionName.Text = "Печать счета, подождите...";
                    printBill();
                    Close();
                    break;

                case "PRINTDISH":
                    label_actionName.Text = "Печать бегунка, подождите...";
                    printDish();
                    Close();
                    break;
            }
        }
    }
}
