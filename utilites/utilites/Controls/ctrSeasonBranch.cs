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
    public partial class ctrSeasonBranch : UserControl
    {
        DTO_DBoard.SeasonBranch oSeasonBranch;

        public ctrSeasonBranch(DTO_DBoard.SeasonBranch pSeasonBranch)
        {
            oSeasonBranch = pSeasonBranch;

            InitializeComponent();

            fillData();
        }

        private void fillData()
        {
            label_seasonNumb.Text = oSeasonBranch.seasonID.ToString();
            label_fio.Text = oSeasonBranch.userName;
            label_dateOpenClose.Text = oSeasonBranch.dateOpen.ToString() + " - " + oSeasonBranch.dateClose.ToString();
            label_status.Text = oSeasonBranch.refStatusName;

            switch (oSeasonBranch.refStatus)
            {
                case 16:
                    label_status.ForeColor = Color.Red;
                    break;

                case 17:
                    label_status.ForeColor = Color.Green;
                    break;

                default:
                    label_status.ForeColor = Color.Blue;
                    break;
            }
        }
    }
}
