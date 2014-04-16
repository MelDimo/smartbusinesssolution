using System.Windows.Forms;
using System.Drawing;
namespace com.sbs.gui.dashboard
{
    partial class fMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel_bills = new System.Windows.Forms.Panel();
            this.panel_dishes = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tSSLabel_fio = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox_bills = new com.sbs.gui.dashboard.extGroupBox();
            this.groupBox_billsUpper = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel_bills = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_printBill = new System.Windows.Forms.Button();
            this.button_newBill = new System.Windows.Forms.Button();
            this.groupBox_billDish = new com.sbs.gui.dashboard.extGroupBox();
            this.groupBox_billDishUpper = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel_billInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox_billInfo = new com.sbs.gui.dashboard.extGroupBox();
            this.groupBox_billInfoUpper = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel_billEdit = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_billInfo = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_searchDish = new System.Windows.Forms.Button();
            this.groupBox_groups = new com.sbs.gui.dashboard.extGroupBox();
            this.groupBox_groupsUpper = new System.Windows.Forms.GroupBox();
            this.treeView_CarteGroups = new System.Windows.Forms.TreeView();
            this.groupBox_refuse = new com.sbs.gui.dashboard.extGroupBox();
            this.groupBox_refuseUpper = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel_refuse = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox_dish = new com.sbs.gui.dashboard.extGroupBox();
            this.groupBox_dishUpper = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel_dish = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel_bills.SuspendLayout();
            this.panel_dishes.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox_bills.SuspendLayout();
            this.groupBox_billsUpper.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox_billDish.SuspendLayout();
            this.groupBox_billDishUpper.SuspendLayout();
            this.groupBox_billInfo.SuspendLayout();
            this.groupBox_billInfoUpper.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox_groups.SuspendLayout();
            this.groupBox_groupsUpper.SuspendLayout();
            this.groupBox_refuse.SuspendLayout();
            this.groupBox_refuseUpper.SuspendLayout();
            this.groupBox_dish.SuspendLayout();
            this.groupBox_dishUpper.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox_bills, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox_billDish, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1127, 672);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.TabStop = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox_billInfo, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1127, 672);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox_dish, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(397, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(727, 666);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox_groups);
            this.panel2.Controls.Add(this.groupBox_refuse);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 660);
            this.panel2.TabIndex = 0;
            // 
            // panel_bills
            // 
            this.panel_bills.Controls.Add(this.tableLayoutPanel1);
            this.panel_bills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_bills.Location = new System.Drawing.Point(0, 0);
            this.panel_bills.Name = "panel_bills";
            this.panel_bills.Size = new System.Drawing.Size(1127, 672);
            this.panel_bills.TabIndex = 1;
            // 
            // panel_dishes
            // 
            this.panel_dishes.Controls.Add(this.tableLayoutPanel2);
            this.panel_dishes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_dishes.Location = new System.Drawing.Point(0, 0);
            this.panel_dishes.Name = "panel_dishes";
            this.panel_dishes.Size = new System.Drawing.Size(1127, 672);
            this.panel_dishes.TabIndex = 2;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSLabel_fio});
            this.statusStrip1.Location = new System.Drawing.Point(0, 672);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1127, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tSSLabel_fio
            // 
            this.tSSLabel_fio.Name = "tSSLabel_fio";
            this.tSSLabel_fio.Size = new System.Drawing.Size(70, 17);
            this.tSSLabel_fio.Text = "tSSLabel_fio";
            // 
            // groupBox_bills
            // 
            this.groupBox_bills.BorderColor = System.Drawing.Color.Empty;
            this.groupBox_bills.Controls.Add(this.groupBox_billsUpper);
            this.groupBox_bills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_bills.Location = new System.Drawing.Point(3, 3);
            this.groupBox_bills.Name = "groupBox_bills";
            this.groupBox_bills.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox_bills.Size = new System.Drawing.Size(388, 666);
            this.groupBox_bills.TabIndex = 0;
            this.groupBox_bills.TabStop = false;
            // 
            // groupBox_billsUpper
            // 
            this.groupBox_billsUpper.Controls.Add(this.flowLayoutPanel_bills);
            this.groupBox_billsUpper.Controls.Add(this.panel1);
            this.groupBox_billsUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_billsUpper.Location = new System.Drawing.Point(6, 19);
            this.groupBox_billsUpper.Name = "groupBox_billsUpper";
            this.groupBox_billsUpper.Size = new System.Drawing.Size(376, 641);
            this.groupBox_billsUpper.TabIndex = 0;
            this.groupBox_billsUpper.TabStop = false;
            // 
            // flowLayoutPanel_bills
            // 
            this.flowLayoutPanel_bills.AutoScroll = true;
            this.flowLayoutPanel_bills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_bills.Location = new System.Drawing.Point(3, 95);
            this.flowLayoutPanel_bills.Name = "flowLayoutPanel_bills";
            this.flowLayoutPanel_bills.Size = new System.Drawing.Size(370, 543);
            this.flowLayoutPanel_bills.TabIndex = 0;
            this.flowLayoutPanel_bills.TabStop = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_printBill);
            this.panel1.Controls.Add(this.button_newBill);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 79);
            this.panel1.TabIndex = 1;
            // 
            // button_printBill
            // 
            this.button_printBill.Location = new System.Drawing.Point(84, 8);
            this.button_printBill.Name = "button_printBill";
            this.button_printBill.Size = new System.Drawing.Size(75, 62);
            this.button_printBill.TabIndex = 2;
            this.button_printBill.TabStop = false;
            this.button_printBill.Text = "F5";
            this.button_printBill.UseVisualStyleBackColor = true;
            this.button_printBill.Click += new System.EventHandler(this.button_printBill_Click);
            // 
            // button_newBill
            // 
            this.button_newBill.Location = new System.Drawing.Point(3, 8);
            this.button_newBill.Name = "button_newBill";
            this.button_newBill.Size = new System.Drawing.Size(75, 62);
            this.button_newBill.TabIndex = 0;
            this.button_newBill.TabStop = false;
            this.button_newBill.Text = "F2";
            this.button_newBill.UseVisualStyleBackColor = true;
            this.button_newBill.Click += new System.EventHandler(this.button_newBill_Click);
            // 
            // groupBox_billDish
            // 
            this.groupBox_billDish.BorderColor = System.Drawing.Color.Empty;
            this.groupBox_billDish.Controls.Add(this.groupBox_billDishUpper);
            this.groupBox_billDish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_billDish.Location = new System.Drawing.Point(397, 3);
            this.groupBox_billDish.Name = "groupBox_billDish";
            this.groupBox_billDish.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox_billDish.Size = new System.Drawing.Size(727, 666);
            this.groupBox_billDish.TabIndex = 1;
            this.groupBox_billDish.TabStop = false;
            // 
            // groupBox_billDishUpper
            // 
            this.groupBox_billDishUpper.Controls.Add(this.flowLayoutPanel_billInfo);
            this.groupBox_billDishUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_billDishUpper.Location = new System.Drawing.Point(6, 19);
            this.groupBox_billDishUpper.Name = "groupBox_billDishUpper";
            this.groupBox_billDishUpper.Size = new System.Drawing.Size(715, 641);
            this.groupBox_billDishUpper.TabIndex = 0;
            this.groupBox_billDishUpper.TabStop = false;
            // 
            // flowLayoutPanel_billInfo
            // 
            this.flowLayoutPanel_billInfo.AutoScroll = true;
            this.flowLayoutPanel_billInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_billInfo.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel_billInfo.Name = "flowLayoutPanel_billInfo";
            this.flowLayoutPanel_billInfo.Size = new System.Drawing.Size(709, 622);
            this.flowLayoutPanel_billInfo.TabIndex = 0;
            // 
            // groupBox_billInfo
            // 
            this.groupBox_billInfo.BorderColor = System.Drawing.Color.Empty;
            this.groupBox_billInfo.Controls.Add(this.groupBox_billInfoUpper);
            this.groupBox_billInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_billInfo.Location = new System.Drawing.Point(3, 3);
            this.groupBox_billInfo.Name = "groupBox_billInfo";
            this.groupBox_billInfo.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox_billInfo.Size = new System.Drawing.Size(388, 666);
            this.groupBox_billInfo.TabIndex = 0;
            this.groupBox_billInfo.TabStop = false;
            // 
            // groupBox_billInfoUpper
            // 
            this.groupBox_billInfoUpper.Controls.Add(this.flowLayoutPanel_billEdit);
            this.groupBox_billInfoUpper.Controls.Add(this.panel_billInfo);
            this.groupBox_billInfoUpper.Controls.Add(this.panel3);
            this.groupBox_billInfoUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_billInfoUpper.Location = new System.Drawing.Point(6, 19);
            this.groupBox_billInfoUpper.Name = "groupBox_billInfoUpper";
            this.groupBox_billInfoUpper.Size = new System.Drawing.Size(376, 641);
            this.groupBox_billInfoUpper.TabIndex = 0;
            this.groupBox_billInfoUpper.TabStop = false;
            // 
            // flowLayoutPanel_billEdit
            // 
            this.flowLayoutPanel_billEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_billEdit.Location = new System.Drawing.Point(3, 184);
            this.flowLayoutPanel_billEdit.Name = "flowLayoutPanel_billEdit";
            this.flowLayoutPanel_billEdit.Size = new System.Drawing.Size(370, 454);
            this.flowLayoutPanel_billEdit.TabIndex = 0;
            // 
            // panel_billInfo
            // 
            this.panel_billInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_billInfo.Location = new System.Drawing.Point(3, 95);
            this.panel_billInfo.Name = "panel_billInfo";
            this.panel_billInfo.Size = new System.Drawing.Size(370, 89);
            this.panel_billInfo.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button_searchDish);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 16);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(370, 79);
            this.panel3.TabIndex = 0;
            // 
            // button_searchDish
            // 
            this.button_searchDish.Location = new System.Drawing.Point(84, 8);
            this.button_searchDish.Name = "button_searchDish";
            this.button_searchDish.Size = new System.Drawing.Size(75, 62);
            this.button_searchDish.TabIndex = 3;
            this.button_searchDish.TabStop = false;
            this.button_searchDish.Text = "F7";
            this.button_searchDish.UseVisualStyleBackColor = true;
            this.button_searchDish.Click += new System.EventHandler(this.button_searchDish_Click);
            // 
            // groupBox_groups
            // 
            this.groupBox_groups.BorderColor = System.Drawing.Color.Empty;
            this.groupBox_groups.Controls.Add(this.groupBox_groupsUpper);
            this.groupBox_groups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_groups.Location = new System.Drawing.Point(0, 0);
            this.groupBox_groups.Name = "groupBox_groups";
            this.groupBox_groups.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox_groups.Size = new System.Drawing.Size(284, 542);
            this.groupBox_groups.TabIndex = 0;
            this.groupBox_groups.TabStop = false;
            // 
            // groupBox_groupsUpper
            // 
            this.groupBox_groupsUpper.Controls.Add(this.treeView_CarteGroups);
            this.groupBox_groupsUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_groupsUpper.Location = new System.Drawing.Point(6, 19);
            this.groupBox_groupsUpper.Name = "groupBox_groupsUpper";
            this.groupBox_groupsUpper.Size = new System.Drawing.Size(272, 517);
            this.groupBox_groupsUpper.TabIndex = 1;
            this.groupBox_groupsUpper.TabStop = false;
            // 
            // treeView_CarteGroups
            // 
            this.treeView_CarteGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_CarteGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView_CarteGroups.FullRowSelect = true;
            this.treeView_CarteGroups.HideSelection = false;
            this.treeView_CarteGroups.Location = new System.Drawing.Point(3, 16);
            this.treeView_CarteGroups.Name = "treeView_CarteGroups";
            this.treeView_CarteGroups.Size = new System.Drawing.Size(266, 498);
            this.treeView_CarteGroups.TabIndex = 0;
            this.treeView_CarteGroups.TabStop = false;
            this.treeView_CarteGroups.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_CarteGroups_AfterSelect);
            // 
            // groupBox_refuse
            // 
            this.groupBox_refuse.BorderColor = System.Drawing.Color.Empty;
            this.groupBox_refuse.Controls.Add(this.groupBox_refuseUpper);
            this.groupBox_refuse.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox_refuse.Location = new System.Drawing.Point(0, 542);
            this.groupBox_refuse.Name = "groupBox_refuse";
            this.groupBox_refuse.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox_refuse.Size = new System.Drawing.Size(284, 118);
            this.groupBox_refuse.TabIndex = 1;
            this.groupBox_refuse.TabStop = false;
            this.groupBox_refuse.Text = "Отказные позиции";
            // 
            // groupBox_refuseUpper
            // 
            this.groupBox_refuseUpper.Controls.Add(this.flowLayoutPanel_refuse);
            this.groupBox_refuseUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_refuseUpper.Location = new System.Drawing.Point(6, 19);
            this.groupBox_refuseUpper.Name = "groupBox_refuseUpper";
            this.groupBox_refuseUpper.Size = new System.Drawing.Size(272, 93);
            this.groupBox_refuseUpper.TabIndex = 0;
            this.groupBox_refuseUpper.TabStop = false;
            // 
            // flowLayoutPanel_refuse
            // 
            this.flowLayoutPanel_refuse.AutoScroll = true;
            this.flowLayoutPanel_refuse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_refuse.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel_refuse.Name = "flowLayoutPanel_refuse";
            this.flowLayoutPanel_refuse.Size = new System.Drawing.Size(266, 74);
            this.flowLayoutPanel_refuse.TabIndex = 0;
            // 
            // groupBox_dish
            // 
            this.groupBox_dish.BorderColor = System.Drawing.Color.Empty;
            this.groupBox_dish.Controls.Add(this.groupBox_dishUpper);
            this.groupBox_dish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_dish.Location = new System.Drawing.Point(293, 3);
            this.groupBox_dish.Name = "groupBox_dish";
            this.groupBox_dish.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox_dish.Size = new System.Drawing.Size(431, 660);
            this.groupBox_dish.TabIndex = 1;
            this.groupBox_dish.TabStop = false;
            // 
            // groupBox_dishUpper
            // 
            this.groupBox_dishUpper.Controls.Add(this.flowLayoutPanel_dish);
            this.groupBox_dishUpper.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_dishUpper.Location = new System.Drawing.Point(6, 19);
            this.groupBox_dishUpper.Name = "groupBox_dishUpper";
            this.groupBox_dishUpper.Size = new System.Drawing.Size(419, 635);
            this.groupBox_dishUpper.TabIndex = 0;
            this.groupBox_dishUpper.TabStop = false;
            // 
            // flowLayoutPanel_dish
            // 
            this.flowLayoutPanel_dish.AutoScroll = true;
            this.flowLayoutPanel_dish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_dish.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel_dish.Name = "flowLayoutPanel_dish";
            this.flowLayoutPanel_dish.Size = new System.Drawing.Size(413, 616);
            this.flowLayoutPanel_dish.TabIndex = 1;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 694);
            this.ControlBox = false;
            this.Controls.Add(this.panel_bills);
            this.Controls.Add(this.panel_dishes);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "fMain";
            this.ShowInTaskbar = false;
            this.Shown += new System.EventHandler(this.fMain_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fMain_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel_bills.ResumeLayout(false);
            this.panel_dishes.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox_bills.ResumeLayout(false);
            this.groupBox_billsUpper.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox_billDish.ResumeLayout(false);
            this.groupBox_billDishUpper.ResumeLayout(false);
            this.groupBox_billInfo.ResumeLayout(false);
            this.groupBox_billInfoUpper.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox_groups.ResumeLayout(false);
            this.groupBox_groupsUpper.ResumeLayout(false);
            this.groupBox_refuse.ResumeLayout(false);
            this.groupBox_refuseUpper.ResumeLayout(false);
            this.groupBox_dish.ResumeLayout(false);
            this.groupBox_dishUpper.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        //private System.Windows.Forms.GroupBox groupBox_bills;
        private extGroupBox groupBox_bills;
        //private System.Windows.Forms.GroupBox groupBox_billDish;
        private extGroupBox groupBox_billDish;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_billInfo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_bills;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        //private System.Windows.Forms.GroupBox groupBox_billInfo;
        private extGroupBox groupBox_billInfo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_billEdit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TreeView treeView_CarteGroups;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_dish;
        //private System.Windows.Forms.GroupBox groupBox_groups;
        private extGroupBox groupBox_groups;
        //private System.Windows.Forms.GroupBox groupBox_dish;
        private extGroupBox groupBox_dish;
        private Panel panel1;
        private Button button_newBill;
        private Panel panel_bills;
        private Panel panel_dishes;
        private Panel panel_billInfo;
        private Button button_printBill;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tSSLabel_fio;
        private extGroupBox groupBox_refuse;
        private FlowLayoutPanel flowLayoutPanel_refuse;
        private Panel panel2;
        private Panel panel3;
        private Button button_searchDish;
        private GroupBox groupBox_billsUpper;
        private GroupBox groupBox_billDishUpper;
        private GroupBox groupBox_billInfoUpper;
        private GroupBox groupBox_groupsUpper;
        private GroupBox groupBox_refuseUpper;
        private GroupBox groupBox_dishUpper;
    }

    public class extGroupBox : GroupBox
    {
        private Color borderColor;

        public Color BorderColor
        {
            get { return this.borderColor; }
            set { this.borderColor = value; }
        }
        public extGroupBox()
        {
            //this.borderColor = Color.Black;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Size tSize = TextRenderer.MeasureText(this.Text, this.Font);
            Rectangle borderRect = e.ClipRectangle;
            borderRect.Y += tSize.Height / 2;
            borderRect.Height -= tSize.Height / 2;
            ControlPaint.DrawBorder(e.Graphics, borderRect, this.borderColor, ButtonBorderStyle.Solid);
            Rectangle textRect = e.ClipRectangle;
            textRect.X += 6;
            textRect.Width = tSize.Width;
            textRect.Height = tSize.Height;
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), textRect);
            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), textRect);
        }
    }
}