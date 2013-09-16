using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.sbs.gui.users
{
    class UsersDTO
    {
        private int _id;
        private string _login;
        private string _fname;
        private string _sname;
        private string _lname;
        private DateTime _bdate;
        private int _branch;
        private int _unit;
        private int _ref_post;
        private int _ref_status;
        private string _pwd;

        public string PWD
        {
            get { return _pwd; }
            set { _pwd = value; }
        }
        


        public int RefStatus
        {
            get { return _ref_status; }
            set { _ref_status = value; }
        }
        

        public int RefPost
        {
            get { return _ref_post; }
            set { _ref_post = value; }
        }
        


        public int _Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }
        


        public int Branch
        {
            get { return _branch; }
            set { _branch = value; }
        }
        

        public DateTime BDate
        {
            get { return _bdate; }
            set { _bdate = value; }
        }
        

        public string lName
        {
            get { return _lname; }
            set { _lname = value; }
        }
        


        public string sName
        {
            get { return _sname; }
            set { _sname = value; }
        }
        

        public string fName
        {
            get { return _fname; }
            set { _fname = value; }
        }
        

        public string Login
        {
            get { return _login; }
            set { _login = value; }
        }
        

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        
    }
}
