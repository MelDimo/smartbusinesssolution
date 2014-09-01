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
    public partial class fDublicate_Carte : Form
    {
        DBAccess dbAccess = new DBAccess();

        DTO.Carte oCarte;
        DataTable dtBranch;
        string BName;

        public fDublicate_Carte(string pBName, DTO.Carte pCarte, DataTable pDtBranch)
        {
            BName = pBName;
            oCarte = pCarte;
            dtBranch = pDtBranch;

            InitializeComponent();
        }

        private void fDublicate_Carte_Shown(object sender, EventArgs e)
        {
            string text = string.Empty;

            comboBox_branch.DataSource = dtBranch;
            comboBox_branch.ValueMember = "id";
            comboBox_branch.DisplayMember = "name";

            text = label_text.Text;

            text = text.Replace("#bname#", BName);
            text = text.Replace("#cname#", oCarte.name);

            label_text.Text = text;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            int branchId;
            int carteCode;

            branchId = (int)comboBox_branch.SelectedValue;
            carteCode = (int)numericUpDown_code.Value;

            if (carteCode == 0)
            {
                MessageBox.Show("Укажите внешний ключ.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (saveData(branchId, carteCode, oCarte.id))
            {
                MessageBox.Show("Меню успешно продублировано.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }

            
        }

        private bool saveData(int pBranchId, int pCarteCode, int pCarteId)
        {
            try
            {
                dbAccess.carte_dublicate(GValues.DBMode, pBranchId, pCarteCode, pCarteId);
            }
            catch (Exception exc)
            {
                uMessage.Show("Неудалось создать меню.", exc, SystemIcons.Information);
                return false;
            }

            return true;
        }
    }
}
