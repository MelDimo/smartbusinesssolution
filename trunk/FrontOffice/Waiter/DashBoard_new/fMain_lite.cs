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

namespace com.sbs.gui.dashboard
{
    public partial class fMain_lite : Form
    {
        #region enum eCurrentPanel
        private enum eCurrentPanel{ Bills, MenuGroups, Dishes}
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
                        dataGridView_bills.Focus();
                        break;

                    case eCurrentPanel.MenuGroups:
                        label_leftAreaInfo.Text = "Меню";
                        panel_menuGroups.BringToFront();
                        treeView_CarteGroups.Focus();
                        panel_carteGroups.BackColor = Color.FromKnownColor(KnownColor.Highlight);
                        panel_carteDishes.BackColor = Color.FromKnownColor(KnownColor.Control);
                        dataGridView_dishes.ClearSelection();
                        break;

                    case eCurrentPanel.Dishes:
                        label_leftAreaInfo.Text = "Меню";
                        panel_carteDishes.BackColor = Color.FromKnownColor(KnownColor.Highlight);
                        panel_carteGroups.BackColor = Color.FromKnownColor(KnownColor.Control);
                        dataGridView_dishes.Rows[0].Selected = true;
                        dataGridView_dishes.Focus();
                        break;
                }
                _currPanel = value;
            }
        }
        #endregion

        private DBaccess dbAccess = new DBaccess();

        private List<DTO_DBoard.Bill> lBills;
        private List<DTO_DBoard.Dish> lDishs;

        DTO_DBoard.Bill curBill;

        private DataTable dtDishes;
        private string dtDishesFilter; // С помощью это фильтра разруиваю какие блюда показывать в доставке а кикие в меню зала

        public fMain_lite()
        {
            InitializeComponent();

            dataGridView_bills.AutoGenerateColumns = false;
            dataGridView_billInfo.AutoGenerateColumns = false;
            dataGridView_dishes.AutoGenerateColumns = false;

            currPanel = eCurrentPanel.Bills;
        }

        private void fMain_lite_Shown(object sender, EventArgs e)
        {
            fillBills();
        }

        private void fMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    switch (currPanel)
                    {
                        case eCurrentPanel.Bills:
                            Close();
                            break;
                        case eCurrentPanel.MenuGroups:
                            currPanel = eCurrentPanel.Bills;
                            break;
                        case eCurrentPanel.Dishes:
                            currPanel = eCurrentPanel.MenuGroups;
                            break;
                    }
                    
                    break;

                case Keys.Enter:
                    break;
            }
        }

        private void fillBills()
        {
            lBills = new List<DTO_DBoard.Bill>();

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

            dataGridView_bills.Focus();

            dataGridView_bills.SelectionChanged -= new EventHandler(dataGridView_bills_SelectionChanged);

            if (lBills.Count > 0) fillBillsInfo(lBills[0]);

            dataGridView_bills.SelectionChanged += new EventHandler(dataGridView_bills_SelectionChanged);
        }

        void dataGridView_bills_SelectionChanged(object sender, EventArgs e)
        {
            fillBillsInfo(lBills[dataGridView_bills.SelectedRows[0].Index]);
        }

        private void fillBillsInfo(DTO_DBoard.Bill pBill)
        {
            lDishs = new List<DTO_DBoard.Dish>();

            try
            {
                lDishs = dbAccess.getBillInfo(GValues.DBMode, pBill);
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
            dataGridView_billInfo.DataSource = lDishs;

            foreach (DataGridViewRow dr in dataGridView_billInfo.Rows)
            {
                dr.Cells["billsinfo_summ"].Value =
                    ((decimal)dr.Cells["billsinfo_price"].Value * (decimal)dr.Cells["billsinfo_count"].Value).ToString("F2");

                if ((int)dr.Cells["billsinfo_refStatus"].Value == 24) dr.DefaultCellStyle.ForeColor = Color.Red;
                else dr.DefaultCellStyle.ForeColor = Color.Green;

                dr.DefaultCellStyle.SelectionForeColor = dr.DefaultCellStyle.ForeColor;
            }

            tSSLabel_countBillInfo.Text = string.Format("Количество позиций: {0}", dataGridView_billInfo.Rows.Count);
        }

        private void dataGridView_bills_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    curBill = lBills[dataGridView_bills.SelectedRows[0].Index];
                    editBill(curBill);
                    break;
            }
        }

        private void editBill(DTO_DBoard.Bill bill)
        {
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
            currPanel = eCurrentPanel.MenuGroups;
            treeView_CarteGroups.Focus();
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

            //if (treeView_CarteGroups.SelectedNode.Nodes.Count > 0) return; // Отсекаем не конечные пункты

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
                if (dataGridView_dishes.Rows.Count == 0) return;

                currPanel = eCurrentPanel.Dishes;
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
                    addDish2Bill(oDish);
                    break;
            }
        }

        private void addDish2Bill(DTO_DBoard.Dish oDish)
        {
            DataTable dtNotesDish = new DataTable();
            ctrDishes oCtrDishes =

            oCtrDishes = new ctrDishes(oDish, "dashboard");

            oCtrDishes.TabStop = false;
            //oCtrDishes.button_topping.Visible = false;
            oCtrDishes.button_deals.Visible = false;
            oCtrDishes.numericUpDown_count.Visible = false;
            oCtrDishes.label_count.Visible = false;
            oCtrDishes.comboBox_note.Visible = false;

            //----------------------------------------------------- Была ошибка с выставление начально кол-ва в последнее указываемое... хз
            oCtrDishes.oDish.count = oCtrDishes.oDish.minStep;
            oCtrDishes.numericUpDown_count.Value = oCtrDishes.oDish.minStep;
            //-----------------------------------------------------

            DashboardEnvironment.dtNotes.DefaultView.RowFilter = "ref_notes_type IN (0, 2)";
            oCtrDishes.comboBox_note.DataSource = DashboardEnvironment.dtNotes; // Выбераем только статусы доступные для блюд
            oCtrDishes.comboBox_note.DisplayMember = "note";
            oCtrDishes.comboBox_note.ValueMember = "id";
            fAddDishToBill faddDish2Bill = new fAddDishToBill(curBill, oCtrDishes);
            if (faddDish2Bill.ShowDialog() == DialogResult.OK)
            {
                fillBillsInfo(curBill);
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
    }
}
