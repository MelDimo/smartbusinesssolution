namespace com.sbs.gui.dashboard
{
    partial class fCloseBill
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label_discount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.cMStrip_closeType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.numericUpDown_curSumm = new System.Windows.Forms.NumericUpDown();
            this.label_diff = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_billSum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel_bills = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_curSumm)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.label_discount);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.numericUpDown_curSumm);
            this.groupBox1.Controls.Add(this.label_diff);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label_billSum);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Location = new System.Drawing.Point(499, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 481);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Оплата";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(242, 55);
            this.panel1.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 48);
            this.button2.TabIndex = 0;
            this.button2.Text = "F4 (скидка)";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label_discount
            // 
            this.label_discount.AutoSize = true;
            this.label_discount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_discount.Location = new System.Drawing.Point(127, 106);
            this.label_discount.Name = "label_discount";
            this.label_discount.Size = new System.Drawing.Size(113, 17);
            this.label_discount.TabIndex = 8;
            this.label_discount.Text = "label_discount";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(6, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Скидка";
            // 
            // button1
            // 
            this.button1.ContextMenuStrip = this.cMStrip_closeType;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(6, 204);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(236, 32);
            this.button1.TabIndex = 6;
            this.button1.Text = "Закрытие счета";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cMStrip_closeType
            // 
            this.cMStrip_closeType.Name = "cMStrip_closeType";
            this.cMStrip_closeType.Size = new System.Drawing.Size(61, 4);
            // 
            // numericUpDown_curSumm
            // 
            this.numericUpDown_curSumm.DecimalPlaces = 2;
            this.numericUpDown_curSumm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown_curSumm.Location = new System.Drawing.Point(127, 131);
            this.numericUpDown_curSumm.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDown_curSumm.Name = "numericUpDown_curSumm";
            this.numericUpDown_curSumm.Size = new System.Drawing.Size(89, 23);
            this.numericUpDown_curSumm.TabIndex = 0;
            this.numericUpDown_curSumm.Enter += new System.EventHandler(this.numericUpDown_curSumm_Enter);
            this.numericUpDown_curSumm.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_curSumm_KeyUp);
            // 
            // label_diff
            // 
            this.label_diff.AutoSize = true;
            this.label_diff.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_diff.Location = new System.Drawing.Point(127, 173);
            this.label_diff.Name = "label_diff";
            this.label_diff.Size = new System.Drawing.Size(75, 17);
            this.label_diff.TabIndex = 5;
            this.label_diff.Text = "label_diff";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(6, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Разница";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(6, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Сумма платежа";
            // 
            // label_billSum
            // 
            this.label_billSum.AutoSize = true;
            this.label_billSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_billSum.Location = new System.Drawing.Point(127, 78);
            this.label_billSum.Name = "label_billSum";
            this.label_billSum.Size = new System.Drawing.Size(104, 17);
            this.label_billSum.TabIndex = 1;
            this.label_billSum.Text = "label_billSum";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сумма по счету:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.flowLayoutPanel_bills);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(497, 481);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Счет";
            // 
            // flowLayoutPanel_bills
            // 
            this.flowLayoutPanel_bills.AutoScroll = true;
            this.flowLayoutPanel_bills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_bills.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel_bills.Name = "flowLayoutPanel_bills";
            this.flowLayoutPanel_bills.Size = new System.Drawing.Size(491, 462);
            this.flowLayoutPanel_bills.TabIndex = 0;
            // 
            // fCloseBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 485);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "fCloseBill";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.fCloseBill_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fCloseBill_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_curSumm)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_bills;
        private System.Windows.Forms.Label label_diff;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_billSum;
        private System.Windows.Forms.NumericUpDown numericUpDown_curSumm;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip cMStrip_closeType;
        private System.Windows.Forms.Label label_discount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
    }
}