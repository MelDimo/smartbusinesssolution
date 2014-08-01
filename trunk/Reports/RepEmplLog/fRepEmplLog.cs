using System;
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

namespace com.sbs.gui.report.repempllog
{
    public partial class fRepEmplLog : Form
    {
        getReference oReferences = new getReference();
        RepParam oRepParam = new RepParam();
        DBaccess dbAccess = new DBaccess();
        DataTable dtUserGroups;
        DataTable dtUsers;

        public fRepEmplLog()
        {
            InitializeComponent();

            initReferences();
        }

        private void initReferences()
        {
            try
            {
                dtUserGroups = oReferences.getAllUserGroups("offline");
            }
            catch (Exception exc) { uMessage.Show("Не удалось получить справочники.", exc, SystemIcons.Error); return; }

            dtUserGroups.Columns.Add("checked", typeof(bool));

            dtUserGroups.Select()
             .ToList<DataRow>()
             .ForEach(r =>
             {
                 r["checked"] = false;
             });
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

        private void button_getGroup_Click(object sender, EventArgs e)
        {
            fChooser fChose = new fChooser("USERGROUPS");

            fChose.dataGridView_main.DataSource = dtUserGroups;

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = "id";
            col0.Name = "id";
            col0.ReadOnly = true;
            col0.DataPropertyName = "id";
            col0.Visible = false;

            DataGridViewCheckBoxColumn col1 = new DataGridViewCheckBoxColumn();
            col1.HeaderText = "";
            col1.Name = "checked";
            col1.DataPropertyName = "checked";
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Наименование";
            col2.Name = "name";
            col2.DataPropertyName = "name";
            col2.ReadOnly = true;
            col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            fChose.dataGridView_main.Columns.AddRange(new DataGridViewColumn[] { col0, col1, col2 });

            fChose.Text = "Группы";
            if (fChose.ShowDialog() == DialogResult.OK)
            {
                oRepParam.checkedUsersGroup = (List<int>)fChose.xData[0];
                textBox_usersGroups.Text = fChose.xData[1].ToString();
            }
        }

        private void button_getEmpl_Click(object sender, EventArgs e)
        {
            try
            {
                dtUsers = dbAccess.getUsers("offline", oRepParam);
            }
            catch (Exception exc) { uMessage.Show("Не удалось получить список сотрудников.", exc, SystemIcons.Error); return; }

            dtUsers.Columns.Add("checked", typeof(bool));

            dtUsers.Select()
             .ToList<DataRow>()
             .ForEach(r =>
             {
                 r["checked"] = false;
             });

            fChooser fChose = new fChooser("USERS");

            fChose.dataGridView_main.DataSource = dtUsers;

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = "id";
            col0.Name = "id";
            col0.ReadOnly = true;
            col0.DataPropertyName = "id";
            col0.Visible = false;

            DataGridViewCheckBoxColumn col1 = new DataGridViewCheckBoxColumn();
            col1.HeaderText = "";
            col1.Name = "checked";
            col1.DataPropertyName = "checked";
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "ФИО";
            col2.Name = "fio";
            col2.DataPropertyName = "fio";
            col2.ReadOnly = true;
            col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            fChose.dataGridView_main.Columns.AddRange(new DataGridViewColumn[] { col0, col1, col2 });

            fChose.Text = "Сотрудники";
            if (fChose.ShowDialog() == DialogResult.OK)
            {
                oRepParam.checkedUsers = (List<int>)fChose.xData[0];
                textBox_users.Text = fChose.xData[1].ToString();
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
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

            pathForReport = Environment.CurrentDirectory + @"\reports\personnel\employeesLog.rpt";

            ReportDocument repDoc = new ReportDocument();
            repDoc.Load(pathForReport);
            repDoc.SetDataSource(dt);
            repDoc.SetParameterValue("xDateTime_start", dateTimePicker_start.Value.ToShortDateString());
            repDoc.SetParameterValue("xDateTime_end", dateTimePicker_end.Value.ToShortDateString());

            fViewer fviewer = new fViewer();
            fviewer.crystalReportViewer_main.ReportSource = repDoc;
            fviewer.crystalReportViewer_main.Refresh();
            fviewer.ShowDialog();
            repDoc.Close();

        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
