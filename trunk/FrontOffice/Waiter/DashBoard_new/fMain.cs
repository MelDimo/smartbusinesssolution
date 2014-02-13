using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;

namespace com.sbs.gui.dashboard
{
    public partial class fMain : Form
    {
        DBaccess dbAccess = new DBaccess();

        enum groupBox { BILL, BILLDISH, BILLINFO, GROUP, DISHES };
        groupBox curGroupBox;

        List<Bill> lBills;
        List<Dish> lDishs;

        DataTable dtDishes;
        
        bool errorOnInit = false;

        public fMain()
        {
            InitializeComponent();

            errorOnInit = fillBills();
        }

        private void fMain_Shown(object sender, EventArgs e)
        {
            if (!errorOnInit) Close();

            showBill();

            this.KeyDown += new KeyEventHandler(fMain_KeyDown);
        }

        #region Наполняем объекты 

        private bool fillBills()
        {
            lBills = new List<Bill>();

            try
            {
                lBills = dbAccess.getBills("offline");
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
                return false;
            }
            return true;
        }

        private bool fillBillsInfo(Bill pBill)
        {
            lDishs = new List<Dish>();

            try
            {
                lDishs = dbAccess.getBillInfo("offline", pBill);
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
                return false;
            }
            return true;
        }

        #endregion

        private void showBill()
        { 
            ctrBill oCtrBill;
            flowLayoutPanel_bills.Controls.Clear();

            foreach(Bill oBill in lBills)
            {
                oCtrBill = new ctrBill();
                oCtrBill.id = oBill.id;
                oCtrBill.label_numbBill.Text = oBill.numb.ToString();
                oCtrBill.label_numbTable.Text = oBill.table.ToString();
                oCtrBill.label_dateOpen.Text = oBill.openDate.ToString();
                oCtrBill.button_host.GotFocus += new EventHandler(Bill_button_host_GotFocus);
                oCtrBill.button_host.Click += new EventHandler(Bill_button_host_Click);
                oCtrBill.Tag = oBill;

                oCtrBill.Width = flowLayoutPanel_bills.Width - 10;

                flowLayoutPanel_bills.Controls.Add(oCtrBill);
            }

            if (flowLayoutPanel_bills.Controls.Count > 0)
            {
                flowLayoutPanel_bills.Controls[0].Focus();
            }

            this.Focus();

            curGroupBox = groupBox.BILL;

            groupBox_bills.BorderColor = Color.Blue;
        }

        void Bill_button_host_GotFocus(object sender, EventArgs e)
        {
            Bill curBill = (Bill)((ctrBill)((Button)sender).Parent).Tag;

            if (!fillBillsInfo(curBill)) return;

            ctrDishes oCtrDishes;
            flowLayoutPanel_billInfo.Controls.Clear();

            foreach (Dish oDish in lDishs)
            {
                oCtrDishes = new ctrDishes();
                oCtrDishes.id = oDish.id;
                oCtrDishes.label_name.Text = oDish.name;
                oCtrDishes.label_portion.Text = oDish.portion;
                oCtrDishes.label_price.Text = oDish.price.ToString("F2");
                oCtrDishes.numericUpDown_count.Value = oDish.count;

                oCtrDishes.TabStop = false;

                oCtrDishes.button_topping.Visible = false;
                oCtrDishes.button_deals.Visible = false;

                oCtrDishes.Width = flowLayoutPanel_billInfo.Width - 10;

                flowLayoutPanel_billInfo.Controls.Add(oCtrDishes);
            }
        }
        
        void Bill_button_host_Click(object sender, EventArgs e)
        {
            Bill curBill = (Bill)((ctrBill)((Button)sender).Parent).Tag;
            
            showBillInfo(curBill);
            prepareCarteDishes();
            
            tabControl_main.SelectedTab = tabControl_main.TabPages[1];
        }

        #region Редактирование заказа
        
        private void showBillInfo(Bill pCurBill)
        {
            flowLayoutPanel_billEdit.Controls.Clear();

            ctrBill oCtrBill = new ctrBill();
            ctrDishesSmall oCtrDishesSmall;

            oCtrBill = new ctrBill();
            oCtrBill.id = pCurBill.id;
            oCtrBill.label_numbBill.Text = pCurBill.numb.ToString();
            oCtrBill.label_numbTable.Text = pCurBill.table.ToString();
            oCtrBill.label_dateOpen.Text = pCurBill.openDate.ToString();
            oCtrBill.Tag = pCurBill;
            oCtrBill.TabStop = false;

            oCtrBill.Width = flowLayoutPanel_billEdit.Width - 10;

            flowLayoutPanel_billEdit.Controls.Add(oCtrBill);

            foreach (Dish oDish in lDishs)
            {
                oCtrDishesSmall = new ctrDishesSmall();
                oCtrDishesSmall.id = oDish.id;
                oCtrDishesSmall.label_name.Text = oDish.name;
                oCtrDishesSmall.label_count.Text = oDish.count.ToString("F2");
                oCtrDishesSmall.label_summa.Text = (oDish.count * oDish.price).ToString("F2");

                oCtrDishesSmall.TabStop = false;

                oCtrDishesSmall.Width = flowLayoutPanel_billEdit.Width - 10;

                flowLayoutPanel_billEdit.Controls.Add(oCtrDishesSmall);
            }
        }

        private void prepareCarteDishes()
        {
            DataSet dsTables = new DataSet();
            DataTable dtBuf = new DataTable();

            TreeNode nodes;
            bool inPalce = false;

            treeView_CarteGroups.Nodes.Clear();

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

                foreach (TreeNode tn in treeView_CarteGroups.Nodes.Find("group" + dr["id_parent"].ToString(), true))
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

        private void treeView_CarteGroups_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int idGroup = 0;
            ctrDishes oCtrDishes;

            flowLayoutPanel_dish.Controls.Clear();

            if (treeView_CarteGroups.SelectedNode.Nodes.Count > 0) return; // Отсекаем не конечные пункты

            if (!int.TryParse(treeView_CarteGroups.SelectedNode.Name.Replace("group", ""), out idGroup)) return;

            foreach (DataRow dr in dtDishes.Select("carte_dishes_group = " + idGroup))
            {
                oCtrDishes = new ctrDishes();
                oCtrDishes.id = (int)dr["id"];
                oCtrDishes.label_name.Text = dr["name"].ToString();
                oCtrDishes.label_portion.Text = dr["portion"].ToString();
                oCtrDishes.label_price.Text = dr["price"].ToString();
                oCtrDishes.button_host.Click += new EventHandler(Dish_button_host_Click);

                oCtrDishes.TabStop = false;
                oCtrDishes.button_topping.Visible = false;
                oCtrDishes.button_deals.Visible = false;
                oCtrDishes.numericUpDown_count.Visible = false;

                oCtrDishes.Width = flowLayoutPanel_dish.Width - 10;

                flowLayoutPanel_dish.Controls.Add(oCtrDishes);
            }
        }

        private void Dish_button_host_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private void tabControl_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(tabControl_main.SelectedIndex)
            {
                case 0:
                    //MessageBox.Show("0");
                    break;
                case 1:
                    //MessageBox.Show("1");
                    break;
            }
        }

        void fMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    SendKeys.Send("+{TAB}");
                    break;

                case Keys.Down:
                    SendKeys.Send("{TAB}");
                    break;

                case Keys.Left:
                    changeGroup("LEFT");
                    break;

                case Keys.Right:
                    changeGroup("RIGHT");
                    break;

                case Keys.Escape:
                    closeForm();
                    break;

                case Keys.Back:
                    break;
            }
        }

        private void changeGroup(string pDirection)
        {
            switch (curGroupBox)
            { 
                case groupBox.BILL:
                    break;

                case groupBox.BILLDISH:
                    break;

                case groupBox.BILLINFO:
                    break;

                case groupBox.DISHES:
                    break;

                case groupBox.GROUP:
                    break;
            }
        }

        private void closeForm()
        {
            Close();
        }

        
    }
}
