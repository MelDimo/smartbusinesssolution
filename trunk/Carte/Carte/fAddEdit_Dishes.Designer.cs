namespace com.sbs.gui.carte
{
    partial class fAddEdit_Dishes
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
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_group = new System.Windows.Forms.ComboBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.numericUpDown_price = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_refStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBox_isVisible = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox_refPrintersType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_refDishesName = new System.Windows.Forms.TextBox();
            this.button_getDishes = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.numericUpDown_minStep = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.checkBox_haveTopping = new System.Windows.Forms.CheckBox();
            this.button_topping = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox_AvalHall = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox_AvalDelivery = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_price)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minStep)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(12, 12);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.ReadOnly = true;
            this.textBox_id.Size = new System.Drawing.Size(100, 20);
            this.textBox_id.TabIndex = 44;
            this.textBox_id.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 26);
            this.label1.TabIndex = 47;
            this.label1.Text = "Наименование";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 26);
            this.label2.TabIndex = 48;
            this.label2.Text = "Цена";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 26);
            this.label3.TabIndex = 49;
            this.label3.Text = "Группа";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_group
            // 
            this.comboBox_group.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_group.FormattingEnabled = true;
            this.comboBox_group.Location = new System.Drawing.Point(155, 3);
            this.comboBox_group.Name = "comboBox_group";
            this.comboBox_group.Size = new System.Drawing.Size(318, 21);
            this.comboBox_group.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.button_cancel);
            this.panel8.Controls.Add(this.button_ok);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 346);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(476, 35);
            this.panel8.TabIndex = 6;
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Location = new System.Drawing.Point(380, 6);
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
            this.button_ok.Location = new System.Drawing.Point(299, 6);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "Ок";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // textBox_name
            // 
            this.textBox_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_name.Location = new System.Drawing.Point(155, 55);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(318, 20);
            this.textBox_name.TabIndex = 1;
            // 
            // numericUpDown_price
            // 
            this.numericUpDown_price.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_price.DecimalPlaces = 2;
            this.numericUpDown_price.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDown_price.Location = new System.Drawing.Point(155, 81);
            this.numericUpDown_price.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.numericUpDown_price.Name = "numericUpDown_price";
            this.numericUpDown_price.Size = new System.Drawing.Size(318, 20);
            this.numericUpDown_price.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(146, 26);
            this.label4.TabIndex = 56;
            this.label4.Text = "Статус";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_refStatus
            // 
            this.comboBox_refStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_refStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_refStatus.FormattingEnabled = true;
            this.comboBox_refStatus.Location = new System.Drawing.Point(155, 133);
            this.comboBox_refStatus.Name = "comboBox_refStatus";
            this.comboBox_refStatus.Size = new System.Drawing.Size(318, 21);
            this.comboBox_refStatus.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 26);
            this.label5.TabIndex = 58;
            this.label5.Text = "Отображать в меню";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox_isVisible
            // 
            this.checkBox_isVisible.AutoSize = true;
            this.checkBox_isVisible.Checked = true;
            this.checkBox_isVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_isVisible.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_isVisible.Location = new System.Drawing.Point(155, 159);
            this.checkBox_isVisible.Name = "checkBox_isVisible";
            this.checkBox_isVisible.Size = new System.Drawing.Size(318, 20);
            this.checkBox_isVisible.TabIndex = 4;
            this.checkBox_isVisible.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(3, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 26);
            this.label6.TabIndex = 60;
            this.label6.Text = "Тип принтера";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_refPrintersType
            // 
            this.comboBox_refPrintersType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_refPrintersType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_refPrintersType.FormattingEnabled = true;
            this.comboBox_refPrintersType.Location = new System.Drawing.Point(155, 237);
            this.comboBox_refPrintersType.Name = "comboBox_refPrintersType";
            this.comboBox_refPrintersType.Size = new System.Drawing.Size(318, 21);
            this.comboBox_refPrintersType.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(3, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 26);
            this.label7.TabIndex = 61;
            this.label7.Text = "Блюдо";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_refDishesName
            // 
            this.textBox_refDishesName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_refDishesName.Location = new System.Drawing.Point(0, 0);
            this.textBox_refDishesName.Name = "textBox_refDishesName";
            this.textBox_refDishesName.ReadOnly = true;
            this.textBox_refDishesName.Size = new System.Drawing.Size(290, 20);
            this.textBox_refDishesName.TabIndex = 62;
            // 
            // button_getDishes
            // 
            this.button_getDishes.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_getDishes.Location = new System.Drawing.Point(290, 0);
            this.button_getDishes.Name = "button_getDishes";
            this.button_getDishes.Size = new System.Drawing.Size(28, 20);
            this.button_getDishes.TabIndex = 63;
            this.button_getDishes.Text = "...";
            this.button_getDishes.UseVisualStyleBackColor = true;
            this.button_getDishes.Click += new System.EventHandler(this.button_getDishes_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(146, 26);
            this.label8.TabIndex = 64;
            this.label8.Text = "Мин. реализ. кол-во";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown_minStep
            // 
            this.numericUpDown_minStep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_minStep.DecimalPlaces = 2;
            this.numericUpDown_minStep.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_minStep.Location = new System.Drawing.Point(155, 107);
            this.numericUpDown_minStep.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_minStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown_minStep.Name = "numericUpDown_minStep";
            this.numericUpDown_minStep.Size = new System.Drawing.Size(318, 20);
            this.numericUpDown_minStep.TabIndex = 65;
            this.numericUpDown_minStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(3, 260);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(146, 31);
            this.label9.TabIndex = 66;
            this.label9.Text = "Топпинги";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox_haveTopping
            // 
            this.checkBox_haveTopping.AutoSize = true;
            this.checkBox_haveTopping.Checked = true;
            this.checkBox_haveTopping.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_haveTopping.Dock = System.Windows.Forms.DockStyle.Left;
            this.checkBox_haveTopping.Location = new System.Drawing.Point(0, 0);
            this.checkBox_haveTopping.Name = "checkBox_haveTopping";
            this.checkBox_haveTopping.Size = new System.Drawing.Size(160, 25);
            this.checkBox_haveTopping.TabIndex = 67;
            this.checkBox_haveTopping.Text = "Блюдо содержит топпинги";
            this.checkBox_haveTopping.UseVisualStyleBackColor = true;
            // 
            // button_topping
            // 
            this.button_topping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_topping.Location = new System.Drawing.Point(160, 0);
            this.button_topping.Name = "button_topping";
            this.button_topping.Size = new System.Drawing.Size(158, 25);
            this.button_topping.TabIndex = 68;
            this.button_topping.Text = "структура топпинга";
            this.button_topping.UseVisualStyleBackColor = true;
            this.button_topping.Click += new System.EventHandler(this.button_topping_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(3, 182);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 26);
            this.label10.TabIndex = 69;
            this.label10.Text = "Доступно в меню зала";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox_AvalHall
            // 
            this.checkBox_AvalHall.AutoSize = true;
            this.checkBox_AvalHall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_AvalHall.Location = new System.Drawing.Point(155, 185);
            this.checkBox_AvalHall.Name = "checkBox_AvalHall";
            this.checkBox_AvalHall.Size = new System.Drawing.Size(318, 20);
            this.checkBox_AvalHall.TabIndex = 70;
            this.checkBox_AvalHall.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 208);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(146, 26);
            this.label11.TabIndex = 71;
            this.label11.Text = "Доступно в меню доставки";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 152F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_group, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_AvalHall, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_refPrintersType, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_name, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_minStep, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.numericUpDown_price, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_isVisible, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_refStatus, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_AvalDelivery, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 10);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 12;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(476, 302);
            this.tableLayoutPanel1.TabIndex = 72;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox_refDishesName);
            this.panel1.Controls.Add(this.button_getDishes);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(155, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(318, 20);
            this.panel1.TabIndex = 62;
            // 
            // checkBox_AvalDelivery
            // 
            this.checkBox_AvalDelivery.AutoSize = true;
            this.checkBox_AvalDelivery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_AvalDelivery.Location = new System.Drawing.Point(155, 211);
            this.checkBox_AvalDelivery.Name = "checkBox_AvalDelivery";
            this.checkBox_AvalDelivery.Size = new System.Drawing.Size(318, 20);
            this.checkBox_AvalDelivery.TabIndex = 72;
            this.checkBox_AvalDelivery.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_topping);
            this.panel2.Controls.Add(this.checkBox_haveTopping);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(155, 263);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(318, 25);
            this.panel2.TabIndex = 73;
            // 
            // fAddEdit_Dishes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 381);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.textBox_id);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(492, 419);
            this.Name = "fAddEdit_Dishes";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fAddEdit_Dishes";
            this.Shown += new System.EventHandler(this.fAddEdit_Dishes_Shown);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_price)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minStep)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.NumericUpDown numericUpDown_price;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBox_isVisible;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox comboBox_group;
        internal System.Windows.Forms.ComboBox comboBox_refStatus;
        internal System.Windows.Forms.ComboBox comboBox_refPrintersType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_refDishesName;
        private System.Windows.Forms.Button button_getDishes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown numericUpDown_minStep;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBox_haveTopping;
        private System.Windows.Forms.Button button_topping;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBox_AvalHall;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox_AvalDelivery;
        private System.Windows.Forms.Panel panel2;
    }
}