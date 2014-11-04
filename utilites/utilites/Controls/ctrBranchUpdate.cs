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
    public partial class ctrBranchUpdate : UserControl
    {
        public DTO_Updater.Branch oBranch;
        public Dictionary<DTO_Updater.Category, Exception> oDCategiryExc;

        public ctrBranchUpdate(DTO_Updater.Branch pBranch)
        {
            oBranch = pBranch;

            InitializeComponent();

            button_host.GotFocus += new EventHandler(button_host_GotFocus);
            button_host.LostFocus += new EventHandler(button_host_LostFocus);

            fillControls();
        }

        private void fillControls()
        {
            label_branchName.Text = oBranch.name;
            label_srvInfo.Text = oBranch.getPath();
        }

        void button_host_LostFocus(object sender, EventArgs e)
        {
            this.BackColor = Color.FromKnownColor(KnownColor.Control);
        }

        void button_host_GotFocus(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(185, 209, 234);
        }

        void selectBtnHost(object sender, EventArgs e)
        {
            button_host.Select();
        }

        private void button_error_Click(object sender, EventArgs e)
        {
            fBranchUpdateError fbranch = new fBranchUpdateError(oDCategiryExc);
            fbranch.ShowDialog();
        }
    }
}
