using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll;
using com.sbs.dll.utilites;

namespace com.sbs.gui.carte
{
    public partial class fAddEdit_Dishes : Form
    {
        DBAccess bdAccess = new DBAccess();

        DTO.CarteDishes oCarteDishes;
        public DataTable dtDishes;

        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        public fAddEdit_Dishes(DTO.CarteDishes pCarteDishes)
        {
            oCarteDishes = pCarteDishes;

            if (oCarteDishes.id == 0) formMode = "ADD";
            else formMode = "EDIT";

            InitializeComponent();
        }

        private void initRefDishes()
        {
            DataRow dishInfo = (from rec in dtDishes.AsEnumerable()
                                where rec.Field<int>("id") == oCarteDishes.refDishes
                                select rec).First();

            textBox_refDishesName.Text = dishInfo.Field<string>("name");
        }

        private void fAddEdit_Dishes_Shown(object sender, EventArgs e)
        {
            textBox_id.DataBindings.Add("Text", oCarteDishes, "id");
            textBox_name.DataBindings.Add("Text", oCarteDishes, "name");
            numericUpDown_price.DataBindings.Add("Value", oCarteDishes, "price");
            numericUpDown_minStep.DataBindings.Add("Value", oCarteDishes, "minStep");
            if (formMode.Equals("EDIT")) checkBox_isVisible.Checked = oCarteDishes.isVisible == 1 ? true : false;
            if (formMode.Equals("EDIT")) initRefDishes();
        }

        private void button_getDishes_Click(object sender, EventArgs e)
        {
            fChooser fChose = new fChooser("REFDISHES", "name", "id", textBox_refDishesName.Text);

            fChose.dataGridView_main.DataSource = dtDishes;

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = "id";
            col0.Name = "id";
            col0.DataPropertyName = "id";
            col0.Visible = false;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Ключ";
            col1.Name = "code";
            col1.DataPropertyName = "code";
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Наименование";
            col2.Name = "name";
            col2.DataPropertyName = "name";
            col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "Цена";
            col3.Name = "price";
            col3.DataPropertyName = "price";
            col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            DataGridViewTextBoxColumn col4 = new DataGridViewTextBoxColumn();
            col4.HeaderText = "Тип принтера";
            col4.Name = "ref_printers_type_name";
            col4.DataPropertyName = "ref_printers_type_name";
            col4.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            DataGridViewTextBoxColumn col5 = new DataGridViewTextBoxColumn();
            col5.HeaderText = "Статус";
            col5.Name = "ref_status_name";
            col5.DataPropertyName = "ref_status_name";
            col5.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            DataGridViewTextBoxColumn col6 = new DataGridViewTextBoxColumn();
            col6.HeaderText = "ref_status";
            col6.Name = "ref_status";
            col6.DataPropertyName = "ref_status";
            col6.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            col6.Visible = false;

            DataGridViewTextBoxColumn col7 = new DataGridViewTextBoxColumn();
            col7.HeaderText = "ref_printers_type";
            col7.Name = "ref_printers_type";
            col7.DataPropertyName = "ref_printers_type";
            col7.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            col7.Visible = false;

            fChose.dataGridView_main.Columns.AddRange(new DataGridViewColumn[] { col0, col1, col2, col3, col4, col5, col6, col7 });

            fChose.Text = "Выбор блюда";
            if (fChose.ShowDialog() == DialogResult.OK)
            {
                oCarteDishes.refDishes = (int)fChose.xData[0];
                textBox_refDishesName.Text = fChose.xData[1].ToString();
                oCarteDishes.price = (decimal)fChose.xData[2];
                oCarteDishes.refStatus = (int)fChose.xData[3];
                oCarteDishes.refPrintersType = (int)fChose.xData[4];
                oCarteDishes.name = fChose.xData[1].ToString();

                textBox_name.DataBindings[0].ReadValue();
                numericUpDown_price.DataBindings[0].ReadValue();
                numericUpDown_minStep.DataBindings[0].ReadValue();
                comboBox_refStatus.SelectedValue = oCarteDishes.refStatus;
                comboBox_refPrintersType.SelectedValue = oCarteDishes.refPrintersType;
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (!saveData()) return;
            DialogResult = DialogResult.OK;
        }

        private bool saveData()
        {
            string errMsg = "Зполнены не все обязательные поля:";

            if (comboBox_group.SelectedIndex == -1) errMsg += Environment.NewLine + "- Группа;";
            else oCarteDishes.carteDishesGroup = (int)comboBox_group.SelectedValue;
            if (oCarteDishes.name.Length == 0) errMsg += Environment.NewLine + "- Наименование;";
            if (oCarteDishes.refDishes == 0) errMsg += Environment.NewLine + "- Блюдо;";
            if (comboBox_refStatus.SelectedIndex == -1) errMsg += Environment.NewLine + "- Статус;";
            else oCarteDishes.refStatus = (int)comboBox_refStatus.SelectedValue;
            if (comboBox_refPrintersType.SelectedIndex == -1) errMsg += Environment.NewLine + "- Тип принтера;";
            else oCarteDishes.refPrintersType = (int)comboBox_refPrintersType.SelectedValue;

            oCarteDishes.isVisible = checkBox_isVisible.Checked ? 1 : 0;

            if (!errMsg.Equals("Зполнены не все обязательные поля:"))
            {
                MessageBox.Show(errMsg, GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            try
            {
                if (formMode.Equals("ADD"))
                    bdAccess.dishes_add("offline", oCarteDishes);
                else
                    bdAccess.dishes_edit("offline", oCarteDishes);
            }
            catch (Exception exc)
            {
                uMessage.Show("Нуедалось сохранить меню.", exc, SystemIcons.Information);
                return false;
            }

            return true;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }


    }
}
