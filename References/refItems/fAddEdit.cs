using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;
using System.Data.SqlClient;
using com.sbs.dll;

namespace com.sbs.gui.references.refitems
{
    public partial class fAddEdit : Form
    {
        getReference oReference = new getReference();
        DataTable dtItemsRaw;
        DataTable dtTmcType;
        DataTable dtMeasure;
        DataTable dtStatus;

        private Items oItems;
        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        public fAddEdit(Items pItems)
        {
            oItems = pItems;

            if (oItems.id == 0) formMode = "ADD";
            else formMode = "EDIT";

            InitializeComponent();
        }


        private void fAddEdit_Shown(object sender, EventArgs e)
        {
            textBox_id.DataBindings.Add("Text", oItems, "id");
            textBox_name.DataBindings.Add("Text", oItems, "name");
            textBox_nameForSale.DataBindings.Add("Text", oItems, "nameForSale");
            textBox_measure.DataBindings.Add("Text", oItems, "refMeasureName");
            textBox_measureForSale.DataBindings.Add("Text", oItems, "refMeasureNameForSale");
            textBox_raw.DataBindings.Add("Text", oItems, "refItemsRawName");
            textBox_measureRaw.DataBindings.Add("Text", oItems, "refMeasureName");
            textBox_nomenclature.DataBindings.Add("Text", oItems, "refTmcTypeNameNomenkl");
            textBox_TMC.DataBindings.Add("Text", oItems, "refTmcTypeName");

            numericUpDown_measureSale.DataBindings.Add("Value", oItems, "koefSale");
            numericUpDown_measureRaw.DataBindings.Add("Value", oItems, "koefRaw");

            getReferences();

            comboBox_status.DataSource = dtStatus;
            comboBox_status.DisplayMember = "name";
            comboBox_status.ValueMember = "id";
            comboBox_status.SelectedValue = oItems.refStatus;
        }

        private void getReferences()
        {
            try
            {
                getItemsRaw();
            }
            catch (Exception exc)
            {
                uMessage.Show("Не удалось загрузить справочники.", exc, SystemIcons.Information);
                setEnabled(false);
                return;
            }
        }

        private void getItemsRaw()
        {
            try
            {
                dtItemsRaw = oReference.getItemsRaw("offline");
                dtTmcType = oReference.getTmcType("offline");
                dtMeasure = oReference.getMeasure("offline");
                dtStatus = oReference.getStatus("offline", 1);
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        private void setEnabled(bool pEnabled)
        {
            tableLayoutPanel1.Enabled = false;
            tableLayoutPanel2.Enabled = false;
        }

        private bool saveData()
        {
            string errMessage = "Заполнены не все обязательные поля:";

            if (oItems.name.Length == 0) errMessage += System.Environment.NewLine + "- Наименовние;";
            if (oItems.nameForSale.Length == 0) errMessage += System.Environment.NewLine + "- Наименование для продажи;";
            if (oItems.itemsType == 0) errMessage += System.Environment.NewLine + "- Тип;";
            if (oItems.refItemsRaw == 0) errMessage += System.Environment.NewLine + "- Сырье;";
            if (oItems.refMeasure == 0) errMessage += System.Environment.NewLine + "- Измерение;";
            //if (oItems.refMeasureForSale == 0) errMessage += System.Environment.NewLine + "- Наименование;";
            //if (oItems.refNomencl == 0) errMessage += System.Environment.NewLine + "- Наименование;";
            if (oItems.refTmcType == 0) errMessage += System.Environment.NewLine + "- Тип ТМЦ;";
            if (comboBox_status.SelectedValue == null) errMessage += System.Environment.NewLine + "- Статус;";
            else oItems.refStatus = (int)comboBox_status.SelectedValue;

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

                command.Parameters.Add("items_type", SqlDbType.Int).Value = oItems.itemsType;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = oItems.name;
                command.Parameters.Add("nameForSale", SqlDbType.NVarChar).Value = oItems.nameForSale;
                command.Parameters.Add("ref_measure", SqlDbType.Int).Value = oItems.refMeasure;
                command.Parameters.Add("ref_measureForSale", SqlDbType.Int).Value = oItems.refMeasureForSale;
                command.Parameters.Add("koefSale", SqlDbType.Decimal).Value = oItems.koefSale;
                command.Parameters.Add("ref_items_raw", SqlDbType.Int).Value = oItems.refItemsRaw;
                command.Parameters.Add("koefRaw", SqlDbType.Decimal).Value = oItems.koefRaw;
                command.Parameters.Add("ref_tmc_type_nomenkl", SqlDbType.Int).Value = oItems.refTmcTypeNomenkl;
                command.Parameters.Add("ref_tmc_type", SqlDbType.Int).Value = oItems.refTmcType;
                command.Parameters.Add("ref_status", SqlDbType.Int).Value = oItems.refStatus;

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
                        command.Parameters.Add("id", SqlDbType.Int).Value = oItems.id;
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

        private void button_ok_Click(object sender, EventArgs e)
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

        private void button_getRaw_Click(object sender, EventArgs e)
        {
            fChooser fChose = new fChooser("ITEMSRAW");

            fChose.dataGridView_main.DataSource = dtItemsRaw;

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

            fChose.Text = "Сырьё";

            if (fChose.ShowDialog() == DialogResult.OK)
            {
                oItems.refItemsRaw = (int)fChose.xData[0];
                oItems.refItemsRawName = fChose.xData[1].ToString();

                textBox_raw.DataBindings[0].ReadValue();
            }
        }

        private void button_getNomenclature_Click(object sender, EventArgs e)
        {
            fChooser fChose = new fChooser("NOMENCLATURE");

            fChose.dataGridView_main.DataSource = dtTmcType;

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

            fChose.Text = "Номенклатура";

            if (fChose.ShowDialog() == DialogResult.OK)
            {
                oItems.refTmcTypeNomenkl = (int)fChose.xData[0];
                oItems.refTmcTypeNameNomenkl = fChose.xData[1].ToString();

                textBox_nomenclature.DataBindings[0].ReadValue();
            }
        }

        private void button_getTMC_Click(object sender, EventArgs e)
        {
            fChooser fChose = new fChooser("NOMENCLATURE");

            fChose.dataGridView_main.DataSource = dtTmcType;

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

            fChose.Text = "Тип ТМЦ";

            if (fChose.ShowDialog() == DialogResult.OK)
            {
                oItems.refTmcType = (int)fChose.xData[0];
                oItems.refTmcTypeName = fChose.xData[1].ToString();

                textBox_TMC.DataBindings[0].ReadValue();
            }
        }

        private void button_getMeasure_Click(object sender, EventArgs e)
        {
            fChooser fChose = new fChooser("MEASURE");

            fChose.dataGridView_main.DataSource = dtMeasure;

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
            col2.HeaderText = "Краткое наименование";
            col2.Name = "name_short";
            col2.DataPropertyName = "name_short";
            col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            fChose.dataGridView_main.Columns.AddRange(new DataGridViewColumn[] { col0, col1, col2 });

            fChose.Text = "Ед.изм.";

            if (fChose.ShowDialog() == DialogResult.OK)
            {
                oItems.refMeasure = (int)fChose.xData[0];
                oItems.refMeasureName = fChose.xData[2].ToString();

                textBox_measure.DataBindings[0].ReadValue();
                textBox_measureRaw.DataBindings[0].ReadValue();

                //textBox_measure.Text = fChose.xData[1].ToString();
                //textBox_measure.Tag = fChose.xData;
            }
        }

        private void button_getMeasureForSale_Click(object sender, EventArgs e)
        {
            fChooser fChose = new fChooser("MEASURE");

            fChose.dataGridView_main.DataSource = dtMeasure;

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

            fChose.Text = "Ед.изм. продажная";

            if (fChose.ShowDialog() == DialogResult.OK)
            {
                oItems.refMeasureForSale = (int)fChose.xData[0];
                oItems.refMeasureNameForSale = fChose.xData[1].ToString();

                textBox_measureForSale.DataBindings[0].ReadValue();
            }
        }
    }
}
