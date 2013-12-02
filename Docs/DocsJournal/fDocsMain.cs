using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;
using com.sbs.gui.docsform;
using com.sbs.dll.docsaction;
using com.sbs.dll;

namespace com.sbs.gui.docsjournal
{
    public partial class fDocsMain : Form
    {
        List<string> OwnType = new List<string> { "Я создал", "Я участник", "Чужой" };

        getReference oReferences = new getReference();
        DBAccess dbAccess = new DBAccess();

        Packages oPack;

        DataTable dtPackType;
        DataTable dtRefStatus;

        public fDocsMain()
        {
            InitializeComponent();

            dataGridView_main.AutoGenerateColumns = false;

            button_filter.BackgroundImage = com.sbs.dll.utilites.Properties.Resources.filter_26;

            comboBox_own.SelectedIndex = 0;
        }

        private void updateData(Filter pFilter)
        {
            DataTable dtResult;
            try
            {
                dtResult = dbAccess.getFilteredData("offline", pFilter);
            }
            catch (Exception exc)
            {
                uMessage.Show("Не удалось получить данные по фильтру", exc, SystemIcons.Information);
                //setEnabled(false);
                return;
            }

            dataGridView_main.DataSource = dtResult;
            dataGridView_main.Columns["id"].DataPropertyName = "id";
            dataGridView_main.Columns["packages_type"].DataPropertyName = "packages_type";
            dataGridView_main.Columns["packages_typeName"].DataPropertyName = "packages_typeName";
            dataGridView_main.Columns["ref_status"].DataPropertyName = "ref_status";
            dataGridView_main.Columns["ref_statusName"].DataPropertyName = "ref_statusName";
            dataGridView_main.Columns["date_create"].DataPropertyName = "date_create";
        }

        private void fDocsMain_Shown(object sender, EventArgs e)
        {
            try
            {
                getReferences();
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных", exc, SystemIcons.Error);
                setEnabled(false);
                return;
            }

            CreateMnu();
        }

        private void CreateMnu()
        {
            foreach (DataRow dr in dtPackType.Rows)
            {
                //id, name
                ToolStripItem tsmi = new ToolStripMenuItem();
                tsmi.Name = dr["id"].ToString();
                tsmi.Text = dr["name"].ToString();
                tsmi.Click += new EventHandler(tsmi_Click);
                tSMenuItem_create.DropDownItems.Add(tsmi);
            }

            comboBox_docsType.DataSource = dtPackType;
            comboBox_docsType.DisplayMember = "name";
            comboBox_docsType.ValueMember = "id";

            comboBox_status.DataSource = dtRefStatus;
            comboBox_status.DisplayMember = "name";
            comboBox_status.ValueMember = "id";

            comboBox_own.DataSource = OwnType;
        }

        void tsmi_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            
            switch (tsmi.Name)
            {
                case "1":         // Приход ТМЦ (пакет)
                    oPack = new Packages();
                    oPack.packages_type = 1;
                    
                    break;
            }
        }

        private void setEnabled(bool pEnabled)
        {
            dataGridView_main.Enabled = pEnabled;
            statusStrip_info.Enabled = pEnabled;
            groupBox_filter.Enabled = pEnabled;
            menuStrip_filter.Enabled = pEnabled;
        }

        private void getReferences()
        {
            try
            {
                dtPackType = oReferences.getPackageType("offline");
                dtRefStatus = oReferences.getStatus("offline", 6);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private void button_filter_Click(object sender, EventArgs e)
        {
            Filter oFilter = new Filter();
            oFilter.packType = (int)comboBox_docsType.SelectedValue;
            oFilter.packNumber = textBox_docsNumber.Text.Trim();
            oFilter.packDate = dateTimePicker_dateCreate.Value;
            oFilter.packStatus = (int)comboBox_status.SelectedValue;
            oFilter.packOwn = (int)comboBox_own.SelectedIndex;

            updateData(oFilter);
        }

        private void dataGridView_main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_main.SelectedRows.Count == 0) return;

            DataGridViewRow dr = dataGridView_main.SelectedRows[0];
            oPack = new Packages();
            oPack.id = (int)dr.Cells["id"].Value;
            oPack.packages_type = (int)dr.Cells["packages_type"].Value;
            oPack.ref_status = (int)dr.Cells["ref_status"].Value;
            oPack.user_create = UsersInfo.UserId;
            oPack.date_create = (DateTime)dr.Cells["date_create"].Value;
            showPackage(oPack);
        }

        private void showPackage(Packages pPackage)
        {
            switch (pPackage.packages_type)
            { 
                case 1:
                    fSupplyTMC fsTMC = new fSupplyTMC(oPack);
                    fsTMC.ShowDialog();
                    break;

            }
        }
    }

    class Filter
    {
        public int packType { get; set; }
        public string packNumber { get; set; }
        public DateTime packDate { get; set; }
        public int packStatus { get; set; }
        public int packOwn { get; set; }
    }
}
