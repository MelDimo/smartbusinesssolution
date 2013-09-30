namespace DashBoard
{
    partial class fMain
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_bill = new System.Windows.Forms.TabPage();
            this.tabPage_dish = new System.Windows.Forms.TabPage();
            this.panel_path = new System.Windows.Forms.Panel();
            this.label_path = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.panel_path.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 508);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(829, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl_main);
            this.splitContainer1.Panel1.Controls.Add(this.panel_path);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(829, 508);
            this.splitContainer1.SplitterDistance = 474;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.splitContainer2.Size = new System.Drawing.Size(351, 508);
            this.splitContainer2.SplitterDistance = 116;
            this.splitContainer2.TabIndex = 0;
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_bill);
            this.tabControl_main.Controls.Add(this.tabPage_dish);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 33);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(474, 475);
            this.tabControl_main.TabIndex = 0;
            // 
            // tabPage_bill
            // 
            this.tabPage_bill.Location = new System.Drawing.Point(4, 22);
            this.tabPage_bill.Name = "tabPage_bill";
            this.tabPage_bill.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_bill.Size = new System.Drawing.Size(466, 449);
            this.tabPage_bill.TabIndex = 0;
            this.tabPage_bill.Text = "tabPage_bill";
            // 
            // tabPage_dish
            // 
            this.tabPage_dish.Location = new System.Drawing.Point(4, 22);
            this.tabPage_dish.Name = "tabPage_dish";
            this.tabPage_dish.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_dish.Size = new System.Drawing.Size(466, 449);
            this.tabPage_dish.TabIndex = 1;
            this.tabPage_dish.Text = "tabPage_dish";
            // 
            // panel_path
            // 
            this.panel_path.Controls.Add(this.label_path);
            this.panel_path.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_path.Location = new System.Drawing.Point(0, 0);
            this.panel_path.Name = "panel_path";
            this.panel_path.Size = new System.Drawing.Size(474, 33);
            this.panel_path.TabIndex = 1;
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.Location = new System.Drawing.Point(12, 9);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(35, 13);
            this.label_path.TabIndex = 0;
            this.label_path.Text = "label1";
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 530);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fMain";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tabControl_main.ResumeLayout(false);
            this.panel_path.ResumeLayout(false);
            this.panel_path.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel_path;
        private System.Windows.Forms.Label label_path;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_bill;
        private System.Windows.Forms.TabPage tabPage_dish;
    }
}

