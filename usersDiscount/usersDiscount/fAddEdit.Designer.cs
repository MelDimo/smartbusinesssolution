namespace com.sbs.gui.usersdiscount
{
    partial class fAddEdit
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
            this.panel8 = new System.Windows.Forms.Panel();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dateTimePicker_dateStart = new System.Windows.Forms.DateTimePicker();
            this.checkBox_dateStart = new System.Windows.Forms.CheckBox();
            this.label_fio = new System.Windows.Forms.Label();
            this.label_discount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_fio = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_key = new System.Windows.Forms.TextBox();
            this.button_getKey = new System.Windows.Forms.Button();
            this.numericUpDown_discount = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dateTimePicker_dateEnd = new System.Windows.Forms.DateTimePicker();
            this.checkBox_dateEnd = new System.Windows.Forms.CheckBox();
            this.comboBox_refStatus = new System.Windows.Forms.ComboBox();
            this.panel8.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_discount)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.button_cancel);
            this.panel8.Controls.Add(this.button_ok);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 207);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(389, 35);
            this.panel8.TabIndex = 7;
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Location = new System.Drawing.Point(293, 6);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "Отмена";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.Location = new System.Drawing.Point(212, 6);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "Ок";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(12, 12);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.ReadOnly = true;
            this.textBox_id.Size = new System.Drawing.Size(100, 20);
            this.textBox_id.TabIndex = 8;
            this.textBox_id.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_fio, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_discount, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox_fio, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_discount, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_refStatus, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(365, 164);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dateTimePicker_dateStart);
            this.panel3.Controls.Add(this.checkBox_dateStart);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(103, 84);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(259, 21);
            this.panel3.TabIndex = 11;
            // 
            // dateTimePicker_dateStart
            // 
            this.dateTimePicker_dateStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker_dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_dateStart.Location = new System.Drawing.Point(15, 0);
            this.dateTimePicker_dateStart.Name = "dateTimePicker_dateStart";
            this.dateTimePicker_dateStart.Size = new System.Drawing.Size(244, 20);
            this.dateTimePicker_dateStart.TabIndex = 1;
            // 
            // checkBox_dateStart
            // 
            this.checkBox_dateStart.AutoSize = true;
            this.checkBox_dateStart.Checked = true;
            this.checkBox_dateStart.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_dateStart.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBox_dateStart.Enabled = false;
            this.checkBox_dateStart.Location = new System.Drawing.Point(0, 0);
            this.checkBox_dateStart.Name = "checkBox_dateStart";
            this.checkBox_dateStart.Size = new System.Drawing.Size(15, 21);
            this.checkBox_dateStart.TabIndex = 0;
            this.checkBox_dateStart.UseVisualStyleBackColor = true;
            // 
            // label_fio
            // 
            this.label_fio.AutoSize = true;
            this.label_fio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_fio.Location = new System.Drawing.Point(3, 0);
            this.label_fio.Name = "label_fio";
            this.label_fio.Size = new System.Drawing.Size(94, 27);
            this.label_fio.TabIndex = 0;
            this.label_fio.Text = "ФИО";
            this.label_fio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_discount
            // 
            this.label_discount.AutoSize = true;
            this.label_discount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_discount.Location = new System.Drawing.Point(3, 27);
            this.label_discount.Name = "label_discount";
            this.label_discount.Size = new System.Drawing.Size(94, 27);
            this.label_discount.TabIndex = 1;
            this.label_discount.Text = "Скидка";
            this.label_discount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ключ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "Дата начала";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 27);
            this.label3.TabIndex = 4;
            this.label3.Text = "Дата окончания";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 27);
            this.label4.TabIndex = 5;
            this.label4.Text = "Статус";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_fio
            // 
            this.textBox_fio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_fio.Location = new System.Drawing.Point(103, 3);
            this.textBox_fio.Name = "textBox_fio";
            this.textBox_fio.Size = new System.Drawing.Size(259, 20);
            this.textBox_fio.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_key);
            this.panel1.Controls.Add(this.button_getKey);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(103, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(259, 21);
            this.panel1.TabIndex = 7;
            // 
            // textBox_key
            // 
            this.textBox_key.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_key.Location = new System.Drawing.Point(0, 0);
            this.textBox_key.Name = "textBox_key";
            this.textBox_key.Size = new System.Drawing.Size(230, 20);
            this.textBox_key.TabIndex = 0;
            // 
            // button_getKey
            // 
            this.button_getKey.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_getKey.Location = new System.Drawing.Point(230, 0);
            this.button_getKey.Name = "button_getKey";
            this.button_getKey.Size = new System.Drawing.Size(29, 21);
            this.button_getKey.TabIndex = 1;
            this.button_getKey.Text = "...";
            this.button_getKey.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_discount
            // 
            this.numericUpDown_discount.DecimalPlaces = 3;
            this.numericUpDown_discount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_discount.Location = new System.Drawing.Point(103, 30);
            this.numericUpDown_discount.Name = "numericUpDown_discount";
            this.numericUpDown_discount.Size = new System.Drawing.Size(259, 20);
            this.numericUpDown_discount.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dateTimePicker_dateEnd);
            this.panel2.Controls.Add(this.checkBox_dateEnd);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(103, 111);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(259, 21);
            this.panel2.TabIndex = 10;
            // 
            // dateTimePicker_dateEnd
            // 
            this.dateTimePicker_dateEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker_dateEnd.Enabled = false;
            this.dateTimePicker_dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_dateEnd.Location = new System.Drawing.Point(15, 0);
            this.dateTimePicker_dateEnd.Name = "dateTimePicker_dateEnd";
            this.dateTimePicker_dateEnd.Size = new System.Drawing.Size(244, 20);
            this.dateTimePicker_dateEnd.TabIndex = 1;
            // 
            // checkBox_dateEnd
            // 
            this.checkBox_dateEnd.AutoSize = true;
            this.checkBox_dateEnd.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBox_dateEnd.Location = new System.Drawing.Point(0, 0);
            this.checkBox_dateEnd.Name = "checkBox_dateEnd";
            this.checkBox_dateEnd.Size = new System.Drawing.Size(15, 21);
            this.checkBox_dateEnd.TabIndex = 0;
            this.checkBox_dateEnd.UseVisualStyleBackColor = true;
            this.checkBox_dateEnd.CheckedChanged += new System.EventHandler(this.checkBox_dateEnd_CheckedChanged);
            // 
            // comboBox_refStatus
            // 
            this.comboBox_refStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_refStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_refStatus.FormattingEnabled = true;
            this.comboBox_refStatus.Location = new System.Drawing.Point(103, 138);
            this.comboBox_refStatus.Name = "comboBox_refStatus";
            this.comboBox_refStatus.Size = new System.Drawing.Size(259, 21);
            this.comboBox_refStatus.TabIndex = 12;
            // 
            // fAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 242);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.textBox_id);
            this.Controls.Add(this.panel8);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fAddEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fAddEdit";
            this.Shown += new System.EventHandler(this.fAddEdit_Shown);
            this.panel8.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_discount)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_fio;
        private System.Windows.Forms.Label label_discount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_fio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox_key;
        private System.Windows.Forms.Button button_getKey;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dateTimePicker_dateStart;
        private System.Windows.Forms.CheckBox checkBox_dateStart;
        private System.Windows.Forms.NumericUpDown numericUpDown_discount;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_dateEnd;
        private System.Windows.Forms.CheckBox checkBox_dateEnd;
        internal System.Windows.Forms.ComboBox comboBox_refStatus;
    }
}