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
using System.Threading;

namespace com.sbs.gui.dashboard
{
    public partial class fMain : Form
    {
        DBaccess dbAccess = new DBaccess();
        Suppurt Supp = new Suppurt();

        enum groupBox { BILL, BILLDISH, BILLINFO, GROUP, DISHES, REFUSE };
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
                        groupBox_refuse.BorderColor = Color.Gray;

                        //groupBox_bills.Enabled = true;
                        //groupBox_billDish.Enabled = false;
                        //groupBox_billInfo.Enabled = false;
                        //groupBox_groups.Enabled = false;
                        //groupBox_dish.Enabled = false;
                        break;

                    case groupBox.BILLDISH:
                        groupBox_bills.BorderColor = Color.Gray;
                        groupBox_billDish.BorderColor = Color.Blue;
                        groupBox_billInfo.BorderColor = Color.Gray;
                        groupBox_groups.BorderColor = Color.Gray;
                        groupBox_dish.BorderColor = Color.Gray;
                        groupBox_refuse.BorderColor = Color.Gray;

                        //groupBox_bills.Enabled = false;
                        //groupBox_billDish.Enabled = true;
                        //groupBox_billInfo.Enabled = false;
                        //groupBox_groups.Enabled = false;
                        //groupBox_dish.Enabled = false;
                        break;

                    case groupBox.BILLINFO:
                        groupBox_bills.BorderColor = Color.Gray;
                        groupBox_billDish.BorderColor = Color.Gray;
                        groupBox_billInfo.BorderColor = Color.Blue;
                        groupBox_groups.BorderColor = Color.Gray;
                        groupBox_dish.BorderColor = Color.Gray;
                        groupBox_refuse.BorderColor = Color.Gray;

                        //groupBox_bills.Enabled = false;
                        //groupBox_billDish.Enabled = false;
                        //groupBox_billInfo.Enabled = true;
                        //groupBox_groups.Enabled = false;
                        //groupBox_dish.Enabled = false;
                        break;

                    case groupBox.DISHES:
                        groupBox_bills.BorderColor = Color.Gray;
                        groupBox_billDish.BorderColor = Color.Gray;
                        groupBox_billInfo.BorderColor = Color.Gray;
                        groupBox_groups.BorderColor = Color.Gray;
                        groupBox_dish.BorderColor = Color.Blue;
                        groupBox_refuse.BorderColor = Color.Gray;

                        //groupBox_bills.Enabled = false;
                        //groupBox_billDish.Enabled = false;
                        //groupBox_billInfo.Enabled = false;
                        //groupBox_groups.Enabled = false;
                        //groupBox_dish.Enabled = true;
                        break;

                    case groupBox.GROUP:
                        groupBox_bills.BorderColor = Color.Gray;
                        groupBox_billDish.BorderColor = Color.Gray;
                        groupBox_billInfo.BorderColor = Color.Gray;
                        groupBox_groups.BorderColor = Color.Blue;
                        groupBox_dish.BorderColor = Color.Gray;
                        groupBox_refuse.BorderColor = Color.Gray;

                        //groupBox_bills.Enabled = false;
                        //groupBox_billDish.Enabled = false;
                        //groupBox_billInfo.Enabled = false;
                        //groupBox_groups.Enabled = true;
                        //groupBox_dish.Enabled = false;
                        break;

                    case groupBox.REFUSE:
                        groupBox_bills.BorderColor = Color.Gray;
                        groupBox_billDish.BorderColor = Color.Gray;
                        groupBox_billInfo.BorderColor = Color.Gray;
                        groupBox_groups.BorderColor = Color.Gray;
                        groupBox_dish.BorderColor = Color.Gray;
                        groupBox_refuse.BorderColor = Color.Blue;

                        //groupBox_bills.Enabled = false;
                        //groupBox_billDish.Enabled = false;
                        //groupBox_billInfo.Enabled = false;
                        //groupBox_groups.Enabled = true;
                        //groupBox_dish.Enabled = false;
                        break;
                }
                this.Refresh();
            }
        }

        List<DTO_DBoard.Bill> lBills;
        List<DTO_DBoard.Dish> lDishs;

        ctrDishesSmall oCtrDishesSmall;

        DTO_DBoard.Bill curBill;

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

            tSSLabel_fio.Text = DashboardEnvironment.gUser.name;
        }

        #region ----------------------------------------------------------------- Наполняем объекты

        private bool fillBills()
        {
            lBills = new List<com.sbs.dll.DTO_DBoard.Bill>();

            try
            {
                lBills = dbAccess.getBills("offline", DashboardEnvironment.gUser);
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
                return false;
            }
            return true;
        }

        private bool fillBillsInfo(DTO_DBoard.Bill pBill)
        {
            lDishs = new List<DTO_DBoard.Dish>();

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
            flowLayoutPanel_billInfo.Controls.Clear();

            foreach(DTO_DBoard.Bill oBill in lBills)
            {
                oCtrBill = new ctrBill(oBill);

                oCtrBill.button_host.GotFocus += new EventHandler(Bill_button_host_GotFocus);
                oCtrBill.button_host.Click += new EventHandler(Bill_button_host_Click);

                oCtrBill.Width = flowLayoutPanel_bills.Width - 10;

                flowLayoutPanel_bills.Controls.Add(oCtrBill);
            }

            if (flowLayoutPanel_bills.Controls.Count > 0)
            {
                flowLayoutPanel_bills.Controls[0].Focus();
                curBill = (DTO_DBoard.Bill)((ctrBill)flowLayoutPanel_bills.Controls[0]).oBill;
            }
            else
            {
                this.Focus();
            }

            foreach (ctrBill ctr in flowLayoutPanel_bills.Controls)
            {
                ctr.TabStop = true;
            }

            curGroupBox = groupBox.BILL;
        }

        void Bill_button_host_GotFocus(object sender, EventArgs e)
        {
            DTO_DBoard.Bill curBill = ((ctrBill)((Button)sender).Parent).oBill;

            if (!fillBillsInfo(curBill)) return;

            ctrDishes oCtrDishes;
            flowLayoutPanel_billInfo.Controls.Clear();

            foreach (DTO_DBoard.Dish oDish in lDishs)
            {
                oCtrDishes = new ctrDishes(oDish);

                oCtrDishes.comboBox_note.Items.Add(oDish.refNotesName);
                oCtrDishes.comboBox_note.SelectedItem = oDish.refNotesName;

                oCtrDishes.TabStop = false;

                oCtrDishes.button_topping.Visible = false;
                oCtrDishes.button_deals.Visible = false;

                oCtrDishes.Width = flowLayoutPanel_billInfo.Width - 10;

                flowLayoutPanel_billInfo.Controls.Add(oCtrDishes);
            }
        }
        
        void Bill_button_host_Click(object sender, EventArgs e)
        {
            curBill = ((ctrBill)((Button)sender).Parent).oBill;
            
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

            // Подгружаем висяки
            getRefuse();

            panel_dishes.BringToFront();
        }

        private void getRefuse()
        {
            ctrDishesRefuse oCtrDishesRefuse;
            List<DTO_DBoard.DishRefuse> lDishesRefuse;
            try 
            {
                lDishesRefuse = dbAccess.getRefuse("offline");
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения отказных позиций." + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
                return;
            }

            if (lDishesRefuse.Count > 0)
            {
                groupBox_refuse.Visible = true;
                
                flowLayoutPanel_refuse.Controls.Clear();

                foreach (DTO_DBoard.DishRefuse oDishRefuse in lDishesRefuse)
                {
                    oCtrDishesRefuse = new ctrDishesRefuse(oDishRefuse);
                    oCtrDishesRefuse.button_host.Click += new EventHandler(CtrDishesRefuse_Click);
                    oCtrDishesRefuse.Width = flowLayoutPanel_refuse.Width - 25;
                    flowLayoutPanel_refuse.Controls.Add(oCtrDishesRefuse);
                }
            }
            else
                groupBox_refuse.Visible = false;

        }

        void CtrDishesRefuse_Click(object sender, EventArgs e)
        {
            ctrDishesRefuse oCtrDishesRefuse = (ctrDishesRefuse)((Button)sender).Parent;
            MessageBox.Show(oCtrDishesRefuse.label_name, GValues.prgNameFull);
        }

        #region ----------------------------------------------------------------- Редактирование заказа
        
        private void showBillInfo()
        {
            panel_billInfo.Controls.Clear();

            ctrBill oCtrBill;// = new ctrBill();

            oCtrBill = new ctrBill(curBill);

            oCtrBill.TabStop = false;

            oCtrBill.Width = panel_billInfo.Width - 10;

            panel_billInfo.Controls.Add(oCtrBill);

            flowLayoutPanel_billEdit.Controls.Clear();

            foreach (DTO_DBoard.Dish oDish in lDishs)
            {
                oCtrDishesSmall = new ctrDishesSmall(oDish);

                oCtrDishesSmall.button_host.Click += new EventHandler(oCtrDishesSmall_button_host_Click);
                oCtrDishesSmall.Name = oDish.id.ToString(); // Присваиваю имя, чтобы потом вернуть фокус при редактировании позиции

                oCtrDishesSmall.TabStop = false;

                oCtrDishesSmall.Width = flowLayoutPanel_billEdit.Width - 25;

                flowLayoutPanel_billEdit.Controls.Add(oCtrDishesSmall);
            }

            panel_dishes.Refresh();
        }

        void oCtrDishesSmall_button_host_Click(object sender, EventArgs e)
        {
            oCtrDishesSmall = (ctrDishesSmall)((Button)sender).Parent;
            fDishToBill_ACTION fDishAction = new fDishToBill_ACTION(curBill, oCtrDishesSmall.oDish);
            if (fDishAction.ShowDialog() != DialogResult.OK)
            {
                fDishAction.Dispose();
                return;
            }
            switch (fDishAction.returnCode)
            {
                case "CLOSE_BILL":
                    printBill();
                    break;
            }

            fDishAction.Dispose();

            fillBillsInfo(curBill);
            showBillInfo();

            if (flowLayoutPanel_billEdit.Controls[oCtrDishesSmall.Name] != null) flowLayoutPanel_billEdit.Controls[oCtrDishesSmall.Name].Focus();
            else
                if (flowLayoutPanel_billEdit.Controls.Count > 0) flowLayoutPanel_billEdit.Controls[0].Focus();
                else treeView_CarteGroups.Focus();
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
                oCtrDishes = new ctrDishes(new DTO_DBoard.Dish() { 
                    id = (int)dr["id"],
                    minStep = (decimal)dr["minStep"],
                    count = (decimal)dr["minStep"],
                    name = dr["name"].ToString(),
                    price = (decimal)dr["price"]

                });
                oCtrDishes.button_host.Click += new EventHandler(Dish_button_host_Click);

                oCtrDishes.TabStop = false;
                oCtrDishes.button_topping.Visible = false;
                oCtrDishes.button_deals.Visible = false;
                oCtrDishes.numericUpDown_count.Visible = false;
                oCtrDishes.comboBox_note.Visible = false;

                oCtrDishes.Width = flowLayoutPanel_dish.Width - 25;

                flowLayoutPanel_dish.Controls.Add(oCtrDishes);
            }
        }

        private void Dish_button_host_Click(object sender, EventArgs e)
        {
            DataTable dtNotesDish = new DataTable();
            ctrDishes oCtrDishes = (ctrDishes)((ctrDishes)((Button)sender).Parent).Clone();

            DashboardEnvironment.dtNotes.DefaultView.RowFilter = "ref_notes_type IN (0,2)";
            oCtrDishes.comboBox_note.DataSource = DashboardEnvironment.dtNotes; // Выбераем только статусы доступные для блюд
            oCtrDishes.comboBox_note.DisplayMember = "note";
            oCtrDishes.comboBox_note.ValueMember = "id";
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
                    {
                        SendKeys.Send("+{TAB}");
                    }
                    break;

                case Keys.Down:
                    if (curGroupBox != groupBox.GROUP) SendKeys.Send("{TAB}");
                    break;

                case Keys.Left | Keys.Control:
                    changeGroup("LEFT");
                    break;

                case Keys.Right | Keys.Control:
                    changeGroup("RIGHT");
                    break;

                case Keys.Down | Keys.Control:
                    if (curGroupBox == groupBox.GROUP) changeGroup("DOWN");
                    break;

                case Keys.Up | Keys.Control:
                    if (curGroupBox == groupBox.REFUSE) changeGroup("UP");
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void changeGroup(string pDirection)
        {
            int bufHeight;
            
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
                            if (flowLayoutPanel_billEdit.Controls.Count > 0)
                            {
                                foreach (ctrDishesSmall ctr in flowLayoutPanel_billEdit.Controls)
                                {
                                    ctr.TabStop = true;
                                }
                                flowLayoutPanel_billEdit.Controls[0].Focus();
                                curGroupBox = groupBox.BILLINFO;
                            }
                            break;

                        case "RIGHT":
                            if (flowLayoutPanel_dish.Controls.Count > 0)
                            {
                                foreach (ctrDishes ctr in flowLayoutPanel_dish.Controls)
                                {
                                    ctr.TabStop = true;
                                }
                                flowLayoutPanel_dish.Controls[0].Focus();
                                curGroupBox = groupBox.DISHES;
                            }
                            break;

                        case "DOWN":

                            if (!flowLayoutPanel_refuse.Visible) return;

                            if (flowLayoutPanel_refuse.Controls.Count > 0) flowLayoutPanel_refuse.Controls[0].Focus();

                            foreach (ctrDishesRefuse ctr in flowLayoutPanel_refuse.Controls) ctr.TabStop = true;

                            bufHeight = groupBox_refuse.Height;
                            groupBox_refuse.Height = groupBox_groups.Height;
                            groupBox_groups.Height = bufHeight;

                            curGroupBox = groupBox.REFUSE;
                            break;
                    }
                    break;

                case groupBox.REFUSE:
                    switch (pDirection)
                    {
                        case "UP":
                            treeView_CarteGroups.Focus();
                            curGroupBox = groupBox.GROUP;
                            break;

                        case "LEFT":
                            if (flowLayoutPanel_billEdit.Controls.Count > 0)
                            {
                                foreach (ctrDishesSmall ctr in flowLayoutPanel_billEdit.Controls)
                                {
                                    ctr.TabStop = true;
                                }
                                curGroupBox = groupBox.BILLINFO;
                            }
                            break;

                        case "RIGHT":
                            if (flowLayoutPanel_dish.Controls.Count > 0)
                            {
                                foreach (ctrDishes ctr in flowLayoutPanel_dish.Controls)
                                {
                                    ctr.TabStop = true;
                                }
                                flowLayoutPanel_dish.Controls[0].Focus();
                                curGroupBox = groupBox.DISHES;
                            }
                            break;
                    }
                    bufHeight = groupBox_groups.Height;
                    groupBox_groups.Height = groupBox_refuse.Height;
                    groupBox_refuse.Height = bufHeight;

                    foreach (ctrDishesRefuse ctr in flowLayoutPanel_refuse.Controls)
                    {
                        ctr.TabStop = false;
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
                    printBill();
                    break;

                case Keys.F7:
                    if (curGroupBox != groupBox.BILL)
                    {
                        button_searchDish_Click(null, null);
                    }
                    break;

                case Keys.Escape:
                    if (curGroupBox != groupBox.BILL)
                        SendKeys.Send("{BACKSPACE}");
                    else
                        closeForm();
                    break;

                case Keys.Back:
                    if (curGroupBox == groupBox.BILLINFO || curGroupBox == groupBox.GROUP || curGroupBox == groupBox.DISHES)
                        if (!checkBillInfo()) return;
                    keysBackspace();
                    break;
            }
        }

        private void printBill()
        {
            fCloseBill fCB = new fCloseBill(curBill, lDishs);
            if (fCB.ShowDialog() != DialogResult.OK) return;

            curBill.paymentType = fCB.paymentType;

            fWaitProcess fWait = new fWaitProcess("PRINTBILL", curBill);
            fWait.ShowDialog();

            if (curGroupBox != groupBox.BILL)
            {
                keysBackspace();
            }
            else
            {
                fillBills();
                showBill();
            }
        }

        private void commitDish()
        {
            fWaitProcess fWait = new fWaitProcess("PRINTDISH", curBill);
            fWait.ShowDialog();
            //if (fWait.retflag)
            //{
                fillBillsInfo(curBill);
                billEdit();
            //}

        }

        private bool checkBillInfo()
        {
            StringBuilder strMsg = new StringBuilder();
            strMsg.AppendLine("В счете присутствуют следующие необработанные позиции.");

            foreach(com.sbs.dll.DTO_DBoard.Dish oDish in lDishs)
            {
                if (oDish.refStatus == 23) // ref_status.id (Необработано) (Позиция в счете нового блюда)
                    strMsg.AppendLine("- " + oDish.name + ", в количестве: " + oDish.count);
            }

            if (strMsg.ToString().Equals("В счете присутствуют следующие необработанные позиции." + Environment.NewLine))return true; // Все ровно, все позиции подтверждены (отправлены бигунки)

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
            else
            {
                return false;
            }
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
            curBill = new DTO_DBoard.Bill();

            try
            {
                curBill = dbAccess.BillOpen("offline");
            }
            catch (Exception exc) { uMessage.Show("Не удалось создать заказ.", exc, SystemIcons.Information); return; }
            
            lDishs = new List<com.sbs.dll.DTO_DBoard.Dish>();

            billEdit();
        }

        private void button_newBill_Click(object sender, EventArgs e)
        {
            openBill();
        }

        private void button_printBill_Click(object sender, EventArgs e)
        {
            printBill();
        }

        #region ------------------------------------------------------------------------------ Поиск блюда
        
        private void button_searchDish_Click(object sender, EventArgs e)
        {
            int dishId;
            int carteDishesGroupId;

            fChooser fChose = new fChooser("DASHBOARD_DISH", "name", "id");
            fChose.dataGridView_main.DataSource = dtDishes;

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
            col2.Name = "carte_dishes_group";
            col2.DataPropertyName = "carte_dishes_group";
            col2.Visible = false;

            fChose.dataGridView_main.Columns.AddRange(new DataGridViewColumn[] { col0, col1, col2 });

            fChose.Text = "Поиск блюда";

            if (fChose.ShowDialog() == DialogResult.OK)
            {
                dishId = (int)fChose.xData[0];
                carteDishesGroupId = (int)fChose.xData[1];

                showDish(carteDishesGroupId, dishId);
            }
        }

        private void showDish(int carteDishesGroupId, int dishId)
        {
            int i = 0;

            ctrDishes oCtrDish;
            TreeNode tn = treeView_CarteGroups.Nodes.Find("group" + carteDishesGroupId.ToString(), true)[0];
            treeView_CarteGroups.SelectedNode = tn;
            
            foreach (Control ctr in flowLayoutPanel_dish.Controls)
            {
                oCtrDish = (ctrDishes)ctr;
                if (oCtrDish.oDish.id == dishId)
                {
                    Dish_button_host_Click(oCtrDish.button_host, null);
                    break;
                }
                i++;
            }
        }

        #endregion
    }
}
