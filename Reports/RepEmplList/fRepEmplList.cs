﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;
using CrystalDecisions.CrystalReports.Engine;
using com.sbs.dll;

namespace com.sbs.gui.report.repempllist
{
    public partial class fRepEmplList : Form
    {
        getReference oReference = new getReference();
        DBaccess dbAccess = new DBaccess();

        RepParam oRepParam = new RepParam();
        List<int> checkedUnit = new List<int>();

        public fRepEmplList()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            prepareReport();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_selectedUnit_Click(object sender, EventArgs e)
        {
            fChooserUnitTree fOrgTree = new fChooserUnitTree();
            fOrgTree.autoCheckChild = true;
            fOrgTree.checkLvl = "unit";
            fOrgTree.Text = "Выбор подразделения";
            fOrgTree.StartPosition = FormStartPosition.CenterParent;
            fOrgTree.ShowDialog();
            oRepParam.checkedUnit = fOrgTree.checkedUnit;
            textBox_unitsNames.Text = fOrgTree.checkedUnitName;
        }

        private void prepareReport()
        {
            string pathForReport = string.Empty;
            DataTable dt = new DataTable();

            oRepParam.checkUvol = checkBox1.Checked ? 1 : 0;

            try
            {
                dt = dbAccess.prepareReport(GValues.DBMode, oRepParam);
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка при формировании отчета", exc, SystemIcons.Information);
                return;
            }

            pathForReport = Environment.CurrentDirectory + @"\reports\personnel\employeesList.rpt";

            ReportDocument repDoc = new ReportDocument();
            repDoc.Load(pathForReport);
            repDoc.SetDataSource(dt);
            repDoc.SetParameterValue("xDate", dateTimePicker_onDate.Value.ToShortDateString());

            fViewer fviewer = new fViewer();
            fviewer.crystalReportViewer_main.ReportSource = repDoc;
            fviewer.crystalReportViewer_main.Refresh();
            fviewer.ShowDialog();
            repDoc.Close();

        }
    }
}
