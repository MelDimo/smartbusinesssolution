namespace com.sbs.gui.references.currency
{
    partial class fCourse
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_currency = new System.Windows.Forms.Label();
            this.textBox_currency = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numUpDown_course = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_multiplicity = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dTimePicker_date = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_course)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_cancel);
            this.panel1.Controls.Add(this.button_ok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(505, 35);
            this.panel1.TabIndex = 1;
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Location = new System.Drawing.Point(409, 6);
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
            this.button_ok.Location = new System.Drawing.Point(328, 6);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "Ок";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.tableLayoutPanel1.Controls.Add(this.label_currency, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_currency, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.numUpDown_course, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_multiplicity, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.dTimePicker_date, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.39622F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.60378F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(505, 50);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label_currency
            // 
            this.label_currency.AutoSize = true;
            this.label_currency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_currency.Location = new System.Drawing.Point(3, 0);
            this.label_currency.Name = "label_currency";
            this.label_currency.Size = new System.Drawing.Size(281, 21);
            this.label_currency.TabIndex = 0;
            this.label_currency.Text = "Валюта";
            this.label_currency.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_currency
            // 
            this.textBox_currency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_currency.Location = new System.Drawing.Point(3, 24);
            this.textBox_currency.Name = "textBox_currency";
            this.textBox_currency.ReadOnly = true;
            this.textBox_currency.Size = new System.Drawing.Size(281, 20);
            this.textBox_currency.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(358, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Курс";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numUpDown_course
            // 
            this.numUpDown_course.DecimalPlaces = 3;
            this.numUpDown_course.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numUpDown_course.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numUpDown_course.Location = new System.Drawing.Point(358, 24);
            this.numUpDown_course.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numUpDown_course.Name = "numUpDown_course";
            this.numUpDown_course.Size = new System.Drawing.Size(58, 20);
            this.numUpDown_course.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(290, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "Кратность";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_multiplicity
            // 
            this.textBox_multiplicity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_multiplicity.Location = new System.Drawing.Point(290, 24);
            this.textBox_multiplicity.Name = "textBox_multiplicity";
            this.textBox_multiplicity.Size = new System.Drawing.Size(62, 20);
            this.textBox_multiplicity.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(422, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "Дата";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dTimePicker_date
            // 
            this.dTimePicker_date.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dTimePicker_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dTimePicker_date.Location = new System.Drawing.Point(422, 24);
            this.dTimePicker_date.Name = "dTimePicker_date";
            this.dTimePicker_date.Size = new System.Drawing.Size(80, 20);
            this.dTimePicker_date.TabIndex = 2;
            // 
            // fCourse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 85);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(16, 123);
            this.Name = "fCourse";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Установка курса";
            this.Shown += new System.EventHandler(this.fCourse_Shown);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown_course)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_currency;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox textBox_multiplicity;
        internal System.Windows.Forms.NumericUpDown numUpDown_course;
        internal System.Windows.Forms.DateTimePicker dTimePicker_date;
        internal System.Windows.Forms.TextBox textBox_currency;
    }
}