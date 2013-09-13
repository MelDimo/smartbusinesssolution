using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sbs.dll.dto
{
    public partial class CompOrgDTO
    {
        public class OrganizationDTO
        {
            private int _id;
            private string _name;
            private int _refStatus;

            public int RefStatus
            {
                get { return _refStatus; }
                set { _refStatus = value; }
            }
            
            public string Name
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

        public class BranchDTO
        {
            private int _id;
            private string _name;
            private int _refStatus;
            private int _refCity;
            private int _refOrg;

            public int RefOrg
            {
                get { return _refOrg; }
                set { _refOrg = value; }
            }

            public int RefCity
            {
                get { return _refCity; }
                set { _refCity = value; }
            }

            public int RefStatus
            {
                get { return _refStatus; }
                set { _refStatus = value; }
            }
            
            public string Name
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

        public class UnitDTO
        {
            private int _id;
            private string _name;
            private int _refStatus;
            private int _branch;

            public int Branch
            {
                get { return _branch; }
                set { _branch = value; }
            }
            

            public int RefStatus
            {
                get { return _refStatus; }
                set { _refStatus = value; }
            }
            
            public string Name
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
