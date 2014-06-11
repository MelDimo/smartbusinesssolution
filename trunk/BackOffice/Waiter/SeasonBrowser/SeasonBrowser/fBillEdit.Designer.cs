namespace com.sbs.gui.seasonbrowser
{
    partial class fBillEdit
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
            this.label_id = new System.Windows.Forms.Label();
            this.label_numb = new System.Windows.Forms.Label();
            this.label_table = new System.Windows.Forms.Label();
            this.label_discount = new System.Windows.Forms.Label();
            this.label_typePayment = new System.Windows.Forms.Label();
            this.label_note = new System.Windows.Forms.Label();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.textBox_numb = new System.Windows.Forms.TextBox();
            this.textBox_table = new System.Windows.Forms.TextBox();
            this.numericUpDown_discount = new System.Windows.Forms.NumericUpDown();
            this.comboBox_typePayment = new System.Windows.Forms.ComboBox();
            this.comboBox_notes = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_status = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_history = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_discount)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label_id, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_numb, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_table, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label_discount, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_typePayment, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label_note, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox_id, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_numb, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_table, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_discount, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_typePayment, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_notes, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_status, 1, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(397, 193);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_id.Location = new System.Drawing.Point(3, 0);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(84, 25);
            this.label_id.TabIndex = 0;
            this.label_id.Text = "ID";
            this.label_id.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_numb
            // 
            this.label_numb.AutoSize = true;
            this.label_numb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_numb.Location = new System.Drawing.Point(3, 25);
            this.label_numb.Name = "label_numb";
            this.label_numb.Size = new System.Drawing.Size(84, 25);
            this.label_numb.TabIndex = 1;
            this.label_numb.Text = "Номер счета";
            this.label_numb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_table
            // 
            this.label_table.AutoSize = true;
            this.label_table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_table.Location = new System.Drawing.Point(3, 50);
            this.label_table.Name = "label_table";
            this.label_table.Size = new System.Drawing.Size(84, 25);
            this.label_table.TabIndex = 2;
            this.label_table.Text = "Столик";
            this.label_table.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_discount
            // 
            this.label_discount.AutoSize = true;
            this.label_discount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_discount.Enabled = false;
            this.label_discount.Location = new System.Drawing.Point(3, 75);
            this.label_discount.Name = "label_discount";
            this.label_discount.Size = new System.Drawing.Size(84, 25);
            this.label_discount.TabIndex = 3;
            this.label_discount.Text = "Скидка";
            this.label_discount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_discount.Visible = false;
            // 
            // label_typePayment
            // 
            this.label_typePayment.AutoSize = true;
            this.label_typePayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_typePayment.Location = new System.Drawing.Point(3, 100);
            this.label_typePayment.Name = "label_typePayment";
            this.label_typePayment.Size = new System.Drawing.Size(84, 25);
            this.label_typePayment.TabIndex = 4;
            this.label_typePayment.Text = "Тип оплаты";
            this.label_typePayment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_note
            // 
            this.label_note.AutoSize = true;
            this.label_note.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_note.Location = new System.Drawing.Point(3, 125);
            this.label_note.Name = "label_note";
            this.label_note.Size = new System.Drawing.Size(84, 25);
            this.label_note.TabIndex = 5;
            this.label_note.Text = "Комментарий";
            this.label_note.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_id
            // 
            this.textBox_id.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_id.Location = new System.Drawing.Point(93, 3);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.ReadOnly = true;
            this.textBox_id.Size = new System.Drawing.Size(301, 20);
            this.textBox_id.TabIndex = 6;
            // 
            // textBox_numb
            // 
            this.textBox_numb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_numb.Location = new System.Drawing.Point(93, 28);
            this.textBox_numb.Name = "textBox_numb";
            this.textBox_numb.ReadOnly = true;
            this.textBox_numb.Size = new System.Drawing.Size(301, 20);
            this.textBox_numb.TabIndex = 7;
            // 
            // textBox_table
            // 
            this.textBox_table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_table.Location = new System.Drawing.Point(93, 53);
            this.textBox_table.Name = "textBox_table";
            this.textBox_table.ReadOnly = true;
            this.textBox_table.Size = new System.Drawing.Size(301, 20);
            this.textBox_table.TabIndex = 8;
            // 
            // numericUpDown_discount
            // 
            this.numericUpDown_discount.DecimalPlaces = 3;
            this.numericUpDown_discount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_discount.Enabled = false;
            this.numericUpDown_discount.Location = new System.Drawing.Point(93, 78);
            this.numericUpDown_discount.Name = "numericUpDown_discount";
            this.numericUpDown_discount.Size = new System.Drawing.Size(301, 20);
            this.numericUpDown_discount.TabIndex = 9;
            this.numericUpDown_discount.Visible = false;
            // 
            // comboBox_typePayment
            // 
            this.comboBox_typePayment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_typePayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_typePayment.FormattingEnabled = true;
            this.comboBox_typePayment.Location = new System.Drawing.Point(93, 103);
            this.comboBox_typePayment.Name = "comboBox_typePayment";
            this.comboBox_typePayment.Size = new System.Drawing.Size(301, 21);
            this.comboBox_typePayment.TabIndex = 10;
            // 
            // comboBox_notes
            // 
            this.comboBox_notes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_notes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_notes.FormattingEnabled = true;
            this.comboBox_notes.Location = new System.Drawing.Point(93, 128);
            this.comboBox_notes.Name = "comboBox_notes";
            this.comboBox_notes.Size = new System.Drawing.Size(301, 21);
            this.comboBox_notes.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 27);
            this.label1.TabIndex = 12;
            this.label1.Text = "Статус счета";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_status
            // 
            this.comboBox_status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_status.FormattingEnabled = true;
            this.comboBox_status.Location = new System.Drawing.Point(93, 153);
            this.comboBox_status.Name = "comboBox_status";
            this.comboBox_status.Size = new System.Drawing.Size(301, 21);
            this.comboBox_status.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_history);
            this.panel1.Controls.Add(this.button_cancel);
            this.panel1.Controls.Add(this.button_ok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 196);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 37);
            this.panel1.TabIndex = 1;
            // 
            // button_history
            // 
            this.button_history.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_history.Location = new System.Drawing.Point(6, 8);
            this.button_history.Name = "button_history";
            this.button_history.Size = new System.Drawing.Size(75, 23);
            this.button_history.TabIndex = 2;
            this.button_history.Text = "История";
            this.button_history.UseVisualStyleBackColor = true;
            this.button_history.Click += new System.EventHandler(this.button_history_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Location = new System.Drawing.Point(319, 8);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "Отмена";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.Location = new System.Drawing.Point(238, 8);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "Сохранить";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // fBillEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 236);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fBillEdit";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование счета";
            this.Shown += new System.EventHandler(this.fBillEdit_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_discount)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_id;
        private System.Windows.Forms.Label label_numb;
        private System.Windows.Forms.Label label_table;
        private System.Windows.Forms.Label label_discount;
        private System.Windows.Forms.Label label_typePayment;
        private System.Windows.Forms.Label label_note;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
        internal System.Windows.Forms.TextBox textBox_numb;
        internal System.Windows.Forms.TextBox textBox_table;
        internal System.Windows.Forms.NumericUpDown numericUpDown_discount;
        internal System.Windows.Forms.ComboBox comboBox_typePayment;
        internal System.Windows.Forms.ComboBox comboBox_notes;
        internal System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox comboBox_status;
        private System.Windows.Forms.Button button_history;

    }
}