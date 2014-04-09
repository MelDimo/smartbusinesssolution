using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;
using com.sbs.dll;

namespace com.sbs.gui.seasonbrowser
{
    public partial class fMain : Form
    {
        DBaccess dbAccess = new DBaccess();

        Filter oFilter = new Filter();
        
        List<ctrSeasonBranch> lCtrSeasonBranch;
        List<DTO_DBoard.SeasonBranch> lSeasonBranch;

        List<ctrBill> lCtrBill;
        List<DTO_DBoard.Bill> lBill;

        List<ctrDishes> lCtrDishes;
        List<DTO_DBoard.Dish> lDish;

        public fMain()
        {
            InitializeComponent();

            button_filter.BackgroundImage = com.sbs.dll.utilites.Properties.Resources.filter_26;
        }

        private void button_branch_Click(object sender, EventArgs e)
        {
            fChooserUnit fChooseBranch = new fChooserUnit(0, 2);
            if (fChooseBranch.ShowDialog() != DialogResult.OK) return;

            oFilter.branch = fChooseBranch.selectedId;
            textBox_branch.Text = fChooseBranch.selectedName;
        }

        private void button_filter_Click(object sender, EventArgs e)
        {
            oFilter.dateStart = dateTimePicker_start.Value;
            oFilter.dateEnd = dateTimePicker_end.Value;

            getData_Season();
        }

        private void getData_Season()
        {
            ctrSeasonBranch oCtrSeasonBranch;

            lCtrSeasonBranch = new List<ctrSeasonBranch>();
            lSeasonBranch = new List<DTO_DBoard.SeasonBranch>();

            try
            {
                lSeasonBranch = dbAccess.getSeason(oFilter);
            }
            catch (Exception exc) { uMessage.Show("Неудалось получить данные.", exc, SystemIcons.Information); return; }

            foreach (Control ctr in flowLayoutPanel_season.Controls)
            {
                ctr.Dispose();
            }

            flowLayoutPanel_season.Controls.Clear();

            foreach (DTO_DBoard.SeasonBranch oSeasonBranch in lSeasonBranch)
            {
                oCtrSeasonBranch = new ctrSeasonBranch(oSeasonBranch);
                oCtrSeasonBranch.Width = flowLayoutPanel_season.Width - 25;
                oCtrSeasonBranch.button_host.Click += new EventHandler(oCtrSeasonBranch_Click);
                flowLayoutPanel_season.Controls.Add(oCtrSeasonBranch);
            }
        }

        void oCtrSeasonBranch_Click(object sender, EventArgs e)
        {
            ctrSeasonBranch oCtrBSeason = (ctrSeasonBranch)((Button)sender).Parent;
            oFilter.season = int.Parse(oCtrBSeason.label_seasonNumb.Text);
            getBills();
        }

        private void getBills()
        {
            ctrBill oCtrBill;

            lBill = new List<DTO_DBoard.Bill>();
            lCtrBill = new List<ctrBill>();

            try
            {
                lBill = dbAccess.getBill(oFilter);
            }
            catch (Exception exc) { uMessage.Show("Неудалось получить данные.", exc, SystemIcons.Information); return; }

            foreach (DTO_DBoard.Bill oBill in lBill)
            {
                oCtrBill = new ctrBill();
                oCtrBill.id = oBill.id;
                oCtrBill.label_numbBill.Text = oBill.numb.ToString();
                oCtrBill.label_summ.Text = oBill.summ.ToString("F2");
                oCtrBill.label_refStatusName.Text = oBill.refStatName;
                switch (oBill.refStat)
                {
                    case 20:
                        oCtrBill.label_refStatusName.ForeColor = Color.Red;
                        break;
                    case 21:
                        oCtrBill.label_refStatusName.ForeColor = Color.Green;
                        break;
                }
                oCtrBill.label_numbTable.Text = oBill.table.ToString();
                oCtrBill.label_dateOpenClose.Text = oBill.openDate.ToString() + " - " + oBill.closeDate.ToString();
                oCtrBill.button_host.Click += new EventHandler(oCtrBill_Click);
                oCtrBill.label_summ.Text = oBill.summFact.ToString("F2");

                oCtrBill.button_editMnu.BackgroundImage = com.sbs.dll.utilites.Properties.Resources.edit_26;

                lCtrBill.Add(oCtrBill);
            }

            label_billsCount.Text = lCtrBill.Count.ToString();

            oFilter.curLast = 0;
            
            showBills();
        }

        void oCtrBill_Click(object sender, EventArgs e)
        {
            ctrBill oCtrBill = (ctrBill)((Button)sender).Parent;
            oFilter.bill = oCtrBill.id;

            getDishes();
        }

        private void getDishes()
        {
            ctrDishes oCtrDishes = new ctrDishes();

            lDish = new List<DTO_DBoard.Dish>();
            lCtrDishes = new List<ctrDishes>();

            try
            {
                lDish = dbAccess.getDish(oFilter);
            }
            catch (Exception exc) { uMessage.Show("Неудалось получить данные.", exc, SystemIcons.Information); return; }

            foreach (DTO_DBoard.Dish oDish in lDish)
            {
                oCtrDishes = new ctrDishes();
                oCtrDishes.id = oDish.id;
                oCtrDishes.label_name.Text = oDish.name;
                oCtrDishes.label_price.Text = oDish.price.ToString("F2");
                oCtrDishes.numericUpDown_count.Value = oDish.count;
                oCtrDishes.numericUpDown_count.ReadOnly = true;
                //oCtrDishes.comboBox_note.FlatStyle = FlatStyle.Standard;
                //oCtrDishes.comboBox_note.Items.Add(oDish.refNotesName);
                //oCtrDishes.comboBox_note.SelectedItem = oDish.refNotesName;

                oCtrDishes.TabStop = false;

                oCtrDishes.button_topping.Visible = false;
                oCtrDishes.button_deals.Visible = false;

                oCtrDishes.Width = flowLayoutPanel_dishes.Width - 25;

                flowLayoutPanel_dishes.Controls.Add(oCtrDishes);
            }
        }

        #region ------------------------------------------------------------- Навигация поп счетам

        private void button_gotoNext_Click(object sender, EventArgs e)
        {
            if (lCtrBill.Count - oFilter.countBill > 0) { }
            else oFilter.curLast = 0;

            showBills();
        }

        private void button_gotoLast_Click(object sender, EventArgs e)
        {
            if (lCtrBill.Count - oFilter.countBill > 0) oFilter.curLast = lCtrBill.Count - oFilter.countBill;
            else oFilter.curLast = 0;
            
            showBills();
        }

        private void button_gotoBack_Click(object sender, EventArgs e)
        {

            if (oFilter.curLast - oFilter.countBill * 2 > 0) oFilter.curLast = oFilter.curLast - oFilter.countBill * 2;
            else oFilter.curLast = 0;

            showBills();
        }

        private void button_gotoFirst_Click(object sender, EventArgs e)
        {
            oFilter.curLast = 0;
            showBills();
        }

        private void showBills()
        {
            int countBills = 0;
            int indexBills = oFilter.curLast ;

            label_billsFirstLast.Text = oFilter.curLast.ToString() + " - ";

            flowLayoutPanel_bills.Controls.Clear();

            while (true)
            {
                countBills++;
                indexBills++;
                if (countBills > oFilter.countBill || indexBills > lCtrBill.Count)
                {
                    label_billsFirstLast.Text += oFilter.curLast.ToString();
                    break;
                }

                lCtrBill[oFilter.curLast].Width = flowLayoutPanel_bills.Width - 25;
                flowLayoutPanel_bills.Controls.Add(lCtrBill[oFilter.curLast]);

                oFilter.curLast = indexBills;
            }
        }

        #endregion

        #region ------------------------------------------------------------- Размер контролов

        private void flowLayoutPanel_season_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control ctr in flowLayoutPanel_season.Controls)
            {
                ctr.Width = flowLayoutPanel_season.Width - 25;
            }
        }

        private void flowLayoutPanel_bills_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control ctr in flowLayoutPanel_bills.Controls)
            {
                ctr.Width = flowLayoutPanel_bills.Width - 25;
            }
        }

        private void flowLayoutPanel_dishes_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control ctr in flowLayoutPanel_dishes.Controls)
            {
                ctr.Width = flowLayoutPanel_dishes.Width - 25;
            }
        }

        #endregion
    }
}
