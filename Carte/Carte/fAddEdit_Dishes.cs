﻿using System;
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
        DBAccess dbAccess = new DBAccess();

        DTO.CarteDishes oCarteDishes;
        public DataTable dtDishes;

        private int branchId;
        private string formMode; // В каком режиме диалог "EDIT"/"ADD"
        private int checkRefDish = 0; // 1 - есть необходимость проверять блюдо, 0 - нет необходимости.

        public fAddEdit_Dishes(DTO.CarteDishes pCarteDishes, int pBranchId)
        {
            oCarteDishes = pCarteDishes;
            branchId = pBranchId;

            if (oCarteDishes.id == 0) formMode = "ADD";
            else
            {
                formMode = "EDIT";
                getDiscountType();
                
            }

            InitializeComponent();
        }

        private void getDiscountType()
        {
            try
            {
                oCarteDishes.refDiscountType = dbAccess.dishes_discount(GValues.DBMode, oCarteDishes.id);
            }
            catch (Exception exc)
            {
                uMessage.Show("Неудалось получить данные по дисконтным картам.", exc, SystemIcons.Information);
            }
        }

        private void initRefDishes()
        {
            var dishInfo = from rec in dtDishes.AsEnumerable()
                           where rec.Field<int>("id") == oCarteDishes.refDishes
                           select rec.Field<string>("name");

            if(dishInfo.Count() != 1)
            {
                MessageBox.Show("С данной позицией нет связанного блюда либо связей больше одной!" + Environment.NewLine +
                    "Данное отклонение является критическим, обратитесь к разработчику!"
                    , GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            textBox_refDishesName.Text = dishInfo.First<string>();
        }

        private void fAddEdit_Dishes_Shown(object sender, EventArgs e)
        {
            textBox_id.DataBindings.Add("Text", oCarteDishes, "id");
            textBox_name.DataBindings.Add("Text", oCarteDishes, "name");
            numericUpDown_price.DataBindings.Add("Value", oCarteDishes, "price");
            numericUpDown_minStep.DataBindings.Add("Value", oCarteDishes, "minStep");
            if (formMode.Equals("EDIT")) checkBox_isVisible.Checked = oCarteDishes.isVisible == 1 ? true : false;
            if (formMode.Equals("EDIT")) checkBox_AvalHall.Checked = oCarteDishes.avalHall == 1 ? true : false;
            if (formMode.Equals("EDIT")) checkBox_AvalDelivery.Checked = oCarteDishes.avalDelivery == 1 ? true : false;
            if (formMode.Equals("EDIT")) initRefDishes();

            checkedListBox_discount.DataSource = ReferData.dtDiscountType;
            checkedListBox_discount.DisplayMember = "name";
            checkedListBox_discount.ValueMember = "id";

            foreach (int discount in oCarteDishes.refDiscountType)
            {
                for (int i = 0; i < checkedListBox_discount.Items.Count; i++)
                    if (((int)((DataRowView)checkedListBox_discount.Items[i])["id"]) == discount) checkedListBox_discount.SetItemChecked(i, true);
            }
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
                if (oCarteDishes.refDishes != (int)fChose.xData[0] && formMode.Equals("EDIT")) checkRefDish = 1;

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

            oCarteDishes.refDiscountType.Clear();
            for (int i = 0; i < checkedListBox_discount.Items.Count; i++)
            {
                DataRowView view = checkedListBox_discount.Items[i] as DataRowView;
                if (checkedListBox_discount.GetItemChecked(i)) oCarteDishes.refDiscountType.Add((int)view["id"]);
            }

            if (comboBox_group.SelectedIndex == -1) errMsg += Environment.NewLine + "- Группа;";
            else oCarteDishes.carteDishesGroup = (int)comboBox_group.SelectedValue;
            if (oCarteDishes.name.Length == 0) errMsg += Environment.NewLine + "- Наименование;";
            if (oCarteDishes.refDishes == 0) errMsg += Environment.NewLine + "- Блюдо;";
            if (comboBox_refStatus.SelectedIndex == -1) errMsg += Environment.NewLine + "- Статус;";
            else
            {
                if (oCarteDishes.refStatus != (int)comboBox_refStatus.SelectedValue) checkRefDish = 1;
                oCarteDishes.refStatus = (int)comboBox_refStatus.SelectedValue;
            }
            if (comboBox_refPrintersType.SelectedIndex == -1) errMsg += Environment.NewLine + "- Тип принтера;";
            else oCarteDishes.refPrintersType = (int)comboBox_refPrintersType.SelectedValue;

            oCarteDishes.isVisible = checkBox_isVisible.Checked ? 1 : 0;
            oCarteDishes.avalHall = checkBox_AvalHall.Checked ? 1 : 0;
            oCarteDishes.avalDelivery = checkBox_AvalDelivery.Checked ? 1 : 0;

            if (oCarteDishes.avalHall + oCarteDishes.avalDelivery == 0) errMsg += Environment.NewLine + "- Позиция не привязана к меню;";

            oCarteDishes.price = numericUpDown_price.Value;
            oCarteDishes.minStep = numericUpDown_minStep.Value;

            if (!errMsg.Equals("Зполнены не все обязательные поля:"))
            {
                MessageBox.Show(errMsg, GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            try
            {
                if (formMode.Equals("ADD"))
                    dbAccess.dishes_add(GValues.DBMode, oCarteDishes, branchId);
                else
                    dbAccess.dishes_edit(GValues.DBMode, oCarteDishes, branchId, checkRefDish);
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

        private void button_topping_Click(object sender, EventArgs e)
        {
            fTopping fTopp = new fTopping(oCarteDishes, (DataTable)comboBox_refStatus.DataSource);
            fTopp.ShowDialog();
        }

    }
}
