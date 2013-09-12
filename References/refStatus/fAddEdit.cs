using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using com.sbs.dll;
using com.sbs.dll.utilites;

namespace com.sbs.gui.references.status
{
    public partial class fAddEdit : Form
    {
        ColorDialog cDialog = new ColorDialog();
        int textColor = -16777216;
        int backColor = -1;
        bool changeData = false;
        string formMode; // В каком режиме диалог "EDIT"/"ADD"

        public fAddEdit()
        {
            InitializeComponent();
            formMode = "ADD";
        }

        public fAddEdit(int pId, string pName, string pDesc, int pTextColor, int pBackColor)
        {
            InitializeComponent();
            formMode = "EDIT";

            textBox_id.Text = pId.ToString();
            textBox_name.Text = pName;
            textBox_description.Text = pDesc;
            textBox_sample.ForeColor = Color.FromArgb(pTextColor);
            textBox_sample.BackColor = Color.FromArgb(pBackColor);
        }

        private void button_texColort_Click(object sender, EventArgs e)
        {
            if (cDialog.ShowDialog() != DialogResult.OK) return;

            textColor = cDialog.Color.ToArgb();
            textBox_sample.ForeColor = Color.FromArgb(textColor);
        }

        private void button_colorBack_Click(object sender, EventArgs e)
        {
            if (cDialog.ShowDialog() != DialogResult.OK) return;

            backColor = cDialog.Color.ToArgb();
            textBox_sample.BackColor = Color.FromArgb(cDialog.Color.ToArgb());
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            saveData();
            DialogResult = DialogResult.OK;
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            saveData();
        }

        private void saveData()
        {
            string errMessage = "Заполнены не все обязательные поля:";
            string xName = textBox_name.Text.Trim();
            string xDesc = textBox_description.Text.Trim();

            if (xName.Length == 0) errMessage += System.Environment.NewLine + "- Наименование";

            if (!errMessage.Equals("Заполнены не все обязательные поля:")) {
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

                command.Parameters.Add("name", SqlDbType.NVarChar).Value = xName;
                command.Parameters.Add("description", SqlDbType.NVarChar).Value = xDesc;
                command.Parameters.Add("textcolor", SqlDbType.Int).Value = textColor;
                command.Parameters.Add("backcolor", SqlDbType.Int).Value = backColor;

                switch(formMode)
                {
                    case "ADD":
                        command.CommandText = "INSERT INTO ref_status(name, description, textcolor, backcolor)"+
                                                " VALUES (@name, @description, @textcolor, @backcolor)";
                        break;

                    case "EDIT":
                        command.CommandText = "UPDATE ref_status SET name = @name, description = @description, textcolor = @textcolor, backcolor = @backcolor" +
                                                " WHERE id = @id";
                        command.Parameters.Add("id", SqlDbType.Int).Value = textBox_id.Text;
                        break;

                    default:
                        throw new Exception("Неудалось определить в каком режиме работает форма!");
                }

                command.ExecuteNonQuery();
                
                con.Close();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            changeData = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (changeData) DialogResult = DialogResult.OK;
            else DialogResult = DialogResult.Cancel;
        }
    }
}
