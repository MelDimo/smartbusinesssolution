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
        DTO_DBoard.DishRefuse oDishRefuse;
        public int id;

        public ctrDishesRefuse(DTO_DBoard.DishRefuse pDishRefuse)
        {
            oDishRefuse = pDishRefuse;

            InitializeComponent();

            fillData();
        }

        private void fillData()
        {
            id = oDishRefuse.id;
            label_name.Text = oDishRefuse.name;
            label_price.Text = oDishRefuse.price.ToString("F2");
            label_count.Text = oDishRefuse.count.ToString("F2");
            label_dateRefuseAdd.Text = oDishRefuse.refuseDate.ToLongTimeString();
            label_userRefuse.Text = oDishRefuse.refuseFio;
        }
    }
}
