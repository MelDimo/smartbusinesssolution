namespace com.sbs.gui.seasonbrowser
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSButton_export = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tSSButton_report = new System.Windows.Forms.ToolStripSplitButton();
            this.tSMItem_xOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_filter = new System.Windows.Forms.Button();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.button_branch = new System.Windows.Forms.Button();
            this.textBox_branch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel_season = new System.Windows.Forms.FlowLayoutPanel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel_bills = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_billsCount = new System.Windows.Forms.Label();
            this.label_billsFirstLast = new System.Windows.Forms.Label();
            this.button_gotoLast = new System.Windows.Forms.Button();
            this.button_gotoNext = new System.Windows.Forms.Button();
            this.button_gotoBack = new System.Windows.Forms.Button();
            this.button_gotoFirst = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel_dishes = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSButton_export,
            this.toolStripSeparator1,
            this.tSSButton_report});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(2);
            this.toolStrip1.Size = new System.Drawing.Size(859, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSButton_export
            // 
            this.tSButton_export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_export.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_export.Name = "tSButton_export";
            this.tSButton_export.Size = new System.Drawing.Size(23, 20);
            this.tSButton_export.ToolTipText = "Выгрузка счетов";
            this.tSButton_export.Click += new System.EventHandler(this.tSButton_export_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // tSSButton_report
            // 
            this.tSSButton_report.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSSButton_report.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMItem_xOrder});
            this.tSSButton_report.Image = ((System.Drawing.Image)(resources.GetObject("tSSButton_report.Image")));
            this.tSSButton_report.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSSButton_report.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSSButton_report.Name = "tSSButton_report";
            this.tSSButton_report.Size = new System.Drawing.Size(32, 20);
            this.tSSButton_report.ToolTipText = "Отчеты";
            // 
            // tSMItem_xOrder
            // 
            this.tSMItem_xOrder.Name = "tSMItem_xOrder";
            this.tSMItem_xOrder.Size = new System.Drawing.Size(160, 22);
            this.tSMItem_xOrder.Text = "Отчет по смене";
            this.tSMItem_xOrder.Click += new System.EventHandler(this.tSMItem_xOrder_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_filter);
            this.groupBox1.Controls.Add(this.dateTimePicker_end);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dateTimePicker_start);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.button_branch);
            this.groupBox1.Controls.Add(this.textBox_branch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(859, 64);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтр";
            // 
            // button_filter
            // 
            this.button_filter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_filter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_filter.Location = new System.Drawing.Point(602, 19);
            this.button_filter.Name = "button_filter";
            this.button_filter.Size = new System.Drawing.Size(39, 39);
            this.button_filter.TabIndex = 7;
            this.button_filter.UseVisualStyleBackColor = true;
            this.button_filter.Click += new System.EventHandler(this.button_filter_Click);
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker_end.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_end.Location = new System.Drawing.Point(485, 35);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(111, 20);
            this.dateTimePicker_end.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(482, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Дата окончания";
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker_start.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_start.Location = new System.Drawing.Point(356, 35);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(113, 20);
            this.dateTimePicker_start.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(353, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Дата начала";
            // 
            // button_branch
            // 
            this.button_branch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_branch.Location = new System.Drawing.Point(312, 33);
            this.button_branch.Name = "button_branch";
            this.button_branch.Size = new System.Drawing.Size(29, 23);
            this.button_branch.TabIndex = 2;
            this.button_branch.Text = "...";
            this.button_branch.UseVisualStyleBackColor = true;
            this.button_branch.Click += new System.EventHandler(this.button_branch_Click);
            // 
            // textBox_branch
            // 
            this.textBox_branch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_branch.Location = new System.Drawing.Point(10, 36);
            this.textBox_branch.Name = "textBox_branch";
            this.textBox_branch.ReadOnly = true;
            this.textBox_branch.Size = new System.Drawing.Size(296, 20);
            this.textBox_branch.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Заведение";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 91);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(859, 445);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel_season);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(250, 445);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Смены";
            // 
            // flowLayoutPanel_season
            // 
            this.flowLayoutPanel_season.AutoScroll = true;
            this.flowLayoutPanel_season.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_season.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel_season.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel_season.Name = "flowLayoutPanel_season";
            this.flowLayoutPanel_season.Size = new System.Drawing.Size(244, 426);
            this.flowLayoutPanel_season.TabIndex = 0;
            this.flowLayoutPanel_season.SizeChanged += new System.EventHandler(this.flowLayoutPanel_season_SizeChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer2.Size = new System.Drawing.Size(605, 445);
            this.splitContainer2.SplitterDistance = 270;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.flowLayoutPanel_bills);
            this.groupBox3.Controls.Add(this.panel1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(270, 445);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Счета";
            // 
            // flowLayoutPanel_bills
            // 
            this.flowLayoutPanel_bills.AutoScroll = true;
            this.flowLayoutPanel_bills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_bills.Location = new System.Drawing.Point(3, 55);
            this.flowLayoutPanel_bills.Name = "flowLayoutPanel_bills";
            this.flowLayoutPanel_bills.Size = new System.Drawing.Size(264, 387);
            this.flowLayoutPanel_bills.TabIndex = 0;
            this.flowLayoutPanel_bills.SizeChanged += new System.EventHandler(this.flowLayoutPanel_bills_SizeChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_billsCount);
            this.panel1.Controls.Add(this.label_billsFirstLast);
            this.panel1.Controls.Add(this.button_gotoLast);
            this.panel1.Controls.Add(this.button_gotoNext);
            this.panel1.Controls.Add(this.button_gotoBack);
            this.panel1.Controls.Add(this.button_gotoFirst);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 39);
            this.panel1.TabIndex = 1;
            // 
            // label_billsCount
            // 
            this.label_billsCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_billsCount.AutoSize = true;
            this.label_billsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_billsCount.Location = new System.Drawing.Point(155, 13);
            this.label_billsCount.Name = "label_billsCount";
            this.label_billsCount.Size = new System.Drawing.Size(14, 15);
            this.label_billsCount.TabIndex = 6;
            this.label_billsCount.Text = "0";
            // 
            // label_billsFirstLast
            // 
            this.label_billsFirstLast.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_billsFirstLast.AutoSize = true;
            this.label_billsFirstLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_billsFirstLast.Location = new System.Drawing.Point(94, 13);
            this.label_billsFirstLast.Name = "label_billsFirstLast";
            this.label_billsFirstLast.Size = new System.Drawing.Size(31, 15);
            this.label_billsFirstLast.TabIndex = 5;
            this.label_billsFirstLast.Text = "0 - 0";
            // 
            // button_gotoLast
            // 
            this.button_gotoLast.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_gotoLast.Location = new System.Drawing.Point(230, 8);
            this.button_gotoLast.Name = "button_gotoLast";
            this.button_gotoLast.Size = new System.Drawing.Size(26, 23);
            this.button_gotoLast.TabIndex = 4;
            this.button_gotoLast.Text = ">|";
            this.button_gotoLast.UseVisualStyleBackColor = true;
            this.button_gotoLast.Click += new System.EventHandler(this.button_gotoLast_Click);
            // 
            // button_gotoNext
            // 
            this.button_gotoNext.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_gotoNext.Location = new System.Drawing.Point(189, 8);
            this.button_gotoNext.Name = "button_gotoNext";
            this.button_gotoNext.Size = new System.Drawing.Size(26, 23);
            this.button_gotoNext.TabIndex = 3;
            this.button_gotoNext.Text = ">";
            this.button_gotoNext.UseVisualStyleBackColor = true;
            this.button_gotoNext.Click += new System.EventHandler(this.button_gotoNext_Click);
            // 
            // button_gotoBack
            // 
            this.button_gotoBack.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_gotoBack.Location = new System.Drawing.Point(48, 8);
            this.button_gotoBack.Name = "button_gotoBack";
            this.button_gotoBack.Size = new System.Drawing.Size(26, 23);
            this.button_gotoBack.TabIndex = 2;
            this.button_gotoBack.Text = "<";
            this.button_gotoBack.UseVisualStyleBackColor = true;
            this.button_gotoBack.Click += new System.EventHandler(this.button_gotoBack_Click);
            // 
            // button_gotoFirst
            // 
            this.button_gotoFirst.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button_gotoFirst.Location = new System.Drawing.Point(7, 8);
            this.button_gotoFirst.Name = "button_gotoFirst";
            this.button_gotoFirst.Size = new System.Drawing.Size(26, 23);
            this.button_gotoFirst.TabIndex = 1;
            this.button_gotoFirst.Text = "|<";
            this.button_gotoFirst.UseVisualStyleBackColor = true;
            this.button_gotoFirst.Click += new System.EventHandler(this.button_gotoFirst_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.flowLayoutPanel_dishes);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(331, 445);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Блюда";
            // 
            // flowLayoutPanel_dishes
            // 
            this.flowLayoutPanel_dishes.AutoScroll = true;
            this.flowLayoutPanel_dishes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_dishes.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel_dishes.Name = "flowLayoutPanel_dishes";
            this.flowLayoutPanel_dishes.Size = new System.Drawing.Size(325, 426);
            this.flowLayoutPanel_dishes.TabIndex = 0;
            this.flowLayoutPanel_dishes.SizeChanged += new System.EventHandler(this.flowLayoutPanel_dishes_SizeChanged);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 536);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.MinimizeBox = false;
            this.Name = "fMain";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Обработка счетов";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fMain_FormClosed);
            this.Load += new System.EventHandler(this.fMain_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tSButton_export;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_branch;
        private System.Windows.Forms.TextBox textBox_branch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_filter;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_season;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_bills;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_dishes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_billsCount;
        private System.Windows.Forms.Label label_billsFirstLast;
        private System.Windows.Forms.Button button_gotoLast;
        private System.Windows.Forms.Button button_gotoNext;
        private System.Windows.Forms.Button button_gotoBack;
        private System.Windows.Forms.Button button_gotoFirst;
        private System.Windows.Forms.ToolStripSplitButton tSSButton_report;
        private System.Windows.Forms.ToolStripMenuItem tSMItem_xOrder;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

