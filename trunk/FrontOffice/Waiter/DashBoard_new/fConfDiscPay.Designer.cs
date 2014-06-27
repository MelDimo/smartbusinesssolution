namespace com.sbs.gui.dashboard
{
    partial class fConfDiscPay
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox_photo = new System.Windows.Forms.PictureBox();
            this.label_fio = new System.Windows.Forms.Label();
            this.label_discount = new System.Windows.Forms.Label();
            this.label_dateExp = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_photo)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(45)))), ((int)(((byte)(36)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox_photo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_fio, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_discount, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_dateExp, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(520, 212);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // pictureBox_photo
            // 
            this.pictureBox_photo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_photo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox_photo.Location = new System.Drawing.Point(3, 3);
            this.pictureBox_photo.Name = "pictureBox_photo";
            this.pictureBox_photo.Size = new System.Drawing.Size(124, 162);
            this.pictureBox_photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_photo.TabIndex = 0;
            this.pictureBox_photo.TabStop = false;
            // 
            // label_fio
            // 
            this.label_fio.AutoSize = true;
            this.label_fio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(45)))), ((int)(((byte)(36)))));
            this.label_fio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_fio.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_fio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(220)))), ((int)(((byte)(0)))));
            this.label_fio.Location = new System.Drawing.Point(133, 0);
            this.label_fio.Name = "label_fio";
            this.label_fio.Size = new System.Drawing.Size(384, 168);
            this.label_fio.TabIndex = 1;
            this.label_fio.Text = "label1";
            this.label_fio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_discount
            // 
            this.label_discount.AutoSize = true;
            this.label_discount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_discount.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_discount.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_discount.Location = new System.Drawing.Point(133, 168);
            this.label_discount.Name = "label_discount";
            this.label_discount.Size = new System.Drawing.Size(384, 44);
            this.label_discount.TabIndex = 2;
            this.label_discount.Text = "label_discount";
            this.label_discount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_dateExp
            // 
            this.label_dateExp.AutoSize = true;
            this.label_dateExp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_dateExp.ForeColor = System.Drawing.Color.White;
            this.label_dateExp.Location = new System.Drawing.Point(3, 168);
            this.label_dateExp.Name = "label_dateExp";
            this.label_dateExp.Size = new System.Drawing.Size(124, 44);
            this.label_dateExp.TabIndex = 3;
            this.label_dateExp.Text = "label1";
            this.label_dateExp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fConfDiscPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 212);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "fConfDiscPay";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Shown += new System.EventHandler(this.fConfDiscPay_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fConfDiscPay_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_photo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox_photo;
        private System.Windows.Forms.Label label_fio;
        private System.Windows.Forms.Label label_discount;
        private System.Windows.Forms.Label label_dateExp;

    }
}