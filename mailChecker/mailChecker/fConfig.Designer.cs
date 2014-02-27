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
            this.SuspendLayout();
            // 
            // comboBox_melody
            // 
            this.comboBox_melody.FormattingEnabled = true;
            this.comboBox_melody.Location = new System.Drawing.Point(142, 12);
            this.comboBox_melody.Name = "comboBox_melody";
            this.comboBox_melody.Size = new System.Drawing.Size(192, 21);
            this.comboBox_melody.TabIndex = 7;
            // 
            // button_play
            // 
            this.button_play.Location = new System.Drawing.Point(340, 10);
            this.button_play.Name = "button_play";
            this.button_play.Size = new System.Drawing.Size(50, 23);
            this.button_play.TabIndex = 8;
            this.button_play.Text = "play";
            this.button_play.UseVisualStyleBackColor = true;
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
            this.button_save.Location = new System.Drawing.Point(234, 57);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 9;
            this.button_save.Text = "Сохранить";
            this.button_save.UseVisualStyleBackColor = true;
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Location = new System.Drawing.Point(315, 57);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 10;
            this.button_cancel.Text = "Отмена";
            this.button_cancel.UseVisualStyleBackColor = true;
            // 
            // fConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 92);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.button_play);
            this.Controls.Add(this.comboBox_melody);
            this.Controls.Add(this.label4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fConfig";
            this.ShowInTaskbar = false;
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_melody;
        private System.Windows.Forms.Button button_play;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_cancel;
    }
}