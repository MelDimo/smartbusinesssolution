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

namespace com.sbs.gui.docs
{
    public partial class fDocsParamAddEdit : Form
    {
        DocsParam oDocParam;

        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        public fDocsParamAddEdit(DocsParam pDocsParam)
        {
            InitializeComponent();

            oDocParam = pDocsParam;

            if (oDocParam.id == 0) formMode = "ADD";
            else formMode = "EDIT";
        }

        private void fDocsParamAddEdit_Shown(object sender, EventArgs e)
        {
            comboBox_docsParam.SelectedValue = oDocParam.refDocsParamId;
            textBox_id.Text = oDocParam.id.ToString();
            textBox_description.Text = oDocParam.description;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            bool retVal = false;
            try
            {
                retVal = saveData();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }

            if (!retVal) return;

            MessageBox.Show("Данные успешно сохранены.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }

        private bool saveData()
        {
            DBAccess dbAccess = new DBAccess();

            string errMessage = "Заполнены не все обязательные поля:";

            if (comboBox_docsParam.SelectedValue == null) errMessage += System.Environment.NewLine + "- Параметр;";
            else oDocParam.refDocsParamId = (int)comboBox_docsParam.SelectedValue;

            if (!errMessage.Equals("Заполнены не все обязательные поля:"))
            {
                uMessage.Show(errMessage, SystemIcons.Information);
                return false;
            }

            switch (formMode)
            {
                case "ADD":
                    dbAccess.addDocsParam("offline", oDocParam);
                    break;

                case "EDIT":
                    dbAccess.editDocsParam("offline", oDocParam);
                    break;

                default:
                    throw new Exception("Неудалось определить в каком режиме работает форма!");
            }

            return true;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
