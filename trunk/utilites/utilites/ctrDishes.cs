﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.sbs.dll.utilites
{
    public partial class ctrDishes : UserControl, ICloneable
    {
        public ctrDishes()
        {
            InitializeComponent();
        }

        public object Clone()
        {
            ctrDishes retVal = this;
            return retVal;
        }
    }
}