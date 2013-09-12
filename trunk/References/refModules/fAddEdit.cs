using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using com.sbs.dll.utilites;
using com.sbs.dll;
using System.IO;

namespace com.sbs.gui.references.modules
{
    public partial class fAddEdit : Form
    {
        bool changeData = false;
        string formMode; // В каком режиме диалог "EDIT"/"ADD"

        public fAddEdit()
        {
            InitializeComponent();

            formMode = "ADD";
        }

        public fAddEdit(string pId, string pFpath, string pAssemblyName, string isGUI)
        {
            InitializeComponent();

            formMode = "EDIT";

            textBox_id.Text = pId;
            textBox_fname.Text = pFpath;
            textBox_assemblyName.Text = pAssemblyName;
            checkBox_isGUI.Checked = isGUI.Equals("1") ? true : false;
        }

        private void button_fname_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory;
            ofd.Multiselect = false;
            if (ofd.ShowDialog() != DialogResult.OK) return;

            textBox_fname.Text = ofd.FileName;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            saveData();
            if (changeData == true) DialogResult = DialogResult.OK;
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            saveData();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            if (changeData) DialogResult = DialogResult.OK;
            else DialogResult = DialogResult.Cancel;
        }

        private void saveData()
        {
            string errMessage = "Заполнены не все обязательные поля:";
            string xFName = textBox_fname.Text.Trim();
            string xAssemblyName = textBox_assemblyName.Text.Trim();
            int isGUI = checkBox_isGUI.Checked ? 1 : 0;

            if (xFName.Length == 0) errMessage += System.Environment.NewLine + "- Путь к файлу;";
            if (xAssemblyName.Length == 0 && isGUI == 1) errMessage += System.Environment.NewLine + "- Имя сборки (т.к. указано что содержится интерфейс);";

            if (!errMessage.Equals("Заполнены не все обязательные поля:"))
            {
                uMessage.Show(errMessage, SystemIcons.Information);
                return;
            }

            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.Parameters.Add("fname", SqlDbType.NVarChar).Value = Path.GetFileName(xFName);
                command.Parameters.Add("fpath", SqlDbType.NVarChar).Value = xFName;
                command.Parameters.Add("assembly_name", SqlDbType.NVarChar).Value = xAssemblyName;
                command.Parameters.Add("isGUI", SqlDbType.Int).Value = isGUI;

                switch (formMode)
                {
                    case "ADD":
                        command.CommandText = "INSERT INTO ref_modules(fname, fpath, assembly_name, isGUI)" +
                                                " VALUES (@fname, @fpath, @assembly_name, @isGUI)";
                        break;

                    case "EDIT":
                        command.CommandText = "UPDATE ref_modules SET fname = @fname, fpath = @fpath, assembly_name = @assembly_name, isGUI = @isGUI" +
                                                " WHERE id = @id";
                        command.Parameters.Add("id", SqlDbType.Int).Value = textBox_id.Text;
                        break;

                    default:
                        throw new Exception("Неудалось определить в каком режиме работает форма!");
                }

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); changeData = false; return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            changeData = true;
        }
    }
}
