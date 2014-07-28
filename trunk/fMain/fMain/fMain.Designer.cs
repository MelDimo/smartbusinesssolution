namespace com.sbs.gui.main
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
            this.statusStrip_mainBottom = new System.Windows.Forms.StatusStrip();
            this.tSSLabel_info = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSSLabel_mailChecker = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl_top = new System.Windows.Forms.TabControl();
            this.tSSLabel_basetype = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip_mainBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip_mainBottom
            // 
            this.statusStrip_mainBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSLabel_info,
            this.tSSLabel_mailChecker,
            this.tSSLabel_basetype});
            this.statusStrip_mainBottom.Location = new System.Drawing.Point(0, 522);
            this.statusStrip_mainBottom.Name = "statusStrip_mainBottom";
            this.statusStrip_mainBottom.Size = new System.Drawing.Size(829, 22);
            this.statusStrip_mainBottom.TabIndex = 1;
            this.statusStrip_mainBottom.Text = "statusStrip1";
            // 
            // tSSLabel_info
            // 
            this.tSSLabel_info.Name = "tSSLabel_info";
            this.tSSLabel_info.Size = new System.Drawing.Size(680, 17);
            this.tSSLabel_info.Spring = true;
            this.tSSLabel_info.Text = "tSSLabel_info";
            this.tSSLabel_info.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tSSLabel_mailChecker
            // 
            this.tSSLabel_mailChecker.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.tSSLabel_mailChecker.Name = "tSSLabel_mailChecker";
            this.tSSLabel_mailChecker.Size = new System.Drawing.Size(0, 17);
            // 
            // tabControl_top
            // 
            this.tabControl_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl_top.Location = new System.Drawing.Point(0, 0);
            this.tabControl_top.Name = "tabControl_top";
            this.tabControl_top.SelectedIndex = 0;
            this.tabControl_top.Size = new System.Drawing.Size(829, 19);
            this.tabControl_top.TabIndex = 3;
            this.tabControl_top.SelectedIndexChanged += new System.EventHandler(this.tabControl_top_SelectedIndexChanged);
            // 
            // tSSLabel_basetype
            // 
            this.tSSLabel_basetype.Name = "tSSLabel_basetype";
            this.tSSLabel_basetype.Size = new System.Drawing.Size(103, 17);
            this.tSSLabel_basetype.Text = "tSSLabel_basetype";
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 544);
            this.Controls.Add(this.tabControl_top);
            this.Controls.Add(this.statusStrip_mainBottom);
            this.IsMdiContainer = true;
            this.Name = "fMain";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fMain_FormClosed);
            this.Load += new System.EventHandler(this.fMain_Load);
            this.Shown += new System.EventHandler(this.fMain_Shown);
            this.statusStrip_mainBottom.ResumeLayout(false);
            this.statusStrip_mainBottom.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip_mainBottom;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabel_info;
        private System.Windows.Forms.TabControl tabControl_top;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabel_mailChecker;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabel_basetype;
    }
}

