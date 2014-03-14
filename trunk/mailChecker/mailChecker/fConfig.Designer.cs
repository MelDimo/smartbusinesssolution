namespace com.sbs.dll.mailChecker
{
    partial class fConfig
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
            this.comboBox_melody = new System.Windows.Forms.ComboBox();
            this.button_play = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_maxMail = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_chkSec = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_maxMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_chkSec)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_melody
            // 
            this.comboBox_melody.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_melody.FormattingEnabled = true;
            this.comboBox_melody.Location = new System.Drawing.Point(142, 12);
            this.comboBox_melody.Name = "comboBox_melody";
            this.comboBox_melody.Size = new System.Drawing.Size(192, 21);
            this.comboBox_melody.TabIndex = 7;
            this.comboBox_melody.SelectionChangeCommitted += new System.EventHandler(this.comboBox_melody_SelectionChangeCommitted);
            // 
            // button_play
            // 
            this.button_play.Location = new System.Drawing.Point(340, 10);
            this.button_play.Name = "button_play";
            this.button_play.Size = new System.Drawing.Size(50, 23);
            this.button_play.TabIndex = 8;
            this.button_play.Text = "play";
            this.button_play.UseVisualStyleBackColor = true;
            this.button_play.Click += new System.EventHandler(this.button_play_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Мелодиия оповещения";
            // 
            // button_save
            // 
            this.button_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_save.Location = new System.Drawing.Point(234, 97);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 9;
            this.button_save.Text = "Сохранить";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Location = new System.Drawing.Point(315, 97);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 10;
            this.button_cancel.Text = "Отмена";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Кол-во писем загружаемое за раз";
            // 
            // numericUpDown_maxMail
            // 
            this.numericUpDown_maxMail.Location = new System.Drawing.Point(204, 39);
            this.numericUpDown_maxMail.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown_maxMail.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown_maxMail.Name = "numericUpDown_maxMail";
            this.numericUpDown_maxMail.Size = new System.Drawing.Size(186, 20);
            this.numericUpDown_maxMail.TabIndex = 12;
            this.numericUpDown_maxMail.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Периодичность проверки (сек.)";
            // 
            // numericUpDown_chkSec
            // 
            this.numericUpDown_chkSec.Location = new System.Drawing.Point(204, 65);
            this.numericUpDown_chkSec.Maximum = new decimal(new int[] {
            1569325055,
            23283064,
            0,
            0});
            this.numericUpDown_chkSec.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_chkSec.Name = "numericUpDown_chkSec";
            this.numericUpDown_chkSec.Size = new System.Drawing.Size(186, 20);
            this.numericUpDown_chkSec.TabIndex = 14;
            this.numericUpDown_chkSec.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // fConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 132);
            this.Controls.Add(this.numericUpDown_chkSec);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown_maxMail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_play);
            this.Controls.Add(this.comboBox_melody);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fConfig";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Настройки";
            this.Shown += new System.EventHandler(this.fConfig_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_maxMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_chkSec)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_melody;
        private System.Windows.Forms.Button button_play;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_maxMail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_chkSec;
    }
}