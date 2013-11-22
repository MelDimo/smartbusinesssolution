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
using System.Data.SqlClient;

namespace com.sbs.gui.docsform
{
    public partial class fSupplyTMC_DOC : Form
    {
        getReference oReference = new getReference();
        DBAccess dbAccess = new DBAccess();

        DataTable dtTmcType;
        DataTable dtAccount;
        SupplyTMC oSupplyTMC;
        SupplyTMC_DOC oSupplyTMC_DOC;

        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        public fSupplyTMC_DOC(SupplyTMC pSupplyTMC, SupplyTMC_DOC pSupplyTMC_DOC)
        {
            oSupplyTMC = pSupplyTMC;
            oSupplyTMC_DOC = pSupplyTMC_DOC;

            if (oSupplyTMC_DOC.itemId == 0) formMode = "ADD";
            else formMode = "EDIT";

            InitializeComponent();

        }

        private void setEnabled(bool pEnabled)
        {
            panel3.Enabled = pEnabled;
            tableLayoutPanel1.Enabled = pEnabled;
            panel4.Enabled = pEnabled;
        }

        private void fSupplyTMC_DOC_Shown(object sender, EventArgs e)
        {
            try
            {
                dtTmcType = oReference.getTmcType("offline");
                dtAccount = oReference.getAccounts("offline");
            }
            catch (Exception exc) 
            { 
                uMessage.Show("Не удалось загрузить справочники.", exc, SystemIcons.Information);
                setEnabled(false);
                return;
            }

            fillControls();
        }

        private void fillControls()
        {
            comboBox_tmcType.SelectedValueChanged -= new EventHandler(comboBox_tmcType_SelectedValueChanged);

            comboBox_tmcType.DataSource = dtTmcType;
            comboBox_tmcType.DisplayMember = "name";
            comboBox_tmcType.ValueMember = "id";

            comboBox_tmcType.SelectedValueChanged +=new EventHandler(comboBox_tmcType_SelectedValueChanged);

            textBox_TmcType.DataBindings.Add("Text", oSupplyTMC_DOC, "itemName");
            textBox_TmcMeasure.DataBindings.Add("Text", oSupplyTMC_DOC, "itemMeasureName");
            numericUpDown_count.DataBindings.Add("Value", oSupplyTMC_DOC, "itemCount", true, DataSourceUpdateMode.OnPropertyChanged);
            textBox_TmcAcc.DataBindings.Add("Text", oSupplyTMC_DOC, "itemDebName");
            textBox_TmcCurr.DataBindings.Add("Text", oSupplyTMC, "currCode");
            numericUpDown_priceCurr.DataBindings.Add("Value", oSupplyTMC_DOC, "itemSumCurr", true, DataSourceUpdateMode.OnPropertyChanged);

            if (formMode.Equals("ADD")) initControls(); // Если добавляем новый указываем дефолтный счет

        }

        private void initControls()
        {
            DataRow recData;

            switch ((int)comboBox_tmcType.SelectedValue)
            { 
                case 1:
                    textBox_TmcAcc.Text = "2111";
                    recData = (from rows in dtAccount.AsEnumerable()
                               where rows.Field<int>("group_II") == 2111
                               select rows).First();
                    oSupplyTMC_DOC.itemDeb = (int)recData["id"];
                    oSupplyTMC_DOC.itemDebName = recData["group_II"].ToString() + " (" + recData["name"].ToString() + ")";
                    textBox_TmcAcc.DataBindings[0].ReadValue();
                    break;
                case 2:
                    textBox_TmcAcc.Text = "2141";
                    recData = (from rows in dtAccount.AsEnumerable()
                               where rows.Field<int>("group_II") == 2141
                               select rows).First();
                    oSupplyTMC_DOC.itemDeb = (int)recData["id"];
                    oSupplyTMC_DOC.itemDebName = recData["group_II"].ToString() + " (" + recData["name"].ToString() + ")";
                    textBox_TmcAcc.DataBindings[0].ReadValue();
                    break;
            }
        }

        private void comboBox_tmcType_SelectedValueChanged(object sender, EventArgs e)
        {
            initControls();
        }

        private void button_TMC_Click(object sender, EventArgs e)
        {
            DataTable dtTMC = new DataTable();
            try
            {
                dtTMC = dbAccess.getTmcByType("offline", (int)comboBox_tmcType.SelectedValue);
            }
            catch (Exception exc)
            {
                uMessage.Show("Не удалось получить данные.", exc, SystemIcons.Information);
                return;
            }

            fChooser fChose = new fChooser("GETTMC");

            fChose.dataGridView_main.DataSource = dtTMC;

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
            col2.HeaderText = "Ед. измерения";
            col2.Name = "name_short";
            col2.DataPropertyName = "name_short";
            col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            fChose.dataGridView_main.Columns.AddRange(new DataGridViewColumn[] { col0, col1, col2 });

            fChose.Text = "ТМЦ";

            if (fChose.ShowDialog() == DialogResult.OK)
            {
                oSupplyTMC_DOC.itemId = (int)fChose.xData[0];
                oSupplyTMC_DOC.itemName = fChose.xData[1].ToString();
                oSupplyTMC_DOC.itemMeasureName = fChose.xData[2].ToString();

                textBox_TmcType.DataBindings[0].ReadValue();
                textBox_TmcMeasure.DataBindings[0].ReadValue();
            }
        }

        private void button_getTmcAcc_Click(object sender, EventArgs e)
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
                oSupplyTMC_DOC.itemDeb = (int)fChose.xData[0];
                oSupplyTMC_DOC.itemDebName = fChose.xData[1].ToString() + " (" + fChose.xData[2].ToString() + ")";

                textBox_TmcAcc.DataBindings[0].ReadValue();
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

        private bool saveData()
        {
            string errMessage = "Заполнены не все обязательные поля:";

            if (oSupplyTMC_DOC.itemId == 0) errMessage += System.Environment.NewLine + "- ТМЦ;";
            if (oSupplyTMC_DOC.itemCount == 0) errMessage += System.Environment.NewLine + "- Кол-во;";
            if (oSupplyTMC_DOC.itemSumCurr == 0) errMessage += System.Environment.NewLine + "- Сумма в валюте;";

            if (!errMessage.Equals("Заполнены не все обязательные поля:"))
            {
                uMessage.Show(errMessage, SystemIcons.Information);
                return false;
            }

            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;
            DataTable dt = new DataTable();

            try
            {
                con.Open();
                command = con.CreateCommand();


                switch (formMode)
                {
                    case "ADD":
                        command.CommandText = "INSERT INTO ref_items(items_type,    name,       nameForSale,            ref_measure,    ref_measureForSale, koefSale," +
                                                                    "ref_items_raw, koefRaw,    ref_tmc_type_nomenkl,   ref_tmc_type,   ref_status)" +
                                                            "VALUES(@items_type,    @name,      @nameForSale,           @ref_measure,   @ref_measureForSale,@koefSale," +
                                                                    "@ref_items_raw,@koefRaw,   @ref_tmc_type_nomenkl,  @ref_tmc_type,  @ref_status)";
                        break;

                    case "EDIT":
                        command.CommandText = "UPDATE ref_items SET items_type = @items_type, " +
                                                                    " name = @name," +
                                                                    " nameForSale = @nameForSale," +
                                                                    " ref_measure = @ref_measure," +
                                                                    " ref_measureForSale = @ref_measureForSale," +
                                                                    " koefSale = @koefSale," +
                                                                    " ref_items_raw = @ref_items_raw," +
                                                                    " koefRaw = @koefRaw," +
                                                                    " ref_tmc_type_nomenkl = @ref_tmc_type_nomenkl," +
                                                                    " ref_tmc_type = @ref_tmc_type," +
                                                                    " ref_status = @ref_status" +
                                                " WHERE id = @id";
                        command.Parameters.Add("id", SqlDbType.Int).Value = oSupplyTMC_DOC.itemId;
                        break;

                    default:
                        throw new Exception("Неудалось определить в каком режиме работает форма!");
                }

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            return true;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
