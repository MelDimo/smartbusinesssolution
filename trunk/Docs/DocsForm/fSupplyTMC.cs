using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;

namespace DocsForm
{
    public partial class fSupplyTMC : Form
    {
        getReference oReference = new getReference();

        DataTable dtUnit = new DataTable();

        public fSupplyTMC()
        {
            InitializeComponent();

            tSButton_add.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSButton_edit.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            tSButton_del.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;
            tSButton_copy.Image = com.sbs.dll.utilites.Properties.Resources.copy_26;
        }

        private void tSButton_add_Click(object sender, EventArgs e)
        {

        }

        private void tSButton_edit_Click(object sender, EventArgs e)
        {

        }

        private void tSButton_del_Click(object sender, EventArgs e)
        {

        }

        private void tSButton_copy_Click(object sender, EventArgs e)
        {

        }

        private void fSupplyTMC_Shown(object sender, EventArgs e)
        {

        }

        private void setEnabled(bool pEnabled)
        {
            groupBox1.Enabled = pEnabled;
            groupBox2.Enabled = pEnabled;
            groupBox3.Enabled = pEnabled;
            groupBox4.Enabled = pEnabled;
            button_save.Enabled = pEnabled;
        }

        private void button_getUnit_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = oReference.getUnit("offline");
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных", exc, SystemIcons.Error);
                setEnabled(false);
                return;
            }

            fChooser fChose = new fChooser();

            fChose.dataGridView_main.DataSource = dt;

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = "id";
            col0.Name = "id";
            col0.DataPropertyName = "id";
            col0.Visible = false;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Наименование";
            col1.Name = "name";
            col1.DataPropertyName = "name";
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            fChose.dataGridView_main.Columns.AddRange(new DataGridViewColumn[] { col0, col1 });

            fChose.Text = "МОЛ (получатель)";
            fChose.ShowDialog();
        }

        private void button_getAccKT_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            DataTable dtBuff = new DataTable();
            try
            {
                dt = oReference.getAccounts("offline", 52, 1);
                dtBuff = oReference.getAccounts("offline", 61, 2);

                dt = dt.AsEnumerable().Union(dtBuff.AsEnumerable()).CopyToDataTable<DataRow>();
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных", exc, SystemIcons.Error);
                setEnabled(false);
                return;
            }

            fChooser fChose = new fChooser();

            fChose.dataGridView_main.DataSource = dt;

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = "id";
            col0.Name = "id";
            col0.DataPropertyName = "id";
            col0.Visible = false;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Наименование";
            col1.Name = "name";
            col1.DataPropertyName = "name";
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            fChose.dataGridView_main.Columns.AddRange(new DataGridViewColumn[] { col0, col1 });

            fChose.Text = "Счет Кредит";
            fChose.ShowDialog();
            
        }

        private void button_getKontr_Click(object sender, EventArgs e)
        {

        }

        private void button_getContract_Click(object sender, EventArgs e)
        {

        }

        private void button_cur_Click(object sender, EventArgs e)
        {

        }

        private void button_getCurType_Click(object sender, EventArgs e)
        {

        }
    }

    class Unit
    {
        public int id { get; set; }
        public string name { get; set; }
    }
}
