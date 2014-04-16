using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.sbs.dll.utilites
{
    public partial class ctrDishesRefuse : UserControl
    {
        public DTO_DBoard.DishRefuse oDishRefuse;

        public ctrDishesRefuse(DTO_DBoard.DishRefuse pDishRefuse)
        {
            oDishRefuse = pDishRefuse;

            InitializeComponent();

            fillData();

            button_host.GotFocus += new EventHandler(button_host_GotFocus);
            button_host.LostFocus += new EventHandler(button_host_LostFocus);
        }

        void button_host_LostFocus(object sender, EventArgs e)
        {
            this.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        void button_host_GotFocus(object sender, EventArgs e)
        {
            this.BackColor = Color.FromKnownColor(KnownColor.GradientActiveCaption);
        }

        private void fillData()
        {
            label_name.Text = oDishRefuse.name;
            label_price.Text = oDishRefuse.price.ToString("F2");
            label_count.Text = oDishRefuse.count.ToString("F2");
            label_dateRefuseAdd.Text = oDishRefuse.refuseDate.ToLongTimeString();
            label_userRefuse.Text = oDishRefuse.refuseFio;
        }
    }
}
