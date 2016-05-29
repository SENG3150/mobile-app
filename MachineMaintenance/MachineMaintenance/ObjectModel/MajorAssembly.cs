/*
    *   Title:          MajorAssembly.cs
    *   Purpose:        A major assembly object
    *   Last Updated:   15/05/16
*/

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
    public class MajorAssembly
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<SubAssembly> subAssemblies { get; set; }
    }
}
