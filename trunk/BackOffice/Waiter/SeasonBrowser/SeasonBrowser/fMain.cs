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
using com.sbs.gui.seasonbrowser.Properties;

namespace com.sbs.gui.seasonbrowser
{
    public partial class fMain : Form
    {
        DBaccess dbAccess = new DBaccess();
        getReference getRef = new getReference();

        Filter oFilter = new Filter();
        
        List<ctrSeasonBranch> lCtrSeasonBranch;
        List<DTO_DBoard.SeasonBranch> lSeasonBranch;

        List<ctrBill> lCtrBill;
        List<DTO_DBoard.Bill> lBill;

        List<ctrDishes> lCtrDishes;
        List<DTO_DBoard.Dish> lDish;

        DataTable dtPaymentType;
        DataTable dtNotesBills;
        DataTable dtNotesDish;
        DataTable dtRefStatusBills;
        DataTable dtRefStatusDish;

        public fMain()
        {
            InitializeComponent();

            button_filter.BackgroundImage = com.sbs.dll.utilites.Properties.Resources.filter_26;
            tSButton_export.Image = com.sbs.dll.utilites.Properties.Resources.download_26;

            initRefer();
        }

        private void initRefer()
        {
            try
            {
                dtPaymentType = getRef.getPaymentType(GValues.DBMode);
                dtNotesBills = getRef.getRefNotes(GValues.DBMode, 1);
                dtNotesDish = getRef.getRefNotes(GValues.DBMode, 2);
                dtRefStatusBills = getRef.getStatus(GValues.DBMode, 4);
                dtRefStatusDish = getRef.getStatus(GValues.DBMode, 5);
            }
            catch (Exception exc)
            {
                uMessage.Show("Не удалось получить справичники", exc, SystemIcons.Information);
                setEnabled(false);
                return;
            }
        }

        private void setEnabled(bool pEnabled)
        {
            foreach (Control ctr in this.Controls) ctr.Enabled = pEnabled;
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
            flowLayoutPanel_bills.Controls.Clear();
            flowLayoutPanel_dishes.Controls.Clear();

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

            flowLayoutPanel_bills.Controls.Clear();
            flowLayoutPanel_dishes.Controls.Clear();

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
                oCtrBill = new ctrBill(oBill);
                oCtrBill.button_host.Click += new EventHandler(oCtrBill_Click);

                oCtrBill.button_editMnu.Visible=true;
                oCtrBill.button_editMnu.Click += new EventHandler(BillButton_editMnu_Click);

                lCtrBill.Add(oCtrBill);
            }

            label_billsCount.Text = lCtrBill.Count.ToString();

            oFilter.curLast = 0;
            
            showBills();
        }

        void BillButton_editMnu_Click(object sender, EventArgs e)
        {
            ctrBill oCtrBill = (ctrBill)((Button)sender).Parent;

            fBillEdit fbillEdit = new fBillEdit(oFilter, oCtrBill.oBill);
            
            fbillEdit.comboBox_typePayment.DataSource = dtPaymentType;
            fbillEdit.comboBox_typePayment.ValueMember = "id";
            fbillEdit.comboBox_typePayment.DisplayMember = "name";

            fbillEdit.comboBox_notes.DataSource = dtNotesBills;
            fbillEdit.comboBox_notes.ValueMember = "id";
            fbillEdit.comboBox_notes.DisplayMember = "note";

            fbillEdit.comboBox_status.DataSource = dtRefStatusBills;
            fbillEdit.comboBox_status.ValueMember = "id";
            fbillEdit.comboBox_status.DisplayMember = "name";

            if (fbillEdit.ShowDialog() != DialogResult.OK) return;

            getBills();
        }

        void oCtrBill_Click(object sender, EventArgs e)
        {
            ctrBill oCtrBill = (ctrBill)((Button)sender).Parent;
            oFilter.bill = oCtrBill.oBill.id;

            flowLayoutPanel_dishes.Controls.Clear();

            getDishes();
        }

        private void getDishes()
        {
            ctrDishes oCtrDishes;

            lDish = new List<DTO_DBoard.Dish>();
            lCtrDishes = new List<ctrDishes>();

            try
            {
                lDish = dbAccess.getDish(oFilter);
            }
            catch (Exception exc) { uMessage.Show("Неудалось получить данные.", exc, SystemIcons.Information); return; }

            flowLayoutPanel_dishes.Controls.Clear();

            foreach (DTO_DBoard.Dish oDish in lDish)
            {
                oCtrDishes = new ctrDishes(oDish);

                oCtrDishes.TabStop = false;

                oCtrDishes.button_topping.Visible = false;
                oCtrDishes.button_deals.Visible = false;
                oCtrDishes.comboBox_note.Visible = false;
                
                oCtrDishes.button_editMnu.Visible = true;
                oCtrDishes.button_editMnu.Click += new EventHandler(DishButton_editMnu_Click);

                oCtrDishes.Width = flowLayoutPanel_dishes.Width - 25;

                flowLayoutPanel_dishes.Controls.Add(oCtrDishes);
            }
        }

        void DishButton_editMnu_Click(object sender, EventArgs e)
        {
            DTO_DBoard.Dish oDish = ((ctrDishes)((Button)sender).Parent).oDish;

            fDishEdit fdishEdit = new fDishEdit(oFilter, oDish);

            fdishEdit.comboBox_status.DataSource = dtRefStatusDish;
            fdishEdit.comboBox_status.ValueMember = "id";
            fdishEdit.comboBox_status.DisplayMember = "name";

            if (fdishEdit.ShowDialog() != DialogResult.OK) return;

            getDishes();
        }

        #region ------------------------------------------------------------- Навигация по счетам

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

        private void tSButton_export_Click(object sender, EventArgs e)
        {
            exportSeason();
        }

        private void exportSeason()
        {

        }
    }

    
}
