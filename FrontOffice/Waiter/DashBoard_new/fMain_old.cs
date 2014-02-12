using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using com.sbs.dll.utilites;

namespace com.sbs.gui.dashboard
{
    public partial class fMain_old : Form
    {
        List<char> lDict = new List<char>(new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' });
        private DBaccess dbAccess = new DBaccess();
        private int curScene = 0;
        ctrDishes oCtrDishes;
        Bill oBill;

        enum zoneFocus { NULL, PANEL_LEFT, PANEL_RIGHT };
        enum action { NULL, SELECT_BILL, ADD_DISH };

        zoneFocus eCurZoneFocus;
        action eCurAction;
        zoneFocus ePrevZoneFocus;
        action ePrevAction;

        DataTable dtDishes;

        public fMain_old()
        {
            InitializeComponent();

            createBillObject();
        }

        #region MainFormKey

        private void fMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    escapeKey();
                    break;
                case Keys.F2:
                    newBill();
                    break;
                case Keys.Back:
                    backSpaceKey();
                    break;
            }
        }

        private void escapeKey()
        {
            Close();
        }

        private void backSpaceKey()
        {
            if (eCurZoneFocus == zoneFocus.NULL || eCurAction == action.NULL || ePrevZoneFocus == zoneFocus.NULL || ePrevAction == action.NULL) return;

            switch (ePrevZoneFocus)
            { 
                case zoneFocus.PANEL_LEFT:                          // Левая панель
                    switch (ePrevAction)
                    { 
                        case action.ADD_DISH:                           // Добавляем блюдо
                            break;

                        case action.SELECT_BILL:                        // Выбераем заказ
                            eCurZoneFocus = zoneFocus.PANEL_LEFT;
                            eCurAction = action.SELECT_BILL;

                            ePrevAction = action.NULL;
                            ePrevZoneFocus = zoneFocus.NULL;

                            tabControl_left.TabPages[0].Show();
                            tabControl_right.TabPages[0].Show();

                            tabControl_left.SelectedTab = tabControl_left.TabPages[0];
                            tabControl_right.SelectedTab = tabControl_right.TabPages[0];

                            foreach(Button ctr in flowLayoutPanel_currBills.Controls)
                            {
                                if (((Bill)ctr.Tag).id == oBill.id)
                                {
                                    ctr.Focus();
                                    return;
                                }
                            }
                            break;
                    }
                    break;
                case zoneFocus.PANEL_RIGHT:                         // Правая панель
                    break;
            }
        }

        #endregion

        private void newBill()
        {
            eCurZoneFocus = zoneFocus.PANEL_RIGHT;

            try
            {
                oBill = dbAccess.BillOpen("offline");
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
                return;
            }

            editBill(oBill);

        }

        private void createBillObject()
        {
            eCurZoneFocus = zoneFocus.PANEL_LEFT;
            eCurAction = action.SELECT_BILL;

            Button btnBill;

            foreach (Bill oBill in DashboardEnvironment.gBillList)
            {
                btnBill = new Button();
                btnBill.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);
                btnBill.UseVisualStyleBackColor = false;
                btnBill.TextAlign = ContentAlignment.MiddleLeft;
                btnBill.Height = 80;
                btnBill.Width = 325;
                btnBill.Click += new EventHandler(btnBill_Click);
                btnBill.GotFocus += new EventHandler(btnBill_GotFocus);
                btnBill.Text = "Счет № " + oBill.numb.ToString() + Environment.NewLine +
                                "Столик: " + oBill.table.ToString() + Environment.NewLine +
                                "Открыт: " + oBill.openDate.ToString() + Environment.NewLine;
                btnBill.Tag = oBill;
                flowLayoutPanel_currBills.Controls.Add(btnBill);
            }

            if (flowLayoutPanel_currBills.Controls.Count > 0)
            {
                flowLayoutPanel_currBills.Controls[0].Focus();
            }
        }

        void btnBill_GotFocus(object sender, EventArgs e)
        {
            getBillInfo((Bill)((Button)sender).Tag);
        }

        private void getBillInfo(Bill pBill)
        {
            List<Dish> oDishList;
            try
            {
                oDishList = dbAccess.getBillInfo("offline", pBill);
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
                return;
            }

            flowLayoutPanel_billInfo.Controls.Clear();

            foreach (Dish oDish in oDishList)
            {
                oCtrDishes = new ctrDishes();
                oCtrDishes.label_name.Text = oDish.name;
                oCtrDishes.numericUpDown_count.Value = oDish.count;
                oCtrDishes.label_portion.Text = oDish.portion;
                oCtrDishes.label_price.Text = (oDish.price * oDish.count).ToString();

                oCtrDishes.button_deals.Visible = false;
                oCtrDishes.button_topping.Visible = false;

                oCtrDishes.Width = flowLayoutPanel_billInfo.Width - 10;

                flowLayoutPanel_billInfo.Controls.Add(oCtrDishes);
            }
        }

        void btnBill_Click(object sender, EventArgs e)
        {
            flowLayoutPanel_editBill.Controls.Clear();

            editBill((Bill)((Button)sender).Tag);

            getBillInfoSmall();
        }

        private void getBillInfoSmall()
        {
            ctrDishesSmall oCtrDishesSmall;

            flowLayoutPanel_editBill.Controls.Clear();

            foreach (ctrDishes oCtr in flowLayoutPanel_billInfo.Controls)
            {
                oCtrDishesSmall = new ctrDishesSmall();

                oCtrDishesSmall.id = oCtr.id;
                oCtrDishesSmall.label_name.Text = oCtr.label_name.Text;
                oCtrDishesSmall.label_count.Text = oCtr.numericUpDown_count.Value.ToString("F2");
                oCtrDishesSmall.label_summa.Text = oCtr.label_price.Text;
                oCtrDishesSmall.button_host.Click += new EventHandler(button_hostSMALL_Click);

                oCtrDishesSmall.Width = flowLayoutPanel_editBill.Width - 10;

                flowLayoutPanel_editBill.Controls.Add(oCtrDishesSmall);
            }
        }

        void button_hostSMALL_Click(object sender, EventArgs e)
        {
            //ctrDishes oDishes = (ctrDishes)((ctrDishes)((Button)sender).Parent).Clone();
            //oDishes.numericUpDown_count.Value = 1;

            //oDishes.button_host.TabStop = false;
            //oDishes.numericUpDown_count.ReadOnly = false;
            //oDishes.numericUpDown_count.Focus();

            //fAddDishToBill faddDish2Bill = new fAddDishToBill(oBill, oDishes);
            //if (faddDish2Bill.ShowDialog() != DialogResult.OK) return;
        }

        private void editBill(Bill pBill)
        {
            oBill = pBill;

            ePrevZoneFocus = eCurZoneFocus;
            ePrevAction = eCurAction;

            eCurZoneFocus = zoneFocus.PANEL_RIGHT;
            eCurAction = action.ADD_DISH;

            label_billsInfo.Text = "Счет № " + oBill.numb.ToString() + Environment.NewLine +
                                    "Столик: " + oBill.table.ToString() + Environment.NewLine +
                                    "Открыт: " + oBill.openDate.ToString() + Environment.NewLine;

            tabControl_left.TabPages[1].Show();
            tabControl_left.SelectedTab = tabControl_left.TabPages[1];

            if (dtDishes == null) prepareCarteDishes();

            tabControl_right.TabPages[1].Show();
            tabControl_right.SelectedTab = tabControl_right.TabPages[1];
            treeView_CarteGroups.Focus();
        }

        private void prepareCarteDishes()
        {
            DataSet dsTables = new DataSet();
            DataTable dtBuf = new DataTable();

            TreeNode nodes;
            bool inPalce = false;

            try
            {
                dsTables = dbAccess.prepareCarteDishes("offline");
            }
            catch (Exception exc) { uMessage.Show("Неудалось сформировать меню.", exc, SystemIcons.Information); return; }

            dtBuf = dsTables.Tables["carte"];
            foreach (DataRow dr in dtBuf.Rows)
            {
                nodes = new TreeNode();
                nodes.Text = dr["name"].ToString();
                nodes.Name = "carte" + dr["id"].ToString();

                treeView_CarteGroups.Nodes.Add(nodes);
            }

            dtBuf = dsTables.Tables["group"];
            foreach (DataRow dr in dtBuf.Rows)
            {
                inPalce = false;
                nodes = new TreeNode();
                nodes.Text = dr["name"].ToString();
                nodes.Name = "group" + dr["id"].ToString();

                foreach(TreeNode tn in treeView_CarteGroups.Nodes.Find("group" + dr["id_parent"].ToString(), true))
                {
                    tn.Nodes.Add(nodes);
                    inPalce = true;
                }

                if (!inPalce)
                {
                    foreach (TreeNode tn in treeView_CarteGroups.Nodes.Find("carte" + dr["carte"].ToString(), true))
                    {
                        tn.Nodes.Add(nodes);
                    }
                }
            }

            dtDishes = dsTables.Tables["dishes"];
        }

        private void changeFocus()
        {
            
        }

        private void tabControl_left_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(tabControl_left.SelectedIndex)
            {
                case 0:
                    radioButton_curBills.Checked = true;
                    break;

                case 1:
                    radioButton_editBills.Checked = true;
                    break;
            }
        }

        private void tabControl_right_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl_right.SelectedIndex)
            {
                case 0:
                    radioButton_billInfo.Checked = true;
                    break;

                case 2:
                    radioButton_groups.Checked = true;
                    break;

                case 4:
                    radioButton_saintBox.Checked = true;
                    break;

                case 5:
                    radioButton_freePage.Checked = true;
                    break;
            }
        }

        private void treeView_CarteGroups_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int idGroup = 0;

            flowLayoutPanel_dish.Controls.Clear();

            if (treeView_CarteGroups.SelectedNode.Nodes.Count > 0) return; // Отсекаем не конечные пункты

            if(!int.TryParse(treeView_CarteGroups.SelectedNode.Name.Replace("group", ""), out idGroup)) return;

            foreach (DataRow dr in dtDishes.Select("carte_dishes_group = " + idGroup))
            {
                oCtrDishes = new ctrDishes();
                oCtrDishes.id = (int)dr["id"];
                oCtrDishes.label_name.Text = dr["name"].ToString();
                oCtrDishes.label_portion.Text = dr["portion"].ToString();
                oCtrDishes.label_price.Text = dr["price"].ToString();
                oCtrDishes.button_host.Click += new EventHandler(button_host_Click);
                
                oCtrDishes.button_topping.Visible = false;
                oCtrDishes.button_deals.Visible = false;
                oCtrDishes.numericUpDown_count.Visible = false;

                oCtrDishes.Width = flowLayoutPanel_dish.Width - 10;

                flowLayoutPanel_dish.Controls.Add(oCtrDishes);
            }
        }

        void button_host_Click(object sender, EventArgs e)
        {
            ctrDishes oDishes = (ctrDishes)((ctrDishes)((Button)sender).Parent).Clone();
            oDishes.numericUpDown_count.Value = 1;
            
            oDishes.button_host.TabStop = false;
            oDishes.numericUpDown_count.ReadOnly = false;
            oDishes.numericUpDown_count.Focus();

            fAddDishToBill faddDish2Bill = new fAddDishToBill(oBill, oDishes);
            if (faddDish2Bill.ShowDialog() != DialogResult.OK) return;

            getBillInfo(oBill);
            getBillInfoSmall();
        }

        private void treeView_CarteGroups_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Back:
                    fMain_KeyDown(null, e);
                    e.Handled = true;
                    break;
            }
        }
    }
}
