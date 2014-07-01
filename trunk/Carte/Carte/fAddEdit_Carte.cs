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

namespace com.sbs.gui.carte
{
    public partial class fAddEdit_Carte : Form
    {
        DTO.Carte oCarte;
        DBAccess bdAccess = new DBAccess();

        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        public fAddEdit_Carte(DTO.Carte pCarte)
        {
            oCarte = pCarte;

            if (oCarte.id == 0) formMode = "ADD";
            else formMode = "EDIT";

            InitializeComponent();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (!saveData()) return;

            DialogResult = DialogResult.OK;
        }

        private bool saveData()
        {
            string errMsg = "Зполнены не все обязательные поля:";

            oCarte.code = int.Parse(numericUpDown_code.Value.ToString());
            ;
            if (comboBox_refStatus.SelectedIndex == -1) errMsg += Environment.NewLine + "- Статус;";
            else oCarte.refStatus = (int)comboBox_refStatus.SelectedValue;

            if (!errMsg.Equals("Зполнены не все обязательные поля:"))
            {
                MessageBox.Show(errMsg, GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            try
            {
                if (formMode.Equals("ADD")) 
                    bdAccess.carte_add("offline", oCarte);
                else 
                    bdAccess.carte_edit("offline", oCarte);
            }
            catch (Exception exc)
            {
                uMessage.Show("Нуедалось сохранить меню.", exc, SystemIcons.Information);
                return false;
            }
            return true;
        }

        private void fAddEdit_Carte_Shown(object sender, EventArgs e)
        {
            textBox_id.DataBindings.Add("Text", oCarte, "id");
            numericUpDown_code.Value = oCarte.code;
            textBox_name.DataBindings.Add("Text", oCarte, "name");
            comboBox_branch.SelectedValue = oCarte.branch;
            comboBox_refStatus.SelectedValue = oCarte.refStatus;
        }
    }
}
