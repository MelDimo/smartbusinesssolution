using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;
using System.Diagnostics;
using com.sbs.dll;
using CrystalDecisions.CrystalReports.Engine;

namespace com.sbs.gui.dashboard
{
    public partial class fMain : Form
    {
        DBaccess dbAccess = new DBaccess();
        Suppurt Supp = new Suppurt();

        enum groupBox { BILL, BILLDISH, BILLINFO, GROUP, DISHES };
        groupBox _curGroupBox;
        groupBox curGroupBox
        {
            get { return _curGroupBox; }
            set
            {
                _curGroupBox = value;
                switch (value)
                {
                    case groupBox.BILL:
                        groupBox_bills.BorderColor = Color.Blue;
                        groupBox_billDish.BorderColor = Color.Gray;
                        groupBox_billInfo.BorderColor = Color.Gray;
                        groupBox_groups.BorderColor = Color.Gray;
                        groupBox_dish.BorderColor = Color.Gray;

                        //groupBox_bills.Enabled = true;
                        //groupBox_billDish.Enabled = false;
                        //groupBox_billInfo.Enabled = false;
                        //groupBox_groups.Enabled = false;
                        //groupBox_dish.Enabled = false;

                        Debug.Print("SET groupBox_bills.BorderColor");
                        break;

                    case groupBox.BILLDISH:
                        groupBox_bills.BorderColor = Color.Gray;
                        groupBox_billDish.BorderColor = Color.Blue;
                        groupBox_billInfo.BorderColor = Color.Gray;
                        groupBox_groups.BorderColor = Color.Gray;
                        groupBox_dish.BorderColor = Color.Gray;

                        //groupBox_bills.Enabled = false;
                        //groupBox_billDish.Enabled = true;
                        //groupBox_billInfo.Enabled = false;
                        //groupBox_groups.Enabled = false;
                        //groupBox_dish.Enabled = false;

                        Debug.Print("SET groupBox_billDish.BorderColor");
                        break;

                    case groupBox.BILLINFO:
                        groupBox_bills.BorderColor = Color.Gray;
                        groupBox_billDish.BorderColor = Color.Gray;
                        groupBox_billInfo.BorderColor = Color.Blue;
                        groupBox_groups.BorderColor = Color.Gray;
                        groupBox_dish.BorderColor = Color.Gray;

                        //groupBox_bills.Enabled = false;
                        //groupBox_billDish.Enabled = false;
                        //groupBox_billInfo.Enabled = true;
                        //groupBox_groups.Enabled = false;
                        //groupBox_dish.Enabled = false;

                        Debug.Print("SET groupBox_billInfo.BorderColor");
                        break;

                    case groupBox.DISHES:
                        groupBox_bills.BorderColor = Color.Gray;
                        groupBox_billDish.BorderColor = Color.Gray;
                        groupBox_billInfo.BorderColor = Color.Gray;
                        groupBox_groups.BorderColor = Color.Gray;
                        groupBox_dish.BorderColor = Color.Blue;

                        //groupBox_bills.Enabled = false;
                        //groupBox_billDish.Enabled = false;
                        //groupBox_billInfo.Enabled = false;
                        //groupBox_groups.Enabled = false;
                        //groupBox_dish.Enabled = true;

                        Debug.Print("SET groupBox_dish.BorderColor");
                        break;

                    case groupBox.GROUP:
                        groupBox_bills.BorderColor = Color.Gray;
                        groupBox_billDish.BorderColor = Color.Gray;
                        groupBox_billInfo.BorderColor = Color.Gray;
                        groupBox_groups.BorderColor = Color.Blue;
                        groupBox_dish.BorderColor = Color.Gray;

                        //groupBox_bills.Enabled = false;
                        //groupBox_billDish.Enabled = false;
                        //groupBox_billInfo.Enabled = false;
                        //groupBox_groups.Enabled = true;
                        //groupBox_dish.Enabled = false;

                        Debug.Print("SET groupBox_groups.BorderColor");
                        break;
                }
                this.Refresh();
            }
        }

        List<Bill> lBills;
        List<Dish> lDishs;

        Bill curBill;

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
                oCtrBill.label_summ.Text = oBill.summ.ToString("F2");
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

            foreach (ctrBill ctr in flowLayoutPanel_bills.Controls)
            {
                ctr.TabStop = true;
            }

            curGroupBox = groupBox.BILL;
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
            curBill = (Bill)((ctrBill)((Button)sender).Parent).Tag;
            
            billEdit();
        }

        private void billEdit()
        {
            showBillInfo();

            if (dtDishes == null) prepareCarteDishes();

            foreach (ctrBill ctr in flowLayoutPanel_bills.Controls)
            {
                ctr.TabStop = false;
            }

            curGroupBox = groupBox.GROUP;

            treeView_CarteGroups.Focus();

            panel_dishes.BringToFront();
        }

        #region ----------------------------------------------------------------- Редактирование заказа
        
        private void showBillInfo()
        {
            flowLayoutPanel_billEdit.Controls.Clear();

            ctrBill oCtrBill = new ctrBill();
            ctrDishesSmall oCtrDishesSmall;

            oCtrBill = new ctrBill();
            oCtrBill.id = curBill.id;
            oCtrBill.label_numbBill.Text = curBill.numb.ToString();
            oCtrBill.label_numbTable.Text = curBill.table.ToString();
            oCtrBill.label_dateOpen.Text = curBill.openDate.ToString();
            oCtrBill.Tag = curBill;
            oCtrBill.TabStop = false;

            oCtrBill.Width = panel_billInfo.Width - 10;

            panel_billInfo.Controls.Add(oCtrBill);

            foreach (Dish oDish in lDishs)
            {
                oCtrDishesSmall = new ctrDishesSmall();
                oCtrDishesSmall.id = oDish.id;
                oCtrDishesSmall.label_name.Text = oDish.name;
                oCtrDishesSmall.label_count.Text = oDish.count.ToString("F2");
                oCtrDishesSmall.label_summa.Text = (oDish.count * oDish.price).ToString("F2");
                                                                                    // Обработан : Необработан
                oCtrDishesSmall.pictureBox_status.BackColor = oDish.refStatus == 24 ? Color.Red : Color.Green;

                oCtrDishesSmall.TabStop = false;

                oCtrDishesSmall.Width = flowLayoutPanel_billEdit.Width - 10;

                flowLayoutPanel_billEdit.Controls.Add(oCtrDishesSmall);
            }

            panel_dishes.Refresh();
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
            Dish oDish = new Dish();
            ctrDishes oCtrDishes = (ctrDishes)((ctrDishes)((Button)sender).Parent).Clone();

            fAddDishToBill faddDish2Bill = new fAddDishToBill(curBill, oCtrDishes);
            if (faddDish2Bill.ShowDialog() == DialogResult.OK)
            {
                fillBillsInfo(curBill);
                showBillInfo();
            }
        }

        #endregion

        #region ----------------------------------------------------------------- Обработка курсора. Навигация

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                    if (curGroupBox != groupBox.GROUP)
                        SendKeys.Send("+{TAB}");
                    break;

                case Keys.Down:
                    if (curGroupBox != groupBox.GROUP)
                        SendKeys.Send("{TAB}");
                    break;

                case Keys.Left | Keys.Control:
                    changeGroup("LEFT");
                    break;

                case Keys.Right | Keys.Control:
                    changeGroup("RIGHT");
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void changeGroup(string pDirection)
        {
            Debug.Print(curGroupBox.ToString() + " | " + "pDirection: " + pDirection);
            switch (curGroupBox)
            { 
                case groupBox.BILL:
                    break;

                case groupBox.BILLDISH:
                    break;

                case groupBox.BILLINFO:
                    switch (pDirection)
                    {
                        case "RIGHT":
                            foreach (ctrDishesSmall ctr in flowLayoutPanel_billEdit.Controls)
                            {
                                ctr.TabStop = false;
                            }
                            treeView_CarteGroups.Focus();

                            curGroupBox = groupBox.GROUP;
                            break;
                    }
                    break;

                case groupBox.DISHES:
                    switch (pDirection)
                    {
                        case "LEFT":
                            foreach (ctrDishes ctr in flowLayoutPanel_dish.Controls)
                            {
                                ctr.TabStop = false;
                            }
                            treeView_CarteGroups.Focus();

                            curGroupBox = groupBox.GROUP;
                            break;
                    }
                    break;

                case groupBox.GROUP:
                    switch (pDirection)
                    { 
                        case "LEFT":
                            if (flowLayoutPanel_billEdit.Controls.Count > 1)
                            {
                                foreach (ctrDishesSmall ctr in flowLayoutPanel_billEdit.Controls)
                                {
                                    ctr.TabStop = true;
                                }
                                flowLayoutPanel_billEdit.Controls[0].Focus();
                            }
                            else 
                                button_trapFocus.Focus();

                            curGroupBox = groupBox.BILLINFO;
                            break;

                        case "RIGHT":
                            if (flowLayoutPanel_dish.Controls.Count > 0)
                            {
                                foreach (ctrDishes ctr in flowLayoutPanel_dish.Controls)
                                {
                                    ctr.TabStop = true;
                                }
                                flowLayoutPanel_dish.Controls[0].Focus();
                            }
                            else
                                button_trapFocus.Focus();

                            curGroupBox = groupBox.DISHES;
                            break;
                    }
                    break;
            }
        }

        #endregion

        #region ----------------------------------------------------------------- Функциональные клавиши

        private void fMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.F2:   //Новый заказ
                    if (curGroupBox == groupBox.BILL)
                    {
                        openBill();
                    }
                    break;

                case Keys.F3:   // Печать бегунков
                    if (curGroupBox != groupBox.BILL)
                    {
                        commitDish();
                    }
                    break;

                case Keys.F5:   // Печать чека
                    if (curGroupBox == groupBox.BILL)
                    {
                        printBill();
                    }
                    break;

                case Keys.Escape:
                    if (curGroupBox != groupBox.BILL) keysBackspace();
                    else closeForm();
                    break;

                case Keys.Back:
                    if (curGroupBox == groupBox.BILLINFO)
                        if (!checkBillInfo()) return;
                    keysBackspace();
                    break;

                case Keys.Space:
                    if (curGroupBox == groupBox.GROUP)
                        if (treeView_CarteGroups.SelectedNode.IsExpanded) treeView_CarteGroups.SelectedNode.Collapse();
                        else treeView_CarteGroups.SelectedNode.Expand();
                    break;
            }
        }

        private void printBill()
        {
            DataTable dtResult = new DataTable();
            ReportDocument repDoc;

            if (curBill == null) return;

            try
            {
                dtResult = dbAccess.billClose("offline", curBill);
            }
            catch (Exception exc) { uMessage.Show("Не удалось закрыть счет.", exc, SystemIcons.Information); return; }

            if (dtResult.Rows.Count == 0) return;

            repDoc = new ReportDocument();
            repDoc.Load(dtResult.Rows[0]["reportPath"].ToString());
            repDoc.SetDataSource(dtResult);
            repDoc.SetParameterValue("waiterName", DashboardEnvironment.gUser.name);
            repDoc.PrintOptions.PrinterName = dtResult.Rows[0]["printerName"].ToString();
            repDoc.PrintToPrinter(1, false, 0, 0);

            fillBills();
            showBill();
        }

        private void commitDish()
        {
            DataTable dtResult = new DataTable();
            ReportDocument repDoc;

            bool flag = false;
            
            try
            {
                dtResult = dbAccess.commitDish("offline", curBill);
            }
            catch (Exception exc) { uMessage.Show("Не удалось исключить необработанные позиции.", exc, SystemIcons.Information); return; }

            var results_1 = from myRow in dtResult.AsEnumerable()
                            where myRow.Field<int>("ref_printers_type") == 1
                            select myRow;

            if (results_1.Count() > 0) // есть позиции на принтер Кухни
            {
                repDoc = new ReportDocument();
                repDoc.Load(results_1.First().Field<string>("reportPath"));
                repDoc.SetDataSource(dtResult);
                repDoc.SetParameterValue("waiterName", DashboardEnvironment.gUser.name);
                repDoc.SetParameterValue("curDate", DateTime.Now);
                repDoc.SetParameterValue("billNumber", curBill.numb);
                repDoc.SetParameterValue("printersType", 1);
                repDoc.PrintOptions.PrinterName = results_1.First().Field<string>("printerName");
                repDoc.PrintToPrinter(1, false, 0, 0);

                flag = true;
            }

            var results_2 = from myRow in dtResult.AsEnumerable()
                            where myRow.Field<int>("ref_printers_type") == 2
                            select myRow;

            if (results_2.Count() > 0) // есть позиции на принтер Бара
            {
                repDoc = new ReportDocument();
                repDoc.Load(results_2.First().Field<string>("reportPath"));
                repDoc.SetDataSource(dtResult);
                repDoc.SetParameterValue("waiterName", DashboardEnvironment.gUser.name);
                repDoc.SetParameterValue("curDate", DateTime.Now);
                repDoc.SetParameterValue("billNumber", curBill.numb);
                repDoc.SetParameterValue("printersType", 2);
                repDoc.PrintOptions.PrinterName = results_2.First().Field<string>("printerName");
                repDoc.PrintToPrinter(1, false, 0, 0);

                flag = true;
            }

            if (flag)
            {
                fillBillsInfo(curBill);
                billEdit();
            }

        }

        private bool checkBillInfo()
        {
            StringBuilder strMsg = new StringBuilder();
            strMsg.AppendLine("В счете присутствуют следующие необработанные позиции.");

            foreach(Dish oDish in lDishs)
            {
                if (oDish.refStatus == 23) // ref_status.id (Необработано) (Позиция в счете нового блюда)
                    strMsg.AppendLine("- " + oDish.name + ", в количестве: " + oDish.count);
            }

            if (strMsg.ToString().Equals("В счете присутствуют следующие необработанные позиции." + Environment.NewLine)) return true; // Все ровно, все позиции подтверждены (отправлены бигунки)


            strMsg.AppendLine("Если вы выйдите из режима редактирования счета, необработанные позиции исключатся из счета.");
            strMsg.AppendLine("Вы уверены, что хотите выйти из режима редактирования счета?");

            if (MessageBox.Show(strMsg.ToString(), GValues.prgNameFull, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    dbAccess.BillInfoCancel("offline", curBill);
                }
                catch (Exception exc) { uMessage.Show("Не удалось исключить необработанные позиции.", exc, SystemIcons.Information); return false; }

                return true;
            }

            return true;
        }

        private void keysBackspace()
        {
            if (curGroupBox == groupBox.BILLINFO || curGroupBox == groupBox.DISHES || curGroupBox == groupBox.GROUP)
            {
                fillBills();

                showBill();

                curGroupBox = groupBox.BILL;

                panel_bills.BringToFront();
            }
        }

        private void closeForm()
        {
            cancelBills();

            Close();
        }

        #endregion

        private bool cancelBills()
        {
            try
            {
                dbAccess.BillCancel("offline");
            }
            catch (Exception exc) { uMessage.Show("Не удалось создать заказ.", exc, SystemIcons.Information); return false; }

            return true;
        }

        private void openBill()
        {
            int xPriv = 0;
            string xErrMessage = string.Empty;

            // Пытаемся создать счет
            xPriv = 3; xErrMessage = "У Вас отсутствуют привилегии на открытие счета.";

            if (!Supp.checkPrivileges(DashboardEnvironment.gUser.oUserACL, xPriv))
            {
                MessageBox.Show(xErrMessage, GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                curBill = dbAccess.BillOpen("offline");
            }
            catch (Exception exc) { uMessage.Show("Не удалось создать заказ.", exc, SystemIcons.Information); return; }
            
            lDishs = new List<Dish>();

            billEdit();
        }

        private void button_newBill_Click(object sender, EventArgs e)
        {
            openBill();
        }
    }
}
