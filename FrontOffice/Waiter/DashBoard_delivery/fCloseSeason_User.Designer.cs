namespace com.sbs.gui.dashboard
{
    partial class fCloseSeason_User
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
            this.panel_top = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label_season = new System.Windows.Forms.Label();
            this.label_seasonFIO = new System.Windows.Forms.Label();
            this.label_seasonPeriod = new System.Windows.Forms.Label();
            this.panel_front = new System.Windows.Forms.Panel();
            this.numericUpDown_diff = new System.Windows.Forms.NumericUpDown();
            this.label_diff = new System.Windows.Forms.Label();
            this.numericUpDown_curr = new System.Windows.Forms.NumericUpDown();
            this.label_summ = new System.Windows.Forms.Label();
            this.label_sumSeason = new System.Windows.Forms.Label();
            this.numericUpDown_season = new System.Windows.Forms.NumericUpDown();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.button_closeSeason = new System.Windows.Forms.Button();
            this.flowLayoutPanel_bills = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_top.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel_front.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_diff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_curr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_season)).BeginInit();
            this.panel_bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel_top, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel_front, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel_bottom, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(803, 464);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel_top
            // 
            this.panel_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(45)))), ((int)(((byte)(36)))));
            this.panel_top.Controls.Add(this.tableLayoutPanel2);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_top.Location = new System.Drawing.Point(3, 3);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(797, 84);
            this.panel_top.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label_season, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_seasonFIO, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label_seasonPeriod, 0, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(797, 84);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label_season
            // 
            this.label_season.AutoSize = true;
            this.label_season.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_season.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_season.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(220)))), ((int)(((byte)(0)))));
            this.label_season.Location = new System.Drawing.Point(3, 0);
            this.label_season.Name = "label_season";
            this.label_season.Size = new System.Drawing.Size(791, 28);
            this.label_season.TabIndex = 0;
            this.label_season.Text = "Закрытие индивидуальной смены №";
            this.label_season.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_seasonFIO
            // 
            this.label_seasonFIO.AutoSize = true;
            this.label_seasonFIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_seasonFIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_seasonFIO.ForeColor = System.Drawing.Color.White;
            this.label_seasonFIO.Location = new System.Drawing.Point(3, 28);
            this.label_seasonFIO.Name = "label_seasonFIO";
            this.label_seasonFIO.Size = new System.Drawing.Size(791, 28);
            this.label_seasonFIO.TabIndex = 1;
            this.label_seasonFIO.Text = "label_seasonFIO";
            this.label_seasonFIO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_seasonPeriod
            // 
            this.label_seasonPeriod.AutoSize = true;
            this.label_seasonPeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_seasonPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_seasonPeriod.ForeColor = System.Drawing.Color.White;
            this.label_seasonPeriod.Location = new System.Drawing.Point(3, 56);
            this.label_seasonPeriod.Name = "label_seasonPeriod";
            this.label_seasonPeriod.Size = new System.Drawing.Size(791, 28);
            this.label_seasonPeriod.TabIndex = 2;
            this.label_seasonPeriod.Text = "label_seasonPeriod";
            this.label_seasonPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_front
            // 
            this.panel_front.Controls.Add(this.flowLayoutPanel_bills);
            this.panel_front.Controls.Add(this.numericUpDown_diff);
            this.panel_front.Controls.Add(this.label_diff);
            this.panel_front.Controls.Add(this.numericUpDown_curr);
            this.panel_front.Controls.Add(this.label_summ);
            this.panel_front.Controls.Add(this.label_sumSeason);
            this.panel_front.Controls.Add(this.numericUpDown_season);
            this.panel_front.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_front.Location = new System.Drawing.Point(3, 93);
            this.panel_front.Name = "panel_front";
            this.panel_front.Size = new System.Drawing.Size(797, 314);
            this.panel_front.TabIndex = 0;
            // 
            // numericUpDown_diff
            // 
            this.numericUpDown_diff.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.numericUpDown_diff.DecimalPlaces = 2;
            this.numericUpDown_diff.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown_diff.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDown_diff.Location = new System.Drawing.Point(629, 147);
            this.numericUpDown_diff.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.numericUpDown_diff.Minimum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            -2147483648});
            this.numericUpDown_diff.Name = "numericUpDown_diff";
            this.numericUpDown_diff.ReadOnly = true;
            this.numericUpDown_diff.Size = new System.Drawing.Size(161, 29);
            this.numericUpDown_diff.TabIndex = 5;
            this.numericUpDown_diff.TabStop = false;
            this.numericUpDown_diff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_diff.ThousandsSeparator = true;
            // 
            // label_diff
            // 
            this.label_diff.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_diff.AutoSize = true;
            this.label_diff.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_diff.Location = new System.Drawing.Point(480, 152);
            this.label_diff.Name = "label_diff";
            this.label_diff.Size = new System.Drawing.Size(72, 20);
            this.label_diff.TabIndex = 4;
            this.label_diff.Text = "Разница";
            // 
            // numericUpDown_curr
            // 
            this.numericUpDown_curr.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.numericUpDown_curr.DecimalPlaces = 2;
            this.numericUpDown_curr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown_curr.Location = new System.Drawing.Point(629, 110);
            this.numericUpDown_curr.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.numericUpDown_curr.Name = "numericUpDown_curr";
            this.numericUpDown_curr.Size = new System.Drawing.Size(161, 29);
            this.numericUpDown_curr.TabIndex = 2;
            this.numericUpDown_curr.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_curr.ThousandsSeparator = true;
            this.numericUpDown_curr.Enter += new System.EventHandler(this.numericUpDown_curr_Enter);
            this.numericUpDown_curr.Leave += new System.EventHandler(this.numericUpDown_curr_Leave);
            // 
            // label_summ
            // 
            this.label_summ.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_summ.AutoSize = true;
            this.label_summ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_summ.Location = new System.Drawing.Point(480, 115);
            this.label_summ.Name = "label_summ";
            this.label_summ.Size = new System.Drawing.Size(146, 20);
            this.label_summ.TabIndex = 2;
            this.label_summ.Text = "Сдаваемая сумма";
            // 
            // label_sumSeason
            // 
            this.label_sumSeason.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_sumSeason.AutoSize = true;
            this.label_sumSeason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_sumSeason.Location = new System.Drawing.Point(480, 79);
            this.label_sumSeason.Name = "label_sumSeason";
            this.label_sumSeason.Size = new System.Drawing.Size(127, 20);
            this.label_sumSeason.TabIndex = 1;
            this.label_sumSeason.Text = "Сумма за смену";
            // 
            // numericUpDown_season
            // 
            this.numericUpDown_season.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.numericUpDown_season.DecimalPlaces = 2;
            this.numericUpDown_season.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown_season.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.numericUpDown_season.Location = new System.Drawing.Point(629, 74);
            this.numericUpDown_season.Maximum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            0});
            this.numericUpDown_season.Minimum = new decimal(new int[] {
            -1981284353,
            -1966660860,
            0,
            -2147483648});
            this.numericUpDown_season.Name = "numericUpDown_season";
            this.numericUpDown_season.ReadOnly = true;
            this.numericUpDown_season.Size = new System.Drawing.Size(161, 29);
            this.numericUpDown_season.TabIndex = 0;
            this.numericUpDown_season.TabStop = false;
            this.numericUpDown_season.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_season.ThousandsSeparator = true;
            // 
            // panel_bottom
            // 
            this.panel_bottom.Controls.Add(this.button_closeSeason);
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_bottom.Location = new System.Drawing.Point(3, 413);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Padding = new System.Windows.Forms.Padding(8);
            this.panel_bottom.Size = new System.Drawing.Size(797, 48);
            this.panel_bottom.TabIndex = 1;
            // 
            // button_closeSeason
            // 
            this.button_closeSeason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_closeSeason.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_closeSeason.Location = new System.Drawing.Point(8, 8);
            this.button_closeSeason.Name = "button_closeSeason";
            this.button_closeSeason.Size = new System.Drawing.Size(781, 32);
            this.button_closeSeason.TabIndex = 0;
            this.button_closeSeason.Text = "Закрыть смену";
            this.button_closeSeason.UseVisualStyleBackColor = true;
            this.button_closeSeason.Click += new System.EventHandler(this.button_closeSeason_Click);
            // 
            // flowLayoutPanel_bills
            // 
            this.flowLayoutPanel_bills.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel_bills.AutoScroll = true;
            this.flowLayoutPanel_bills.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel_bills.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel_bills.Name = "flowLayoutPanel_bills";
            this.flowLayoutPanel_bills.Size = new System.Drawing.Size(477, 314);
            this.flowLayoutPanel_bills.TabIndex = 1;
            // 
            // fCloseSeason_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 464);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "fCloseSeason_User";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fCloseSeason_User_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel_top.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel_front.ResumeLayout(false);
            this.panel_front.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_diff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_curr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_season)).EndInit();
            this.panel_bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label_season;
        private System.Windows.Forms.Label label_seasonFIO;
        private System.Windows.Forms.Label label_seasonPeriod;
        private System.Windows.Forms.Panel panel_front;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.Button button_closeSeason;
        private System.Windows.Forms.NumericUpDown numericUpDown_diff;
        private System.Windows.Forms.Label label_diff;
        private System.Windows.Forms.NumericUpDown numericUpDown_curr;
        private System.Windows.Forms.Label label_summ;
        private System.Windows.Forms.Label label_sumSeason;
        private System.Windows.Forms.NumericUpDown numericUpDown_season;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_bills;
    }
}