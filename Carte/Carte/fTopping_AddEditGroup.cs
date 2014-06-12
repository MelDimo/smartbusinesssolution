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
    public partial class fTopping_AddEditGroup : Form
    {
        DBAccess dbAccess = new DBAccess();

        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        DTO.ToppingGroup oToppingGroup;

        public fTopping_AddEditGroup(DTO.ToppingGroup pToppingGroup)
        {
            oToppingGroup = pToppingGroup;

            InitializeComponent();

            if (oToppingGroup.id == 0) formMode = "ADD";
            else formMode = "EDIT";
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            oToppingGroup.id_parent = (int)comboBox_parent.SelectedValue;
            oToppingGroup.name = textBox_name.Text.Trim();
            oToppingGroup.refStatus = (int)comboBox_status.SelectedValue;

            saveData();
        }

        private void saveData()
        {
            string errMsg = "Заполнены не все обязвтельные поля поля:";

            if ("".Equals(oToppingGroup.name)) errMsg += Environment.NewLine + "-Наименование;";

            if (!errMsg.Equals("Заполнены не все обязвтельные поля поля:"))
            {
                MessageBox.Show(errMsg, GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try 
            {
                switch(formMode)
                {
                    case "ADD":
                        dbAccess.topping_add(GValues.DBMode, oToppingGroup);
                        break;
                    case "EDIT":
                        dbAccess.topping_edit(GValues.DBMode, oToppingGroup);
                        break;
                }
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных.", exc, SystemIcons.Information); return; }

            DialogResult = DialogResult.OK;
        }

        private void fTopping_AddEditGroup_Shown(object sender, EventArgs e)
        {
            comboBox_parent.SelectedValue = oToppingGroup.id_parent;
            comboBox_status.SelectedValue = oToppingGroup.refStatus;
            textBox_name.Text = oToppingGroup.name;
        }
    }
}
