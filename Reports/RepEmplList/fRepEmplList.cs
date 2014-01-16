using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;

namespace com.sbs.gui.report
{
    public partial class fRepEmplList : Form
    {
        getReference oReference = new getReference();
        DBaccess dbAccess = new DBaccess();

        RepParam oRepParam = new RepParam();
        List<int> checkedUnit = new List<int>();

        public fRepEmplList()
        {
            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            prepareReport();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_selectedUnit_Click(object sender, EventArgs e)
        {
            fChooserUnitTree fOrgTree = new fChooserUnitTree();
            fOrgTree.Text = "Выбор подразделения";
            fOrgTree.StartPosition = FormStartPosition.CenterParent;
            fOrgTree.ShowDialog();
            oRepParam.checkedUnit = fOrgTree.checkedUnit;
            textBox_unitsNames.Text = fOrgTree.checkedUnitName;
        }

        private void prepareReport()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = dbAccess.prepareReport("offline", oRepParam);
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка при формировании отчета", exc, SystemIcons.Information);
                return;
            }

            
        }
    }
}
