using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll;
using com.sbs.dll.utilites;

namespace com.sbs.gui.updatereference
{
    public partial class fEditScript : Form
    {
        DBAccess dbAccess = new DBAccess();

        public DTO_Updater.Category oCategory;

        public fEditScript()
        {
            InitializeComponent();
        }

        private void fEditScript_Shown(object sender, EventArgs e)
        {
            this.Text = string.Format("Редактирование сценария '{0}'", oCategory.name);
            richTextBox_script.Text = oCategory.script;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (richTextBox_script.Text.Trim().Length == 0)
            {
                MessageBox.Show("Невозможно сохранить пустой сценарий.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            oCategory.script = richTextBox_script.Text;
            try
            {
                dbAccess.saveScript(GValues.DBMode, oCategory);
            }
            catch (Exception exc)
            {
                uMessage.Show("Не удалось сохранить сценарий.", exc, SystemIcons.Information);
                DialogResult = DialogResult.Cancel;
            }

            MessageBox.Show("Сценарий сохранен.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }
    }
}
