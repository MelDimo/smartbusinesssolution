namespace com.sbs.dll.utilites
{
    partial class ctrSeasonPerson
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
            this.label_fio = new System.Windows.Forms.Label();
            this.label_dateOpenClose = new System.Windows.Forms.Label();
            this.label_curStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_host
            // 
            this.button_host.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_host.Location = new System.Drawing.Point(0, 0);
            this.button_host.Name = "button_host";
            this.button_host.Size = new System.Drawing.Size(444, 61);
            this.button_host.TabIndex = 0;
            this.button_host.UseVisualStyleBackColor = false;
            // 
            // label_fio
            // 
            this.label_fio.AutoSize = true;
            this.label_fio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_fio.Location = new System.Drawing.Point(12, 11);
            this.label_fio.Name = "label_fio";
            this.label_fio.Size = new System.Drawing.Size(70, 17);
            this.label_fio.TabIndex = 1;
            this.label_fio.Text = "label_fio";
            // 
            // label_dateOpenClose
            // 
            this.label_dateOpenClose.AutoSize = true;
            this.label_dateOpenClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_dateOpenClose.Location = new System.Drawing.Point(12, 33);
            this.label_dateOpenClose.Name = "label_dateOpenClose";
            this.label_dateOpenClose.Size = new System.Drawing.Size(144, 17);
            this.label_dateOpenClose.TabIndex = 2;
            this.label_dateOpenClose.Text = "label_dateOpenClose";
            // 
            // label_curStatus
            // 
            this.label_curStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_curStatus.AutoSize = true;
            this.label_curStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_curStatus.Location = new System.Drawing.Point(329, 11);
            this.label_curStatus.Name = "label_curStatus";
            this.label_curStatus.Size = new System.Drawing.Size(106, 17);
            this.label_curStatus.TabIndex = 3;
            this.label_curStatus.Text = "label_curStatus";
            this.label_curStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctrSeasonPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_curStatus);
            this.Controls.Add(this.label_dateOpenClose);
            this.Controls.Add(this.label_fio);
            this.Controls.Add(this.button_host);
            this.Name = "ctrSeasonPerson";
            this.Size = new System.Drawing.Size(444, 61);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button button_host;
        public System.Windows.Forms.Label label_fio;
        public System.Windows.Forms.Label label_dateOpenClose;
        public System.Windows.Forms.Label label_curStatus;

    }
}
