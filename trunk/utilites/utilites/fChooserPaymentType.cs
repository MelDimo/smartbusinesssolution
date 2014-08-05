using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.sbs.dll.utilites
{
    public partial class fChooserPaymentType : Form
    {
        //class Items
        //{
        //    public int id { get; set; }
        //    public string name { get; set; }
        //    public bool isChecked { get; set; }
        //}

        //List<Items> lItems = new List<Items>();
        public List<int> isChoosen;
        public string choosenName;

        DataTable dtPaymentType;
        getReference oReference = new getReference();

        public fChooserPaymentType(List<int> pIsChoosen)
        {
            isChoosen = pIsChoosen;

            InitializeComponent();

            initRef();
        }

        private void initRef()
        {
            dtPaymentType = new DataTable();
            try
            {
                dtPaymentType = oReference.getPaymentType(GValues.DBMode);
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных.", exc, SystemIcons.Error);
                return;
            }

            //foreach (DataRow dr in dtPaymentType.Rows)
            //{
            //    lItems.Add(new Items()
            //    {
            //        id = (int)dr["id"],
            //        name = dr["name"].ToString(),
            //        isChecked = bool.Parse(dr["isChecked"].ToString())
            //    });
            //}

            ((ListBox)this.checkedListBox_paymentType).DataSource = dtPaymentType;
            ((ListBox)this.checkedListBox_paymentType).DisplayMember = "name";
            ((ListBox)this.checkedListBox_paymentType).ValueMember = "id";
        }

        private void button_select_Click(object sender, EventArgs e)
        {
            isChoosen = new List<int>();

            for (int i = 0; i < checkedListBox_paymentType.Items.Count; i++)
            {
                DataRowView view = checkedListBox_paymentType.Items[i] as DataRowView;
                if (checkedListBox_paymentType.GetItemChecked(i))
                { 
                    isChoosen.Add(((int)view["id"]));
                    choosenName += view["name"].ToString() + "; ";
                }
            }

            Close();
        }

        private void fChooserPaymentType_Shown(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox_paymentType.Items.Count; i++)
            {
                DataRowView view = checkedListBox_paymentType.Items[i] as DataRowView;
                if (isChoosen.Contains((int)view["ID"]))
                    checkedListBox_paymentType.SetItemChecked(i, true);
            }
        }
    }
}
