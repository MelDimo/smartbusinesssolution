using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace com.sbs.dll.utilites
{
    public partial class ctrDishes : UserControl
    {
        private Suppurt oSupport = new Suppurt();
        private getReference oReferences = new getReference();
        public DTO_DBoard.Dish oDish;

        private DataTable dtGroup = new DataTable();
        public DataTable dtToppings = new DataTable();

        private string sModule;

        public ctrDishes(DTO_DBoard.Dish pDish, string pModule)
        {
            oDish = pDish;
            sModule = pModule;
           
            InitializeComponent();

            fillControls();
            
            button_host.GotFocus += new EventHandler(button_host_GotFocus);
            button_host.LostFocus += new EventHandler(button_host_LostFocus);

            if (sModule.Equals("dashboard")) initData();

        }

        private void initData()
        {
            try
            {
                if (oDish.refStatus == 34) //Присваивается позиции попавшей в season_refuse
                {
                    dtGroup = oReferences.getToppingsGroups(GValues.DBMode, oDish.carteDishes);
                    MessageBox.Show(string.Format("oDish.carteDishes:{0}; oDish.id{1}", oDish.carteDishes, oDish.id));
                    dtToppings = oReferences.getTopingsCarteDishes_refuse(GValues.DBMode, oDish.carteDishes, oDish.id);
                }
                else
                {
                    dtGroup = oReferences.getToppingsGroups(GValues.DBMode, oDish.id);
                    dtToppings = oReferences.getTopingsCarteDishes(GValues.DBMode, oDish.id);
                }
            }
            catch (Exception exc)
            {
                uMessage.Show("Неудалось получить данные по топпингам.", exc, SystemIcons.Information);
                return;
            }

            if (dtToppings.Rows.Count > 0) button_topping.Enabled = true;
            else button_topping.Enabled = false;
        }

        void button_host_LostFocus(object sender, EventArgs e)
        {
            this.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        void button_host_GotFocus(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(185, 209, 234);
        }

        private void fillControls()
        {
            button_editMnu.BackgroundImage = Properties.Resources.edit_26;

            label_name.Text = oDish.name;
            label_price.Text = oDish.price.ToString("F2") + (oDish.discount > 0 ? " (-" + oDish.discount.ToString("F3") + "%)" : "");
            numericUpDown_count.minValue = oDish.minStep;
            numericUpDown_count.stepValue = oDish.minStep;
            numericUpDown_count.Value = oDish.count;
            comboBox_note.SelectedValue = oDish.refNotes;
            label_count.Text = oDish.count.ToString("F2");
        }

        public object Clone()
        {
            ctrDishes oCtr = new ctrDishes(oDish, sModule);
            return oCtr;
        }

        private void button_topping_Click(object sender, EventArgs e)
        {
            fAddDishToBill_topping fTopp = new fAddDishToBill_topping(dtGroup, dtToppings);
            //if (oSupport.checkPrivileges(UsersInfo.Acl, 21) || oSupport.checkPrivileges(UsersInfo.Acl, 22))
            //{
                fTopp.Text = "Топиинги";
                fTopp.MinimizeBox = false;
                fTopp.MaximizeBox = false;
                fTopp.ControlBox = false;
            //}

            if (fTopp.ShowDialog() == DialogResult.Cancel)
            {
                if (this.Parent.GetType().Equals(typeof(Form)))
                {
                    ((Form)this.Parent).DialogResult = DialogResult.Cancel;
                    ((Form)this.Parent).Close();
                }
            }

            numericUpDown_count.Focus();
        }

        public void DisposeAllCtr()
        {
            foreach (Control ctr in this.Controls)
            {
                ctr.Dispose();
            }
        }
    }
}
