using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleCRUD.Models
{
    public class DGCourse
    {
        #region [Fields]

        private int _id;
        private string _name;
        private string _address;
        private string _city;
        private AppEnum.StateAbrv _state;
        private string _zip;
        private bool _open;
        private string _status;

        #endregion

        #region [Properties]

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value;  }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public AppEnum.StateAbrv State
        {
            get { return _state; }
            set { _state = value; }
        }

        public string Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }

        public bool Open
        {
            get { return _open; }
            set { _open = value; }
        }

        public string Status
        {
            get { return _status; }
            set
            {
                if (_open == false)
                {
                    _status = "Closed";
                }
                else
                {
                    _status = "Open";
                }
            }
        }

        #endregion  
    }
}