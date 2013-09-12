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
            this.SuspendLayout();
            // 
            // statusStrip_mainBottom
            // 
            this.statusStrip_mainBottom.Location = new System.Drawing.Point(0, 413);
            this.statusStrip_mainBottom.Name = "statusStrip_mainBottom";
            this.statusStrip_mainBottom.Size = new System.Drawing.Size(732, 22);
            this.statusStrip_mainBottom.TabIndex = 1;
            this.statusStrip_mainBottom.Text = "statusStrip1";
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 435);
            this.Controls.Add(this.statusStrip_mainBottom);
            this.IsMdiContainer = true;
            this.Name = "fMain";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip_mainBottom;
    }
}

