﻿namespace com.sbs.gui.references.refdishes
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
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.numericUpDown_code = new System.Windows.Forms.NumericUpDown();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.numericUpDown_price = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_refStatus = new System.Windows.Forms.ComboBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.comboBox_refPrintersType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown_minStep = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_treeGroup = new System.Windows.Forms.TextBox();
            this.button_treeGroup = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_code)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_price)).BeginInit();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minStep)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(12, 12);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.ReadOnly = true;
            this.textBox_id.Size = new System.Drawing.Size(100, 20);
            this.textBox_id.TabIndex = 6;
            this.textBox_id.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Наименование";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(132, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Внешний ключ";
            // 
            // numericUpDown_code
            // 
            this.numericUpDown_code.Location = new System.Drawing.Point(215, 12);
            this.numericUpDown_code.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numericUpDown_code.Name = "numericUpDown_code";
            this.numericUpDown_code.Size = new System.Drawing.Size(64, 20);
            this.numericUpDown_code.TabIndex = 40;
            // 
            // textBox_name
            // 
            this.textBox_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_name.Location = new System.Drawing.Point(154, 78);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(358, 20);
            this.textBox_name.TabIndex = 42;
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
            this.numericUpDown_price.Location = new System.Drawing.Point(154, 130);
            this.numericUpDown_price.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDown_price.Name = "numericUpDown_price";
            this.numericUpDown_price.Size = new System.Drawing.Size(183, 20);
            this.numericUpDown_price.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Цена";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 45;
            this.label3.Text = "Статус";
            // 
            // comboBox_refStatus
            // 
            this.comboBox_refStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_refStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_refStatus.FormattingEnabled = true;
            this.comboBox_refStatus.Location = new System.Drawing.Point(154, 183);
            this.comboBox_refStatus.Name = "comboBox_refStatus";
            this.comboBox_refStatus.Size = new System.Drawing.Size(358, 21);
            this.comboBox_refStatus.TabIndex = 46;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.button_cancel);
            this.panel8.Controls.Add(this.button_ok);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 221);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(524, 35);
            this.panel8.TabIndex = 47;
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Location = new System.Drawing.Point(428, 6);
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
            this.button_ok.Location = new System.Drawing.Point(347, 6);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "Ок";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // comboBox_refPrintersType
            // 
            this.comboBox_refPrintersType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_refPrintersType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_refPrintersType.FormattingEnabled = true;
            this.comboBox_refPrintersType.Location = new System.Drawing.Point(154, 156);
            this.comboBox_refPrintersType.Name = "comboBox_refPrintersType";
            this.comboBox_refPrintersType.Size = new System.Drawing.Size(358, 21);
            this.comboBox_refPrintersType.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 159);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Тип принтера";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 106);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "Мин. реализ. кол-во";
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
            this.numericUpDown_minStep.Location = new System.Drawing.Point(154, 104);
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
            this.numericUpDown_minStep.Size = new System.Drawing.Size(183, 20);
            this.numericUpDown_minStep.TabIndex = 51;
            this.numericUpDown_minStep.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 52;
            this.label6.Text = "Группа";
            // 
            // textBox_treeGroup
            // 
            this.textBox_treeGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_treeGroup.Location = new System.Drawing.Point(154, 50);
            this.textBox_treeGroup.Name = "textBox_treeGroup";
            this.textBox_treeGroup.ReadOnly = true;
            this.textBox_treeGroup.Size = new System.Drawing.Size(320, 20);
            this.textBox_treeGroup.TabIndex = 54;
            // 
            // button_treeGroup
            // 
            this.button_treeGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_treeGroup.Location = new System.Drawing.Point(480, 47);
            this.button_treeGroup.Name = "button_treeGroup";
            this.button_treeGroup.Size = new System.Drawing.Size(32, 23);
            this.button_treeGroup.TabIndex = 55;
            this.button_treeGroup.Text = "...";
            this.button_treeGroup.UseVisualStyleBackColor = true;
            this.button_treeGroup.Click += new System.EventHandler(this.button_treeGroup_Click);
            // 
            // fAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 256);
            this.Controls.Add(this.button_treeGroup);
            this.Controls.Add(this.textBox_treeGroup);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDown_minStep);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_refPrintersType);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.comboBox_refStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown_price);
            this.Controls.Add(this.textBox_name);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.numericUpDown_code);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_id);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(540, 294);
            this.Name = "fAddEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fAddEdit";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_code)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_price)).EndInit();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_minStep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown numericUpDown_code;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.NumericUpDown numericUpDown_price;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ComboBox comboBox_refStatus;
        internal System.Windows.Forms.ComboBox comboBox_refPrintersType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown_minStep;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_treeGroup;
        internal System.Windows.Forms.TextBox textBox_treeGroup;
    }
}