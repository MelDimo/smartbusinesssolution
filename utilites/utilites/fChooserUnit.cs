using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.sbs.dll.utilites
{
    public partial class fChooserUnit : Form
    {
        // Сохраняем выбанные элементы
        public int xOrgId;
        public int xBranchId;
        public int xUnitId;

        getReference oReference = new getReference();

        private DataTable dtOrg;
        private DataTable dtBranch;
        private DataTable dtUnit;

        private int lvl_min;    // Уровь отображение 0 - Орг; 1 - Заведение; 2 - Подразделение
        private int lvl_max;    // Уровь отображение 0 - Орг; 1 - Заведение; 2 - Подразделение
        private int lvl_curent; // Уровь - текущий
        private int id;         // id предыдущего уровня (0 - незаморачиваюсь, меню организации)

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
            dtUnit = oReference.getUnit("offline");
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
                    break;

                case Keys.Back:
                    fromItem();
                    break;
            }
        }

        private void fromItem()
        {
            DataGridViewRow dr = dataGridView_main.SelectedRows[0];
            if (lvl_curent > lvl_min)
            {
                lvl_curent = lvl_curent - 1;
                dtBranch.DefaultView.RowFilter = "organization =" + dr.Cells["id"].Value.ToString() ;
                dataGridView_main.DataSource = dtBranch;
            }
        }

        private void inItem()
        {
            DataGridViewRow dr = dataGridView_main.SelectedRows[0];
            if (lvl_curent < lvl_max)
            {
                lvl_curent = lvl_curent + 1;
            }
        }
    }
}
