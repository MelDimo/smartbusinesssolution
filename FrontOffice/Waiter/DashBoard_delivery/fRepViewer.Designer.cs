namespace com.sbs.gui.dashboard
{
    partial class fRepViewer
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
            this.crystalReportViewer_main.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer_main.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer_main.Name = "crystalReportViewer_main";
            this.crystalReportViewer_main.ShowExportButton = false;
            this.crystalReportViewer_main.ShowGotoPageButton = false;
            this.crystalReportViewer_main.ShowGroupTreeButton = false;
            this.crystalReportViewer_main.ShowParameterPanelButton = false;
            this.crystalReportViewer_main.ShowTextSearchButton = false;
            this.crystalReportViewer_main.Size = new System.Drawing.Size(582, 574);
            this.crystalReportViewer_main.TabIndex = 0;
            this.crystalReportViewer_main.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // fRepViwer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 574);
            this.Controls.Add(this.crystalReportViewer_main);
            this.Name = "fRepViwer";
            this.Text = "fRepViwer";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer_main;


    }
}