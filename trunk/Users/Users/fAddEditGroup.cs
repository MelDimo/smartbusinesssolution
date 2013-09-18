using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;

namespace com.sbs.gui.users
{
    public partial class fAddEditGroup : Form
    {
        private bool changeData = false;

        private DataTable dtRefStatus = new DataTable();
        private GroupDTO oGroupDTO = new GroupDTO();

        private DBaccess DbAccess = new DBaccess();

        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        public fAddEditGroup(GroupDTO pGroupDTO)
        {
            InitializeComponent();

            oGroupDTO = pGroupDTO;

            if (oGroupDTO.Id == 0) formMode = "ADD";
            else formMode = "EDIT";

            initRef();

            textBox_name.Text = oGroupDTO.Name;
            comboBox_status.SelectedValue = oGroupDTO.RefStatus;
        }

        private void initRef()
        {
            getReference getRef = new getReference();

            try
            {
                dtRefStatus = getRef.getStatus("offline");
            }
            catch (Exception exc) { uMessage.Show("Ошибка получения справочника.", exc, SystemIcons.Information); }

            comboBox_status.DataSource = dtRefStatus;
            comboBox_status.ValueMember = "id";
            comboBox_status.DisplayMember = "name";
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            saveData();
            if (changeData) DialogResult = DialogResult.OK;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void saveData()
        {
            string errMessage = "Заполнены не все обязательные поля:";

            oGroupDTO.Name = textBox_name.Text.Trim();
            oGroupDTO.RefStatus = comboBox_status.SelectedValue == null ? 0 : (int)comboBox_status.SelectedValue;

            if (oGroupDTO.Name.Length == 0) errMessage += System.Environment.NewLine + "- Наименование;";
            if (oGroupDTO.RefStatus == 0) errMessage += System.Environment.NewLine + "- Статус;";

            if (!errMessage.Equals("Заполнены не все обязательные поля:"))
            {
                uMessage.Show(errMessage, SystemIcons.Information);
                return;
            }

            switch (formMode)
            {
                case "ADD":
                    try
                    {
                        DbAccess.addGroup("offline", oGroupDTO);
                    }
                    catch (Exception exc) { uMessage.Show("Ошибка при добавлении записи.", exc, SystemIcons.Error); }
                    break;

                case "EDIT":
                    try
                    {
                        DbAccess.editGroup("offline", oGroupDTO);
                    }
                    catch (Exception exc) { uMessage.Show("Ошибка при редактировании записи.", exc, SystemIcons.Error); }
                    break;
            }

            changeData = true;
        }
    }
}
