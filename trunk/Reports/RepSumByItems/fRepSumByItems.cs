using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;
using com.sbs.gui.report.repsumbyitems;
using com.sbs.dll;
using CrystalDecisions.CrystalReports.Engine;

namespace com.sbs.gui.report.repsumbyitems
{
    public partial class fRepSumByItems : Form
    {
        DBaccess dbAccess = new DBaccess();
        Filter oFilter = new Filter();

        public fRepSumByItems()
        {
            InitializeComponent();
        }

        private void fRepSumByItems_Shown(object sender, EventArgs e)
        {
            dateTimePicker_timeStart.Value = new DateTime(1999, 1, 1, 0, 0, 0);
            dateTimePicker_timeEnd.Value = new DateTime(1999, 1, 1, 23, 59, 59);
        }

        private void button_branch_Click(object sender, EventArgs e)
        {
            fChooserUnitTree fCut = new fChooserUnitTree();
            fCut.checkLvl = "branch";
            fCut.ShowDialog();

            textBox_branch.Text = fCut.checkedBranchName;
            oFilter.lBranch = fCut.checkedBranch;
        }

        private void button_paymentType_Click(object sender, EventArgs e)
        {
            fChooserPaymentType fCpt = new fChooserPaymentType(oFilter.lPaymentType);
            fCpt.ShowDialog();

            textBox_paymentType.Text = fCpt.choosenName;
            oFilter.lPaymentType = fCpt.isChoosen;
        }

        private void button_items_Click(object sender, EventArgs e)
        {
            fChooserItems fItems = new fChooserItems(oFilter.lItems);
            fItems.ShowDialog();

            textBox_items.Text = fItems.choosenName;
            oFilter.lItems = fItems.isChoosen;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            string errMsg = "Заполнены не все обязательные поля:";

            oFilter.dateStart = new DateTime(dateTimePicker_dateStart.Value.Year, dateTimePicker_dateStart.Value.Month, dateTimePicker_dateStart.Value.Day,
                                             dateTimePicker_timeStart.Value.Hour, dateTimePicker_timeStart.Value.Minute, dateTimePicker_timeStart.Value.Second);
            oFilter.dateEnd = new DateTime(dateTimePicker_dateEnd.Value.Year, dateTimePicker_dateEnd.Value.Month, dateTimePicker_dateEnd.Value.Day,
                                             dateTimePicker_dateEnd.Value.Hour, dateTimePicker_dateEnd.Value.Minute, dateTimePicker_dateEnd.Value.Second);

            if (oFilter.lBranch.Count == 0) { errMsg += Environment.NewLine + "- Заведения;"; }
            if (oFilter.lPaymentType.Count == 0) { errMsg += Environment.NewLine + "- Типы оплаты;"; }

            if (!errMsg.Equals("Заполнены не все обязательные поля:"))
            {
                MessageBox.Show(errMsg, GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            showReport();
        }

        private void showReport()
        {
            string pathForReport = string.Empty;
            DataTable dt = new DataTable();

            try
            {
                dt = dbAccess.prepareReport(GValues.DBMode, oFilter);
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка при формировании отчета", exc, SystemIcons.Information);
                return;
            }

            pathForReport = Environment.CurrentDirectory + @"\reports\byItemSum.rpt";

            ReportDocument repDoc = new ReportDocument();
            repDoc.Load(pathForReport);
            repDoc.SetDataSource(dt);
            repDoc.SetParameterValue("dateStart", oFilter.dateStart.ToString());
            repDoc.SetParameterValue("dateEnd", oFilter.dateEnd.ToString());

            fViewer fviewer = new fViewer();
            fviewer.crystalReportViewer_main.ReportSource = repDoc;
            fviewer.crystalReportViewer_main.Refresh();
#if DEBUG
            fviewer.ShowDialog();
            repDoc.Close();
#else
            fviewer.TopLevel = true;
            fviewer.Show(this);
            repDoc.Close();
#endif
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
