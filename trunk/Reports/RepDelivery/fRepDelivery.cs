using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;
using com.sbs.dll;
using CrystalDecisions.CrystalReports.Engine;

namespace com.sbs.gui.report.repdelivery
{
    public partial class fRepDelivery : Form
    {
        RepParam oRepParam = new RepParam();
        DBAccess dbAccess = new DBAccess();

        public fRepDelivery()
        {
            InitializeComponent();
        }

        private void button_getBranch_Click(object sender, EventArgs e)
        {
            fChooserUnitTree fOrgTree = new fChooserUnitTree();
            fOrgTree.checkLvl = "branch";
            fOrgTree.autoCheckChild = false;
            fOrgTree.Text = "Выбор заведения";
            fOrgTree.StartPosition = FormStartPosition.CenterParent;
            fOrgTree.ShowDialog();
            oRepParam.checkedBranch = fOrgTree.checkedBranch;
            textBox_branchsNames.Text = fOrgTree.checkedBranchName;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            oRepParam.dateStart = new DateTime(dateTimePicker_start.Value.Year, dateTimePicker_start.Value.Month, dateTimePicker_start.Value.Day,
                0, 0, 0);
            oRepParam.dateEnd = new DateTime(dateTimePicker_end.Value.Year, dateTimePicker_end.Value.Month, dateTimePicker_end.Value.Day,
                23, 59, 59);

            prepareReport();
        }

        private void prepareReport()
        {
            string pathForReport = string.Empty;
            DataTable dt = new DataTable();

            try
            {
                dt = dbAccess.prepareReport(GValues.DBMode, oRepParam);
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка при формировании отчета", exc, SystemIcons.Information);
                return;
            }

            pathForReport = Environment.CurrentDirectory + @"\reports\delivery.rpt";

            ReportDocument repDoc = new ReportDocument();
            repDoc.Load(pathForReport);
            repDoc.SetDataSource(dt);
            repDoc.SetParameterValue("dateStart", dateTimePicker_start.Value.ToShortDateString());
            repDoc.SetParameterValue("dateEnd", dateTimePicker_end.Value.ToShortDateString());

            fViewer fviewer = new fViewer();
            fviewer.crystalReportViewer_main.ReportSource = repDoc;
            fviewer.crystalReportViewer_main.Refresh();
            fviewer.ShowDialog();
            repDoc.Close();

        }
    }
}
