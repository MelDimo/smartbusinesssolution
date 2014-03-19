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
    public partial class fAddEdit_Group : Form
    {
        DTO.CarteDishesGroup oCarteDishesGroup;
        DBAccess bdAccess = new DBAccess();

        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        public fAddEdit_Group(DTO.CarteDishesGroup pCarteDishesGroup)
        {
            oCarteDishesGroup = pCarteDishesGroup;

            if (oCarteDishesGroup.id == 0) formMode = "ADD";
            else formMode = "EDIT";

            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (!saveData()) return;
            DialogResult = DialogResult.OK;
        }

        private bool saveData()
        {
            string errMsg = "Зполнены не все обязательные поля:";

            if (oCarteDishesGroup.name.Length == 0) errMsg += Environment.NewLine + "- Наименование;";
            if (comboBox_status.SelectedIndex == -1) errMsg += Environment.NewLine + "- Статус;";
            else oCarteDishesGroup.refStatus = (int)comboBox_status.SelectedValue;

            if (!errMsg.Equals("Зполнены не все обязательные поля:"))
            {
                MessageBox.Show(errMsg, GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            oCarteDishesGroup.idParent = (int)comboBox_parent.SelectedValue;

            try
            {
                if (formMode.Equals("ADD"))
                    bdAccess.group_add("offline", oCarteDishesGroup);
                else
                    bdAccess.group_edit("offline", oCarteDishesGroup);
            }
            catch (Exception exc)
            {
                uMessage.Show("Нуедалось сохранить меню.", exc, SystemIcons.Information);
                return false;
            }
            return true;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void fAddEdit_Group_Shown(object sender, EventArgs e)
        {
            comboBox_parent.SelectedValue = oCarteDishesGroup.idParent;
            comboBox_status.SelectedValue = oCarteDishesGroup.refStatus;
            textBox_id.DataBindings.Add("Text", oCarteDishesGroup, "id");
            textBox_name.DataBindings.Add("Text", oCarteDishesGroup, "name");
            textBox_carte.DataBindings.Add("Text", oCarteDishesGroup, "carte_name");
        }
    }
}
