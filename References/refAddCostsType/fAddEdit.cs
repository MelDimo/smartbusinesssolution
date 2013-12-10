using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;
using System.Data.SqlClient;
using com.sbs.dll;

namespace com.sbs.gui.references.refaddcoststype
{
    public partial class fAddEdit : Form
    {
        Items oItems;

        DataTable dtAccount;
        DataTable dtContractor;

        getReference oReference = new getReference();

        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        public fAddEdit(Items pItems)
        {
            oItems = pItems;

            if (oItems.id == 0) formMode = "ADD";
            else formMode = "EDIT";

            InitializeComponent();
        }

        private void fAddEdit_Shown(object sender, EventArgs e)
        {
            try
            {
                dtAccount = oReference.getAccounts("offline");
                dtContractor = oReference.getContactor("offline");
            }
            catch (Exception exc)
            {
                uMessage.Show("Не удалось загрузить справочники.", exc, SystemIcons.Information);
                setEnabled(false);
                return;
            }

            textBox_name.DataBindings.Add("Text", oItems, "name");
            textBox_id.DataBindings.Add("Text", oItems, "id");
            textBox_account.DataBindings.Add("Text", oItems, "refAccountsName");
            textBox_contr.DataBindings.Add("Text", oItems, "refContractorName");

        }

        private void setEnabled(bool pEnabled)
        {
            tableLayoutPanel1.Enabled = pEnabled;
        }

        private void button_getAcc_Click(object sender, EventArgs e)
        {
            fChooser fChose = new fChooser("ACCOUNT");

            fChose.dataGridView_main.DataSource = dtAccount;

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = "id";
            col0.Name = "id";
            col0.DataPropertyName = "id";
            col0.Visible = false;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Счет";
            col1.Name = "group_II";
            col1.DataPropertyName = "group_II";
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "Наименование";
            col2.Name = "name";
            col2.DataPropertyName = "name";
            col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            fChose.dataGridView_main.Columns.AddRange(new DataGridViewColumn[] { col0, col1, col2 });

            fChose.Text = "Счет Дебет";
            if (fChose.ShowDialog() == DialogResult.OK)
            {
                oItems.refAccounts = (int)fChose.xData[0];
                oItems.refAccountsName = fChose.xData[1].ToString() + " (" + fChose.xData[2].ToString() + ")";

                textBox_account.DataBindings[0].ReadValue();
            }
        }

        private void button_getContr_Click(object sender, EventArgs e)
        {
            fChooser fChose = new fChooser("CONTRACTOR");

            fChose.dataGridView_main.DataSource = dtContractor;

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = "id";
            col0.Name = "id";
            col0.DataPropertyName = "id";
            col0.Visible = false;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Наименование";
            col1.Name = "name";
            col1.DataPropertyName = "name";
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            fChose.dataGridView_main.Columns.AddRange(new DataGridViewColumn[] { col0, col1 });

            fChose.Text = "Контрагент";

            if (fChose.ShowDialog() == DialogResult.OK)
            {
                oItems.refContractorName = fChose.xData[1].ToString();
                oItems.refContractor = (int)fChose.xData[0];

                textBox_contr.DataBindings[0].ReadValue();
            }
        }

        private bool saveData()
        {
            string errMessage = "Заполнены не все обязательные поля:";

            if (oItems.name.Length == 0) errMessage += System.Environment.NewLine + "- Наименовние;";
            if (oItems.refAccounts == 0) errMessage += System.Environment.NewLine + "- Счет;";
            if (oItems.refContractor == 0) errMessage += System.Environment.NewLine + "- Контрагент;";

            if (!errMessage.Equals("Заполнены не все обязательные поля:"))
            {
                uMessage.Show(errMessage, SystemIcons.Information);
                return false;
            }

            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                command = con.CreateCommand();

                command.Parameters.Add("name", SqlDbType.NVarChar).Value = oItems.name;
                command.Parameters.Add("ref_accounts", SqlDbType.Int).Value = oItems.refAccounts;
                command.Parameters.Add("ref_contractor", SqlDbType.Int).Value = oItems.refContractor;

                switch (formMode)
                {
                    case "ADD":
                        command.CommandText = " INSERT INTO ref_additionalCost(name, ref_accounts,   ref_contractor) " +
                                                            " VALUES(@name, @ref_accounts,  @ref_contractor) ";
                        break;

                    case "EDIT":
                        command.CommandText = "UPDATE ref_additionalCost SET name = @name, " +
                                                                    " ref_accounts = @ref_accounts," +
                                                                    " ref_contractor = @ref_contractor" +
                                                    " WHERE id = @id";
                        command.Parameters.Add("id", SqlDbType.Int).Value = oItems.id;
                        break;

                    default:
                        throw new Exception("Неудалось определить в каком режиме работает форма!");
                }

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            return true;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                MessageBox.Show("Данные успешно сохранены", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }



    }
}
