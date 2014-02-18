namespace com.sbs.gui.dashboard
{
    partial class fCloseSeason
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
            this.panel_front = new System.Windows.Forms.Panel();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.button_closeSeason = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel_top, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel_front, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel_bottom, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.33251F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.6675F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(633, 458);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel_top
            // 
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_top.Location = new System.Drawing.Point(3, 3);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(627, 84);
            this.panel_top.TabIndex = 0;
            // 
            // panel_front
            // 
            this.panel_front.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_front.Location = new System.Drawing.Point(3, 93);
            this.panel_front.Name = "panel_front";
            this.panel_front.Size = new System.Drawing.Size(627, 307);
            this.panel_front.TabIndex = 1;
            // 
            // panel_bottom
            // 
            this.panel_bottom.Controls.Add(this.button_closeSeason);
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_bottom.Location = new System.Drawing.Point(3, 406);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Padding = new System.Windows.Forms.Padding(8);
            this.panel_bottom.Size = new System.Drawing.Size(627, 49);
            this.panel_bottom.TabIndex = 2;
            // 
            // button_closeSeason
            // 
            this.button_closeSeason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_closeSeason.Location = new System.Drawing.Point(8, 8);
            this.button_closeSeason.Name = "button_closeSeason";
            this.button_closeSeason.Size = new System.Drawing.Size(611, 33);
            this.button_closeSeason.TabIndex = 0;
            this.button_closeSeason.Text = "Закрыть смену";
            this.button_closeSeason.UseVisualStyleBackColor = true;
            // 
            // fCloseSeason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 458);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "fCloseSeason";
            this.Text = "fCloseSeason";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel_bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.Panel panel_front;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.Button button_closeSeason;
    }
}