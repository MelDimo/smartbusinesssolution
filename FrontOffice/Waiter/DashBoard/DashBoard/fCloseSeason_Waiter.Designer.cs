namespace com.sbs.gui.DashBoard
{
    partial class fCloseSeason_Waiter
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tSStatusLabel_whoOpen = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSStatusLabel_whenOpen = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel_waiterSum = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.numeric_sum = new System.Windows.Forms.NumericUpDown();
            this.label_difference = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_sum = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_waiter = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_waiterMain = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.button_sumWaiterBack = new System.Windows.Forms.Button();
            this.panel_logIn = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel_image = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.panel_waiterSum.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_sum)).BeginInit();
            this.panel_waiterMain.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel_logIn.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSStatusLabel_whoOpen,
            this.toolStripStatusLabel1,
            this.tSStatusLabel_whenOpen});
            this.statusStrip1.Location = new System.Drawing.Point(0, 287);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1094, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tSStatusLabel_whoOpen
            // 
            this.tSStatusLabel_whoOpen.Name = "tSStatusLabel_whoOpen";
            this.tSStatusLabel_whoOpen.Size = new System.Drawing.Size(134, 17);
            this.tSStatusLabel_whoOpen.Text = "tSStatusLabel_whoOpen";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(25, 17);
            this.toolStripStatusLabel1.Text = "      ";
            // 
            // tSStatusLabel_whenOpen
            // 
            this.tSStatusLabel_whenOpen.Name = "tSStatusLabel_whenOpen";
            this.tSStatusLabel_whenOpen.Size = new System.Drawing.Size(140, 17);
            this.tSStatusLabel_whenOpen.Text = "tSStatusLabel_whenOpen";
            // 
            // panel_waiterSum
            // 
            this.panel_waiterSum.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_waiterSum.Controls.Add(this.label4);
            this.panel_waiterSum.Controls.Add(this.panel1);
            this.panel_waiterSum.Controls.Add(this.numeric_sum);
            this.panel_waiterSum.Controls.Add(this.label_difference);
            this.panel_waiterSum.Controls.Add(this.label3);
            this.panel_waiterSum.Controls.Add(this.label_sum);
            this.panel_waiterSum.Controls.Add(this.label1);
            this.panel_waiterSum.Location = new System.Drawing.Point(728, 0);
            this.panel_waiterSum.Name = "panel_waiterSum";
            this.panel_waiterSum.Size = new System.Drawing.Size(357, 287);
            this.panel_waiterSum.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Разница";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.button_sumWaiterBack);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 32);
            this.panel1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(78, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // numeric_sum
            // 
            this.numeric_sum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.numeric_sum.Location = new System.Drawing.Point(109, 93);
            this.numeric_sum.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.numeric_sum.Name = "numeric_sum";
            this.numeric_sum.Size = new System.Drawing.Size(243, 20);
            this.numeric_sum.TabIndex = 6;
            this.numeric_sum.ThousandsSeparator = true;
            // 
            // label_difference
            // 
            this.label_difference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label_difference.AutoSize = true;
            this.label_difference.Location = new System.Drawing.Point(106, 130);
            this.label_difference.Name = "label_difference";
            this.label_difference.Size = new System.Drawing.Size(82, 13);
            this.label_difference.TabIndex = 5;
            this.label_difference.Text = "label_difference";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Сдаваемая сумма";
            // 
            // label_sum
            // 
            this.label_sum.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label_sum.AutoSize = true;
            this.label_sum.Location = new System.Drawing.Point(106, 65);
            this.label_sum.Name = "label_sum";
            this.label_sum.Size = new System.Drawing.Size(54, 13);
            this.label_sum.TabIndex = 1;
            this.label_sum.Text = "label_sum";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Сумма";
            // 
            // panel_waiter
            // 
            this.panel_waiter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_waiter.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.panel_waiter.Location = new System.Drawing.Point(0, 32);
            this.panel_waiter.Name = "panel_waiter";
            this.panel_waiter.Size = new System.Drawing.Size(355, 253);
            this.panel_waiter.TabIndex = 0;
            // 
            // panel_waiterMain
            // 
            this.panel_waiterMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_waiterMain.Controls.Add(this.panel_waiter);
            this.panel_waiterMain.Controls.Add(this.panel3);
            this.panel_waiterMain.Location = new System.Drawing.Point(0, 0);
            this.panel_waiterMain.Name = "panel_waiterMain";
            this.panel_waiterMain.Size = new System.Drawing.Size(357, 287);
            this.panel_waiterMain.TabIndex = 8;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.label6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(355, 32);
            this.panel3.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(78, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Авторизованные официанты";
            // 
            // button_sumWaiterBack
            // 
            this.button_sumWaiterBack.Location = new System.Drawing.Point(3, 3);
            this.button_sumWaiterBack.Name = "button_sumWaiterBack";
            this.button_sumWaiterBack.Size = new System.Drawing.Size(26, 26);
            this.button_sumWaiterBack.TabIndex = 1;
            this.button_sumWaiterBack.UseVisualStyleBackColor = true;
            this.button_sumWaiterBack.Click += new System.EventHandler(this.button_sumWaiterBack_Click);
            // 
            // panel_logIn
            // 
            this.panel_logIn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_logIn.Controls.Add(this.panel_image);
            this.panel_logIn.Controls.Add(this.panel4);
            this.panel_logIn.Location = new System.Drawing.Point(363, 0);
            this.panel_logIn.Name = "panel_logIn";
            this.panel_logIn.Size = new System.Drawing.Size(357, 287);
            this.panel_logIn.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(355, 32);
            this.panel4.TabIndex = 7;
            // 
            // panel_image
            // 
            this.panel_image.BackColor = System.Drawing.Color.White;
            this.panel_image.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel_image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_image.Location = new System.Drawing.Point(0, 32);
            this.panel_image.Name = "panel_image";
            this.panel_image.Size = new System.Drawing.Size(355, 253);
            this.panel_image.TabIndex = 8;
            // 
            // fCloseSeason_Waiter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 309);
            this.ControlBox = false;
            this.Controls.Add(this.panel_logIn);
            this.Controls.Add(this.panel_waiterSum);
            this.Controls.Add(this.panel_waiterMain);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.Name = "fCloseSeason_Waiter";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Закрытие смены официанта";
            this.Shown += new System.EventHandler(this.fCloseSeason_Waiter_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fCloseSeason_Waiter_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel_waiterSum.ResumeLayout(false);
            this.panel_waiterSum.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_sum)).EndInit();
            this.panel_waiterMain.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel_logIn.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tSStatusLabel_whoOpen;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tSStatusLabel_whenOpen;
        private System.Windows.Forms.Panel panel_waiterSum;
        private System.Windows.Forms.FlowLayoutPanel panel_waiter;
        private System.Windows.Forms.Label label_difference;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_sum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numeric_sum;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel_waiterMain;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_sumWaiterBack;
        private System.Windows.Forms.Panel panel_logIn;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel_image;
    }
}