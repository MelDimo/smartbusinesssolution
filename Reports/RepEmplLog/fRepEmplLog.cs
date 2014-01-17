using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;

namespace com.sbs.gui.report.repempllog
{
    public partial class fRepEmplLog : Form
    {
        RepParam oRepParam = new RepParam();
        DBaccess dbAccess = new DBaccess();

        public fRepEmplLog()
        {
            InitializeComponent();
        }

        private void button_getBranch_Click(object sender, EventArgs e)
        {
            fChooserUnitTree fOrgTree = new fChooserUnitTree();
            fOrgTree.autoCheckChild = false;
            fOrgTree.Text = "Выбор заведения";
            fOrgTree.StartPosition = FormStartPosition.CenterParent;
            fOrgTree.ShowDialog();
            oRepParam.checkedBranch = fOrgTree.checkedUnit;
        }

        private void button_getGroup_Click(object sender, EventArgs e)
        {

        }

        private void button_getEmpl_Click(object sender, EventArgs e)
        {

        }

        private void button_ok_Click(object sender, EventArgs e)
        {

        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
