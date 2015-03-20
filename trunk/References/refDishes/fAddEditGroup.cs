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
using System.Data.SqlClient;

namespace com.sbs.gui.references.refdishes
{
    public partial class fAddEditGroup : Form
    {
        Suppurt.FormOpenModes eFormOpenModes;
        DishGroup oDishGroup;

        public fAddEditGroup(DishGroup pDishGroup, Suppurt.FormOpenModes pFormOpenModes)
        {
            eFormOpenModes = pFormOpenModes;
            oDishGroup = pDishGroup;

            InitializeComponent();

            initData();
        }

        private void initData()
        {
            textBox_nameGrop.Text = oDishGroup.name;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            switch (eFormOpenModes)
            { 
                case Suppurt.FormOpenModes.New:
                    saveData();
                    break;

                case Suppurt.FormOpenModes.Edit:
                    editData();
                    break;
            }
        }

        private bool checkData()
        {
            string errMsg = "Незаполнены след обязательные поля:";

            oDishGroup.name = textBox_nameGrop.Text.Trim();
            oDishGroup.id_parent = (int)comboBox_parentGroup.SelectedValue;

            if ("".Equals(oDishGroup.name)) errMsg += Environment.NewLine + "- Наименование;";

            if (!errMsg.Equals("Незаполнены след обязательные поля:"))
            {
                MessageBox.Show(errMsg, GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }

        private void editData()
        {
            if (!checkData()) return;

            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;

            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = " UPDATE ref_dishes_group  SET id_parent = @idParent,  name = @name " +
                                        " WHERE id = @id";

                command.Parameters.Add("id", SqlDbType.Int).Value = oDishGroup.id;
                command.Parameters.Add("idParent", SqlDbType.Int).Value = oDishGroup.id_parent;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = oDishGroup.name;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            DialogResult = DialogResult.OK;
        }

        private void saveData()
        {
            if (!checkData()) return;

            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;
            
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = " INSERT INTO ref_dishes_group (id,   id_parent,  name,   ref_status) " +
                                        "                       VALUES(0,   @idParent,  @name,  1)";

                command.Parameters.Add("idParent", SqlDbType.Int).Value = oDishGroup.id_parent;
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = oDishGroup.name;
                
                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            DialogResult = DialogResult.OK;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void fAddEditGroup_Shown(object sender, EventArgs e)
        {
            comboBox_parentGroup.SelectedValue = oDishGroup.id_parent;
        }
    }
}
