﻿using System;
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
        DBaccess.Role curRole;

        private DBaccess dbAccess = new DBaccess();
        private RepParam oRepParam = new RepParam();

        Suppurt Supp = new Suppurt();

        public fRepCheckTape()
        {
            InitializeComponent();

            curRole = getRole();

            if (curRole == DBaccess.Role.NONE)
            {
                MessageBox.Show("У декущего пользователя неустановлены привелегии для работы в данном модуле",
                                GValues.prgNameFull,
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                setEnabled(false);
                return;
            }
        }

        private void setEnabled(bool pEnabled)
        {
            foreach (Control ctr in this.Controls) ctr.Enabled = pEnabled;
        }

        private DBaccess.Role getRole()
        {
            if (Supp.checkPrivileges(UsersInfo.Acl, 26)) return DBaccess.Role.BACKOFFICE;   // Просмотр чековой ленты ЛЮБОГО заведения
            if (Supp.checkPrivileges(UsersInfo.Acl, 24)) return DBaccess.Role.FRONTOFFICE;  // Просмотр чековой ленты СВОЕГО заведения
            return DBaccess.Role.NONE;
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

            repDoc.Close();
        }

        private void button_branch_Click(object sender, EventArgs e)
        {
            fChooserUnit fChooseBranch = new fChooserUnit(0, 2);
            if (fChooseBranch.ShowDialog() != DialogResult.OK) return;

            oRepParam.branch = fChooseBranch.selectedId;
            textBox_branchsNames.Text = fChooseBranch.selectedName;
        }

        private void fRepCheckTape_Shown(object sender, EventArgs e)
        {
            if (curRole == DBaccess.Role.FRONTOFFICE)
            {
                button_branch.Enabled = false;
                oRepParam.branch = GValues.branchId;
                textBox_branchsNames.Text = GValues.branchName;
            }
        }

        private void button_paymentType_Click(object sender, EventArgs e)
        {
            fChooserPaymentType fCpt = new fChooserPaymentType(oRepParam.lPaymentType);
            if (fCpt.ShowDialog() == DialogResult.OK)
            {
                textBox_paymentType.Text = fCpt.choosenName;
                oRepParam.lPaymentType = fCpt.isChoosen;
            }
        }
    }
}
