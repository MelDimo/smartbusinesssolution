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
    public partial class fMain : Form
    {
        private DBaccess dbAccess = new DBaccess();
        private int curScene = 0;
        ctrDishes oCtrDishes;
        Bill oBill;

        enum zoneFocus { PANEL_LEFT, PANEL_RIGHT };
        enum action { SELECT_BILL, ADD_DISH };

        zoneFocus eCurZoneFocus;
        action eCurAction;
        zoneFocus ePrevZoneFocus;
        action ePrevAction;

        public fMain()
        {
            InitializeComponent();

            createBillObject();
        }

        private void fMain_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Close();
                    break;
                case Keys.F2:
                    newBill();
                    break;
                case Keys.Return:
                    backSpaceKey();
                    break;
            }
        }

        private void backSpaceKey()
        {
            if (eCurZoneFocus == null || eCurAction == null || ePrevZoneFocus == null || ePrevAction == null) return;

            switch (ePrevZoneFocus)
            { 
                case zoneFocus.PANEL_LEFT:
                    switch (ePrevAction)
                    { 
                        case action.ADD_DISH:
                            break;
                        case action.SELECT_BILL:
                            break;
                    }
                    break;
                case zoneFocus.PANEL_RIGHT:
                    break;
            }
        }

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
                //btnBill.BackColor = Color.FromArgb(255, 255, 196);
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
            List<Dish> oDishList;
            try
            {
                oDishList = dbAccess.getBillInfo("offline", (Bill)((Button)sender).Tag);
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
                return;
            }

            flowLayoutPanel_billInfo.Controls.Clear();

            foreach(Dish oDish in oDishList)
            {
                oCtrDishes = new ctrDishes();
                oCtrDishes.label_name.Text = oDish.name;
                oCtrDishes.label_count.Text = oDish.count.ToString();
                oCtrDishes.label_portion.Text = oDish.portion;
                oCtrDishes.label_price.Text = (oDish.price * oDish.count).ToString();
 
                flowLayoutPanel_billInfo.Controls.Add(oCtrDishes);
            }
        }

        void btnBill_Click(object sender, EventArgs e)
        {
            editBill((Bill)((Button)sender).Tag);
        }

        private void editBill(Bill pBill)
        {
            ePrevZoneFocus = eCurZoneFocus;
            ePrevAction = eCurAction;
            eCurZoneFocus = zoneFocus.PANEL_RIGHT;
            eCurAction = action.ADD_DISH;

            label_billsInfo.Text = "Счет № " + pBill.numb.ToString() + Environment.NewLine +
                                    "Столик: " + pBill.table.ToString() + Environment.NewLine +
                                    "Открыт: " + pBill.openDate.ToString() + Environment.NewLine;

            tabControl_left.SelectedTab = tabControl_left.TabPages[1];
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

                case 1:
                    radioButton_carte.Checked = true;
                    break;

                case 2:
                    radioButton_groups.Checked = true;
                    break;

                case 3:
                    radioButton_dishes.Checked = true;
                    break;

                case 4:
                    radioButton_saintBox.Checked = true;
                    break;

                case 5:
                    radioButton_freePage.Checked = true;
                    break;
            }
        }

        
    }
}
