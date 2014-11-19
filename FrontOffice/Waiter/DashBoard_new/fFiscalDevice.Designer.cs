namespace com.sbs.gui.dashboard
{
    partial class fFiscalDevice
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_season = new System.Windows.Forms.Label();
            this.button_Zorder = new System.Windows.Forms.Button();
            this.button_Xorder = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.51648F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.48351F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(380, 182);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(45)))), ((int)(((byte)(36)))));
            this.panel1.Controls.Add(this.label_season);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 54);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_Xorder);
            this.panel2.Controls.Add(this.button_Zorder);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 63);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(374, 116);
            this.panel2.TabIndex = 0;
            // 
            // label_season
            // 
            this.label_season.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_season.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_season.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(220)))), ((int)(((byte)(0)))));
            this.label_season.Location = new System.Drawing.Point(0, 0);
            this.label_season.Name = "label_season";
            this.label_season.Size = new System.Drawing.Size(374, 54);
            this.label_season.TabIndex = 1;
            this.label_season.Text = "Операции с фискальным принтером";
            this.label_season.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_Zorder
            // 
            this.button_Zorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Zorder.ForeColor = System.Drawing.Color.Red;
            this.button_Zorder.Location = new System.Drawing.Point(221, 11);
            this.button_Zorder.Name = "button_Zorder";
            this.button_Zorder.Size = new System.Drawing.Size(107, 94);
            this.button_Zorder.TabIndex = 1;
            this.button_Zorder.Text = "Z отчет";
            this.button_Zorder.UseVisualStyleBackColor = false;
            this.button_Zorder.Click += new System.EventHandler(this.button_Zorder_Click);
            // 
            // button_Xorder
            // 
            this.button_Xorder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Xorder.ForeColor = System.Drawing.Color.Green;
            this.button_Xorder.Location = new System.Drawing.Point(50, 11);
            this.button_Xorder.Name = "button_Xorder";
            this.button_Xorder.Size = new System.Drawing.Size(107, 94);
            this.button_Xorder.TabIndex = 0;
            this.button_Xorder.Text = "X отчет";
            this.button_Xorder.UseVisualStyleBackColor = false;
            this.button_Xorder.Click += new System.EventHandler(this.button_Xorder_Click);
            // 
            // fFiscalDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 182);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.Name = "fFiscalDevice";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fFiscalDevice_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label_season;
        private System.Windows.Forms.Button button_Xorder;
        private System.Windows.Forms.Button button_Zorder;

    }
}