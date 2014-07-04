using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using com.sbs.dll.utilites;
using com.sbs.dll;

namespace com.sbs.gui.report.repchecktape
{
    public partial class fRepCheckTape : Form
    {
        private DBaccess dbAccess = new DBaccess();
        private RepParam oRepParam = new RepParam();

        public fRepCheckTape()
        {
            InitializeComponent();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (oRepParam.branch == 0)
            {
                MessageBox.Show("Укажите заведение.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            oRepParam.dateStart = DateTime.Parse(dateTimePicker_dateStart.Value.ToShortDateString());
            oRepParam.dateEnd = DateTime.Parse(dateTimePicker_dateEnd.Value.ToShortDateString());
            oRepParam.dateEnd = oRepParam.dateEnd.AddHours(23).AddMinutes(59).AddSeconds(59);

            prepareReport();
        }

        private void prepareReport()
        {
            string pathForReport = string.Empty;
            DataTable dt = new DataTable();

            try
            {
                dt = dbAccess.REP_CheckType(GValues.DBMode, oRepParam);
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка при формировании отчета", exc, SystemIcons.Information);
                return;
            }

            pathForReport = Environment.CurrentDirectory + @"\reports\checkTape.rpt";

            ReportDocument repDoc = new ReportDocument();
            repDoc.Load(pathForReport);
            repDoc.SetDataSource(dt);
            repDoc.SetParameterValue("pDateStart", oRepParam.dateStart);
            repDoc.SetParameterValue("pDateEnd", oRepParam.dateEnd);

            fViewer fviewer = new fViewer();
            fviewer.crystalReportViewer_main.ReportSource = repDoc;
            fviewer.crystalReportViewer_main.Refresh();
            fviewer.ShowDialog();
        }

        private void button_branch_Click(object sender, EventArgs e)
        {
            fChooserUnit fChooseBranch = new fChooserUnit(0, 2);
            if (fChooseBranch.ShowDialog() != DialogResult.OK) return;

            oRepParam.branch = fChooseBranch.selectedId;
            textBox_branchsNames.Text = fChooseBranch.selectedName;
        }
    }
}
