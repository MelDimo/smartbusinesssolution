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
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using System.Drawing.Printing;

namespace com.sbs.gui.seasonbrowser
{
    public partial class fMain : Form
    {
        DBaccess.Role curRole;

        DBaccess dbAccess = new DBaccess();
        getReference getRef = new getReference();
        Suppurt Supp = new Suppurt();

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

        int editBillId;
        int editBillOrder;

        public fMain()
        {
            InitializeComponent();

            button_filter.BackgroundImage = com.sbs.dll.utilites.Properties.Resources.filter_26;
            tSSButton_report.Image = com.sbs.dll.utilites.Properties.Resources.order_26;
            tSButton_export.Image = com.sbs.dll.utilites.Properties.Resources.download_26;

            initRefer();

            curRole = getRole();

            if (curRole == DBaccess.Role.NONE)
            {
                MessageBox.Show("У декущего пользователя неустановлены привелегии для работы в данном модуле",
                                GValues.prgNameFull,
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                setEnabled(false);
                return;
            }
        }

        private DBaccess.Role getRole()
        {
            if (Supp.checkPrivileges(UsersInfo.Acl, 22)) return DBaccess.Role.BACKOFFICE;   // Постобработка счетов в ЗАКРЫТОЙ смене
            if (Supp.checkPrivileges(UsersInfo.Acl, 21)) return DBaccess.Role.FRONTOFFICE;  // Постобработка счетов в ОТКРЫТОЙ смене
            return DBaccess.Role.NONE;
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
                uMessage.Show("Не удалось получить справочники", exc, SystemIcons.Information);
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
            oFilter.dateStart = DateTime.Parse(dateTimePicker_start.Value.ToShortDateString());
            oFilter.dateEnd = DateTime.Parse(dateTimePicker_end.Value.ToShortDateString());
            oFilter.dateEnd = oFilter.dateEnd.AddDays(1);

            label_billsCount.Text = "0";
            label_billsFirstLast.Text = "0 - 0";

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
                oCtrSeasonBranch.button_host.LostFocus += new EventHandler(oCtrSeasonBranch_LostFocus);
                oCtrSeasonBranch.button_host.GotFocus += new EventHandler(oCtrSeasonBranch_GotFocus);
                flowLayoutPanel_season.Controls.Add(oCtrSeasonBranch);
            }

            oFilter.curLast = 0;
        }

        void oCtrSeasonBranch_GotFocus(object sender, EventArgs e)
        {
            foreach (Control ctr in flowLayoutPanel_season.Controls)
                if (!((ctrSeasonBranch)ctr).Equals(((Button)sender).Parent))
                    ((ctrSeasonBranch)ctr).BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        void oCtrSeasonBranch_LostFocus(object sender, EventArgs e)
        {
            ((ctrSeasonBranch)((Button)sender).Parent).BackColor = Color.FromArgb(185, 209, 234);
        }

        void oCtrSeasonBranch_Click(object sender, EventArgs e)
        {
            ctrSeasonBranch oCtrBSeason = (ctrSeasonBranch)((Button)sender).Parent;
            oFilter.season = int.Parse(oCtrBSeason.label_seasonNumb.Text);
            oFilter.isSeasonOpen = oCtrBSeason.oSeasonBranch.refStatus == 16 ? true : false;

            flowLayoutPanel_bills.Controls.Clear();
            flowLayoutPanel_dishes.Controls.Clear();

            if (curRole == DBaccess.Role.FRONTOFFICE && !oFilter.isSeasonOpen)
            {
                MessageBox.Show("У Вас недостаточно привилегий для просмотра закрытой смены.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            oFilter.curLast = 0;

            getBills();
        }

        private void getBills()
        {
            int i = 0;
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
                oCtrBill.button_host.GotFocus += new EventHandler(oCtrBill_GotFocus);
                oCtrBill.button_host.LostFocus += new EventHandler(oCtrBill_LostFocus);

                if (curRole == DBaccess.Role.FRONTOFFICE)
                {
                    oCtrBill.label_summ.Visible = false;
                }

                oCtrBill.button_editMnu.Visible=true;
                oCtrBill.button_editMnu.Click += new EventHandler(BillButton_editMnu_Click);
                
                oCtrBill.Tag = i; // цепляю к контролу его порядок, при обновлении отображаю с это контрола

                lCtrBill.Add(oCtrBill);
                i++;
            }

            label_billsCount.Text = lCtrBill.Count.ToString();

            oFilter.curLast = oFilter.curLast == 0 ? 0 : oFilter.curLast;
            
            showBills();
        }

        void oCtrBill_LostFocus(object sender, EventArgs e)
        {
            ((ctrBill)((Button)sender).Parent).BackColor = Color.FromArgb(185, 209, 234);
        }

        void oCtrBill_GotFocus(object sender, EventArgs e)
        {
            foreach (Control ctr in flowLayoutPanel_bills.Controls)
                if (!((ctrBill)ctr).Equals(((Button)sender).Parent))
                {
                    ((ctrBill)ctr).BackColor = Color.FromKnownColor(KnownColor.Control);
                    editBillId = ((ctrBill)ctr).oBill.id;
                    editBillOrder = (int)((ctrBill)ctr).Tag;
                }
        }

        void BillButton_editMnu_Click(object sender, EventArgs e)
        {
            ctrBill oCtrBill = (ctrBill)((Button)sender).Parent;

            editBillId = oCtrBill.oBill.id;

            DTO_DBoard.Bill oBill = (DTO_DBoard.Bill)oCtrBill.oBill.Clone();

            oFilter.bill = oBill.id;

            fBillEdit fbillEdit = new fBillEdit(oFilter, oBill, curRole);
            
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

            oFilter.curLast = editBillOrder;

            getBills();

            flowLayoutPanel_bills.Controls[0].Focus();
        }

        void oCtrBill_Click(object sender, EventArgs e)
        {
            ctrBill oCtrBill = (ctrBill)((Button)sender).Parent;
            oFilter.bill = oCtrBill.oBill.id;

            editBillId = oCtrBill.oBill.id;
            editBillOrder = (int)oCtrBill.Tag;

            flowLayoutPanel_dishes.Controls.Clear();

            if (curRole == DBaccess.Role.FRONTOFFICE)
            {
                MessageBox.Show("У Вас недостаточно привилегий для просмотра позиций счета.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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

                //oCtrDishes.button_topping.Visible = false;
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
            DTO_DBoard.Dish oDish = (DTO_DBoard.Dish)((ctrDishes)((Button)sender).Parent).oDish.Clone();

            fDishEdit fdishEdit = new fDishEdit(oFilter, oDish, curRole);

            fdishEdit.comboBox_status.DataSource = dtRefStatusDish;
            fdishEdit.comboBox_status.ValueMember = "id";
            fdishEdit.comboBox_status.DisplayMember = "name";

            if (fdishEdit.ShowDialog() != DialogResult.OK) return;

            oFilter.curLast = editBillOrder;

            getBills();

            flowLayoutPanel_bills.Controls[0].Focus();
            oCtrBill_Click(((ctrBill)flowLayoutPanel_bills.Controls[0]).button_host, new EventArgs());

            //for (int i = 0; i < flowLayoutPanel_bills.Controls.Count; i++)
            //{
            //    if ((flowLayoutPanel_bills.Controls[i] as ctrBill).oBill.id == editBillId)
            //    {
            //        flowLayoutPanel_bills.Controls[i].Focus();
            //        oCtrBill_Click(((ctrBill)flowLayoutPanel_bills.Controls[i]).button_host, new EventArgs());
            //        break;
            //    }
            //}
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
            int indexBills = oFilter.curLast;

            label_billsFirstLast.Text = oFilter.curLast.ToString() + " - ";

            flowLayoutPanel_bills.Controls.Clear();
            flowLayoutPanel_dishes.Controls.Clear();

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
            if (oFilter.season == 0)
            {
                MessageBox.Show("Выберите выгружаемую смену.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach(DTO_DBoard.SeasonBranch oSeasonBranch in lSeasonBranch)
            {
                if( oSeasonBranch.seasonID == oFilter.season)
                {
                    fExport41C fExport = new fExport41C(oSeasonBranch, oFilter);
                    fExport.ShowDialog();
                }
            }
        }

        private void tSMItem_xOrder_Click(object sender, EventArgs e)
        {
            string eCentre = string.Empty + (char)27 + (char)97 + "1";
            string eLeft = string.Empty + (char)27 + (char)97 + "0";
            string eRight = string.Empty + (char)27 + (char)97 + "2";
            string eCut = string.Empty + (char)27 + (char)105;
            string eItalicOn = string.Empty + (char)27 + (char)73 + "1";
            string eItalicOff = string.Empty + (char)27 + (char)73 + "0";

            int rHeight = 50;
            string oldFio = string.Empty;
            decimal sumWaiter = 0;

            StringBuilder sb = new StringBuilder();

            char[] line = new char[76];

            DataSet ds = new DataSet();

            try
            {
                ds = dbAccess.REP_xOrder_RAW(oFilter);
            }
            catch (Exception exc)
            {
                uMessage.Show("Неудалось сформировать отчет.", exc, SystemIcons.Information);
                return;
            }

            sb.AppendLine("-".PadRight(rHeight, '-'));

            foreach (DataRow dr in ds.Tables["SEASON_HEADER"].Rows)
            {
                sb.AppendLine(string.Format("Контрольный счет по: {0}", textBox_branch.Text));
                sb.AppendLine(string.Format("Смена: {0}", oFilter.season ));
                sb.AppendLine(string.Format("Открыта: {0}", dr["season_start"]));
                sb.AppendLine(string.Format("Закрыта: {0}", dr["season_end"]));
                sb.AppendLine(string.Format("Итого за смену: {0}", ((decimal)dr["season_sum"]).ToString("F2")));
                sb.AppendLine(string.Format("Всего обслужено гостей: {0}", dr["count_bill"]));
            }

            sb.AppendLine("-".PadRight(rHeight, '-'));
            sb.AppendLine("По сотрудникам" + eCentre);
            sb.AppendLine("-".PadRight(rHeight, '-'));

            foreach (DataRow dr in ds.Tables["SEASON_ORDER_EMPL"].Rows)
            {
                if (!dr["user_fio"].ToString().Equals(oldFio))
                {
                    if (!oldFio.Equals(string.Empty))
                    {
                        sb.AppendLine(eItalicOn + sumWaiter.ToString("F2").PadLeft(rHeight, ' ') + eItalicOff);
                        sumWaiter = 0;
                    }

                    oldFio = dr["user_fio"].ToString();
                    sb.AppendLine(oldFio);
                }
                sb.Append(dr["bill_paymentType"].ToString());
                sumWaiter += (decimal)dr["summ"];
                sb.AppendLine(((decimal)dr["summ"]).ToString("F2").PadLeft(rHeight - dr["bill_paymentType"].ToString().Length, ' '));
            }
            // Печатаю сумму по последнему сотруднику
            if (ds.Tables["SEASON_ORDER_EMPL"].Rows.Count > 0) sb.AppendLine(eItalicOn + sumWaiter.ToString("F2").PadLeft(rHeight, ' ') + eItalicOff);

            sb.AppendLine("-".PadRight(rHeight, '-'));
            sb.AppendLine(eCentre + "По подразделениям");
            sb.AppendLine("-".PadRight(rHeight, '-'));

            foreach (DataRow dr in ds.Tables["SEASON_ORDER_UNIT"].Rows)
            {
                sb.Append(dr["dish_printer"].ToString());
                sb.AppendLine(((decimal)dr["summ"]).ToString("F2").PadLeft(rHeight - dr["dish_printer"].ToString().Length, ' '));
            }

            sb.AppendLine("-".PadRight(rHeight, '-'));
            sb.AppendLine(eCentre + "По проводкам");
            sb.AppendLine("-".PadRight(rHeight, '-'));

            foreach (DataRow dr in ds.Tables["SEASON_ORDER_PAYMENT"].Rows)
            {
                sb.Append(dr["bill_paymentType"].ToString());
                sb.AppendLine(((decimal)dr["summ"]).ToString("F2").PadLeft(rHeight - dr["bill_paymentType"].ToString().Length, ' '));
            }

            sb.AppendLine("-".PadRight(rHeight, '-'));

            sb.AppendLine(eCut);

            String printerAddress = ds.Tables["PRINTER"].Rows[0]["printerName"].ToString();
            String documentName = "My document";
            String documentText = sb.ToString();

            fXOrderViewer fxoviewer = new fXOrderViewer(printerAddress, documentText, documentName);
            fxoviewer.ShowDialog();

            return;

            Report oReport = new Report();
            ReportDocument repDoc = new ReportDocument();

            if (curRole == DBaccess.Role.FRONTOFFICE && !oFilter.isSeasonOpen)
            {
                MessageBox.Show("У Вас недостаточно привилегий для формирования отчета закрытой смены.", 
                    GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                oReport = dbAccess.REP_xOrder(oFilter);
                repDoc.Load(oReport.repPath);
                repDoc.SetDataSource(oReport.dtReport);
                repDoc.SetParameterValue("pBranchName", textBox_branch.Text);
                repDoc.PrintOptions.PrinterName = GValues.billPrinter.Equals("default") ?
                                            (new System.Drawing.Printing.PrinterSettings()).PrinterName :
                                            oReport.printName;
            }
            catch (Exception exc)
            {
                uMessage.Show("Неудалось сформировать отчет.", exc, SystemIcons.Information);
                return;
            }

            fRepViewer repViewer = new fRepViewer();
            repViewer.Text = "Х Отчет";
            repViewer.crystalReportViewer_main.ReportSource = repDoc;
            repViewer.ShowDialog();

            repDoc.Close();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            Settings set = new Settings();
            this.Size = set.formSize;
            this.Location = set.formLocation;
            this.WindowState = set.formState;
        }

        private void fMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings set = new Settings();
            set.formSize = this.Size;
            set.formLocation = this.Location;
            set.formState = this.WindowState;
            set.Save();
        }

        private void fMain_Shown(object sender, EventArgs e)
        {
            if (curRole == DBaccess.Role.FRONTOFFICE)
            {
                button_branch.Enabled = false;
                oFilter.branch = GValues.branchId;
                textBox_branch.Text = GValues.branchName;
            }
        }
    }
}
