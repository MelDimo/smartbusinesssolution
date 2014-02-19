namespace com.sbs.gui.dashboard
{
    partial class fCloseSeason_Branch
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
            this.panel_front = new System.Windows.Forms.Panel();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.button_closeSeason = new System.Windows.Forms.Button();
            this.flowLayoutPanel_seasonPerson = new System.Windows.Forms.FlowLayoutPanel();
            this.label_seasonPeriod = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_top.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel_front.SuspendLayout();
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(633, 458);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel_top
            // 
            this.panel_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(45)))), ((int)(((byte)(36)))));
            this.panel_top.Controls.Add(this.tableLayoutPanel2);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_top.Location = new System.Drawing.Point(3, 3);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(627, 84);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(627, 84);
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
            this.label_season.Size = new System.Drawing.Size(621, 27);
            this.label_season.TabIndex = 0;
            this.label_season.Text = "Закрытие смены №";
            this.label_season.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_seasonFIO
            // 
            this.label_seasonFIO.AutoSize = true;
            this.label_seasonFIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_seasonFIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_seasonFIO.ForeColor = System.Drawing.Color.White;
            this.label_seasonFIO.Location = new System.Drawing.Point(3, 27);
            this.label_seasonFIO.Name = "label_seasonFIO";
            this.label_seasonFIO.Size = new System.Drawing.Size(621, 27);
            this.label_seasonFIO.TabIndex = 1;
            this.label_seasonFIO.Text = "label_seasonFIO";
            this.label_seasonFIO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel_front
            // 
            this.panel_front.Controls.Add(this.flowLayoutPanel_seasonPerson);
            this.panel_front.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_front.Location = new System.Drawing.Point(3, 93);
            this.panel_front.Name = "panel_front";
            this.panel_front.Size = new System.Drawing.Size(627, 308);
            this.panel_front.TabIndex = 1;
            // 
            // panel_bottom
            // 
            this.panel_bottom.Controls.Add(this.button_closeSeason);
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_bottom.Location = new System.Drawing.Point(3, 407);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Padding = new System.Windows.Forms.Padding(8);
            this.panel_bottom.Size = new System.Drawing.Size(627, 48);
            this.panel_bottom.TabIndex = 2;
            // 
            // button_closeSeason
            // 
            this.button_closeSeason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_closeSeason.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_closeSeason.Location = new System.Drawing.Point(8, 8);
            this.button_closeSeason.Name = "button_closeSeason";
            this.button_closeSeason.Size = new System.Drawing.Size(611, 32);
            this.button_closeSeason.TabIndex = 0;
            this.button_closeSeason.Text = "Закрыть смену";
            this.button_closeSeason.UseVisualStyleBackColor = true;
            this.button_closeSeason.Click += new System.EventHandler(this.button_closeSeason_Click);
            // 
            // flowLayoutPanel_seasonPerson
            // 
            this.flowLayoutPanel_seasonPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_seasonPerson.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel_seasonPerson.Name = "flowLayoutPanel_seasonPerson";
            this.flowLayoutPanel_seasonPerson.Size = new System.Drawing.Size(627, 308);
            this.flowLayoutPanel_seasonPerson.TabIndex = 0;
            // 
            // label_seasonPeriod
            // 
            this.label_seasonPeriod.AutoSize = true;
            this.label_seasonPeriod.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_seasonPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_seasonPeriod.ForeColor = System.Drawing.Color.White;
            this.label_seasonPeriod.Location = new System.Drawing.Point(3, 54);
            this.label_seasonPeriod.Name = "label_seasonPeriod";
            this.label_seasonPeriod.Size = new System.Drawing.Size(621, 30);
            this.label_seasonPeriod.TabIndex = 2;
            this.label_seasonPeriod.Text = "label_seasonPeriod";
            this.label_seasonPeriod.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fCloseSeason_Branch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 458);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "fCloseSeason_Branch";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Shown += new System.EventHandler(this.fCloseSeason_Branch_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fCloseSeason_Branch_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel_top.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel_front.ResumeLayout(false);
            this.panel_bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Panel panel_front;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label_season;
        private System.Windows.Forms.Label label_seasonFIO;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.Button button_closeSeason;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_seasonPerson;
        private System.Windows.Forms.Label label_seasonPeriod;
    }
}