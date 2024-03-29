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
using com.sbs.gui.report.reptimesheets.Properties;
using com.sbs.dll;

namespace com.sbs.gui.report.reptimesheets
{
    public partial class fRepTimesheets : Form
    {
        getReference oReferences = new getReference();
        RepParam oRepParam = new RepParam();
        DBaccess dbAccess = new DBaccess();
        DataTable dtUserGroups;
        DataTable dtUsers;

        public fRepTimesheets()
        {
            InitializeComponent();

            initReferences();

            comboBox_season.SelectedIndex = 0;
            comboBox_week.SelectedIndex = 0;
        }

        private void initReferences()
        {
            try
            {
                dtUserGroups = oReferences.getAllUserGroups(GValues.DBMode);
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
            fChooserUnit fChooseBranch = new fChooserUnit(0, 2);
            if (fChooseBranch.ShowDialog() != DialogResult.OK) return;

            oRepParam.xBranch = fChooseBranch.selectedId;
            textBox_branchsNames.Text = fChooseBranch.selectedName;
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
                dtUsers = dbAccess.getUsers(GValues.DBMode, oRepParam);
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
            int xSeason = int.Parse(comboBox_season.SelectedItem.ToString());
            int xWeak = int.Parse(comboBox_week.SelectedItem.ToString());
            int xCurSeason = xSeason;
            int xCurWeak = xWeak;
            string arrSeason = string.Empty;

            string pathForReport = string.Empty;
            DataTable dt = new DataTable();

            oRepParam.xYear = dateTimePicker_year.Value.Year;
            oRepParam.xMonth = dateTimePicker_month.Value.Month;
            oRepParam.xDayStart = dateTimePicker_dayStart.Value.Day;
            oRepParam.xDayEnd = dateTimePicker_dayEnd.Value.Day;
            
            try
            {
                dt = dbAccess.prepareReport(GValues.DBMode, oRepParam);
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка при формировании отчета", exc, SystemIcons.Information);
                return;
            }

            pathForReport = Environment.CurrentDirectory + @"\reports\personnel\timesheets.rpt";

            for (int i = 1; i <= 31; i++)
            {
                if (xCurSeason == 1) arrSeason += string.Format("{0},", i);

                if (xCurWeak + 1 > 2)
                {
                    xCurWeak = 1;
                    if (xCurSeason + 1 > 2)
                    {
                        xCurSeason = 1;
                    }
                    else
                    {
                        xCurSeason = xCurSeason + 1;
                    }
                }
                else
                {
                    xCurWeak = xCurWeak + 1;
                }
            }

            arrSeason = arrSeason.TrimEnd(',');

            ReportDocument repDoc = new ReportDocument();
            repDoc.Load(pathForReport);
            repDoc.SetDataSource(dt);
            repDoc.SetParameterValue("pBranchName", textBox_branchsNames.Text);
            repDoc.SetParameterValue("xDateTime_start", oRepParam.xDayStart.ToString().PadLeft(2, '0') + "." + oRepParam.xMonth.ToString().PadLeft(2, '0') + "." + oRepParam.xYear.ToString());
            repDoc.SetParameterValue("xDateTime_end",oRepParam.xDayEnd.ToString().PadLeft(2, '0') + "." + oRepParam.xMonth.ToString().PadLeft(2, '0') + "." + oRepParam.xYear.ToString());
            repDoc.SetParameterValue("arrSeason", arrSeason);

            for(int i = 1; i <= 31; i = i+ 2)
            {
                xSeason = xSeason + i;
                xSeason = xSeason + i+1;
            }



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

        private void fRepTimesheets_Load(object sender, EventArgs e)
        {
            Settings set = new Settings();
            this.Size = set.formSize;
            this.Location = set.formLocation;
            this.WindowState = set.formState;
        }

        private void fRepTimesheets_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings set = new Settings();
            set.formSize = this.Size;
            set.formLocation = this.Location;
            set.formState = this.WindowState;
            set.Save();
        }

        private void dateTimePicker_month_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker_dayEnd.Value = new DateTime(dateTimePicker_month.Value.Year,
                                                            dateTimePicker_month.Value.Month,
                        DateTime.DaysInMonth(dateTimePicker_month.Value.Year, dateTimePicker_month.Value.Month));
        }
    }
}
