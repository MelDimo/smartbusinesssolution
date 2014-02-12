namespace com.sbs.dll.utilites
{
    partial class ctrDishesSmall
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
            this.label_name = new System.Windows.Forms.Label();
            this.label_count = new System.Windows.Forms.Label();
            this.label_summa = new System.Windows.Forms.Label();
            this.button_host = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name.Location = new System.Drawing.Point(4, 4);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(81, 17);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "label_name";
            // 
            // label_count
            // 
            this.label_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_count.AutoSize = true;
            this.label_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_count.Location = new System.Drawing.Point(81, 21);
            this.label_count.Name = "label_count";
            this.label_count.Size = new System.Drawing.Size(81, 17);
            this.label_count.TabIndex = 1;
            this.label_count.Text = "label_count";
            this.label_count.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label_summa
            // 
            this.label_summa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_summa.AutoSize = true;
            this.label_summa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_summa.Location = new System.Drawing.Point(168, 21);
            this.label_summa.Name = "label_summa";
            this.label_summa.Size = new System.Drawing.Size(91, 17);
            this.label_summa.TabIndex = 2;
            this.label_summa.Text = "label_summa";
            this.label_summa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_host
            // 
            this.button_host.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_host.Location = new System.Drawing.Point(0, 0);
            this.button_host.Name = "button_host";
            this.button_host.Size = new System.Drawing.Size(262, 46);
            this.button_host.TabIndex = 3;
            this.button_host.UseVisualStyleBackColor = false;
            // 
            // ctrDishesSmall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_summa);
            this.Controls.Add(this.label_count);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.button_host);
            this.Name = "ctrDishesSmall";
            this.Size = new System.Drawing.Size(262, 46);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label_name;
        public System.Windows.Forms.Label label_count;
        public System.Windows.Forms.Label label_summa;
        public System.Windows.Forms.Button button_host;
    }
}
