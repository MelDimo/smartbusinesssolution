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

namespace com.sbs.gui.docs
{
    public partial class fDocsBlockAddEdit : Form
    {
        DocsBlock oDocsBlock;

        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        public fDocsBlockAddEdit(DocsBlock pDocsBlock)
        {
            oDocsBlock = pDocsBlock;

            if (oDocsBlock.id == 0) formMode = "ADD";
            else formMode = "EDIT";

            InitializeComponent();
        }

        private void fDocsBlockAddEdit_Shown(object sender, EventArgs e)
        {
            textBox_name.DataBindings.Add("Text", oDocsBlock, "name");
            numericUpDown_xOrder.DataBindings.Add("Value",oDocsBlock, "xorder");
            comboBox_statusIn.SelectedValue = oDocsBlock.refStatusIn;
            comboBox_statusOut.SelectedValue = oDocsBlock.refStatusOut;
            checkBox_isAuto.Checked = oDocsBlock.isAuto == 1 ? true : false;
            textBox_condition.DataBindings.Add("Text", oDocsBlock, "condition");
            textBox_id.Text = oDocsBlock.id.ToString();
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

            if (oDocsBlock.name.Length == 0) errMessage += System.Environment.NewLine + "- Наименование;";
            if (checkBox_isAuto.Checked) oDocsBlock.isAuto = 1;
            else oDocsBlock.isAuto = 0;
            if (oDocsBlock.condition.Length == 0) errMessage += System.Environment.NewLine + "- Условие выполнения;";
            if (comboBox_statusIn.SelectedValue == null) errMessage += System.Environment.NewLine + "- Начальный статус;";
            else oDocsBlock.refStatusIn = (int)comboBox_statusIn.SelectedValue;
            if (comboBox_statusOut.SelectedValue == null) errMessage += System.Environment.NewLine + "- Конечный статус;";
            else oDocsBlock.refStatusOut = (int)comboBox_statusOut.SelectedValue;

            if (!errMessage.Equals("Заполнены не все обязательные поля:"))
            {
                uMessage.Show(errMessage, SystemIcons.Information);
                return false;
            }

            switch (formMode)
            {
                case "ADD":
                    dbAccess.addDocsBlock("offline", oDocsBlock);
                    break;

                case "EDIT":
                    dbAccess.editDocsBlock("offline", oDocsBlock);
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
