namespace com.sbs.dll.utilites
{
    partial class ctrDishesRefuse
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
            this.label_name = new System.Windows.Forms.Label();
            this.label_count = new System.Windows.Forms.Label();
            this.label_price = new System.Windows.Forms.Label();
            this.label_dateRefuseAdd = new System.Windows.Forms.Label();
            this.label_userRefuse = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_host
            // 
            this.button_host.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_host.Location = new System.Drawing.Point(0, 0);
            this.button_host.Name = "button_host";
            this.button_host.Size = new System.Drawing.Size(358, 49);
            this.button_host.TabIndex = 0;
            this.button_host.TabStop = false;
            this.button_host.UseVisualStyleBackColor = false;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name.Location = new System.Drawing.Point(4, 4);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(81, 17);
            this.label_name.TabIndex = 1;
            this.label_name.Text = "label_name";
            // 
            // label_count
            // 
            this.label_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_count.AutoSize = true;
            this.label_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_count.Location = new System.Drawing.Point(274, 4);
            this.label_count.Name = "label_count";
            this.label_count.Size = new System.Drawing.Size(81, 17);
            this.label_count.TabIndex = 2;
            this.label_count.Text = "label_count";
            // 
            // label_price
            // 
            this.label_price.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_price.AutoSize = true;
            this.label_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_price.Location = new System.Drawing.Point(274, 24);
            this.label_price.Name = "label_price";
            this.label_price.Size = new System.Drawing.Size(77, 17);
            this.label_price.TabIndex = 3;
            this.label_price.Text = "label_price";
            // 
            // label_dateRefuseAdd
            // 
            this.label_dateRefuseAdd.AutoSize = true;
            this.label_dateRefuseAdd.Location = new System.Drawing.Point(4, 28);
            this.label_dateRefuseAdd.Name = "label_dateRefuseAdd";
            this.label_dateRefuseAdd.Size = new System.Drawing.Size(109, 13);
            this.label_dateRefuseAdd.TabIndex = 4;
            this.label_dateRefuseAdd.Text = "label_dateRefuseAdd";
            // 
            // label_userRefuse
            // 
            this.label_userRefuse.AutoSize = true;
            this.label_userRefuse.Location = new System.Drawing.Point(119, 28);
            this.label_userRefuse.Name = "label_userRefuse";
            this.label_userRefuse.Size = new System.Drawing.Size(89, 13);
            this.label_userRefuse.TabIndex = 5;
            this.label_userRefuse.Text = "label_userRefuse";
            // 
            // ctrDishesRefuse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_userRefuse);
            this.Controls.Add(this.label_dateRefuseAdd);
            this.Controls.Add(this.label_price);
            this.Controls.Add(this.label_count);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.button_host);
            this.Name = "ctrDishesRefuse";
            this.Size = new System.Drawing.Size(358, 49);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button button_host;
        public System.Windows.Forms.Label label_name;
        public System.Windows.Forms.Label label_count;
        public System.Windows.Forms.Label label_price;
        public System.Windows.Forms.Label label_dateRefuseAdd;
        public System.Windows.Forms.Label label_userRefuse;

    }
}
