namespace com.sbs.gui.dashboard
{
    partial class fDishToBill_ACTION
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
            this.button_topping = new System.Windows.Forms.Button();
            this.button_deals = new System.Windows.Forms.Button();
            this.button_refuse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_topping
            // 
            this.button_topping.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_topping.Enabled = false;
            this.button_topping.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_topping.Location = new System.Drawing.Point(0, 30);
            this.button_topping.Name = "button_topping";
            this.button_topping.Size = new System.Drawing.Size(473, 36);
            this.button_topping.TabIndex = 0;
            this.button_topping.Text = "Топпинги";
            this.button_topping.UseVisualStyleBackColor = true;
            // 
            // button_deals
            // 
            this.button_deals.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_deals.Enabled = false;
            this.button_deals.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_deals.Location = new System.Drawing.Point(0, 66);
            this.button_deals.Name = "button_deals";
            this.button_deals.Size = new System.Drawing.Size(473, 36);
            this.button_deals.TabIndex = 1;
            this.button_deals.Text = "Акционные позиции";
            this.button_deals.UseVisualStyleBackColor = true;
            // 
            // button_refuse
            // 
            this.button_refuse.Dock = System.Windows.Forms.DockStyle.Top;
            this.button_refuse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_refuse.Location = new System.Drawing.Point(0, 115);
            this.button_refuse.Name = "button_refuse";
            this.button_refuse.Size = new System.Drawing.Size(473, 36);
            this.button_refuse.TabIndex = 2;
            this.button_refuse.Text = "Отказ";
            this.button_refuse.UseVisualStyleBackColor = true;
            this.button_refuse.Click += new System.EventHandler(this.button_refuse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 4;
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_name.Location = new System.Drawing.Point(0, 0);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(91, 17);
            this.label_name.TabIndex = 5;
            this.label_name.Text = "label_name";
            // 
            // fDishToBill_ACTION
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 204);
            this.ControlBox = false;
            this.Controls.Add(this.button_refuse);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_deals);
            this.Controls.Add(this.button_topping);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "fDishToBill_ACTION";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fDishToBill_ACTION_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_topping;
        private System.Windows.Forms.Button button_deals;
        private System.Windows.Forms.Button button_refuse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label_name;
    }
}