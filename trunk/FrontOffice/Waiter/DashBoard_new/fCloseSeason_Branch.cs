using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;

namespace com.sbs.gui.dashboard
{
    public partial class fCloseSeason_Branch : Form
    {
        private DBaccess dbAccess = new DBaccess();
        List<SeasonUser> lSeasonUser = new List<SeasonUser>();

        public fCloseSeason_Branch()
        {
            InitializeComponent();

            getSeasonUser();
        }

        private void getSeasonUser()
        {
            try
            {
                lSeasonUser = dbAccess.getSeasonUser("offline");
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных." + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
                return;
            }
        }

        private void fCloseSeason_Branch_Shown(object sender, EventArgs e)
        {

        }


    }
}
