/*
    *   Title:          User.cs
    *   Purpose:        A user object
    *   Last Updated:   15/05/16
*/

using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMaintenance.ObjectModel
{
    public class User
    {
        [PrimaryKey]
        public int id { get; set; }
        public string username { get; set;  }
        public string name { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public bool temporary { get; set; }
        public string loginExpiresTime { get; set; }
        public bool expired { get; set; }
    }
}
