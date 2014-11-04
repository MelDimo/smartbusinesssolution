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

namespace com.sbs.gui.deals
{
    public partial class fDealsAddEdit : Form
    {
        getReference oReferences = new getReference();
        DBAccess dbAccess = new DBAccess();

        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        private DTO.Carte oCarte;
        private DTO.Deals oDeals;

        public fDealsAddEdit(DTO.Carte pCarte, DTO.Deals pDeals)
        {
            oCarte = pCarte;
            oDeals = pDeals;

            InitializeComponent();

            dataGridView_dish.AutoGenerateColumns = false;
            dataGridView_bonus.AutoGenerateColumns = false;

            tSButton_bonusAdd.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSButton_bonusDel.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;

            tSButton_dishAdd.Image = com.sbs.dll.utilites.Properties.Resources.add_26;
            tSButton_dishDel.Image = com.sbs.dll.utilites.Properties.Resources.delete_26;

            if (oDeals.id == 0) formMode = "ADD";
            else formMode = "EDIT";

            setValues();
        }

        private void setValues()
        {
            textBox_dealsId.Text = oDeals.id.ToString();
            textBox_dealsName.Text = oDeals.name;
            numericUpDown_sumCount.Value = oDeals.sumCount;

            comboBox_dealsStatus.DataSource = RefData.dtRefStatus;
            comboBox_dealsStatus.DisplayMember = "name";
            comboBox_dealsStatus.ValueMember = "id";
            comboBox_dealsStatus.SelectedValue = oDeals.refStatus == 0 ? 1 : oDeals.refStatus;

            var blistDish = new BindingSource();
            blistDish.DataSource = oDeals.lCarteDishes;
            var blistBonus = new BindingSource();
            blistBonus.DataSource = oDeals.lCarteDishesBonus;

            dataGridView_dish.DataSource = blistDish;
            dataGridView_dish.Columns["dish_refDishes"].DataPropertyName = "refDishes";
            dataGridView_dish.Columns["dish_name"].DataPropertyName = "name";
            dataGridView_dish.Columns["dish_price"].DataPropertyName = "price";

            dataGridView_bonus.DataSource = blistBonus;
            dataGridView_bonus.Columns["bonus_refDishes"].DataPropertyName = "refDishes";
            dataGridView_bonus.Columns["bonus_name"].DataPropertyName = "name";
            dataGridView_bonus.Columns["bonus_price"].DataPropertyName = "price";
        }

        private void tSButton_dishAdd_Click(object sender, EventArgs e)
        {
            DataTable dtDishes = new DataTable();
            try
            {
                dtDishes = oReferences.getCarteDishes_Carte(GValues.DBMode, oCarte.id);
            }
            catch (Exception exc)
            {
                uMessage.Show("Не удалось получить список блюд.", exc, SystemIcons.Information);

            }

            getDishes(dtDishes, "dish");

        }

        private void getDishes(DataTable pDtDishes, string pTypeDish)
        {
            fChooser fChose = new fChooser("REFDISHES", "name", "id", "");

            fChose.dataGridView_main.DataSource = pDtDishes;

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = "id";
            col0.Name = "id";
            col0.DataPropertyName = "ref_dishes"; // (!)
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
                DTO.CarteDishes oCarteDishes;

                switch(pTypeDish)
                {
                    case "dish":
                        oCarteDishes = new DTO.CarteDishes()
                        {
                            refDishes = (int)fChose.xData[0],
                            price = (decimal)fChose.xData[2],
                            refStatus = (int)fChose.xData[3],
                            name = fChose.xData[1].ToString()
                        };

                        foreach(DTO.CarteDishes cd in oDeals.lCarteDishes)
                        {
                            if (cd.refDishes.Equals(oCarteDishes.refDishes))
                            {
                                MessageBox.Show(string.Format("Элемент [{0}] уже существует в списке", cd.name), GValues.prgNameFull, 
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

                        oDeals.lCarteDishes.Add(oCarteDishes);

                        dataGridView_dish.DataSource = null;
                
                        var blist = new BindingSource();
                        blist.DataSource = oDeals.lCarteDishes;

                        dataGridView_dish.DataSource = blist;
                        dataGridView_dish.Columns["dish_refDishes"].DataPropertyName = "refDishes";
                        dataGridView_dish.Columns["dish_name"].DataPropertyName = "name";
                        dataGridView_dish.Columns["dish_price"].DataPropertyName = "price";
                        break;

                    case "bonus":
                        oCarteDishes = new DTO.CarteDishes()
                        {
                            refDishes = (int)fChose.xData[0],
                            price = (decimal)fChose.xData[2],
                            refStatus = (int)fChose.xData[3],
                            name = fChose.xData[1].ToString()
                        };

                        foreach(DTO.CarteDishes cd in oDeals.lCarteDishesBonus)
                        {
                            if (cd.refDishes.Equals(oCarteDishes.refDishes))
                            {
                                MessageBox.Show(string.Format("Элемент [{0}] уже существует в списке", cd.name), GValues.prgNameFull, 
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }

                        oDeals.lCarteDishesBonus.Add(oCarteDishes);

                        dataGridView_bonus.DataSource = null;
                
                        var blistBonus = new BindingSource();
                        blistBonus.DataSource = oDeals.lCarteDishesBonus;

                        dataGridView_bonus.DataSource = blistBonus;
                        dataGridView_bonus.Columns["bonus_refDishes"].DataPropertyName = "refDishes";
                        dataGridView_bonus.Columns["bonus_name"].DataPropertyName = "name";
                        dataGridView_bonus.Columns["bonus_price"].DataPropertyName = "price";
                        break;

                }
            }
        }

        private void tSButton_dishDel_Click(object sender, EventArgs e)
        {
            if (dataGridView_dish.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент который хотите исключить", GValues.prgNameFull, 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            oDeals.lCarteDishes.RemoveAt(dataGridView_dish.SelectedRows[0].Index);

            var blist = new BindingSource();
            blist.DataSource = oDeals.lCarteDishes;

            dataGridView_dish.DataSource = blist;
            dataGridView_dish.Columns["dish_refDishes"].DataPropertyName = "refDishes";
            dataGridView_dish.Columns["dish_name"].DataPropertyName = "name";
            dataGridView_dish.Columns["dish_price"].DataPropertyName = "price";
        }

        private void tSButton_bonusAdd_Click(object sender, EventArgs e)
        {
            DataTable dtDishes = new DataTable();
            try
            {
                dtDishes = oReferences.getCarteDishes_Carte(GValues.DBMode, oCarte.id);
            }
            catch (Exception exc)
            {
                uMessage.Show("Не удалось получить список блюд.", exc, SystemIcons.Information);

            }

            getDishes(dtDishes, "bonus");
        }

        private void tSButton_bonusDel_Click(object sender, EventArgs e)
        {
            if (dataGridView_bonus.SelectedRows.Count == 0)
            {
                MessageBox.Show("Укажите элемент который хотите исключить", GValues.prgNameFull,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            oDeals.lCarteDishesBonus.RemoveAt(dataGridView_bonus.SelectedRows[0].Index);

            var blist = new BindingSource();
            blist.DataSource = oDeals.lCarteDishesBonus;

            dataGridView_bonus.DataSource = blist;
            dataGridView_bonus.Columns["bonus_refDishes"].DataPropertyName = "refDishes";
            dataGridView_bonus.Columns["bonus_name"].DataPropertyName = "name";
            dataGridView_bonus.Columns["bonus_price"].DataPropertyName = "price";
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (!checkData()) return;

            switch (formMode)
            { 
                case "ADD":
                    saveData();
                    break;

                case "EDIT":
                    updateData();
                    break;
            }
            
        }

        private void updateData()
        {
            try
            {
                dbAccess.updateData(GValues.DBMode, oDeals);
            }
            catch (Exception exc) { uMessage.Show("Неудалось сохранить данные.", exc, SystemIcons.Information); return; }
        }

        private void saveData()
        {
            try
            {
                dbAccess.saveData(GValues.DBMode, oDeals);
            }
            catch (Exception exc) { uMessage.Show("Неудалось сохранить данные.", exc, SystemIcons.Information); return; }
        }

        private bool checkData()
        {
            string errMsg = "Заполнены не все обязательные поля";

            oDeals.name = textBox_dealsName.Text.Trim();
            oDeals.sumCount = (int)numericUpDown_sumCount.Value;
            oDeals.dateStart = dateTimePicker_start.Value;
            oDeals.refStatus = (int)comboBox_dealsStatus.SelectedValue;
            oDeals.carte = oCarte.id;

            if (dateTimePicker_end.Checked) oDeals.dateEnd = dateTimePicker_end.Value;

            if (string.Empty.Equals(oDeals.name)) errMsg += Environment.NewLine + "- Наименование;";
            if (oDeals.refStatus == 0) errMsg += Environment.NewLine + "- Статус;";
            if (checkBox_sumCount.Checked && oDeals.sumCount == 0) errMsg += Environment.NewLine + "- Суммарное кол-во = 0;";

            if (oDeals.lCarteDishes.Count == 0) errMsg += Environment.NewLine + "- Количество позиций участвующих в акции = 0;";
            if (oDeals.lCarteDishesBonus.Count == 0) errMsg += Environment.NewLine + "- Количество бонусных позиций = 0;";

            if (!errMsg.Equals("Заполнены не все обязательные поля"))
            {
                MessageBox.Show(errMsg, GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
    }
}

