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
using com.sbs.dll;

namespace com.sbs.gui.docsform
{
    public partial class fSupplyTMC : Form
    {
        getReference oReference = new getReference();
        SupplyTMC oSupplyTMC = new SupplyTMC();

        List<SupplyTMC_DOC> oListSupplyTMC_DOC = new List<SupplyTMC_DOC>();
        
        DBAccess dbAccess = new DBAccess();

        DataTable dtUnit;           // Справочник подразделений(склады)
        DataTable dtBuff;           // Временная таблица для объединения счетов
        DataTable dtAccount;        // Таблица счетов
        DataTable dtContractor;     // Поставщики
        DataTable dtCurr;           // Валюта
        DataTable dtTMC;            // Товарно мат ценность

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

            textBox_BASE.DataBindings.Add("Text", oPackages, "doc_base");
            textBox_PROXY.DataBindings.Add("Text", oPackages, "doc_proxy");
            textBox_comment.DataBindings.Add("Text", oPackages, "doc_comment");

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

        private bool checkValidity(SupplyTMC pSupplyTMC)
        {
            string errMsg = "Заполнены не все обязательные поля:" + Environment.NewLine;

            try
            {
                oSupplyTMC.DocReason = textBox_BASE.Text;
                oSupplyTMC.DocProxy = textBox_PROXY.Text;
                oSupplyTMC.comment = textBox_comment.Text;

                if (pSupplyTMC.mol == 0)
                {
                    errMsg += "- МОЛ;" + Environment.NewLine;
                }

                if (pSupplyTMC.accKred == 0)
                {
                    errMsg += "- Счет Кредит;" + Environment.NewLine;
                }

                if (pSupplyTMC.kontrId == 0)
                {
                    errMsg += "- Контрагент;" + Environment.NewLine;
                }

                if (pSupplyTMC.courseId == 0)
                {
                    errMsg += "- Валюта;" + Environment.NewLine;
                }

                if (!errMsg.Equals("Заполнены не все обязательные поля:" + Environment.NewLine))
                {
                    throw new Exception(errMsg);
                }
            }
            catch (Exception exc)
            {
                throw exc;
            }

            return true;
        }

#region ------------------------------------------------------ ------------------- Приход ТМЦ

        private void tSButton_add_Click(object sender, EventArgs e)
        {
            SupplyTMC_DOC oSupplyTMC_DOC = new SupplyTMC_DOC();

            try
            {
                if (!checkValidity(oSupplyTMC))
                {
                    throw new Exception("");
                }
            }
            catch (Exception exc)
            {
                uMessage.Show("Проверка валидности данных привела к ошибке." + Environment.NewLine +
                                "Проверьте заполнены ли обязательные поля.", exc, SystemIcons.Information);
                return;
            }

            fSupplyTMC_DOC fsupplyDoc = new fSupplyTMC_DOC(oSupplyTMC, oSupplyTMC_DOC, oPackages);
            if (fsupplyDoc.ShowDialog() == DialogResult.OK)
                updateData();
        }

        private void tSButton_edit_Click(object sender, EventArgs e)
        {
            int index;

            if (dataGridView_main.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент для редактирования", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            index = dataGridView_main.SelectedRows[0].Index;

            if (!checkValidity(oSupplyTMC)) return;

            fSupplyTMC_DOC fsupplyDoc = new fSupplyTMC_DOC(oSupplyTMC, oListSupplyTMC_DOC[index], oPackages);
            if (fsupplyDoc.ShowDialog() == DialogResult.OK)
                updateData();
        }

        private void tSButton_del_Click(object sender, EventArgs e)
        {

        }

        private void tSButton_copy_Click(object sender, EventArgs e)
        {

        }

#endregion -------------------------------------------------------------------------------------

        private void fSupplyTMC_Shown(object sender, EventArgs e)
        {
            updateData();
        }

        private void updateData()
        {
            int xDocId = 0;

            DataTable dtAccountAll;
            DataTable dtDoc;
            DataRow drValue;

            if (oPackages.id == 0) return; // Новый пакет, просто отображаем форму

            try
            {
                dtDoc = dbAccess.getTMC_DOC("offline", oPackages);
                dtAccountAll = oReference.getAccounts("offline");
            }
            catch (Exception exc)
            {
                uMessage.Show("Не удалось получить данные по пакету.", exc, SystemIcons.Information);
                setEnabled(false);
                return;
            }

            SupplyTMC_DOC oSupplyTMC_DOC = new SupplyTMC_DOC();
            foreach (DataRow dr in dtDoc.Rows)
            {
                if (xDocId == 0)    // Первый проход
                {
                    xDocId = int.Parse(dr["id"].ToString());
                    oSupplyTMC_DOC.docId = xDocId;
                }

                if (xDocId != int.Parse(dr["id"].ToString()))
                {
                    oListSupplyTMC_DOC.Add(oSupplyTMC_DOC);

                    xDocId = int.Parse(dr["id"].ToString());
                    oSupplyTMC_DOC = new SupplyTMC_DOC();
                    oSupplyTMC_DOC.docId = xDocId;
                }

                switch (dr["name"].ToString())
                {
                    case "SUPPLIER":
                        drValue = (from row in dtContractor.AsEnumerable() where row.Field<int>("id") == int.Parse(dr["value"].ToString()) select row).First();
                        textBox_kontr.Text = drValue["name"].ToString();
                        textBox_kontr.Tag = drValue;
                        oSupplyTMC.kontrId = (int)drValue["id"];
                        break;
                    case "ACC_DT":
                        drValue = (from row in dtAccountAll.AsEnumerable() where row.Field<int>("id") == int.Parse(dr["value"].ToString()) select row).First();
                        oSupplyTMC_DOC.itemDeb = (int)drValue["id"];
                        oSupplyTMC_DOC.itemDebName = drValue["group_II"].ToString() + " (" + drValue["name"].ToString() + ")";
                        break;
                    case "ACC_KT":
                        drValue = (from row in dtAccount.AsEnumerable() where row.Field<int>("id") == int.Parse(dr["value"].ToString()) select row).First();
                        textBox_AccKT.Text = drValue["group_II"].ToString();
                        oSupplyTMC.accKred = (int)drValue["id"];
                        break;
                    case "TYPE_TMC":
                        drValue = (from row in dtTmcType.AsEnumerable() where row.Field<int>("id") == int.Parse(dr["value"].ToString()) select row).First();
                        oSupplyTMC_DOC.itemTmcType_Name = drValue["name"].ToString();
                        oSupplyTMC_DOC.itemTmcType = (int)drValue["id"];
                        try
                        {
                            dtTMC = dbAccess.getTmcByType("offline", oSupplyTMC_DOC.itemTmcType);
                        }
                        catch (Exception exc)
                        {
                            uMessage.Show("Не удалось получить данные.", exc, SystemIcons.Information);
                            setEnabled(false);
                            return;
                        }
                        break;
                    case "TMC":
                        oSupplyTMC_DOC.itemId = int.Parse(dr["value"].ToString());
                        drValue = (from row in dtTMC.AsEnumerable() where row.Field<int>("id") == oSupplyTMC_DOC.itemId select row).First();
                        oSupplyTMC_DOC.itemName = drValue["name"].ToString();
                        break;
                    case "COUNT":
                        oSupplyTMC_DOC.itemCount = decimal.Parse(dr["value"].ToString());
                        break;
                    case "SUM_CURR":
                        oSupplyTMC_DOC.itemSumCurr = decimal.Parse(dr["value"].ToString());
                        break;
                    case "SUM_RUB":
                        oSupplyTMC_DOC.itemSumRub = decimal.Parse(dr["value"].ToString());
                        break;
                    case "SUM_COST":
                        oSupplyTMC_DOC.itemSumCost = decimal.Parse(dr["value"].ToString());
                        break;
                    case "COURSE":
                        drValue = (from row in dtCurr.AsEnumerable() where row.Field<int>("idCourse") == int.Parse(dr["value"].ToString()) select row).First();
                        textBox_curr.Text = drValue["code"].ToString();
                        textBox_currCourse.Text = drValue["course"].ToString();
                        textBox_curType.Text = drValue["ref_currency_type_name"].ToString();
                        oSupplyTMC.currCourse = (decimal)drValue["course"];
                        oSupplyTMC.courseId = (int)drValue["idCourse"];
                        oSupplyTMC.currCode = drValue["code"].ToString();
                        break;
                    case "UNIT_KT":
                        drValue = (from row in dtUnit.AsEnumerable() where row.Field<int>("id") == int.Parse(dr["value"].ToString()) select row).First();
                        textBox_mol.Text = drValue["name"].ToString();
                        oSupplyTMC.mol = (int)drValue["id"];
                        break;
                    case "COMMENTS":
                        oSupplyTMC.comment = dr["value"].ToString();
                        textBox_comment.Text = oSupplyTMC.comment;
                        break;
                    case "DOC_BASE":
                        oSupplyTMC.DocReason = dr["value"].ToString();
                        textBox_BASE.Text = oSupplyTMC.DocReason;
                        break;
                    case "DOC_PROXY":
                        oSupplyTMC.DocProxy = dr["value"].ToString();
                        textBox_PROXY.Text = oSupplyTMC.DocProxy;
                        break;
                }
            }

            if (dtDoc.Rows.Count > 0) oListSupplyTMC_DOC.Add(oSupplyTMC_DOC); //Добавляем последний или единственный документ

            dataGridView_main.DataSource = oListSupplyTMC_DOC;
            dataGridView_main.Columns["itemName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView_main.Refresh();
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

                oSupplyTMC.mol = (int)fChoseUnit.selectedId;
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

                oSupplyTMC.accKred = (int)fChose.xData[0];
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

                oSupplyTMC.kontrId = (int)fChose.xData[0];
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
            col5.HeaderText = "Тип";
            col5.Name = "ref_currency_type_name";
            col5.DataPropertyName = "ref_currency_type_name";
            col5.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

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
            col8.HeaderText = "Курс";
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

                oSupplyTMC.courseId = (int)fChose.xData[6];
                oSupplyTMC.currCode = fChose.xData[1].ToString();
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
        public decimal currCourse { get; set; }
        public int courseId { get; set; }
        public string currCode { get; set; }
        public string comment { get; set; }
    }

    public class SupplyTMC_DOC
    {
        [Browsable(false)]
        public int docId { get; set; }
        [Browsable(false)]
        public int itemTmcType { get; set; }
        [DisplayName("Вид ТМЦ"),]
        public string itemTmcType_Name { get; set; }
        [Browsable(false)]
        public int itemId { get; set; }
        [DisplayName("ТМЦ")]
        public string itemName { get; set; }
        [Browsable(false)]
        public string itemMeasureName { get; set; }
        [DisplayName("Кол-во")]
        public decimal itemCount { get; set; }
        [DisplayName("Счет")]
        public int itemDeb { get; set; }
        [Browsable(false)]
        public string itemDebName { get; set; }
        [DisplayName("Сумма в валюте")]
        public decimal itemSumCurr { get; set; }
        [DisplayName("Сумма в рублях")]
        public decimal itemSumRub { get; set; }
        [DisplayName("Сумма затрат")]
        public decimal itemSumCost { get; set; }
    }

    public class SupplyTMC_DOC_COST
    {
        public int costType { get; set; }
        public string costTypeName { get; set; }
        public int costAcc { get; set; }
        public string costAccName { get; set; }
        public int costContractor { get; set; }
        public string costContractorName { get; set; }
        public int costCurr { get; set; }
        public string costCurrTypeName { get; set; }
        public string costCurrCodeName { get; set; }
        public int costCourse { get; set; }
        public decimal costCourseVal { get; set; }
        public decimal costSumCurr { get; set; }
        public decimal costSumRup { get; set; }
    }
}
