using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;
using com.sbs.dll;

namespace com.sbs.gui.references.refspecialty
{
    public partial class fAddEdit : Form
    {
        private DBAccess dbAccess = new DBAccess();
        private Specialty oSpecialty;
        private string formMode; // В каком режиме диалог "EDIT"/"ADD"
        

        public fAddEdit(Specialty pSpecialty)
        {
            oSpecialty = pSpecialty;

            InitializeComponent();

            if (oSpecialty.id == 0) formMode = "ADD";
            else formMode = "EDIT";
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            string errMsg = "Заполенены не все обязательные поля:";

            oSpecialty.name = textBox_name.Text.Trim();
            oSpecialty.refStatus = (int)comboBox_status.SelectedValue;

            if (oSpecialty.name.Length == 0) errMsg += Environment.NewLine + "- Наименование;";

            if (!errMsg.Equals("Заполенены не все обязательные поля:"))
            {
                MessageBox.Show(errMsg, GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            saveData();
        }

        private void saveData()
        {
            try
            {
                switch (formMode)
                { 
                    case "ADD":
                        dbAccess.data_add(oSpecialty);
                        break;
                    case "EDIT":
                        dbAccess.data_edit(oSpecialty);
                        break;
                }
            }
            catch (Exception exc) { uMessage.Show("Неудалось сохранить данные.", exc, SystemIcons.Information); return; }

            DialogResult = DialogResult.OK;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void fAddEdit_Shown(object sender, EventArgs e)
        {
            textBox_id.Text = oSpecialty.id.ToString();
            textBox_name.Text = oSpecialty.name;
            comboBox_status.SelectedValue = oSpecialty.refStatus == 0 ? 1 : oSpecialty.refStatus;
        }
    }
}
