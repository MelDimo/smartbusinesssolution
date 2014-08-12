namespace com.sbs.gui.report.repsumbyitems
{
    partial class fRepSumByItems
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_dateStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_timeStart = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker_dateEnd = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_timeEnd = new System.Windows.Forms.DateTimePicker();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox_items = new System.Windows.Forms.TextBox();
            this.button_items = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_branch = new System.Windows.Forms.TextBox();
            this.button_branch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox_paymentType = new System.Windows.Forms.TextBox();
            this.button_paymentType = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel8.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(450, 52);
            this.tableLayoutPanel1.TabIndex = 58;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker_dateStart);
            this.groupBox1.Controls.Add(this.dateTimePicker_timeStart);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 46);
            this.groupBox1.TabIndex = 53;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Начало периода";
            // 
            // dateTimePicker_dateStart
            // 
            this.dateTimePicker_dateStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker_dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_dateStart.Location = new System.Drawing.Point(7, 18);
            this.dateTimePicker_dateStart.Name = "dateTimePicker_dateStart";
            this.dateTimePicker_dateStart.Size = new System.Drawing.Size(107, 20);
            this.dateTimePicker_dateStart.TabIndex = 1;
            // 
            // dateTimePicker_timeStart
            // 
            this.dateTimePicker_timeStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker_timeStart.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_timeStart.Location = new System.Drawing.Point(120, 19);
            this.dateTimePicker_timeStart.Name = "dateTimePicker_timeStart";
            this.dateTimePicker_timeStart.ShowUpDown = true;
            this.dateTimePicker_timeStart.Size = new System.Drawing.Size(93, 20);
            this.dateTimePicker_timeStart.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePicker_dateEnd);
            this.groupBox2.Controls.Add(this.dateTimePicker_timeEnd);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(228, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 46);
            this.groupBox2.TabIndex = 54;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Окончание периода";
            // 
            // dateTimePicker_dateEnd
            // 
            this.dateTimePicker_dateEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker_dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_dateEnd.Location = new System.Drawing.Point(6, 19);
            this.dateTimePicker_dateEnd.Name = "dateTimePicker_dateEnd";
            this.dateTimePicker_dateEnd.Size = new System.Drawing.Size(106, 20);
            this.dateTimePicker_dateEnd.TabIndex = 3;
            // 
            // dateTimePicker_timeEnd
            // 
            this.dateTimePicker_timeEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker_timeEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dateTimePicker_timeEnd.Location = new System.Drawing.Point(118, 20);
            this.dateTimePicker_timeEnd.Name = "dateTimePicker_timeEnd";
            this.dateTimePicker_timeEnd.ShowUpDown = true;
            this.dateTimePicker_timeEnd.Size = new System.Drawing.Size(93, 20);
            this.dateTimePicker_timeEnd.TabIndex = 2;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.button_cancel);
            this.panel8.Controls.Add(this.button_ok);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 167);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(450, 35);
            this.panel8.TabIndex = 59;
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(343, 6);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "Отмена";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(262, 6);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "Ок";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 360F));
            this.tableLayoutPanel2.Controls.Add(this.panel3, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 52);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(450, 79);
            this.tableLayoutPanel2.TabIndex = 60;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textBox_items);
            this.panel3.Controls.Add(this.button_items);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(93, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(354, 21);
            this.panel3.TabIndex = 5;
            // 
            // textBox_items
            // 
            this.textBox_items.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_items.Location = new System.Drawing.Point(0, 0);
            this.textBox_items.Name = "textBox_items";
            this.textBox_items.ReadOnly = true;
            this.textBox_items.Size = new System.Drawing.Size(320, 20);
            this.textBox_items.TabIndex = 1;
            // 
            // button_items
            // 
            this.button_items.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_items.Location = new System.Drawing.Point(320, 0);
            this.button_items.Name = "button_items";
            this.button_items.Size = new System.Drawing.Size(34, 21);
            this.button_items.TabIndex = 2;
            this.button_items.Text = "...";
            this.button_items.UseVisualStyleBackColor = true;
            this.button_items.Click += new System.EventHandler(this.button_items_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "Товары*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Заведения*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Типы оплаты*";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_branch);
            this.panel1.Controls.Add(this.button_branch);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(93, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(354, 20);
            this.panel1.TabIndex = 2;
            // 
            // textBox_branch
            // 
            this.textBox_branch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_branch.Location = new System.Drawing.Point(0, 0);
            this.textBox_branch.Name = "textBox_branch";
            this.textBox_branch.ReadOnly = true;
            this.textBox_branch.Size = new System.Drawing.Size(320, 20);
            this.textBox_branch.TabIndex = 0;
            // 
            // button_branch
            // 
            this.button_branch.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_branch.Location = new System.Drawing.Point(320, 0);
            this.button_branch.Name = "button_branch";
            this.button_branch.Size = new System.Drawing.Size(34, 20);
            this.button_branch.TabIndex = 1;
            this.button_branch.Text = "...";
            this.button_branch.UseVisualStyleBackColor = true;
            this.button_branch.Click += new System.EventHandler(this.button_branch_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox_paymentType);
            this.panel2.Controls.Add(this.button_paymentType);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(93, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(354, 20);
            this.panel2.TabIndex = 3;
            // 
            // textBox_paymentType
            // 
            this.textBox_paymentType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_paymentType.Location = new System.Drawing.Point(0, 0);
            this.textBox_paymentType.Name = "textBox_paymentType";
            this.textBox_paymentType.ReadOnly = true;
            this.textBox_paymentType.Size = new System.Drawing.Size(320, 20);
            this.textBox_paymentType.TabIndex = 1;
            // 
            // button_paymentType
            // 
            this.button_paymentType.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_paymentType.Location = new System.Drawing.Point(320, 0);
            this.button_paymentType.Name = "button_paymentType";
            this.button_paymentType.Size = new System.Drawing.Size(34, 20);
            this.button_paymentType.TabIndex = 2;
            this.button_paymentType.Text = "...";
            this.button_paymentType.UseVisualStyleBackColor = true;
            this.button_paymentType.Click += new System.EventHandler(this.button_paymentType_Click);
            // 
            // fRepSumByItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 202);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(466, 240);
            this.Name = "fRepSumByItems";
            this.ShowInTaskbar = false;
            this.Text = "Статистика по товарам";
            this.Shown += new System.EventHandler(this.fRepSumByItems_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_dateStart;
        private System.Windows.Forms.DateTimePicker dateTimePicker_timeStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_dateEnd;
        private System.Windows.Forms.DateTimePicker dateTimePicker_timeEnd;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_branch;
        private System.Windows.Forms.Button button_branch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox_paymentType;
        private System.Windows.Forms.Button button_paymentType;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox_items;
        private System.Windows.Forms.Button button_items;
        private System.Windows.Forms.Label label3;
    }
}

