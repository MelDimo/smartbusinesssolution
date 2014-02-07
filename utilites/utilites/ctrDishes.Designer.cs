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
            this.label_measure = new System.Windows.Forms.Label();
            this.label_price = new System.Windows.Forms.Label();
            this.button_topping = new System.Windows.Forms.Button();
            this.button_deals = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name.Location = new System.Drawing.Point(3, 4);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(81, 17);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "label_name";
            // 
            // label_measure
            // 
            this.label_measure.AutoSize = true;
            this.label_measure.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_measure.Location = new System.Drawing.Point(3, 24);
            this.label_measure.Name = "label_measure";
            this.label_measure.Size = new System.Drawing.Size(101, 17);
            this.label_measure.TabIndex = 1;
            this.label_measure.Text = "label_measure";
            // 
            // label_price
            // 
            this.label_price.AutoSize = true;
            this.label_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_price.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label_price.Location = new System.Drawing.Point(367, 24);
            this.label_price.Name = "label_price";
            this.label_price.Size = new System.Drawing.Size(77, 17);
            this.label_price.TabIndex = 2;
            this.label_price.Text = "label_price";
            // 
            // button_topping
            // 
            this.button_topping.Location = new System.Drawing.Point(6, 49);
            this.button_topping.Name = "button_topping";
            this.button_topping.Size = new System.Drawing.Size(145, 23);
            this.button_topping.TabIndex = 3;
            this.button_topping.Text = "Топпинг";
            this.button_topping.UseVisualStyleBackColor = true;
            // 
            // button_deals
            // 
            this.button_deals.Location = new System.Drawing.Point(158, 49);
            this.button_deals.Name = "button_deals";
            this.button_deals.Size = new System.Drawing.Size(138, 23);
            this.button_deals.TabIndex = 4;
            this.button_deals.Text = "Акционные позиции";
            this.button_deals.UseVisualStyleBackColor = true;
            // 
            // ctrDishes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_deals);
            this.Controls.Add(this.button_topping);
            this.Controls.Add(this.label_price);
            this.Controls.Add(this.label_measure);
            this.Controls.Add(this.label_name);
            this.Name = "ctrDishes";
            this.Size = new System.Drawing.Size(447, 75);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_measure;
        private System.Windows.Forms.Label label_price;
        private System.Windows.Forms.Button button_topping;
        private System.Windows.Forms.Button button_deals;
    }
}
