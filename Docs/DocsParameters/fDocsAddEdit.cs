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
    public partial class fDocsAddEdit : Form
    {
        DocsType oDocType;

        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        public fDocsAddEdit(DocsType pDocsType)
        {
            InitializeComponent();

            oDocType = pDocsType;

            if (oDocType.id == 0) formMode = "ADD";
            else formMode = "EDIT";
        }

        private void fDocsAddEdit_Shown(object sender, EventArgs e)
        {
            comboBox_refStatus.SelectedValue = oDocType.refStat;
            textBox_id.Text = oDocType.id.ToString();
            textBox_name.Text = oDocType.name;
            textBox_id.Text = oDocType.id.ToString();
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
            oDocType.name = textBox_name.Text.Trim();

            if (oDocType.name.Length == 0) errMessage += System.Environment.NewLine + "- Наименование;";
            if (comboBox_refStatus.SelectedValue == null) errMessage += System.Environment.NewLine + "- Статус;";
            else oDocType.refStat = (int)comboBox_refStatus.SelectedValue;

            if (!errMessage.Equals("Заполнены не все обязательные поля:"))
            {
                uMessage.Show(errMessage, SystemIcons.Information);
                return false;
            }

            switch (formMode)
            {
                case "ADD":
                    dbAccess.addDocsType("offline", oDocType);
                    break;

                case "EDIT":
                    dbAccess.editDocsType("offline", oDocType);
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
