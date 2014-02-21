namespace com.sbs.gui.dashboard
{
    partial class fRefuse
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
            this.trackBar_count = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_info = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_count)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBar_count
            // 
            this.trackBar_count.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackBar_count.Location = new System.Drawing.Point(3, 16);
            this.trackBar_count.Name = "trackBar_count";
            this.trackBar_count.Size = new System.Drawing.Size(290, 51);
            this.trackBar_count.TabIndex = 0;
            this.trackBar_count.Scroll += new System.EventHandler(this.trackBar_count_Scroll);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_info);
            this.groupBox1.Controls.Add(this.trackBar_count);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(296, 70);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Новое количество:";
            // 
            // label_info
            // 
            this.label_info.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label_info.AutoSize = true;
            this.label_info.Location = new System.Drawing.Point(131, 53);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(52, 13);
            this.label_info.TabIndex = 1;
            this.label_info.Text = "label_info";
            // 
            // fRefuse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 70);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "fRefuse";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Shown += new System.EventHandler(this.fRefuse_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fRefuse_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_count)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_info;
        public System.Windows.Forms.TrackBar trackBar_count;
    }
}