﻿namespace com.sbs.dll.utilites
{
    partial class ctrDishes
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
            this.label_price = new System.Windows.Forms.Label();
            this.button_topping = new System.Windows.Forms.Button();
            this.button_deals = new System.Windows.Forms.Button();
            this.button_host = new System.Windows.Forms.Button();
            this.comboBox_note = new System.Windows.Forms.ComboBox();
            this.button_editMnu = new System.Windows.Forms.Button();
            this.label_count = new System.Windows.Forms.Label();
            this.numericUpDown_count = new com.sbs.dll.utilites.Controls.textBoxNumeric();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name.Location = new System.Drawing.Point(7, 6);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(431, 20);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "label_name";
            // 
            // label_price
            // 
            this.label_price.AutoSize = true;
            this.label_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_price.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_price.Location = new System.Drawing.Point(7, 25);
            this.label_price.Name = "label_price";
            this.label_price.Size = new System.Drawing.Size(88, 17);
            this.label_price.TabIndex = 2;
            this.label_price.Text = "label_price";
            this.label_price.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_topping
            // 
            this.button_topping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_topping.Location = new System.Drawing.Point(6, 47);
            this.button_topping.Name = "button_topping";
            this.button_topping.Size = new System.Drawing.Size(145, 23);
            this.button_topping.TabIndex = 1;
            this.button_topping.Text = "Топпинги";
            this.button_topping.UseVisualStyleBackColor = false;
            this.button_topping.Click += new System.EventHandler(this.button_topping_Click);
            // 
            // button_deals
            // 
            this.button_deals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_deals.Location = new System.Drawing.Point(158, 47);
            this.button_deals.Name = "button_deals";
            this.button_deals.Size = new System.Drawing.Size(138, 23);
            this.button_deals.TabIndex = 2;
            this.button_deals.Text = "Акционные позиции";
            this.button_deals.UseVisualStyleBackColor = false;
            // 
            // button_host
            // 
            this.button_host.AutoSize = true;
            this.button_host.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_host.Location = new System.Drawing.Point(0, 0);
            this.button_host.Name = "button_host";
            this.button_host.Size = new System.Drawing.Size(447, 75);
            this.button_host.TabIndex = 0;
            this.button_host.TabStop = false;
            this.button_host.UseVisualStyleBackColor = false;
            // 
            // comboBox_note
            // 
            this.comboBox_note.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_note.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_note.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox_note.Location = new System.Drawing.Point(302, 47);
            this.comboBox_note.Name = "comboBox_note";
            this.comboBox_note.Size = new System.Drawing.Size(104, 21);
            this.comboBox_note.TabIndex = 3;
            // 
            // button_editMnu
            // 
            this.button_editMnu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_editMnu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_editMnu.Location = new System.Drawing.Point(412, 39);
            this.button_editMnu.Name = "button_editMnu";
            this.button_editMnu.Size = new System.Drawing.Size(26, 26);
            this.button_editMnu.TabIndex = 10;
            this.button_editMnu.UseVisualStyleBackColor = false;
            this.button_editMnu.Visible = false;
            // 
            // label_count
            // 
            this.label_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_count.Location = new System.Drawing.Point(361, 4);
            this.label_count.Name = "label_count";
            this.label_count.Size = new System.Drawing.Size(77, 32);
            this.label_count.TabIndex = 0;
            this.label_count.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDown_count
            // 
            this.numericUpDown_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_count.AutoSize = true;
            this.numericUpDown_count.Location = new System.Drawing.Point(361, 6);
            this.numericUpDown_count.Name = "numericUpDown_count";
            this.numericUpDown_count.Size = new System.Drawing.Size(77, 26);
            this.numericUpDown_count.TabIndex = 0;
            // 
            // ctrDishes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDown_count);
            this.Controls.Add(this.label_count);
            this.Controls.Add(this.comboBox_note);
            this.Controls.Add(this.button_editMnu);
            this.Controls.Add(this.button_deals);
            this.Controls.Add(this.button_topping);
            this.Controls.Add(this.label_price);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.button_host);
            this.Name = "ctrDishes";
            this.Size = new System.Drawing.Size(447, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label_name;
        public System.Windows.Forms.Label label_price;
        public System.Windows.Forms.Button button_topping;
        public System.Windows.Forms.Button button_deals;
        public System.Windows.Forms.Button button_host;
        public System.Windows.Forms.Button button_editMnu;
        public System.Windows.Forms.ComboBox comboBox_note;
        public System.Windows.Forms.Label label_count;
        public Controls.textBoxNumeric numericUpDown_count;

    }
}
