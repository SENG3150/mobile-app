/*
    *   Title:          Author.cs
    *   Purpose:        An author object
    *   Last Updated:   20/05/16
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMaintenance.Inspections
{
    public class Author
    {
        public int id { get; set; }
        public string name { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public bool temporary { get; set; }
        public object loginExpiresTime { get; set; }
        public bool expired { get; set; }
    }
}
