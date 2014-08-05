namespace com.sbs.dll.utilites
{
    partial class fChooserPaymentType
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_select = new System.Windows.Forms.Button();
            this.checkedListBox_paymentType = new System.Windows.Forms.CheckedListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_select);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 419);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(264, 32);
            this.panel1.TabIndex = 5;
            // 
            // button_select
            // 
            this.button_select.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_select.Location = new System.Drawing.Point(0, 0);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(264, 32);
            this.button_select.TabIndex = 0;
            this.button_select.Text = "Выбрать";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // checkedListBox_paymentType
            // 
            this.checkedListBox_paymentType.CheckOnClick = true;
            this.checkedListBox_paymentType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox_paymentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkedListBox_paymentType.FormattingEnabled = true;
            this.checkedListBox_paymentType.Location = new System.Drawing.Point(0, 0);
            this.checkedListBox_paymentType.Name = "checkedListBox_paymentType";
            this.checkedListBox_paymentType.Size = new System.Drawing.Size(264, 419);
            this.checkedListBox_paymentType.TabIndex = 6;
            // 
            // fChooserPaymentType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 451);
            this.Controls.Add(this.checkedListBox_paymentType);
            this.Controls.Add(this.panel1);
            this.Name = "fChooserPaymentType";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Типы оплаты";
            this.Shown += new System.EventHandler(this.fChooserPaymentType_Shown);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.CheckedListBox checkedListBox_paymentType;
    }
}