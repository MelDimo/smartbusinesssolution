using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace com.sbs.dll.utilites
{
    public partial class fChooserUnit : Form
    {
        public int selectedId;
        public string selectedName;

        // Сохраняем выбанные элементы
        public int xOrgId;
        public string xOrgName;
        public int xBranchId;
        public string xBranchName;
        //public int xUnitId;
        //public string xUnitName;

        getReference oReference = new getReference();

        private DataTable dtOrg;
        private DataTable dtBranch;
        private DataTable dtUnit;

        private int lvl_min;    // Уровь отображение 0 - Орг; 1 - Заведение; 2 - Подразделение
        private int lvl_max;    // Уровь отображение 0 - Орг; 1 - Заведение; 2 - Подразделение
        private int lvl_curent; // Уровь - текущий

        public fChooserUnit(int plvl_min, int plvl_max)
        {
            lvl_min = plvl_min;
            lvl_max = plvl_max;

            getReferences();

            InitializeComponent();
        }

        private void getReferences()
        {
            dtOrg = oReference.getOrganization("offline");
            dtBranch = oReference.getBranch("offline");
            dtUnit = oReference.getUnitWhithDepot("offline");
        }

        private void fChooserUnit_Shown(object sender, EventArgs e)
        {
            switch (lvl_min)
            { 
                case 0:
                    dataGridView_main.DataSource = dtOrg;
                    break;

                case 1:
                    dataGridView_main.DataSource = dtBranch;
                    break;

                case 2:
                    dataGridView_main.DataSource = dtUnit;
                    break;
            }
        }

        private void dataGridView_main_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Enter:
                    inItem();
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Back:
                    fromItem();
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Escape:
                    closeForm(false);
                    break;
            }
        }

        private void fromItem()
        {
            int index;
            string itemPath;

            if (lvl_curent > lvl_min)
            {
                lvl_curent = lvl_curent - 1;
                switch (lvl_curent)
                { 
                    case 0:
                        dataGridView_main.DataSource = dtOrg;
                        break;

                    case 1:
                        dtBranch.DefaultView.RowFilter = "organization =" + xOrgId;
                        dataGridView_main.DataSource = dtBranch;
                        break;
                }

                index = label_path.Text.LastIndexOf(" \\ ");
                if (index == -1)
                {
                    label_path.Text = string.Empty;
                }
                else
                {
                    itemPath = label_path.Text.Substring(0, index);
                    label_path.Text = itemPath;
                }
            }
        }

        private void inItem()
        {
            string itemName;
            if (dataGridView_main.SelectedRows.Count == 0) return;

            DataGridViewRow dr = dataGridView_main.SelectedRows[0];
            if (lvl_curent < lvl_max - 1)
            {
                itemName = dr.Cells["name"].Value.ToString();
                lvl_curent = lvl_curent + 1;
                switch (lvl_curent)
                {
                    case 1:
                        xOrgId = (int)dr.Cells["id"].Value;
                        xOrgName = dr.Cells["name"].Value.ToString();
                        dtBranch.DefaultView.RowFilter = "organization =" + xOrgId;
                        dataGridView_main.DataSource = dtBranch;
                        break;

                    case 2:
                        xBranchId = (int)dr.Cells["id"].Value;
                        xBranchName = dr.Cells["name"].Value.ToString();
                        dtUnit.DefaultView.RowFilter = "branch =" + xBranchId;
                        dataGridView_main.DataSource = dtUnit;
                        break;

                }
                if (label_path.Text.Length != 0) label_path.Text += " \\ ";
                label_path.Text += itemName;
            }
            else // Конечный элемент
            {
                selectedId = (int)dr.Cells["id"].Value;
                selectedName = dr.Cells["name"].Value.ToString();
                closeForm(true);
            }

        }

        private void closeForm(bool pSelectItem)
        {
            if (pSelectItem)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Cancel;
            }
        }

        private void dataGridView_main_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            inItem();
        }
    }
}
