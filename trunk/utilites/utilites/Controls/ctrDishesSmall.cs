using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll;

namespace com.sbs.dll.utilites
{
    public partial class ctrDishesSmall : UserControl
    {
        public DTO_DBoard.Dish oDish { set; get; }

        public ctrDishesSmall(DTO_DBoard.Dish pDish)
        {
            InitializeComponent();

            oDish = pDish;

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
            label_count.Text = oDish.count.ToString("F2");
            label_name.Text = oDish.name;
            label_summa.Text = (oDish.count * oDish.price).ToString("F2");
            pictureBox_status.BackColor = oDish.refStatus == 24 ? Color.Red : Color.Green;
            label_time.Text = oDish.dateStatus.Value.ToLongTimeString();
            label_note.Text = oDish.refNotesName;
        }
    }
}
