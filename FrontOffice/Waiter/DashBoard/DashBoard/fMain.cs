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
using CrystalDecisions.CrystalReports.Engine;

namespace com.sbs.gui.DashBoard
{
    public partial class fMain : Form
    {
        private DBaccess DbAccess = new DBaccess();
        
        private oBill bill = new oBill();

        private Dictionary<int, List<oBillInfo>> BillInfo = new Dictionary<int, List<oBillInfo>>();

        internal DataSet dsDishes;
        private DataTable dtBills;

        int xCurCarte, xCurDishesGroup;    // id текущих выбранных позиций
        int xSelectedBillInfoId;              // Сохраняю bills_info.id, связано с топпингами

        public fMain(DataSet pDsDishes)
        {
            dsDishes = pDsDishes;

            InitializeComponent();

            dataGridView_bill.AutoGenerateColumns = false;
            dataGridView_bill.MultiSelect = false;
            dataGridView_bill.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_bill.KeyDown += new KeyEventHandler(dataGridView_bill_KeyDown);

            dataGridView_dish.AutoGenerateColumns = false;
            dataGridView_dish.MultiSelect = false;
            dataGridView_dish.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_dish.KeyDown += new KeyEventHandler(dataGridView_dish_KeyDown);

            dataGridView_billInfo.AutoGenerateColumns = false;
            dataGridView_billInfo.KeyDown += new KeyEventHandler(dataGridView_billInfo_KeyDown);

            dataGridView_refusing.AutoGenerateColumns = false;

            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer2.FixedPanel = FixedPanel.Panel1;

            tSStatusLabel_whoOpen.Text = "Смена открыта: " + GValues.openSeasonUserName;
            tSStatusLabel_whenOpen.Text = GValues.openSeasonDate;
            tSStatusLabel_curWaiter.Text = UsersInfo.UserName;
        }

        void dataGridView_billInfo_KeyDown(object sender, KeyEventArgs e)
        {
            int xSelectedDishId;
            string xSelectedDishName;
            xSelectedBillInfoId = 0;

            switch (e.KeyCode)
            { 
                case Keys.Enter:
                    if (dataGridView_billInfo.SelectedRows.Count == 0) return;

                    xSelectedDishId = (int)dataGridView_billInfo.SelectedRows[0].Cells["dishes"].Value;
                    xSelectedDishName = dataGridView_billInfo.SelectedRows[0].Cells["dishes_name"].Value.ToString();
                    xSelectedBillInfoId = (int)dataGridView_billInfo.SelectedRows[0].Cells["billsinfo_id"].Value;

                    if ((int)dataGridView_billInfo.SelectedRows[0].Cells["isToppingFor"].Value != 0)
                    {
                        uMessage.Show("Редактирование топпинга невозможно. Редактируйте блюдо.", SystemIcons.Information);
                        e.SuppressKeyPress = true;
                        return;
                    }

                    DataRow[] dr = dsDishes.Tables["dishes"].Select("id = " + xSelectedDishId);
                    if (dr.Count() != 1)
                    {
                        uMessage.Show("Неудалось однозначно определить блюдо '" + xSelectedDishName + "'.", SystemIcons.Information);
                        e.SuppressKeyPress = true;
                        return;
                    }

                    tabControl_main.SelectedIndex = 1;
                    createDishes((int)dr[0]["dishes_group"], (int)dr[0]["id"]);
                    dataGridView_dish.Focus();
                    dataGridView_dish.Rows[dataGridView_dish.CurrentRow.Index].Selected = true;
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Tab:
                    tabControl_main.SelectedIndex = tabControl_main.SelectedIndex;
                    switch(tabControl_main.SelectedIndex)
                    {
                        case 0:
                            dataGridView_bill.Focus();
                            dataGridView_bill.Rows[dataGridView_bill.CurrentRow.Index].Selected = true;
                            break;

                        case 1:
                            dataGridView_dish.Focus();
                            dataGridView_dish.Rows[dataGridView_dish.CurrentRow.Index].Selected = true;
                            break;

                        case 2:
                            break;
                    }
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Delete:
                    if (dataGridView_billInfo.SelectedRows.Count == 0) return;

                    int rowIndex;
                    rowIndex = dataGridView_billInfo.SelectedRows[0].Index;
                    oBillInfo oBInfo = ((BindingList<oBillInfo>)dataGridView_billInfo.DataSource)[rowIndex];

                    if (oBInfo.RefStatus != 23) // позиция не подтверждена = можно редактировать
                    {
                        uMessage.Show("Позиция '" + oBInfo.DishesName + "' уже подтверждена. изменение не возможно", SystemIcons.Information);
                        return;
                    }

                    fDishToBill_Edit fdishremove = new fDishToBill_Edit(ref oBInfo);
                    if (fdishremove.ShowDialog() == DialogResult.OK)
                    {
                        getBillsInfo(oBInfo.Bill);
                    }

                    dataGridView_billInfo.CurrentCell = dataGridView_billInfo.Rows[rowIndex].Cells[1];
                    dataGridView_billInfo.Rows[rowIndex].Selected = true;

                    e.SuppressKeyPress = true;
                    break;

                case Keys.Space:
                    break;

            }
        }

        private void fMain_Shown(object sender, EventArgs e)
        {
            getBill();

            dataGridView_bill.SelectionChanged += new EventHandler(dataGridView_bill_SelectionChanged);

            if (dataGridView_bill.RowCount > 0)
            {
                bill.BillId = (int)dataGridView_bill.SelectedRows[0].Cells["id"].Value;
                bill.DateOpen = (DateTime)dataGridView_bill.SelectedRows[0].Cells["date_open"].Value;
                getBillsInfo(bill.BillId);
            }

            dataGridView_billInfo.ClearSelection();

            dataGridView_bill.Focus();
            dataGridView_bill.Select();
        }

        private void getBill()
        {
            dtBills = DbAccess.getAvaliableBills("offline", ref BillInfo);

            dataGridView_bill.DataSource = dtBills;
            dataGridView_bill.Columns["id"].DataPropertyName = "id";
            dataGridView_bill.Columns["bill_numb"].DataPropertyName = "id";
            dataGridView_bill.Columns["date_open"].DataPropertyName = "date_open";
            dataGridView_bill.Columns["ref_status_name"].DataPropertyName = "ref_status_name";
        }

        void dataGridView_bill_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    createCarte();
                    tabControl_main.SelectedIndex = 1;
                    e.SuppressKeyPress = true;
                    break;
                case Keys.Tab:
                    if (dataGridView_billInfo.CurrentRow == null) return;
                    dataGridView_billInfo.Focus();
                    dataGridView_billInfo.Rows[dataGridView_billInfo.CurrentRow.Index].Selected = true;
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        private void dataGridView_bill_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_bill.SelectedRows.Count > 0)
            {
                bill = new oBill();
                bill.BillId = (int)dataGridView_bill.SelectedRows[0].Cells["id"].Value;
                bill.DateOpen = (DateTime)dataGridView_bill.SelectedRows[0].Cells["date_open"].Value;
                getBillsInfo(bill.BillId);
            }

            dataGridView_billInfo.ClearSelection();
        }

        private void getBillsInfo(int pBillsId)
        {
            TimeSpan DateTimeBetween;
            string xDay, xHours, xMinutes;

            var filenamesList = new BindingList<oBillInfo>(BillInfo[pBillsId]);

            dataGridView_billInfo.DataSource = filenamesList;
            dataGridView_billInfo.Columns["billsinfo_id"].DataPropertyName = "id";
            dataGridView_billInfo.Columns["dishes"].DataPropertyName = "Dishes";
            dataGridView_billInfo.Columns["dishes_name"].DataPropertyName = "DishesName";
            dataGridView_billInfo.Columns["dishes_price"].DataPropertyName = "DishesPrice";
            dataGridView_billInfo.Columns["xcount"].DataPropertyName = "XCount";
            dataGridView_billInfo.Columns["suma"].DataPropertyName = "Suma";
            dataGridView_billInfo.Columns["ref_status"].DataPropertyName = "RefStatus";
            dataGridView_billInfo.Columns["status_name"].DataPropertyName = "RefStatusName";
            dataGridView_billInfo.Columns["status_name"].DataPropertyName = "RefStatusName";
            dataGridView_billInfo.Columns["discount"].DataPropertyName = "Discount";
            dataGridView_billInfo.Columns["isToppingFor"].DataPropertyName = "isToppingFor";

            textBox_billNumber.Text = bill.BillId.ToString();
            textBox_billDateOpen.Text = bill.DateOpen.ToShortDateString() + " " + bill.DateOpen.ToShortTimeString();
            textBox_billSum.Text = BillInfo[bill.BillId].Sum(p => p.Suma).ToString();
            DateTimeBetween = DateTime.Now - bill.DateOpen;
            xDay = DateTimeBetween.Days.ToString();
            if (!xDay.Equals("0")) xDay += "дн. ";
            else xDay = "";
            xHours = DateTimeBetween.Hours.ToString();
            if (!xHours.Equals("0")) xHours += "час. ";
            else xHours = "";
            xMinutes = DateTimeBetween.Minutes.ToString();
            if (!xMinutes.Equals("0")) xMinutes += "мин.";
            else xMinutes = "";
            textBox_billTime.Text = xDay + xHours + xMinutes;
        }

        void dataGridView_dish_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (dataGridView_dish.SelectedRows.Count == 0) return;
                    ToolStripButton tsButton;
                    oFilter filter;
                    int xId = (int)dataGridView_dish.SelectedRows[0].Cells["id"].Value;

                    switch (((DataTable)dataGridView_dish.DataSource).TableName)
                    { 
                        case "carte":
                            filter = new oFilter();

                            tsButton = new ToolStripButton();
                            tsButton.Click += new EventHandler(tsButton_Click);
                            tsButton.Text = dataGridView_dish.SelectedRows[0].Cells["name"].Value.ToString();
                            tsButton.Name = (toolStrip_top.Items.Count + 1).ToString();

                            filter.TabName = "carte";
                            tsButton.Tag = filter;

                            toolStrip_top.Items.Add(tsButton);

                            xCurCarte = xId;
                            createDishesGroup(xCurCarte, 0);
                            break;

                        case "dishesgroup":
                            filter = new oFilter();

                            tsButton = new ToolStripButton();
                            tsButton.Click += new EventHandler(tsButton_Click);
                            tsButton.Text = dataGridView_dish.SelectedRows[0].Cells["name"].Value.ToString();
                            tsButton.Name = (toolStrip_top.Items.Count + 1).ToString();

                            filter.TabName = "dishesgroup";
                            filter.Dishesgroup = (int)dataGridView_dish.SelectedRows[0].Cells["id_parent"].Value;
                            filter.Carte = xCurCarte;
                            tsButton.Tag = filter;

                            toolStrip_top.Items.Add(tsButton);

                            xCurDishesGroup = xId;

                            var results = from myRow in dsDishes.Tables["dishes"].AsEnumerable()
                                          where myRow.Field<int>("carte_dishes_group") == xId
                                          select myRow;

                            if (results.Count() > 0)
                                createDishes(xCurDishesGroup, -1);
                            else
                                createDishesGroup(xCurCarte, xCurDishesGroup);

                            break;

                        case "dishes":
                            addDishToBill();
                            break;
                    }
                    e.SuppressKeyPress = true;
                    break;

                case Keys.Back:
                    if (toolStrip_top.Items.Count == 0) 
                    {
                        tabControl_main.SelectedIndex = 0;
                        dataGridView_bill.Rows[dataGridView_bill.CurrentRow.Index].Selected = true;
                        return; 
                    }
                    filter = (oFilter)((ToolStripButton)toolStrip_top.Items[(toolStrip_top.Items.Count).ToString()]).Tag;
                    toolStrip_top.Items[(toolStrip_top.Items.Count).ToString()].Dispose();
                    switch (filter.TabName)
                    {
                        case "carte":
                            createCarte();
                            break;

                        case "dishesgroup":
                            createDishesGroup(filter.Carte, filter.Dishesgroup);
                            break;
                    }
                    break;

                case Keys.Tab:
                    if (dataGridView_billInfo.CurrentRow == null) return;
                    dataGridView_billInfo.Focus();
                    dataGridView_billInfo.Rows[dataGridView_billInfo.CurrentRow.Index].Selected = true;
                    e.SuppressKeyPress = true;
                    break;
            }
        }

        private void addDishToBill()
        {
            oDishes Dishes = new oDishes();

            if (UsersInfo.Acl.Contains(4))   // Позволяет добавлять позиции к заказу
            {
                Dishes.Name = dataGridView_dish.SelectedRows[0].Cells["name"].Value.ToString();
                Dishes.Id = (int)dataGridView_dish.SelectedRows[0].Cells["id"].Value;
                Dishes.Price = float.Parse(dataGridView_dish.SelectedRows[0].Cells["price"].Value.ToString());

                oBillInfo billInfo = new oBillInfo();
                billInfo.Bill = bill.BillId;
                billInfo.Dishes = Dishes.Id;
                billInfo.DishesName = Dishes.Name;
                billInfo.DishesPrice = Dishes.Price;
                billInfo.RefStatus = 23;
                billInfo.RefStatusName = "Не обработано";

                billInfo.XCount = Dishes.Count;
                billInfo.Suma = billInfo.DishesPrice * billInfo.XCount;

                try
                {
                    DbAccess.addDishToBill("offline", bill, Dishes, xSelectedBillInfoId);
                }
                catch (Exception exc) { uMessage.Show("Не удалось добавить позицию к заказу.", exc, SystemIcons.Information); return; }

                BillInfo[billInfo.Bill].Add(billInfo);
                getBillsInfo(billInfo.Bill);
            }
        }

        void tsButton_Click(object sender, EventArgs e)
        {
            ToolStripButton tsButton = sender as ToolStripButton;
            oFilter filter = tsButton.Tag as oFilter;

            for(int i = toolStrip_top.Items.Count - 1; i >= 0; i--)
            {
                if (toolStrip_top.Items[i].Equals(tsButton))
                {
                    toolStrip_top.Items[i].Dispose();
                    break;
                }

                toolStrip_top.Items[i].Dispose();
            }

            switch (filter.TabName)
            {
                case "carte":
                    createCarte();
                    break;

                case "dishesgroup":
                    createDishesGroup(filter.Carte, filter.Dishesgroup);
                    break;
            }
        }

        private void createCarte()
        {
            switch (dsDishes.Tables["carte"].Rows.Count)
            {
                case 1:
                    xCurCarte = int.Parse(dsDishes.Tables["carte"].Rows[0]["id"].ToString());
                    createDishesGroup(xCurCarte, 0);
                    break;

                case 0:
                    return;

                default:
                    break;
            }

            dataGridView_dish.Columns.Clear();

            dataGridView_dish.DataSource = dsDishes.Tables["carte"];

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


            dataGridView_dish.Columns.AddRange(new DataGridViewColumn[] { col0, col1 });

        }

        private void createDishesGroup(int pCurCarte, int pCurDishesGroup)
        {
            dataGridView_dish.Columns.Clear();

            dsDishes.Tables["dishesgroup"].DefaultView.RowFilter = string.Format("carte = {0} AND id_parent = {1}", pCurCarte, pCurDishesGroup);
            dataGridView_dish.DataSource = dsDishes.Tables["dishesgroup"];

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = "id";
            col0.Name = "id";
            col0.DataPropertyName = "id";
            col0.Visible = false;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "carte";
            col1.Name = "carte";
            col1.DataPropertyName = "carte";
            col1.Visible = false;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "id_parent";
            col2.Name = "id_parent";
            col2.DataPropertyName = "id_parent";
            col2.Visible = false;

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "name";
            col3.Name = "name";
            col3.DataPropertyName = "name";
            col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView_dish.Columns.AddRange(new DataGridViewColumn[] { col0, col1, col2, col3 });
        }

        private void createDishes(int pCurDishesGroup, int pCurSelectedDishId)
        {
            dataGridView_dish.Columns.Clear();

            
            dsDishes.Tables["dishes"].DefaultView.RowFilter = string.Format("carte_dishes_group = {0}", pCurDishesGroup);
            dataGridView_dish.DataSource = dsDishes.Tables["dishes"];

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = "id";
            col0.Name = "id";
            col0.DataPropertyName = "id";
            col0.Visible = false;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "carte_dishes_group";
            col1.Name = "carte_dishes_group";
            col1.DataPropertyName = "carte_dishes_group";
            col1.Visible = false;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "name";
            col2.Name = "name";
            col2.DataPropertyName = "name";
            col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "price";
            col3.Name = "price";
            col3.DataPropertyName = "price";
            col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView_dish.Columns.AddRange(new DataGridViewColumn[] { col0, col1, col2, col3 });

            if (pCurSelectedDishId >= 0)
            {
                int rowIndex = -1;

                DataGridViewRow row = dataGridView_dish.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => r.Cells["id"].Value.ToString().Equals(pCurSelectedDishId.ToString()))
                    .First();

                rowIndex = row.Index;
                dataGridView_dish.CurrentCell = dataGridView_dish.Rows[rowIndex].Cells["name"];
                dataGridView_dish.Rows[rowIndex].Selected = true;
            }
        }

        private void fMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    UsersInfo.Clear();
                    checkEmptyBill(); // проверяем пустой ли счет, если пустой - ставим статус удален
                    Close();
                    break;

                case Keys.F2:   // Новый счет
                    if (UsersInfo.Acl.Contains(3))
                    {
                        createBill();
                        dataGridView_bill.Rows[dataGridView_bill.Rows.Count - 1].Selected = true;
                        dataGridView_bill_KeyDown(null, new KeyEventArgs(Keys.Enter));
                    }
                    else
                        uMessage.Show("Нет доступа на создание заказа.", SystemIcons.Information);
                    break;

                case Keys.F3:   // Печать бегунка
                    if (UsersInfo.Acl.Contains(7))
                    {
                        processBill();
                    }
                    else
                        uMessage.Show("Нет доступа на формирования заказа.", SystemIcons.Information);
                    break;

                case Keys.F5:   // Закрытие заказа, печать чека
                    if (UsersInfo.Acl.Contains(8))
                    {
                        closeBill();
                    }
                    else
                        uMessage.Show("Нет доступа на закрытие заказа.", SystemIcons.Information);
                    break;
            }
        }

        // проверяем пустой ли счет, если пустой - ставим статус удален
        private void checkEmptyBill()
        {
            try
            {
                DbAccess.checkEmptyBill("offline", bill);
            }
            catch (Exception exc) { uMessage.Show("Не удалось закрыть пустой счет.", exc, SystemIcons.Information); return; }
        }

        private void closeBill()
        {
            DataTable dtResult = null;

            bool NotProcessed = false;

            #region Проверка блюд в счете

            List<oBillInfo> list = BillInfo[bill.BillId];
            foreach (oBillInfo oBInfo in list)
            {
                if (oBInfo.RefStatus == 23)
                {
                    NotProcessed = true;
                    break;
                }
            }

            if (NotProcessed)
            {
                MessageBox.Show("Есть позиции не отправленные на приготовление, закрытие заказа не возможно", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            #endregion

            try
            {
                dtResult = DbAccess.closeBill("offline", bill);
            }
            catch (Exception exc) { uMessage.Show("Не удалось закрыть счет.", exc, SystemIcons.Information); return; }

            ReportDocument repDoc = new ReportDocument();
            repDoc.Load(dtResult.Rows[0]["reportPath"].ToString());
            repDoc.SetDataSource(dtResult);
            repDoc.SetParameterValue("waiterName", UsersInfo.UserName);
            repDoc.PrintOptions.PrinterName = dtResult.Rows[0]["printerName"].ToString();
            repDoc.PrintToPrinter(1, false, 0, 0);

            getBill();
        }

        private void processBill()
        {
            DataTable dtResult = null;
            ReportDocument repDoc;
            DataSet ds = new DataSet();
            bool NotProcessed = false;

            #region Проверка блюд в счете

            List<oBillInfo> list = BillInfo[bill.BillId];
            foreach (oBillInfo oBInfo in list)
            {
                if (oBInfo.RefStatus == 23)
                {
                    NotProcessed = true;
                    break;
                }
            }

            if (!NotProcessed)
            {
                MessageBox.Show("Нет позиций для изготовления.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            #endregion

            try
            {
                dtResult = DbAccess.processBill("offline", bill);
            }
            catch (Exception exc) { uMessage.Show("Не удалось создать заказ.", exc, SystemIcons.Information); }

            if (dtResult.Rows.Count == 0) return;

            ds.Tables.Add(dtResult);

            var results_1 = from myRow in dtResult.AsEnumerable()
                          where myRow.Field<int>("ref_printers_type") == 1
                          select myRow;

            if (results_1.Count() > 0) // есть позиции на принтер Кухни
            {
                repDoc = new ReportDocument();
                repDoc.Load(results_1.First().Field<string>("reportPath"));
                repDoc.SetDataSource(ds);
                repDoc.SetParameterValue("waiterName", UsersInfo.UserName);
                repDoc.SetParameterValue("curDate", DateTime.Now);
                repDoc.SetParameterValue("billNumber", bill.BillId);
                repDoc.SetParameterValue("printersType",1);
                repDoc.PrintOptions.PrinterName = results_1.First().Field<string>("printerName");
                repDoc.PrintToPrinter(1, false, 0, 0);
            }

            var results_2 = from myRow in dtResult.AsEnumerable()
                          where myRow.Field<int>("ref_printers_type") == 2
                          select myRow;

            if (results_2.Count() > 0) // есть позиции на принтер Бара
            {
                repDoc = new ReportDocument();
                repDoc.Load(results_2.First().Field<string>("reportPath"));
                repDoc.SetDataSource(ds);
                repDoc.SetParameterValue("waiterName", UsersInfo.UserName);
                repDoc.SetParameterValue("curDate", DateTime.Now);
                repDoc.SetParameterValue("billNumber", bill.BillId);
                repDoc.SetParameterValue("printersType", 2);
                repDoc.PrintOptions.PrinterName = results_2.First().Field<string>("printerName");
                repDoc.PrintToPrinter(1, false, 0, 0);
            }

            changeBillInfoStatus(24);
            getBill();
        }

        private void changeBillInfoStatus(int pStatus)
        {
            try
            {
                DbAccess.changeBillInfoStatus("offline", bill, pStatus);
            }
            catch (Exception exc) { uMessage.Show("Не удалось создать заказ.", exc, SystemIcons.Information); }
        }

        private void createBill()
        {
            try
            {
                DbAccess.createBill("offline");
            }
            catch (Exception exc) { uMessage.Show("Не удалось создать заказ.", exc, SystemIcons.Information); }

            getBill();
        }

        private void tabControl_main_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl_main.SelectedIndex)
            {
                case 0:
                    dataGridView_bill.Focus();
                    break;

                case 1:
                    dataGridView_dish.Focus();
                    break;

                case 2:
                    break;
            }
        }

        private void dataGridView_billInfo_Leave(object sender, EventArgs e)
        {
            dataGridView_billInfo.ClearSelection();
        }

        private void dataGridView_bill_Leave(object sender, EventArgs e)
        {
            dataGridView_bill.ClearSelection();
        }

        private void dataGridView_dish_Leave(object sender, EventArgs e)
        {
            dataGridView_dish.ClearSelection();
        }
    }

    class oFilter
    {
        private string _tabName;
        private int _carte;
        private int _dishesgroup;
        private int _dishes;

	    public int Dishes
	    {
		    get { return _dishes;}
		    set { _dishes = value;}
	    }
	
	    public int Dishesgroup
	    {
		    get { return _dishesgroup;}
		    set { _dishesgroup = value;}
	    }

	    public int Carte
	    {
		    get { return _carte;}
		    set { _carte = value;}
	    }
	
	    public string TabName
	    {
		    get { return _tabName;}
		    set { _tabName = value;}
	    }
    }
}
