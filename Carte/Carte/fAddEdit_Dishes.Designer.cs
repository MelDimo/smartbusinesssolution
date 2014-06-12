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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button_topping = new System.Windows.Forms.Button();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_price)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minStep)).BeginInit();
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
            this.label1.Location = new System.Drawing.Point(9, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Наименование";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 48;
            this.label2.Text = "Цена";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Группа";
            // 
            // comboBox_group
            // 
            this.comboBox_group.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_group.FormattingEnabled = true;
            this.comboBox_group.Location = new System.Drawing.Point(134, 51);
            this.comboBox_group.Name = "comboBox_group";
            this.comboBox_group.Size = new System.Drawing.Size(330, 21);
            this.comboBox_group.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.button_cancel);
            this.panel8.Controls.Add(this.button_ok);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 311);
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
            this.textBox_name.Location = new System.Drawing.Point(134, 105);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(330, 20);
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
            this.numericUpDown_price.Location = new System.Drawing.Point(134, 132);
            this.numericUpDown_price.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.numericUpDown_price.Name = "numericUpDown_price";
            this.numericUpDown_price.Size = new System.Drawing.Size(330, 20);
            this.numericUpDown_price.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 56;
            this.label4.Text = "Статус";
            // 
            // comboBox_refStatus
            // 
            this.comboBox_refStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_refStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_refStatus.FormattingEnabled = true;
            this.comboBox_refStatus.Location = new System.Drawing.Point(134, 189);
            this.comboBox_refStatus.Name = "comboBox_refStatus";
            this.comboBox_refStatus.Size = new System.Drawing.Size(330, 21);
            this.comboBox_refStatus.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 58;
            this.label5.Text = "Отображать в меню";
            // 
            // checkBox_isVisible
            // 
            this.checkBox_isVisible.AutoSize = true;
            this.checkBox_isVisible.Checked = true;
            this.checkBox_isVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_isVisible.Location = new System.Drawing.Point(134, 216);
            this.checkBox_isVisible.Name = "checkBox_isVisible";
            this.checkBox_isVisible.Size = new System.Drawing.Size(15, 14);
            this.checkBox_isVisible.TabIndex = 4;
            this.checkBox_isVisible.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 239);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 60;
            this.label6.Text = "Тип принтера";
            // 
            // comboBox_refPrintersType
            // 
            this.comboBox_refPrintersType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_refPrintersType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_refPrintersType.FormattingEnabled = true;
            this.comboBox_refPrintersType.Location = new System.Drawing.Point(134, 236);
            this.comboBox_refPrintersType.Name = "comboBox_refPrintersType";
            this.comboBox_refPrintersType.Size = new System.Drawing.Size(330, 21);
            this.comboBox_refPrintersType.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 81);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 61;
            this.label7.Text = "Блюдо";
            // 
            // textBox_refDishesName
            // 
            this.textBox_refDishesName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_refDishesName.Location = new System.Drawing.Point(134, 78);
            this.textBox_refDishesName.Name = "textBox_refDishesName";
            this.textBox_refDishesName.ReadOnly = true;
            this.textBox_refDishesName.Size = new System.Drawing.Size(296, 20);
            this.textBox_refDishesName.TabIndex = 62;
            // 
            // button_getDishes
            // 
            this.button_getDishes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_getDishes.Location = new System.Drawing.Point(436, 76);
            this.button_getDishes.Name = "button_getDishes";
            this.button_getDishes.Size = new System.Drawing.Size(28, 23);
            this.button_getDishes.TabIndex = 63;
            this.button_getDishes.Text = "...";
            this.button_getDishes.UseVisualStyleBackColor = true;
            this.button_getDishes.Click += new System.EventHandler(this.button_getDishes_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 13);
            this.label8.TabIndex = 64;
            this.label8.Text = "Мин. реализ. кол-во";
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
            this.numericUpDown_minStep.Location = new System.Drawing.Point(134, 160);
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
            this.numericUpDown_minStep.Size = new System.Drawing.Size(330, 20);
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
            this.label9.Location = new System.Drawing.Point(9, 271);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 66;
            this.label9.Text = "Топпинги";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(134, 271);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(160, 17);
            this.checkBox1.TabIndex = 67;
            this.checkBox1.Text = "Блюдо содержит топпинги";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button_topping
            // 
            this.button_topping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button_topping.Location = new System.Drawing.Point(300, 266);
            this.button_topping.Name = "button_topping";
            this.button_topping.Size = new System.Drawing.Size(165, 23);
            this.button_topping.TabIndex = 68;
            this.button_topping.Text = "структура топпинга";
            this.button_topping.UseVisualStyleBackColor = true;
            this.button_topping.Click += new System.EventHandler(this.button_topping_Click);
            // 
            // fAddEdit_Dishes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 346);
            this.Controls.Add(this.button_topping);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.numericUpDown_minStep);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button_getDishes);
            this.Controls.Add(this.textBox_refDishesName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox_refPrintersType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.checkBox_isVisible);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_refStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown_price);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.comboBox_group);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_id);
            this.MinimizeBox = false;
            this.Name = "fAddEdit_Dishes";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fAddEdit_Dishes";
            this.Shown += new System.EventHandler(this.fAddEdit_Dishes_Shown);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_price)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minStep)).EndInit();
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
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button_topping;
    }
}