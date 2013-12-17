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
using com.sbs.dll;
using com.sbs.dll.docsaction;

namespace com.sbs.gui.docsform
{
    public partial class fSupplyTMC_DOC_COST : Form
    {
        SupplyTMC_DOC_COST oSupplyCost;
        getReference oReference = new getReference();
        DBAccess dbAccess = new DBAccess();
        DocActions oDocAction = new DocActions();
        Packages oPackages;
        SupplyTMC oSupplyTMC;

        DataTable dtCost;
        DataTable dtAccount;
        DataTable dtContractor;
        DataTable dtCurr;

        private string formMode;        // В каком режиме диалог "EDIT"/"ADD"

        public fSupplyTMC_DOC_COST(SupplyTMC pSupplyTMC, SupplyTMC_DOC_COST pSupplyCost, Packages pPackages)
        {
            oSupplyCost = pSupplyCost;
            oPackages = pPackages;
            oSupplyTMC = pSupplyTMC;

            if (oSupplyCost.docId == 0) formMode = "ADD";
            else formMode = "EDIT";

            InitializeComponent();

        }

        private void fSupplyTMC_DOC_COST_Shown(object sender, EventArgs e)
        {
            try
            {
                dtCost = dbAccess.getAdditionalCost("offline");
                dtAccount = oReference.getAccounts("offline");
                dtContractor = oReference.getContactor("offline");
                dtCurr = oReference.getCurrency("offline");
            }
            catch (Exception exc)
            {
                uMessage.Show("Не удалось загрузить справочники.", exc, SystemIcons.Information);
                setEnabled(false);
                return;
            }

            textBox_costAcc.DataBindings.Add("Text", oSupplyCost, "costAccName");
            textBox_costContractor.DataBindings.Add("Text", oSupplyCost, "costContractorName");
            textBox_costType.DataBindings.Add("Text", oSupplyCost, "costTypeName");
            textBox_curr.DataBindings.Add("Text", oSupplyCost, "costCurrCodeName");
            textBox_currCourse.DataBindings.Add("Text", oSupplyCost, "costCourseVal");
            textBox_curType.DataBindings.Add("Text", oSupplyCost, "costCurrTypeName");
            numericUpDown_sumCurr.DataBindings.Add("Value", oSupplyCost, "costSumCurr", true, DataSourceUpdateMode.OnPropertyChanged);
            numericUpDown_sumRup.DataBindings.Add("Value", oSupplyCost, "costSumRup", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void setEnabled(bool pIsEnabled)
        {
            tableLayoutPanel1.Visible = pIsEnabled;
        }

        private void button_getCostType_Click(object sender, EventArgs e)
        {
            fChooser fChose = new fChooser("ADDITIONALCOST");

            fChose.dataGridView_main.DataSource = dtCost;

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

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "ref_accounts";
            col2.Name = "ref_accounts";
            col2.DataPropertyName = "ref_accounts";
            col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "Счет";
            col3.Name = "ref_accounts_name";
            col3.DataPropertyName = "ref_accounts_name";
            col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = "ref_contractor";
            col4.Name = "ref_contractor";
            col4.DataPropertyName = "ref_contractor";
            col4.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.HeaderText = "Контрагент";
            col5.Name = "ref_contractor_name";
            col5.DataPropertyName = "ref_contractor_name";
            col5.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            fChose.dataGridView_main.Columns.AddRange(new DataGridViewColumn[] { col0, col1, col2, col3, col4, col5 });

            fChose.Text = "Вид доп. расходов ";
            if (fChose.ShowDialog() == DialogResult.OK)
            {
                oSupplyCost.costType = (int)fChose.xData[0];
                oSupplyCost.costTypeName = fChose.xData[1].ToString();
                oSupplyCost.costAcc = (int)fChose.xData[2];
                oSupplyCost.costAccName = fChose.xData[3].ToString();
                oSupplyCost.costContractor = (int)fChose.xData[4];
                oSupplyCost.costContractorName = fChose.xData[5].ToString();

                textBox_costType.DataBindings[0].ReadValue();
                textBox_costAcc.DataBindings[0].ReadValue();
                textBox_costContractor.DataBindings[0].ReadValue();
            }
        }

        private void button_getCostAcc_Click(object sender, EventArgs e)
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

            fChose.Text = "Счет Дебет";
            if (fChose.ShowDialog() == DialogResult.OK)
            {
                oSupplyCost.costAcc = (int)fChose.xData[0];
                oSupplyCost.costAccName = fChose.xData[1].ToString() + " (" + fChose.xData[2].ToString() + ")";

                textBox_costAcc.DataBindings[0].ReadValue();
            }
        }

        private void button_getCostContractor_Click(object sender, EventArgs e)
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
                oSupplyCost.costContractor = (int)fChose.xData[0];
                oSupplyCost.costContractorName = fChose.xData[1].ToString();

                textBox_costContractor.DataBindings[0].ReadValue();
            }
        }

        private void button_getCurr_Click(object sender, EventArgs e)
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
                oSupplyCost.costCurr = (int)fChose.xData[0];
                oSupplyCost.costCurrCodeName = fChose.xData[1].ToString();
                oSupplyCost.costCurrTypeName = fChose.xData[5].ToString();
                oSupplyCost.costCourse = (int)fChose.xData[6];
                oSupplyCost.costCourseVal = (decimal)fChose.xData[8];

                textBox_curr.DataBindings[0].ReadValue();
                textBox_currCourse.DataBindings[0].ReadValue();
                textBox_curType.DataBindings[0].ReadValue();
            }
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                MessageBox.Show("Данные успешно сохранены", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private bool saveData()
        {
            string errMessage = "Заполнены не все обязательные поля:";

            if (oSupplyCost.costType == 0) errMessage += System.Environment.NewLine + "- Вид;";
            if (oSupplyCost.costAcc == 0) errMessage += System.Environment.NewLine + "- Счет;";
            if (oSupplyCost.costContractor == 0) errMessage += System.Environment.NewLine + "- Контр агент;";
            if (oSupplyCost.costCourse == 0) errMessage += System.Environment.NewLine + "- Контр агент;";


            if (!errMessage.Equals("Заполнены не все обязательные поля:"))
            {
                uMessage.Show(errMessage, SystemIcons.Information);
                return false;
            }

            Docs oDoc = new Docs();
            try
            {
                switch (formMode)
                {
                    case "ADD":
                        if (oPackages.id == 0)  // Запись документ добавляется в новый пакет
                        {
                            oPackages.ref_status = 28;
                            oPackages.id = oDocAction.savePackage("offline", oPackages);
                        }
                        oDoc.docs_type = 5;
                        oDoc.packages = oPackages.id;
                        oDoc.addParam("COST_TYPE", oSupplyCost.costType);
                        oDoc.addParam("ACC_DT", oSupplyCost.costAcc);
                        oDoc.addParam("ACC_KT", oSupplyTMC.accKred);
                        oDoc.addParam("UNIT_KT", oSupplyTMC.mol);
                        oDoc.addParam("SUPPLIER", oSupplyCost.costContractor);
                        oDoc.addParam("COURSE", oSupplyCost.costCourse);
                        oDoc.addParam("SUM_CURR", oSupplyCost.costSumCurr);
                        oDoc.addParam("SUM_RUB", oSupplyCost.costSumRup);

                        oDocAction.saveDoc("offline", oPackages, oDoc);
                        oDocAction.recalcPackageCost("offline", oPackages, 4);
                        break;

                    case "EDIT":
                        
                        oDocAction.savePackage("offline", oPackages);

                        oDoc.id = oSupplyCost.docId;
                        oDoc.docs_type = 5;
                        oDoc.packages = oPackages.id;
                        oDoc.addParam("COST_TYPE", oSupplyCost.costType);
                        oDoc.addParam("ACC_DT", oSupplyCost.costAcc);
                        oDoc.addParam("ACC_KT", oSupplyTMC.accKred);
                        oDoc.addParam("UNIT_KT", oSupplyTMC.mol);
                        oDoc.addParam("SUPPLIER", oSupplyCost.costContractor);
                        oDoc.addParam("COURSE", oSupplyCost.costCourse);
                        oDoc.addParam("SUM_CURR", oSupplyCost.costSumCurr);
                        oDoc.addParam("SUM_RUB", oSupplyCost.costSumRup);

                        oDocAction.saveDoc("offline", oPackages, oDoc);
                        oDocAction.recalcPackageCost("offline", oPackages, 4);
                        break;

                    default:
                        throw new Exception("Неудалось определить в каком режиме работает форма!");
                }
            }
            catch (Exception exc)
            {
                uMessage.Show("Не удалось создать запись.", exc, SystemIcons.Information);
                setEnabled(false);
                return false;
            }
            finally
            {

            }

            return true;
        }

        private void numericUpDown_sumCurr_Leave(object sender, EventArgs e)
        {
            numericUpDown_sumCurr.DataBindings[0].WriteValue();
            oSupplyCost.costSumRup = Math.Round(oSupplyCost.costSumCurr * oSupplyCost.costCourseVal, 2);
            numericUpDown_sumRup.DataBindings[0].ReadValue();
        }

    }
}
