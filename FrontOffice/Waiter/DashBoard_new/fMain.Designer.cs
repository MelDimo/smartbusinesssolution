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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_bills = new System.Windows.Forms.TabPage();
            this.tabPage_dishes = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox_bills = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel_bills = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip_bills = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel_billInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox_billInfo = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel_billEdit = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.treeView_CarteGroups = new System.Windows.Forms.TreeView();
            this.flowLayoutPanel_dish = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox_groups = new System.Windows.Forms.GroupBox();
            this.groupBox_dish = new System.Windows.Forms.GroupBox();
            this.tabControl_main.SuspendLayout();
            this.tabPage_bills.SuspendLayout();
            this.tabPage_dishes.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox_bills.SuspendLayout();
            this.toolStrip_bills.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox_billInfo.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox_groups.SuspendLayout();
            this.groupBox_dish.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_main
            // 
            this.tabControl_main.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl_main.Controls.Add(this.tabPage_bills);
            this.tabControl_main.Controls.Add(this.tabPage_dishes);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(1022, 642);
            this.tabControl_main.TabIndex = 0;
            this.tabControl_main.TabStop = false;
            this.tabControl_main.SelectedIndexChanged += new System.EventHandler(this.tabControl_main_SelectedIndexChanged);
            // 
            // tabPage_bills
            // 
            this.tabPage_bills.Controls.Add(this.tableLayoutPanel1);
            this.tabPage_bills.Location = new System.Drawing.Point(4, 4);
            this.tabPage_bills.Name = "tabPage_bills";
            this.tabPage_bills.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_bills.Size = new System.Drawing.Size(1014, 616);
            this.tabPage_bills.TabIndex = 0;
            this.tabPage_bills.Text = "tabPage_bills";
            // 
            // tabPage_dishes
            // 
            this.tabPage_dishes.Controls.Add(this.tableLayoutPanel2);
            this.tabPage_dishes.Location = new System.Drawing.Point(4, 4);
            this.tabPage_dishes.Name = "tabPage_dishes";
            this.tabPage_dishes.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_dishes.Size = new System.Drawing.Size(1014, 616);
            this.tabPage_dishes.TabIndex = 1;
            this.tabPage_dishes.Text = "tabPage_dishes";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox_bills, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1008, 610);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox_bills
            // 
            this.groupBox_bills.Controls.Add(this.flowLayoutPanel_bills);
            this.groupBox_bills.Controls.Add(this.toolStrip_bills);
            this.groupBox_bills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_bills.Location = new System.Drawing.Point(3, 3);
            this.groupBox_bills.Name = "groupBox_bills";
            this.groupBox_bills.Size = new System.Drawing.Size(346, 604);
            this.groupBox_bills.TabIndex = 0;
            this.groupBox_bills.TabStop = false;
            // 
            // flowLayoutPanel_bills
            // 
            this.flowLayoutPanel_bills.AutoScroll = true;
            this.flowLayoutPanel_bills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_bills.Location = new System.Drawing.Point(3, 41);
            this.flowLayoutPanel_bills.Name = "flowLayoutPanel_bills";
            this.flowLayoutPanel_bills.Size = new System.Drawing.Size(340, 560);
            this.flowLayoutPanel_bills.TabIndex = 0;
            this.flowLayoutPanel_bills.TabStop = true;
            // 
            // toolStrip_bills
            // 
            this.toolStrip_bills.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_bills.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip_bills.Location = new System.Drawing.Point(3, 16);
            this.toolStrip_bills.Name = "toolStrip_bills";
            this.toolStrip_bills.Size = new System.Drawing.Size(340, 25);
            this.toolStrip_bills.TabIndex = 1;
            this.toolStrip_bills.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel_billInfo);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(355, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(650, 604);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // flowLayoutPanel_billInfo
            // 
            this.flowLayoutPanel_billInfo.AutoScroll = true;
            this.flowLayoutPanel_billInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_billInfo.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel_billInfo.Name = "flowLayoutPanel_billInfo";
            this.flowLayoutPanel_billInfo.Size = new System.Drawing.Size(644, 585);
            this.flowLayoutPanel_billInfo.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox_billInfo, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1008, 610);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox_billInfo
            // 
            this.groupBox_billInfo.Controls.Add(this.flowLayoutPanel_billEdit);
            this.groupBox_billInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_billInfo.Location = new System.Drawing.Point(3, 3);
            this.groupBox_billInfo.Name = "groupBox_billInfo";
            this.groupBox_billInfo.Size = new System.Drawing.Size(346, 584);
            this.groupBox_billInfo.TabIndex = 0;
            this.groupBox_billInfo.TabStop = false;
            // 
            // flowLayoutPanel_billEdit
            // 
            this.flowLayoutPanel_billEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_billEdit.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel_billEdit.Name = "flowLayoutPanel_billEdit";
            this.flowLayoutPanel_billEdit.Size = new System.Drawing.Size(340, 565);
            this.flowLayoutPanel_billEdit.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox_groups, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox_dish, 1, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(355, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(644, 584);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // treeView_CarteGroups
            // 
            this.treeView_CarteGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_CarteGroups.Location = new System.Drawing.Point(3, 16);
            this.treeView_CarteGroups.Name = "treeView_CarteGroups";
            this.treeView_CarteGroups.Size = new System.Drawing.Size(245, 559);
            this.treeView_CarteGroups.TabIndex = 0;
            this.treeView_CarteGroups.TabStop = false;
            this.treeView_CarteGroups.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_CarteGroups_AfterSelect);
            // 
            // flowLayoutPanel_dish
            // 
            this.flowLayoutPanel_dish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_dish.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel_dish.Name = "flowLayoutPanel_dish";
            this.flowLayoutPanel_dish.Size = new System.Drawing.Size(375, 559);
            this.flowLayoutPanel_dish.TabIndex = 1;
            // 
            // groupBox_groups
            // 
            this.groupBox_groups.Controls.Add(this.treeView_CarteGroups);
            this.groupBox_groups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_groups.Location = new System.Drawing.Point(3, 3);
            this.groupBox_groups.Name = "groupBox_groups";
            this.groupBox_groups.Size = new System.Drawing.Size(251, 578);
            this.groupBox_groups.TabIndex = 0;
            this.groupBox_groups.TabStop = false;
            // 
            // groupBox_dish
            // 
            this.groupBox_dish.Controls.Add(this.flowLayoutPanel_dish);
            this.groupBox_dish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_dish.Location = new System.Drawing.Point(260, 3);
            this.groupBox_dish.Name = "groupBox_dish";
            this.groupBox_dish.Size = new System.Drawing.Size(381, 578);
            this.groupBox_dish.TabIndex = 1;
            this.groupBox_dish.TabStop = false;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 642);
            this.Controls.Add(this.tabControl_main);
            this.Name = "fMain";
            this.Text = "fMain";
            this.Shown += new System.EventHandler(this.fMain_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fMain_KeyDown);
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_bills.ResumeLayout(false);
            this.tabPage_dishes.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox_bills.ResumeLayout(false);
            this.groupBox_bills.PerformLayout();
            this.toolStrip_bills.ResumeLayout(false);
            this.toolStrip_bills.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox_billInfo.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupBox_groups.ResumeLayout(false);
            this.groupBox_dish.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_bills;
        private System.Windows.Forms.TabPage tabPage_dishes;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox_bills;
        private System.Windows.Forms.ToolStrip toolStrip_bills;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_billInfo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_bills;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox_billInfo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_billEdit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TreeView treeView_CarteGroups;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_dish;
        private System.Windows.Forms.GroupBox groupBox_groups;
        private System.Windows.Forms.GroupBox groupBox_dish;
    }
}