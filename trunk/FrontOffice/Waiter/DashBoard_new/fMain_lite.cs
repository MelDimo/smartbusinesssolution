using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.gui.dashboard;
using com.sbs.dll;
using com.sbs.dll.utilites;
using System.Collections;

namespace com.sbs.gui.dashboard
{
    public partial class fMain_lite : Form
    {
        #region enum eCurrentPanel
        private enum eCurrentPanel{ Bills, MenuGroups, Dishes, Refuse, DishesInBill}
        private eCurrentPanel _currPanel;
        private eCurrentPanel currPanel
        {
            get { return _currPanel; }
            set
            {
                switch (value)
                {
                    case eCurrentPanel.Bills:
                        label_leftAreaInfo.Text = "Доступные счета";
                        
                        panel_bills.BringToFront();

                        fillBills();

                        dataGridView_dishes.ClearSelection();
                        dataGridView_refuse.ClearSelection();
                        dataGridView_billInfo.ClearSelection();
                        break;

                    case eCurrentPanel.MenuGroups:
                        label_leftAreaInfo.Text = "Меню";
                        panel_menuGroups.BringToFront();
                        treeView_CarteGroups.Focus();

                        panel_carteGroups.BackColor = Color.FromKnownColor(KnownColor.Highlight);
                        panel_dishes.BackColor = Color.FromKnownColor(KnownColor.Control);
                        panel_refuse.BackColor = Color.FromKnownColor(KnownColor.Control);
                        statusStrip_billInfo.BackColor = Color.FromKnownColor(KnownColor.Control);
                        tableLayoutPanel_billsInfo.BackColor = Color.FromKnownColor(KnownColor.Control);

                        dataGridView_dishes.ClearSelection();
                        dataGridView_refuse.ClearSelection();
                        dataGridView_billInfo.ClearSelection();
                        dataGridView_bills.ClearSelection();
                        break;

                    case eCurrentPanel.Dishes:
                        label_leftAreaInfo.Text = "Меню";

                        panel_carteGroups.BackColor = Color.FromKnownColor(KnownColor.Control);
                        panel_dishes.BackColor = Color.FromKnownColor(KnownColor.Highlight);
                        groupBox_dishes.BackColor = Color.FromKnownColor(KnownColor.Control);
                        panel_refuse.BackColor = Color.FromKnownColor(KnownColor.Control);

                        dataGridView_refuse.ClearSelection();
                        dataGridView_billInfo.ClearSelection();
                        dataGridView_bills.ClearSelection();

                        dataGridView_dishes.Rows[0].Selected = true;
                        dataGridView_dishes.Rows[0].Cells[1].Selected = true;
                        dataGridView_dishes.Focus();
                        break;

                    case eCurrentPanel.Refuse:
                        label_leftAreaInfo.Text = "Меню";

                        panel_refuse.BackColor = Color.FromKnownColor(KnownColor.Highlight);
                        
                        panel_dishes.BackColor = Color.FromKnownColor(KnownColor.Control);
                        panel_carteGroups.BackColor = Color.FromKnownColor(KnownColor.Control);
                        tableLayoutPanel_billsInfo.BackColor = Color.FromKnownColor(KnownColor.Control);
                        groupBox_refuse.BackColor = Color.FromKnownColor(KnownColor.Control);

                        dataGridView_dishes.ClearSelection();
                        dataGridView_billInfo.ClearSelection();
                        dataGridView_bills.ClearSelection();

                        dataGridView_refuse.Rows[0].Selected = true;
                        dataGridView_refuse.Focus();
                        break;

                    case eCurrentPanel.DishesInBill:
                        panel_refuse.BackColor = Color.FromKnownColor(KnownColor.Control);
                        panel_dishes.BackColor = Color.FromKnownColor(KnownColor.Control);
                        panel_carteGroups.BackColor = Color.FromKnownColor(KnownColor.Control);
                        statusStrip_billInfo.BackColor = Color.FromKnownColor(KnownColor.Control);

                        tableLayoutPanel_billsInfo.BackColor = Color.FromKnownColor(KnownColor.Highlight);
                        panel_BillsInfoHeader.BackColor = Color.FromKnownColor(KnownColor.Control);

                        dataGridView_refuse.ClearSelection();
                        dataGridView_dishes.ClearSelection();
                        dataGridView_bills.ClearSelection();

                        dataGridView_billInfo.Rows[0].Selected = true;
                        dataGridView_billInfo.Rows[0].Cells[1].Selected = true;
                        dataGridView_billInfo.Focus();
                        break;
                }
                _currPanel = value;
            }
        }
        #endregion

        private DBaccess dbAccess = new DBaccess();

        Suppurt Supp = new Suppurt();

        private List<DTO_DBoard.Bill> lBills = null;
        private List<DTO_DBoard.Dish> lDishes = null;
        private List<DTO_DBoard.DishRefuse> lDishesRefuse = null;

        private DTO_DBoard.Bill curBill = null;
        private DTO_DBoard.Delivery oDelivery = null;

        private DataTable dtDishes;

        private int curEditBillId = 0;
        private int idCarte = 0; // Использую для акционных позиций

        private string dtDishesFilter; // С помощью это фильтра разруиваю какие блюда показывать в доставке а кикие в меню зала

        public fMain_lite()
        {
            InitializeComponent();

            dataGridView_bills.AutoGenerateColumns = false;
            dataGridView_billInfo.AutoGenerateColumns = false;
            dataGridView_dishes.AutoGenerateColumns = false;
            dataGridView_refuse.AutoGenerateColumns = false;

            currPanel = eCurrentPanel.Bills;
        }

        private void fMain_lite_Shown(object sender, EventArgs e)
        {
            tSSLabel_fio.Text = DashboardEnvironment.gUser.name;

            currPanel = eCurrentPanel.Bills;
        }

        private void fMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                switch (e.KeyCode)
                {
                    case Keys.F2:
                        openDelivery();
                        break;

                    case Keys.D:        // Отобразить свойства доставки
                        if (curBill.oDelivery.bills == 0) return; // У выбранного счета нет доставки

                        fDelivery fDeliv = new fDelivery(curBill.oDelivery, Suppurt.FormOpenModes.Edit);
                        if (fDeliv.ShowDialog() == DialogResult.OK){} curBill.oDelivery = fDeliv.oDelivery;
                        break;
                }
            }
            else
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    switch (currPanel)
                    {
                        case eCurrentPanel.Bills:
                            closeForm();
                            break;
                        case eCurrentPanel.MenuGroups:
                            if (!checkBillInfo()) return;
                            currPanel = eCurrentPanel.Bills;
                            dataGridView_bills_SelectionChanged(null, new EventArgs());
                            break;
                        case eCurrentPanel.Dishes:
                            currPanel = eCurrentPanel.MenuGroups;
                            break;
                        case eCurrentPanel.Refuse:
                            currPanel = eCurrentPanel.MenuGroups;
                            break;
                        case eCurrentPanel.DishesInBill:
                            currPanel = eCurrentPanel.MenuGroups;
                            break;
                    }
                    break;

                case Keys.Back:
                    switch (currPanel)
                    {
                        case eCurrentPanel.Dishes:
                            currPanel = eCurrentPanel.MenuGroups;
                            break;
                        case eCurrentPanel.Refuse:
                            currPanel = eCurrentPanel.MenuGroups;
                            break;
                        case eCurrentPanel.DishesInBill:
                            currPanel = eCurrentPanel.MenuGroups;
                            break;
                    }
                    break;

                case Keys.F1:   // Помощь
                    fHelp fHLP = new fHelp();
                    fHLP.ShowDialog();
                    fHLP.Dispose();
                    break;

                case Keys.F2:   //Новый заказ
                    if (currPanel == eCurrentPanel.Bills)
                    {
                        openBill();
                    }
                    break;

                case Keys.F3:   // Печать бегунков
                    if (currPanel != eCurrentPanel.Bills)
                    {
                        commitDish();
                    }
                    break;

                case Keys.F5:   // Печать чека
                    if (curBill == null) return;
                    printBill();
                    break;

                case Keys.F9:        // Переход на висяки
                    if (dataGridView_refuse.Rows.Count == 0) return;

                    currPanel = eCurrentPanel.Refuse;
                    break;

                case Keys.F10:        // Переход к редактированию позиций в счете
                    if (dataGridView_billInfo.Rows.Count == 0 || currPanel == eCurrentPanel.Bills) return;
                    currPanel = eCurrentPanel.DishesInBill;
                    break;
                case Keys.Enter:
                    break;
            }
        }

        private void commitDish()
        {
            checkDeals();
            fWaitProcess fWait = new fWaitProcess("PRINTDISH", curBill);
            fWait.ShowDialog();
            fillBillsInfo(curBill);
            editBill(curBill);
        }

        private void openBill()
        {
            int xPriv = 0;
            string xErrMessage = string.Empty;

            int tableNumb = 0;

            // Пытаемся создать счет
            xPriv = 3; xErrMessage = "У Вас отсутствуют привилегии на открытие счета.";

            if (!Supp.checkPrivileges(DashboardEnvironment.gUser.oUserACL, xPriv))
            {
                MessageBox.Show(xErrMessage, GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (GValues.branchTable > 0)
            {
                fTable ftable = new fTable();
                ftable.tableNumber = GValues.branchTable;
                if (ftable.ShowDialog() != DialogResult.OK)
                {
                    cancelBills();
                    return;
                }

                tableNumb = ftable.tableNumber;

                ftable.Dispose();
            }

            curBill = new DTO_DBoard.Bill();

            try
            {
                curBill = dbAccess.BillOpen(GValues.DBMode, tableNumb);
            }
            catch (Exception exc) { uMessage.Show("Не удалось создать заказ.", exc, SystemIcons.Information); return; }

            lDishes = new List<DTO_DBoard.Dish>();
            dataGridView_billInfo.DataSource = lDishes;

            lDishes = new List<com.sbs.dll.DTO_DBoard.Dish>();

            dtDishesFilter = "avalHall = 1";

            editBill(curBill);
        }

        private void printBill()
        {
            foreach (DTO_DBoard.Dish oDish in lDishes)
                if (oDish.refStatus != 24) // Позиция обработана
                {
                    if (GValues.printRunners == 0)  // Если не надо печатать бегунки просто комичу их
                    {
                        dbAccess.commitDish(GValues.DBMode, curBill);
                        break;
                    }
                    else
                    {
                        MessageBox.Show("В счете есть необработанные позиции." + Environment.NewLine + "Закрытие счета невозможно",
                            GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

            fCloseBill fCB = new fCloseBill(curBill, lDishes);
            if (fCB.ShowDialog() != DialogResult.OK) return;

            curBill.paymentType = fCB.paymentType;
            curBill.oDiscountInfo = fCB.oDiscountInfo;

            fCB.Dispose();

            fWaitProcess fWait = new fWaitProcess("PRINTBILL", curBill);

            if (fWait.ShowDialog() == DialogResult.OK) curBill = null;

            fWait.Dispose();

            if (currPanel != eCurrentPanel.Bills)
            {
                currPanel = eCurrentPanel.Bills;
            }
            else
            {
                fillBills();
            }
        }

        private void openDelivery()
        {
            int xPriv = 0;
            string xErrMessage = string.Empty;

            // Пытаемся создать счет
            xPriv = 27; xErrMessage = "У Вас отсутствуют привилегии на открытие счета доставки.";

            if (!Supp.checkPrivileges(DashboardEnvironment.gUser.oUserACL, xPriv))
            {
                MessageBox.Show(xErrMessage, GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                curBill = dbAccess.BillOpen(GValues.DBMode, 0);
            }
            catch (Exception exc) { uMessage.Show("Не удалось создать заказ.", exc, SystemIcons.Information); return; }

            fillBillsInfo(curBill);

            Stack stack = new Stack(2);
            stack.Push(curBill);
            stack.Push(lDishes);

            oDelivery = new DTO_DBoard.Delivery();
            oDelivery.bills = curBill.id;
            oDelivery.branch = GValues.branchId;
            oDelivery.season = DashboardEnvironment.gSeasonBranch.seasonID;

            fDelivery fDeliv = new fDelivery(oDelivery, Suppurt.FormOpenModes.New);
            if (fDeliv.ShowDialog() != DialogResult.OK)
            {
                stack.Clear();
                cancelBills();
                fillBills();
                return;
            }

            oDelivery = fDeliv.oDelivery;

            lDishes = (List<DTO_DBoard.Dish>)stack.Pop();
            curBill = (DTO_DBoard.Bill)stack.Pop();

            dtDishesFilter = "avalDelivery = 1";
            curBill.oDelivery = oDelivery;

            editBill(curBill);
        }

        private void fillBills()
        {
            lBills = new List<DTO_DBoard.Bill>();
            
            lDishes = new List<DTO_DBoard.Dish>();
            dataGridView_billInfo.DataSource = lDishes;

            label_billNumber.Text = string.Empty;
            label_billSum.Text = string.Empty;
            label_billType.Text = string.Empty;
            label_dateOpen.Text = string.Empty;
            label_elapsedTime.Text = string.Empty;

            try
            {
                lBills = dbAccess.getBills(GValues.DBMode, DashboardEnvironment.gUser);
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
            }

            dataGridView_bills.DataSource = lBills;
            dataGridView_bills.Columns["bills_id"].DataPropertyName = "id";
            dataGridView_bills.Columns["bills_number"].DataPropertyName = "numb";
            dataGridView_bills.Columns["bills_table"].DataPropertyName = "table";
            dataGridView_bills.Columns["bills_sum"].DataPropertyName = "summ";

            dataGridView_bills.SelectionChanged -= new EventHandler(dataGridView_bills_SelectionChanged);

            if (lBills.Count > 0)
            {
                curBill = lBills[0];
                fillBillsInfo(curBill);
            }

            for (int i = 0; i < dataGridView_bills.Rows.Count; i++)
            {
                if (lBills[i].oDelivery.bills == 0) 
                    dataGridView_bills.Rows[i].Cells["bills_billType"].Value = com.sbs.dll.utilites.Properties.Resources.order_26;
                else
                    dataGridView_bills.Rows[i].Cells["bills_billType"].Value = com.sbs.dll.utilites.Properties.Resources.delivery_26;

                if (curEditBillId == lBills[i].id) dataGridView_bills.CurrentCell = dataGridView_bills.Rows[i].Cells[2];
            }

            dataGridView_bills.Focus();

            dataGridView_bills.SelectionChanged += new EventHandler(dataGridView_bills_SelectionChanged);

        }

        void dataGridView_bills_SelectionChanged(object sender, EventArgs e)
        {
            if (currPanel == eCurrentPanel.Bills)
                if (dataGridView_bills.SelectedRows.Count == 1)
                {
                    curBill = lBills[dataGridView_bills.SelectedRows[0].Index];
                    fillBillsInfo(curBill);
                    dataGridView_billInfo.ClearSelection();
                };
        }

        private void fillBillsInfo(DTO_DBoard.Bill pBill)
        {
            lDishes = new List<DTO_DBoard.Dish>();

            try
            {
                lDishes = dbAccess.getBillInfo(GValues.DBMode, pBill);
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
            }

            dataGridView_billInfo.Columns["billsinfo_id"].DataPropertyName = "id";
            dataGridView_billInfo.Columns["billsinfo_refStatus"].DataPropertyName = "refStatus";
            dataGridView_billInfo.Columns["billsinfo_name"].DataPropertyName = "name";
            dataGridView_billInfo.Columns["billsinfo_price"].DataPropertyName = "price";
            dataGridView_billInfo.Columns["billsinfo_count"].DataPropertyName = "count";
            dataGridView_billInfo.DataSource = lDishes;

            foreach (DataGridViewRow dr in dataGridView_billInfo.Rows)
            {
                dr.Cells["billsinfo_summ"].Value =
                    ((decimal)dr.Cells["billsinfo_price"].Value * (decimal)dr.Cells["billsinfo_count"].Value).ToString("F2");

                if ((int)dr.Cells["billsinfo_refStatus"].Value != 24)
                {
                    dr.DefaultCellStyle.ForeColor = Color.Green;
                    dr.DefaultCellStyle.SelectionForeColor = Color.FromKnownColor(KnownColor.Lime);
                }
            }

            setBillsInfo(pBill);

            tSSLabel_countBillInfo.Text = string.Format("Количество позиций: {0}", dataGridView_billInfo.Rows.Count);
        }

        private void setBillsInfo(DTO_DBoard.Bill pBill)
        {
            string timeAfter = string.Empty;
            TimeSpan ts = new TimeSpan();

            label_billNumber.Text = pBill.numb.ToString();
            label_billType.Text = pBill.oDelivery.bills == 0 ? "Счет зала" : "Счет доставки";
            label_dateOpen.Text = pBill.openDate.ToLongTimeString();

            decimal result = lDishes.Sum(dish => dish.count * dish.price);
            label_billSum.Text = result.ToString("F2");

            switch (pBill.refStat)
            {
                case 20:
                    ts = DateTime.Now.Subtract(pBill.openDate);
                    if (ts.Hours == 0 && ts.Minutes == 0) { timeAfter = "меньше мин."; }
                    if (ts.Hours == 0 && ts.Minutes > 0) { timeAfter = ts.Minutes + " мин."; }
                    if (ts.Hours > 0) { timeAfter = string.Format("{0}ч. {1}м.", ts.Hours, ts.Minutes); }
                    if (ts.Days > 0) { timeAfter = string.Format("{0} д. {1} ч. {2} м.", ts.Days, ts.Hours, ts.Minutes); }
                    label_elapsedTime.Text = timeAfter;
                    break;

                case 19:
                    ts = DateTime.Now.Subtract(pBill.openDate);
                    if (ts.Hours == 0 && ts.Minutes == 0) { timeAfter = "меньше мин."; }
                    if (ts.Hours == 0 && ts.Minutes > 0) { timeAfter = ts.Minutes + " мин."; }
                    if (ts.Hours > 0) { timeAfter = string.Format("{0}ч. {1}м.", ts.Hours, ts.Minutes); }
                    if (ts.Days > 0) { timeAfter = string.Format("{0} д. {1} ч. {2} м.", ts.Days, ts.Hours, ts.Minutes); }
                    label_elapsedTime.Text = timeAfter;
                    break;
            }
        }

        private void checkDeals()
        {
            DataTable dtDeals = new DataTable();
            DataTable dtDealsDishes = new DataTable();
            DataTable dtBonusDishes = new DataTable();

            string refDishes = string.Empty;
            Dictionary<int, decimal> refDishesCount = new Dictionary<int, decimal>();
            decimal xDealsDishes = 0;
            decimal xBonusDishes = 0;

            foreach (DTO_DBoard.Dish dish in lDishes)
            {
                refDishes = refDishes + string.Format("{0},", dish.refDishes);

                if (refDishesCount.Keys.Contains(dish.refDishes)) refDishesCount[dish.refDishes] = refDishesCount[dish.refDishes] + dish.count;
                else refDishesCount.Add(dish.refDishes, dish.count);

            }
            refDishes.TrimEnd(',');

            try
            {
                dtDeals = dbAccess.getDeals(GValues.DBMode, idCarte, refDishes.TrimEnd(','));
            }
            catch(Exception exc)
            {
                uMessage.Show("Неудалось прогрузить акции." + Environment.NewLine + 
                            "Это ошибка не является критической, можете продолжить работу.", exc, SystemIcons.Information);
                return;
            }

            if (dtDeals.Rows.Count == 0) return;

            foreach (DataRow dr in dtDeals.Rows)
            {
                dtDealsDishes = dbAccess.getDealsDishes(GValues.DBMode, (int)dr["id"], refDishes.TrimEnd(','));
                dtBonusDishes = dbAccess.getBonusDishes(GValues.DBMode, (int)dr["id"], refDishes.TrimEnd(','));

                xDealsDishes = selectDealsDishes(dtDealsDishes, refDishes, refDishesCount);
                xBonusDishes = selectBonusDishes(dtBonusDishes, refDishes, refDishesCount);

                if ((xDealsDishes / (int)dr["xcount"]) <= xBonusDishes)
                {
                    continue;
                }

                xBonusDishes = Math.Truncate((xDealsDishes / (int)dr["xcount"]) - xBonusDishes);

                if (xBonusDishes != 0)
                {
                    List<DTO_DBoard.Dish> olDishes = dbAccess.getBonusDishes(GValues.DBMode, (int)dr["id"]);

                    fDealsDishes fdeals = new fDealsDishes(olDishes, dr["name"].ToString(), xBonusDishes);
                    if (fdeals.ShowDialog() != DialogResult.OK) return;

                    addDish2Bill(fdeals.oDish, "deals");
                }
            }

            return;
        }

        private decimal selectBonusDishes(DataTable dtBonusDishes, string refDishes, Dictionary<int, decimal> refDishesCount)
        {
            decimal xCountDishes = 0;

            foreach (DataRow dr in dtBonusDishes.Rows)
            {
                xCountDishes += xCountDishes + refDishesCount[(int)dr["ref_dishes"]];
            }

            return xCountDishes;
        }

        private decimal selectDealsDishes(DataTable dtDealsDishes, string refDishes, Dictionary<int, decimal> refDishesCount)
        {
            decimal xCountDishes = 0;

            foreach (DataRow dr in dtDealsDishes.Rows)
            {
                xCountDishes += xCountDishes + refDishesCount[(int)dr["ref_dishes"]];
            }

            return xCountDishes;
        }

        private void dataGridView_bills_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (dataGridView_bills.SelectedRows.Count == 0) return;
                    curBill = lBills[dataGridView_bills.SelectedRows[0].Index];
                    editBill(curBill);
                    break;
            }
        }

        private void editBill(DTO_DBoard.Bill bill)
        {
            curEditBillId = bill.id;

            setBillsInfo(bill);

            switch (bill.oDelivery.bills)
            {
                case 0:
                    dtDishesFilter = "avalHall = 1";
                    break;

                default:
                    dtDishesFilter = "avalDelivery = 1";
                    break;
            }

            if (dtDishes == null) prepareCarteDishes();

            getRefuse();

            currPanel = eCurrentPanel.MenuGroups;
            if (treeView_CarteGroups.Nodes.Count > 0) treeView_CarteGroups.SelectedNode = treeView_CarteGroups.Nodes[0];
            tSSLabel_countBillInfo.Text = string.Format("Количество позиций: {0}", dataGridView_billInfo.Rows.Count);
        }

        private void getRefuse()
        {
            try
            {
                lDishesRefuse = dbAccess.getRefuse(GValues.DBMode, dtDishesFilter);
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения отказных позиций." + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
                return;
            }

            if (lDishesRefuse.Count > 0)
            {
                panel_refuse.Height = 118;
                panel_refuse.Visible = true;

                dataGridView_refuse.DataSource = lDishesRefuse;
                dataGridView_refuse.Columns["refuse_id"].DataPropertyName = "id";
                dataGridView_refuse.Columns["refuse_name"].DataPropertyName = "name";
                dataGridView_refuse.Columns["refuse_count"].DataPropertyName = "count";
            }
            else
                panel_refuse.Visible = false;
        }

        private void closeForm()
        {
            cancelBills();
            Close();
        }

        private bool cancelBills()
        {
            try
            {
                dbAccess.BillCancel(GValues.DBMode);
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных.", exc, SystemIcons.Information); return false; }

            return true;
        }

        private bool checkBillInfo()
        {
            StringBuilder strMsg = new StringBuilder();
            strMsg.AppendLine("В счете присутствуют следующие необработанные позиции.");

            foreach (com.sbs.dll.DTO_DBoard.Dish oDish in lDishes)
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
                    dbAccess.BillInfoCancel(GValues.DBMode, curBill);
                    fillBillsInfo(curBill);
                }
                catch (Exception exc) { uMessage.Show("Не удалось исключить необработанные позиции.", exc, SystemIcons.Information); return false; }

                return true;
            }
            else
            {
                return false;
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
                dsTables = dbAccess.prepareCarteDishes(GValues.DBMode);
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

            dataGridView_dishes.DataSource = dtDishes;
            dataGridView_dishes.Columns["dishes_id"].DataPropertyName = "id";
            dataGridView_dishes.Columns["dishes_name"].DataPropertyName = "name";
            dataGridView_dishes.Columns["dishes_price"].DataPropertyName = "price";
        }

        private void treeView_CarteGroups_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int idGroup = 0;
            int xidCarte;

            //if (treeView_CarteGroups.SelectedNode.Nodes.Count > 0) return; // Отсекаем не конечные пункты

            if (int.TryParse(treeView_CarteGroups.SelectedNode.Name.Replace("carte", ""), out xidCarte)) { idCarte = xidCarte; }

            if (!int.TryParse(treeView_CarteGroups.SelectedNode.Name.Replace("group", ""), out idGroup))
            {
                dtDishes.DefaultView.RowFilter = "carte_dishes_group = 0";
                return;
            }

            dtDishes.DefaultView.RowFilter = string.Format("carte_dishes_group = {0} AND {1}", idGroup, dtDishesFilter);
            dataGridView_dishes.ClearSelection();
        }

        private void treeView_CarteGroups_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Enter:
                    if (treeView_CarteGroups.Nodes.Count == 0) return;
                    if (treeView_CarteGroups.SelectedNode.Nodes.Count > 0)
                    {
                        treeView_CarteGroups.SelectedNode.Expand();
                        return;
                    }
                    if (dataGridView_dishes.Rows.Count != 0) currPanel = eCurrentPanel.Dishes;
                    break;
            }
        }

        private void dataGridView_dishes_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (dataGridView_dishes.SelectedRows.Count == 0) return;
                    DTO_DBoard.Dish oDish = fillDish((int)dataGridView_dishes.SelectedRows[0].Cells["dishes_id"].Value);
                    addDish2Bill(oDish,"dish");
                    break;
            }
        }

        private void dataGridView_refuse_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (dataGridView_refuse.SelectedRows.Count == 0) return;
                    DTO_DBoard.Dish oDish = fillDishRefuse(dataGridView_refuse.SelectedRows[0].Index);
                    addDish2Bill(oDish,"refuse");
                    break;
            }
        }

        private void addDish2Bill(DTO_DBoard.Dish oDish, string pDishType)
        {
            DataTable dtNotesDish = new DataTable();
            ctrDishes oCtrDishes = null;

            oCtrDishes = new ctrDishes(oDish, "dashboard");

            oCtrDishes.TabStop = true;
            oCtrDishes.button_deals.Visible = false;
            
            oCtrDishes.label_count.Visible = false;
            oCtrDishes.comboBox_note.Visible = true;

            //----------------------------------------------------- Была ошибка с выставление начально кол-ва в последнее указываемое... хз
            oCtrDishes.oDish.count = oCtrDishes.oDish.minStep;
            switch (pDishType)
            { 
                case "deals":
                    oCtrDishes.numericUpDown_count.maxValue = oCtrDishes.oDish.count;
                    break;
            }
            oCtrDishes.numericUpDown_count.Value = oCtrDishes.oDish.minStep;
            oCtrDishes.numericUpDown_count.Visible = true;
            oCtrDishes.numericUpDown_count.TabStop = true;
            //-----------------------------------------------------

            DashboardEnvironment.dtNotes.DefaultView.RowFilter = "ref_notes_type IN (0, 2)";
            oCtrDishes.comboBox_note.DataSource = DashboardEnvironment.dtNotes; // Выбераем только статусы доступные для блюд
            oCtrDishes.comboBox_note.DisplayMember = "note";
            oCtrDishes.comboBox_note.ValueMember = "id";
            oCtrDishes.comboBox_note.Visible = true;

            oCtrDishes.button_host.Enabled = false;

            fAddDishToBill faddDish2Bill = new fAddDishToBill(curBill, oCtrDishes);
            if (faddDish2Bill.ShowDialog() == DialogResult.OK)
            {
                fillBillsInfo(curBill);
                getRefuse();
                
                if (currPanel != eCurrentPanel.Refuse) dataGridView_refuse.ClearSelection();
                else
                    if (currPanel == eCurrentPanel.Refuse && lDishesRefuse.Count == 0) currPanel = eCurrentPanel.MenuGroups;

                dataGridView_billInfo.ClearSelection();
            }

            faddDish2Bill.Dispose();
        }

        private DTO_DBoard.Dish fillDish(int pId)
        {
            DTO_DBoard.Dish oDish = new DTO_DBoard.Dish();

            var result = from rec in dtDishes.AsEnumerable()
                      where rec.Field<int>("id") == pId
                      select rec;

            oDish.id = result.First().Field<int>("id");
            oDish.minStep = result.First().Field<decimal>("minStep");
            oDish.count = result.First().Field<decimal>("minStep");
            oDish.name = result.First().Field<string>("name");
            oDish.price = result.First().Field<decimal>("price");
            oDish.refDishes = result.First().Field<int>("ref_dishes");

            return oDish;
        }

        private DTO_DBoard.Dish fillDishRefuse(int pIndex)
        {
            DTO_DBoard.Dish oDish = new DTO_DBoard.Dish();

            oDish.id = lDishesRefuse[pIndex].id;
            oDish.carteDishes = lDishesRefuse[pIndex].carteDishes;
            oDish.refDishes = lDishesRefuse[pIndex].refDishes;
            oDish.count = lDishesRefuse[pIndex].count;
            oDish.minStep = lDishesRefuse[pIndex].minStep;
            oDish.name = lDishesRefuse[pIndex].name;
            oDish.price = lDishesRefuse[pIndex].price;
            oDish.refPrintersType = lDishesRefuse[pIndex].refPrintersType;
            oDish.refStatus = lDishesRefuse[pIndex].refStatus;

            return oDish;
        }

        private void dataGridView_billInfo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (dataGridView_billInfo.SelectedRows.Count == 0) return;
                    DTO_DBoard.Dish oDish = lDishes[dataGridView_billInfo.SelectedRows[0].Index];
                    fDishToBill_ACTION fDishAction = new fDishToBill_ACTION(curBill, oDish);
                    if (fDishAction.ShowDialog() != DialogResult.OK)
                    {
                        fDishAction.Dispose();
                        return;
                    }
                    fillBillsInfo(curBill);
                    getRefuse();
                    dataGridView_refuse.ClearSelection();
                    break;
            }
        }
    }
}
