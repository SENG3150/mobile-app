using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensions.Extensions;

namespace MachineMaintenance.ObjectModel
{
    public class SubAssembly
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Test> tests { get; set; }
    }
}
