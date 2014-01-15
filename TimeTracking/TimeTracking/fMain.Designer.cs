namespace com.sbs.gui.timetracking
{
    partial class fMain
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label_fio = new System.Windows.Forms.Label();
            this.label_tabn = new System.Windows.Forms.Label();
            this.button_in = new System.Windows.Forms.Button();
            this.button_out = new System.Windows.Forms.Button();
            this.label_dateIN = new System.Windows.Forms.Label();
            this.label_dateOUT = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.button_in, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_out, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_dateIN, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_dateOUT, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 92);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(718, 162);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label_fio, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_tabn, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 14F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(718, 92);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label_fio
            // 
            this.label_fio.AutoSize = true;
            this.label_fio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_fio.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_fio.ForeColor = System.Drawing.Color.Blue;
            this.label_fio.Location = new System.Drawing.Point(3, 0);
            this.label_fio.Name = "label_fio";
            this.label_fio.Size = new System.Drawing.Size(712, 58);
            this.label_fio.TabIndex = 0;
            this.label_fio.Text = "label_fio";
            this.label_fio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_tabn
            // 
            this.label_tabn.AutoSize = true;
            this.label_tabn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_tabn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_tabn.Location = new System.Drawing.Point(3, 58);
            this.label_tabn.Name = "label_tabn";
            this.label_tabn.Size = new System.Drawing.Size(712, 34);
            this.label_tabn.TabIndex = 1;
            this.label_tabn.Text = "label_tabn";
            this.label_tabn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_in
            // 
            this.button_in.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_in.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_in.Location = new System.Drawing.Point(3, 84);
            this.button_in.Name = "button_in";
            this.button_in.Size = new System.Drawing.Size(353, 75);
            this.button_in.TabIndex = 0;
            this.button_in.Text = "Приход";
            this.button_in.UseVisualStyleBackColor = true;
            this.button_in.Click += new System.EventHandler(this.button_in_Click);
            // 
            // button_out
            // 
            this.button_out.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_out.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_out.Location = new System.Drawing.Point(362, 84);
            this.button_out.Name = "button_out";
            this.button_out.Size = new System.Drawing.Size(353, 75);
            this.button_out.TabIndex = 1;
            this.button_out.Text = "Уход";
            this.button_out.UseVisualStyleBackColor = true;
            this.button_out.Click += new System.EventHandler(this.button_out_Click);
            // 
            // label_dateIN
            // 
            this.label_dateIN.AutoSize = true;
            this.label_dateIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_dateIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_dateIN.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label_dateIN.Location = new System.Drawing.Point(3, 0);
            this.label_dateIN.Name = "label_dateIN";
            this.label_dateIN.Size = new System.Drawing.Size(353, 81);
            this.label_dateIN.TabIndex = 2;
            this.label_dateIN.Text = "label_dateIN";
            this.label_dateIN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_dateOUT
            // 
            this.label_dateOUT.AutoSize = true;
            this.label_dateOUT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_dateOUT.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_dateOUT.ForeColor = System.Drawing.Color.Red;
            this.label_dateOUT.Location = new System.Drawing.Point(362, 0);
            this.label_dateOUT.Name = "label_dateOUT";
            this.label_dateOUT.Size = new System.Drawing.Size(353, 81);
            this.label_dateOUT.TabIndex = 3;
            this.label_dateOUT.Text = "label_dateOUT";
            this.label_dateOUT.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 254);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel2);
            this.KeyPreview = true;
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Регистрация прихода/ухода сотрудника";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fMain_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_in;
        private System.Windows.Forms.Button button_out;
        private System.Windows.Forms.Label label_dateIN;
        private System.Windows.Forms.Label label_dateOUT;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label_fio;
        private System.Windows.Forms.Label label_tabn;
    }
}

