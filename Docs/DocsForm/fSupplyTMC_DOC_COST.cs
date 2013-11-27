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
    public partial class fSupplyTMC_DOC_COST : Form
    {
        SupplyTMC_DOC_COST oSupplyCost;
        getReference oReference = new getReference();
        DBAccess dbAccess = new DBAccess();

        DataTable dtCost;
        DataTable dtAccount;
        DataTable dtContractor;

        public fSupplyTMC_DOC_COST(SupplyTMC_DOC_COST pSupplyCost)
        {
            oSupplyCost = pSupplyCost;

            InitializeComponent();

        }

        private void fSupplyTMC_DOC_COST_Shown(object sender, EventArgs e)
        {
            try
            {
                dtCost = dbAccess.getAdditionalCost("offline");
                dtAccount = oReference.getAccounts("offline");
                dtContractor = oReference.getContactor("offline");
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


    }
}
