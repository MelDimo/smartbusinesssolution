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
    public partial class fBranchUpdateError : Form
    {
        public fBranchUpdateError(Dictionary<DTO_Updater.Category, Exception> pDicExc)
        {
            InitializeComponent();

            foreach (DTO_Updater.Category keyCol in pDicExc.Keys)
            {
                richTextBox_errors.AppendText("Наименование категории: " + keyCol.name + Environment.NewLine);
                richTextBox_errors.AppendText("Сценарий: " + keyCol.script + Environment.NewLine);
                richTextBox_errors.AppendText("Ошибка: " + pDicExc[keyCol].Message + Environment.NewLine);
                richTextBox_errors.AppendText("---------------------------------------------------------");
                richTextBox_errors.AppendText(Environment.NewLine);
            }
        }
    }
}
