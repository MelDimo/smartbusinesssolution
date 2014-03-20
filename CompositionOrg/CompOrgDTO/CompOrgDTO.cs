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
            private DateTime _xopen = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
            private DateTime _xclose = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 0, 0);
            private int _xduration = 15;
            private string _xip = "000.000.000.000";
            private int _xtable;
            private int _code;
            #region
            public int Code
            {
                get { return _code; }
                set { _code = value; }
            }

            public int XTable
            {
                get { return _xtable; }
                set { _xtable = value; }
            }

            public string Xip
            {
                get { return _xip; }
                set { _xip = value; }
            }

            public int XDuration
            {
                get { return _xduration; }
                set { _xduration = value; }
            }

            public DateTime XClose
            {
                get { return _xclose; }
                set { _xclose = value; }
            }

            public DateTime XOpen
            {
                get { return _xopen; }
                set { _xopen = value; }
            }

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
            #endregion

            public List<BranchPaymentType> paymentType { get; set; }
        }

        public class BranchPaymentType
        {
            public bool isChecked { get; set; }
            public int id { get; set; }
            public string name { get; set; }
        }

        public class UnitDTO
        {
            private int _id;
            private string _name;
            private int _refStatus;
            private int _branch;
            private int _refPrinters;
            private int _refPrintersType;
            private int _isDepot;
            private int _code;

            public int Code
            {
                get { return _code; }
                set { _code = value; }
            }
            

            public int isDepot
            {
                get { return _isDepot; }
                set { _isDepot = value; }
            }

            public int RefPrintersType
            {
                get { return _refPrintersType; }
                set { _refPrintersType = value; }
            }
            
            public int RefPrinters
            {
                get { return _refPrinters; }
                set { _refPrinters = value; }
            }

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
