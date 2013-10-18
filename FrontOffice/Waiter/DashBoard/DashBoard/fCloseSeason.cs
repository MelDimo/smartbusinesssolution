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

namespace com.sbs.gui.DashBoard
{
    public partial class fCloseSeason : Form
    {

        private DBaccess DbAccess = new DBaccess();
        int xCurPanel;

        public fCloseSeason()
        {
            InitializeComponent();

            //b.id AS billId, b.numb AS billNumber, u.id AS userId, u.lname +' '+ u.fname +' '+ u.sname AS fio,
            //                            sum(bi.dishes_price * xcount) AS suma,
            //                            b.date_open, b.date_close, stat.id AS statId, stat.name

            dataGridView_waiterInfo.AutoGenerateColumns = false;
            dataGridView_waiterInfo.Columns["billId"].DataPropertyName = "billId";
            dataGridView_waiterInfo.Columns["billNumber"].DataPropertyName = "billNumber";
            dataGridView_waiterInfo.Columns["billId"].DataPropertyName = "billId";
            dataGridView_waiterInfo.Columns["billSum"].DataPropertyName = "suma";
            dataGridView_waiterInfo.Columns["billStatus"].DataPropertyName = "name";
            dataGridView_waiterInfo.Columns["idStatus"].DataPropertyName = "statId";
        }

        private void fCloseSeason_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;

                case Keys.Back:
                    switch (xCurPanel)
                    { 
                        case 1:
                            showMain();
                            break;

                        default:
                            break;
                    }
                    break;
            }
        }


        private void fCloseSeason_Shown(object sender, EventArgs e)
        {
            label_seasonNumber.Text += " " + GValues.openSeasonId;
            label_seasonName.Text = GValues.openSeasonUserName + " (" + GValues.openSeasonDate + ")";

            getWaiter();

            if (flowLayoutPanel_waiter.Controls.Count > 0)
                flowLayoutPanel_waiter.Controls[0].Focus();
        }

        private void getWaiter()
        {
            int xCurUser;
            int xCurStatusId;;

            Dictionary<int, WaiterBills> dWaiterBills = new Dictionary<int, WaiterBills>();

            DataTable dtWaiter = new DataTable();

            try
            {
                dtWaiter = DbAccess.getWaiters("offline");
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information); return; }

            dataGridView_waiterInfo.DataSource = dtWaiter;

            foreach (DataRow dr in dtWaiter.Rows)
            {
                xCurUser = (int)dr["userId"];
                xCurStatusId = (int)dr["statId"];

                if (dWaiterBills.ContainsKey(xCurUser))
                {
                    // если сохранен статус открытого счета, его не переписываем
                    if (((WaiterBills)dWaiterBills[xCurUser]).status != xCurStatusId && ((WaiterBills)dWaiterBills[xCurUser]).status != 20)
                    {
                        ((WaiterBills)dWaiterBills[xCurUser]).status = xCurStatusId;
                    }
                }
                else
                {
                    dWaiterBills.Add(xCurUser, new WaiterBills() { userId = xCurUser, 
                                                                    userName = dr["fio"].ToString(), 
                                                                    status = xCurStatusId });
                }
            }

            Button btn;

            foreach (WaiterBills wb in dWaiterBills.Values)
            {
                btn = new Button();
                btn.Text = wb.userName;
                btn.BackColor = wb.status == 20 ? Color.Red : Color.Green;
                btn.Font = new Font("Microsoft Sans Serif", 15);
                btn.Width = 530;
                btn.Height = 35;
                btn.Tag = wb;
                btn.Click += new EventHandler(btn_Click);

                flowLayoutPanel_waiter.Controls.Add(btn);
            }
        }

        void btn_Click(object sender, EventArgs e)
        {
            Button bt = sender as Button;
            showWaiterInfo(bt.Tag as WaiterBills);
        }

        void showWaiterInfo(WaiterBills pWaiterBills)
        {
            xCurPanel += 1;

            panel_waiterInfo.BringToFront();
            panel_main.SendToBack();

            panel_waiterInfo.Left = panel_main.Left + panel_main.Width;

            (dataGridView_waiterInfo.DataSource as DataTable).DefaultView.RowFilter = string.Format("userId = '{0}'", pWaiterBills.userId);

            dataGridView_waiterInfo.Focus();

            while (true)
            {
                if (panel_waiterInfo.Left != panel_main.Left)
                {
                    panel_waiterInfo.Left--;
                }
                else return;
            }
        }

        private void showMain()
        {
            xCurPanel -= 1;

            panel_main.BringToFront();
            panel_waiterInfo.SendToBack();

            panel_main.Left = -1 * panel_waiterInfo.Width;

            while (true)
            {
                if (panel_main.Left != panel_waiterInfo.Left)
                {
                    panel_main.Left++;
                }
                else return;
            }
        }

        private void dataGridView_waiterInfo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            actionOnBill(e.RowIndex);
        }

        private void dataGridView_waiterInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridView_waiterInfo.SelectedRows.Count != 0) return;

            actionOnBill(dataGridView_waiterInfo.SelectedRows[0].Index);
        }

        private void actionOnBill(int pRowIndex)
        {
            DataGridViewRow dr = dataGridView_waiterInfo.Rows[pRowIndex];

            // проверяем состояние счета. Интересууют только открытые счета
            if ((int)dr.Cells["idStatus"].Value != 20) return;

            // проверяем есть ли разрешение закрывать счета официантов
            if (!UsersInfo.Acl.Contains(9)) return;



            //closeWaiterBill((int)dr.Cells["billId"].Value, pUserId_from, pUserId_to);
        }

        private void closeWaiterBill(int pBillId, int pUserId_from, int pUserId_to)
        {
            try
            {
                DbAccess.BillToAnotherWaiter("offline", pBillId, pUserId_from, pUserId_to);
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information); return; }

            MessageBox.Show("Close bill");
        }
    }

    class WaiterBills
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public int status { get; set; }
    }
}

