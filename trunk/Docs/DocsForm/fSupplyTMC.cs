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
using com.sbs.dll.docsaction;

namespace com.sbs.gui.docsform
{
    public partial class fSupplyTMC : Form
    {
        getReference oReference = new getReference();
        
        DBAccess dbAccess = new DBAccess();

        DataTable dtUnit;           // Справочник подразделений(склады)
        DataTable dtBuff;           // Временная таблица для объединения счетов
        DataTable dtAccount;        // Таблица счетов
        DataTable dtContractor;     // Поставщики
        DataTable dtCurr;           // Валюта

        DataTable dtTmcType;        // Вид ТМС

        Packages oPackages;

        public fSupplyTMC(Packages pPackages)
        {
            oPackages = pPackages;

            InitializeComponent();

            tSButton_add.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSButton_edit.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            tSButton_del.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;
            tSButton_copy.Image = com.sbs.dll.utilites.Properties.Resources.copy_26;

            tSButton_addDop.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSButton_editDop.Image = com.sbs.dll.utilites.Properties.Resources.edit_26;
            tSButton_delDop.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;
            tSButton_copyDop.Image = com.sbs.dll.utilites.Properties.Resources.copy_26;

            fillReferences();
        }

        private void fillReferences()
        {
            dtUnit = new DataTable();
            dtBuff = new DataTable();
            dtAccount = new DataTable();
            dtContractor = new DataTable();
            dtCurr = new DataTable();

            try
            {
                dtUnit = oReference.getUnit("offline");

                dtAccount = oReference.getAccounts("offline", 52, 1);
                dtBuff = oReference.getAccounts("offline", 61, 2);
                dtAccount = dtAccount.AsEnumerable().Union(dtBuff.AsEnumerable()).CopyToDataTable<DataRow>();

                dtContractor = oReference.getContactor("offline");
                
                dtCurr = oReference.getCurrency("offline");
                dtTmcType = oReference.getTmcType("offline");
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных.", exc, SystemIcons.Error);
                setEnabled(false);
                return;
            }
        }

        private SupplyTMC checkValidity()
        {
            Object[] oData;
            SupplyTMC oSupplyTMC = new SupplyTMC();

            try
            {
                oSupplyTMC.mol = (int)textBox_mol.Tag;

                oData = textBox_AccKT.Tag as Object[];
                oSupplyTMC.accKred = (int)oData[0];

                oData = textBox_kontr.Tag as Object[];
                oSupplyTMC.kontrId = (int)oData[0];

                oData = textBox_curr.Tag as Object[];
                oSupplyTMC.currId = (int)oData[6];
                oSupplyTMC.currCode = oData[1].ToString();
            }
            catch (Exception exc)
            {
                throw exc;
            }

            return oSupplyTMC;
        }

        private void tSButton_add_Click(object sender, EventArgs e)
        {

            SupplyTMC oSupplyTMC;
            SupplyTMC_DOC oSupplyTMC_DOC = new SupplyTMC_DOC();

            try
            {
                oSupplyTMC = checkValidity();
            }
            catch (Exception exc)
            {
                uMessage.Show("Проверка валидности данных привела к ошибке." + Environment.NewLine +
                                "Проверьте заполнены ли обязательные поля.", exc, SystemIcons.Information);
                return;
            }

            //SupplyTMC oSupplyTMC = new SupplyTMC();

            fSupplyTMC_DOC fsupplyDoc = new fSupplyTMC_DOC(oSupplyTMC, oSupplyTMC_DOC, oPackages);
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
            toolStrip1.Enabled = pEnabled;
            toolStrip2.Enabled = pEnabled;
        }

#region ------------------------------------------------------ -------------------Элементы шапки

        private void button_getUnit_Click(object sender, EventArgs e)
        {
            fChooserUnit fChoseUnit = new fChooserUnit(0, 3);
            fChoseUnit.Text = "МОЛ (получатель)";

            if (fChoseUnit.ShowDialog() == DialogResult.OK)
            {
                textBox_mol.Text = fChoseUnit.selectedName;
                textBox_mol.Tag = fChoseUnit.selectedId;
            }
        }

        private void button_getAccKT_Click(object sender, EventArgs e)
        {
            fChooser fChose = new fChooser("ACCOUNT");

            fChose.dataGridView_main.DataSource = dtAccount;

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
            fChooser fChose = new fChooser("CONTRACTOR");

            fChose.dataGridView_main.DataSource = dtContractor;

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

        private void button_cur_Click(object sender, EventArgs e)
        {
            fChooser fChose = new fChooser("CURRENCY");

            fChose.dataGridView_main.DataSource = dtCurr;

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

#endregion -------------------------------------------------------------------------------------

        private void tSButton_addDop_Click(object sender, EventArgs e)
        {

            fSupplyTMC_DOC_COST fsupplyDocCost = new fSupplyTMC_DOC_COST(new SupplyTMC_DOC_COST());
            fsupplyDocCost.ShowDialog();
        }

        private void tSButton_editDop_Click(object sender, EventArgs e)
        {

        }

        private void tSButton_delDop_Click(object sender, EventArgs e)
        {

        }

        private void tSButton_copyDop_Click(object sender, EventArgs e)
        {

        }

    }

    public class SupplyTMC
    {
        public int mol { get; set; }
        public int accKred { get; set; }
        public int kontrId { get; set; }
        public string DocReason { get; set; }
        public string DocProxy { get; set; }
        public int currId { get; set; }
        public string currCode { get; set; }
        public string comment { get; set; }
    }

    public class SupplyTMC_DOC
    {
        public int itemTmcType { get; set; }
        public int itemId { get; set; }
        public string itemName { get; set; }
        public string itemMeasureName { get; set; }
        public decimal itemCount { get; set; }
        public int itemDeb { get; set; }
        public string itemDebName { get; set; }
        public decimal itemSumCurr { get; set; }
        public decimal itemSumRub { get; set; }
    }

    public class SupplyTMC_DOC_COST
    {
        public int costType { get; set; }
        public string costTypeName { get; set; }
        public int costAcc { get; set; }
        public string costAccName { get; set; }
        public int costContractor { get; set; }
        public string costContractorName { get; set; }
    }
}
