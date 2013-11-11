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
    public partial class fChooserUnit : Form
    {
        public int xOrgId;
        public int xBranchId;
        public int xUnitId;

        private DataTable dtOrg;
        private DataTable dtBranch;
        private DataTable dtUnit;

        public fChooserUnit()
        {
            getReferences();

            InitializeComponent();
        }

        private void getReferences()
        {
            
        }

    }
}
