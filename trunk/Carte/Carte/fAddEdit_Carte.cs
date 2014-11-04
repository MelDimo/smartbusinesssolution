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

            for (int i = 0; i < checkedListBox_branch.Items.Count; i++)
            {
                DataRowView view = checkedListBox_branch.Items[i] as DataRowView;
                if (checkedListBox_branch.GetItemChecked(i)) oCarte.unit.Add((int)view["unit"]);
            }

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
                {
                    bdAccess.carte_add(GValues.DBMode, oCarte);
                }
                else
                {
                    bdAccess.carte_edit(GValues.DBMode, oCarte);
                }

                bdAccess.setDtCheckedUnit(GValues.DBMode);
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

            ReferData.dtUnit.DefaultView.RowFilter = string.Format("branch = {0}", oCarte.branch, oCarte.id);
            checkedListBox_branch.DataSource = ReferData.dtUnit;
            checkedListBox_branch.DisplayMember = "name";
            checkedListBox_branch.ValueMember = "unit";

            comboBox_branch.SelectedIndexChanged +=new EventHandler(comboBox_branch_SelectedIndexChanged);

            comboBox_branch_SelectedIndexChanged(null,new EventArgs());
        }

        private void comboBox_branch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReferData.dtUnit.DefaultView.RowFilter = string.Format("branch = {0}", comboBox_branch.SelectedValue, oCarte.id);

            int xUnit, xCount = 0;

            for (int i = 0; i < checkedListBox_branch.Items.Count; ++i)
            {
                xUnit = (int)((DataRowView)checkedListBox_branch.Items[i])["unit"];

                xCount = ReferData.dtCheckedUnit.AsEnumerable().Where(r => (int)r["unit"] == xUnit && (int)r["carte"] == oCarte.id).Count();

                checkedListBox_branch.SetItemChecked(i, xCount != 0);
                
            }
            
        }
    }
}
