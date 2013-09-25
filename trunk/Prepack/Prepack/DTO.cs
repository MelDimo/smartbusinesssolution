using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sbs.gui.prepack
{
    public class DTO
    {
        public class Prepack
        {
            private int _id;
            private string _code;
            private string _name;
            private int _unit;
            private int _status;
            private int _org;
            private int _branch;

            public int Branch
            {
                get { return _branch; }
                set { _branch = value; }
            }
            
            public int Org
            {
                get { return _org; }
                set { _org = value; }
            }
            
            public int Status
            {
                get { return _status; }
                set { _status = value; }
            }
            
            public int Unit
            {
                get { return _unit; }
                set { _unit = value; }
            }
            
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            
            public string Code
            {
                get { return _code; }
                set { _code = value; }
            }
            
            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }
            
        }

        public class Goods
        {
            private int _id;
            private int _code;
            private string _name;
            private int _refmeasure;
            private int _refstatus;
            private string _manufacturer;
            
            public int Code
            {
                get { return _code; }
                set { _code = value; }
            }

            public string Manufacturer
            {
                get { return _manufacturer; }
                set { _manufacturer = value; }
            }
            
            public int RefStatus
            {
                get { return _refstatus; }
                set { _refstatus = value; }
            }
            
            public int RefMeasure
            {
                get { return _refmeasure; }
                set { _refmeasure = value; }
            }
            
            public string MyProperty
            {
                get { return _name; }
                set { _name = value; }
            }
            
            public int Id
            {
                get { return _id; }
                set { _id = value; }
            }
            
        }
    }
}
