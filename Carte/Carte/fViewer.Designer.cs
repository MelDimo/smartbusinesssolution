namespace com.sbs.gui.carte
{
    partial class fViewer
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
            this.crystalReportViewer_main = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReportViewer_main
            // 
            this.crystalReportViewer_main.ActiveViewIndex = -1;
            this.crystalReportViewer_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer_main.CachedPageNumberPerDoc = 10;
            this.crystalReportViewer_main.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer_main.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer_main.Name = "crystalReportViewer_main";
            this.crystalReportViewer_main.Size = new System.Drawing.Size(819, 434);
            this.crystalReportViewer_main.TabIndex = 0;
            // 
            // fViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 434);
            this.Controls.Add(this.crystalReportViewer_main);
            this.Name = "fViewer";
            this.Text = "Отчет";
            this.ResumeLayout(false);

        }

        #endregion

        internal CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer_main;

    }
}