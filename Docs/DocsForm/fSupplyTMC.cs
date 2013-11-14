using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;
using com.sbs.gui.docsform.db;

namespace com.sbs.gui.docsform
{
    public partial class fSupplyTMC : Form
    {
        getReference oReference = new getReference();
        DBAccess dbAccess = new DBAccess();

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
            fSupplyTMC_DOC fsupplyDoc = new fSupplyTMC_DOC();
            fsupplyDoc.ShowDialog();
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
            groupBox3.Enabled = pEnabled;
            groupBox4.Enabled = pEnabled;
            button_save.Enabled = pEnabled;
        }

#region ------------------------------------------------------ -------------------Элементы шапки

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

            fChooser fChose = new fChooser("UNIT");

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

            if (fChose.ShowDialog() == DialogResult.OK)
            {
                textBox_mol.Text = fChose.xData[1].ToString();
                textBox_mol.Tag = fChose.xData;
            }
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

            fChooser fChose = new fChooser("ACCOUNT");

            fChose.dataGridView_main.DataSource = dt;

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = "id";
            col0.Name = "id";
            col0.DataPropertyName = "id";
            col0.Visible = false;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Счет";
            col1.Name = "group_II";
            col1.DataPropertyName = "group_II";
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Наименование";
            col2.Name = "name";
            col2.DataPropertyName = "name";
            col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            fChose.dataGridView_main.Columns.AddRange(new DataGridViewColumn[] { col0, col1, col2 });

            fChose.Text = "Счет Кредит";
            if (fChose.ShowDialog() == DialogResult.OK)
            {
                textBox_AccKT.Text = fChose.xData[1].ToString();
                textBox_AccKT.Tag = fChose.xData;
            }
            
        }

        private void button_getKontr_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = dbAccess.getContactor("offline");
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных", exc, SystemIcons.Error);
                setEnabled(false);
                return;
            }

            fChooser fChose = new fChooser("CONTRACTOR");

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

            fChose.Text = "Контрагент";

            if (fChose.ShowDialog() == DialogResult.OK)
            {
                textBox_kontr.Text = fChose.xData[1].ToString();
                textBox_kontr.Tag = fChose.xData;
            }
        }

        private void button_getContract_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = dbAccess.getContactor("offline");
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных", exc, SystemIcons.Error);
                setEnabled(false);
                return;
            }

            fChooser fChose = new fChooser("CONTRACTOR");

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

            fChose.Text = "Контрагент";

            if (fChose.ShowDialog() == DialogResult.OK)
            {
                textBox_AccKT.Text = fChose.xData[1].ToString();
                textBox_AccKT.Tag = fChose.xData;
            }
        }

        private void button_cur_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = oReference.getCurrency("offline");
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных", exc, SystemIcons.Error);
                setEnabled(false);
                return;
            }

            fChooser fChose = new fChooser("CURRENCY");

            fChose.dataGridView_main.DataSource = dt;

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = "idCurrency";
            col0.Name = "idCurrency";
            col0.DataPropertyName = "idCurrency";
            col0.Visible = false;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "code";
            col1.Name = "code";
            col1.DataPropertyName = "code";
            col1.Visible = false;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "name";
            col2.Name = "name";
            col2.DataPropertyName = "name";
            col2.Visible = false;

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "Описание";
            col3.Name = "description";
            col3.DataPropertyName = "description";
            col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = "ref_currency_type";
            col4.Name = "ref_currency_type";
            col4.DataPropertyName = "ref_currency_type";
            col4.Visible = false;

            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.HeaderText = "ref_currency_type_name";
            col5.Name = "ref_currency_type_name";
            col5.DataPropertyName = "ref_currency_type_name";
            col5.Visible = false;

            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
            col6.HeaderText = "idCourse";
            col6.Name = "idCourse";
            col6.DataPropertyName = "idCourse";
            col6.Visible = false;

            DataGridViewTextBoxColumn col7 = new DataGridViewTextBoxColumn();
            col7.HeaderText = "multiplicity";
            col7.Name = "multiplicity";
            col7.DataPropertyName = "multiplicity";
            col7.Visible = false;

            DataGridViewTextBoxColumn col8 = new DataGridViewTextBoxColumn();
            col8.HeaderText = "course";
            col8.Name = "course";
            col8.DataPropertyName = "course";
            col8.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            fChose.dataGridView_main.Columns.AddRange(new DataGridViewColumn[] { col0, col1, col2, col3, col4, col5, col6, col7, col8 });

            fChose.Text = "Валюта расчета";
            if (fChose.ShowDialog() == DialogResult.OK)
            {
                textBox_curr.Text = fChose.xData[1].ToString();
                textBox_currCourse.Text = fChose.xData[8].ToString();
                textBox_curType.Text = fChose.xData[5].ToString();

                textBox_curr.Tag = fChose.xData;
            }
        }

        private void button_getCurType_Click(object sender, EventArgs e)
        {

        }

#endregion -------------------------------------------------------------------------------------

    }
}
