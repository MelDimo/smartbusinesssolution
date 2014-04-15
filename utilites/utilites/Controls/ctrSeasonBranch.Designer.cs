namespace com.sbs.dll.utilites
{
    partial class ctrSeasonBranch
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_host = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label_seasonNumb = new System.Windows.Forms.Label();
            this.label_fio = new System.Windows.Forms.Label();
            this.label_dateOpenClose = new System.Windows.Forms.Label();
            this.label_status = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_host
            // 
            this.button_host.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_host.Location = new System.Drawing.Point(0, 0);
            this.button_host.Name = "button_host";
            this.button_host.Size = new System.Drawing.Size(330, 71);
            this.button_host.TabIndex = 0;
            this.button_host.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Смена№";
            // 
            // label_seasonNumb
            // 
            this.label_seasonNumb.AutoSize = true;
            this.label_seasonNumb.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_seasonNumb.Location = new System.Drawing.Point(71, 8);
            this.label_seasonNumb.Name = "label_seasonNumb";
            this.label_seasonNumb.Size = new System.Drawing.Size(129, 17);
            this.label_seasonNumb.TabIndex = 2;
            this.label_seasonNumb.Text = "label_seasonNumb";
            // 
            // label_fio
            // 
            this.label_fio.AutoSize = true;
            this.label_fio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_fio.Location = new System.Drawing.Point(6, 29);
            this.label_fio.Name = "label_fio";
            this.label_fio.Size = new System.Drawing.Size(61, 17);
            this.label_fio.TabIndex = 3;
            this.label_fio.Text = "label_fio";
            // 
            // label_dateOpenClose
            // 
            this.label_dateOpenClose.AutoSize = true;
            this.label_dateOpenClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_dateOpenClose.Location = new System.Drawing.Point(6, 49);
            this.label_dateOpenClose.Name = "label_dateOpenClose";
            this.label_dateOpenClose.Size = new System.Drawing.Size(144, 17);
            this.label_dateOpenClose.TabIndex = 4;
            this.label_dateOpenClose.Text = "label_dateOpenClose";
            // 
            // label_status
            // 
            this.label_status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_status.AutoSize = true;
            this.label_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_status.Location = new System.Drawing.Point(237, 29);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(84, 17);
            this.label_status.TabIndex = 6;
            this.label_status.Text = "label_status";
            // 
            // ctrSeasonBranch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_status);
            this.Controls.Add(this.label_dateOpenClose);
            this.Controls.Add(this.label_fio);
            this.Controls.Add(this.label_seasonNumb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_host);
            this.Name = "ctrSeasonBranch";
            this.Size = new System.Drawing.Size(330, 71);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button button_host;
        public System.Windows.Forms.Label label_seasonNumb;
        public System.Windows.Forms.Label label_fio;
        public System.Windows.Forms.Label label_dateOpenClose;
        public System.Windows.Forms.Label label_status;
    }
}
