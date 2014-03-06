using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.sbs.dll.mailChecker
{
    public partial class fMain : Form
    {
        List<DTO.Mail> oMail = new List<DTO.Mail>();
        Checker checker = new Checker();

        const int stepMail = 10;

        public fMain()
        {
            InitializeComponent();
        }

        private void tSButton_recive_Click(object sender, EventArgs e)
        {
            oMail = checker.getMail(1, 10);
            dataGridView_postBox.DataSource = oMail;
        }
    }
}
