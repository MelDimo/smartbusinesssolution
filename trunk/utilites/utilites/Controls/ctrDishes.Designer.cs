namespace com.sbs.dll.utilites
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
            this.numericUpDown_count = new System.Windows.Forms.NumericUpDown();
            this.comboBox_note = new System.Windows.Forms.ComboBox();
            this.button_editMnu = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_count)).BeginInit();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name.Location = new System.Drawing.Point(7, 6);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(91, 20);
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
            this.button_topping.TabStop = false;
            this.button_topping.Text = "Топпинги";
            this.button_topping.UseVisualStyleBackColor = true;
            // 
            // button_deals
            // 
            this.button_deals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_deals.Location = new System.Drawing.Point(158, 47);
            this.button_deals.Name = "button_deals";
            this.button_deals.Size = new System.Drawing.Size(138, 23);
            this.button_deals.TabIndex = 2;
            this.button_deals.TabStop = false;
            this.button_deals.Text = "Акционные позиции";
            this.button_deals.UseVisualStyleBackColor = true;
            // 
            // button_host
            // 
            this.button_host.AutoSize = true;
            this.button_host.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_host.Location = new System.Drawing.Point(0, 0);
            this.button_host.Name = "button_host";
            this.button_host.Size = new System.Drawing.Size(447, 75);
            this.button_host.TabIndex = 0;
            this.button_host.UseVisualStyleBackColor = false;
            // 
            // numericUpDown_count
            // 
            this.numericUpDown_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_count.DecimalPlaces = 2;
            this.numericUpDown_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown_count.Location = new System.Drawing.Point(361, 7);
            this.numericUpDown_count.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_count.Name = "numericUpDown_count";
            this.numericUpDown_count.ReadOnly = true;
            this.numericUpDown_count.Size = new System.Drawing.Size(77, 29);
            this.numericUpDown_count.TabIndex = 0;
            this.numericUpDown_count.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_count.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_count_KeyUp);
            // 
            // comboBox_note
            // 
            this.comboBox_note.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_note.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_note.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBox_note.FormattingEnabled = true;
            this.comboBox_note.Location = new System.Drawing.Point(302, 47);
            this.comboBox_note.Name = "comboBox_note";
            this.comboBox_note.Size = new System.Drawing.Size(104, 21);
            this.comboBox_note.TabIndex = 3;
            this.comboBox_note.TabStop = false;
            // 
            // button_editMnu
            // 
            this.button_editMnu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_editMnu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_editMnu.Location = new System.Drawing.Point(412, 39);
            this.button_editMnu.Name = "button_editMnu";
            this.button_editMnu.Size = new System.Drawing.Size(26, 26);
            this.button_editMnu.TabIndex = 10;
            this.button_editMnu.UseVisualStyleBackColor = true;
            this.button_editMnu.Visible = false;
            // 
            // ctrDishes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBox_note);
            this.Controls.Add(this.button_editMnu);
            this.Controls.Add(this.numericUpDown_count);
            this.Controls.Add(this.button_deals);
            this.Controls.Add(this.button_topping);
            this.Controls.Add(this.label_price);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.button_host);
            this.Name = "ctrDishes";
            this.Size = new System.Drawing.Size(447, 75);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_count)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label_name;
        public System.Windows.Forms.Label label_price;
        public System.Windows.Forms.Button button_topping;
        public System.Windows.Forms.Button button_deals;
        public System.Windows.Forms.Button button_host;
        public System.Windows.Forms.NumericUpDown numericUpDown_count;
        public System.Windows.Forms.ComboBox comboBox_note;
        public System.Windows.Forms.Button button_editMnu;

    }
}
