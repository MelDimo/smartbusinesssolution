namespace com.sbs.gui.seasonbrowser
{
    partial class fXOrderViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fXOrderViewer));
            this.textBox_report = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSButton_print = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tSSLabel_printerName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_report
            // 
            this.textBox_report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_report.Location = new System.Drawing.Point(0, 25);
            this.textBox_report.Multiline = true;
            this.textBox_report.Name = "textBox_report";
            this.textBox_report.ReadOnly = true;
            this.textBox_report.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_report.Size = new System.Drawing.Size(386, 471);
            this.textBox_report.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSButton_print});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(386, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSButton_print
            // 
            this.tSButton_print.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_print.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_print.Image")));
            this.tSButton_print.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_print.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_print.Name = "tSButton_print";
            this.tSButton_print.Size = new System.Drawing.Size(23, 22);
            this.tSButton_print.ToolTipText = "Печать";
            this.tSButton_print.Click += new System.EventHandler(this.tSButton_print_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSLabel_printerName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 496);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(386, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tSSLabel_printerName
            // 
            this.tSSLabel_printerName.Name = "tSSLabel_printerName";
            this.tSSLabel_printerName.Size = new System.Drawing.Size(123, 17);
            this.tSSLabel_printerName.Text = "tSSLabel_printerName";
            // 
            // fXOrderViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(386, 518);
            this.Controls.Add(this.textBox_report);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fXOrderViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fXOrderViewer";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_report;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tSButton_print;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabel_printerName;
    }
}