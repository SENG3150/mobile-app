/*
    *   Title:          Oil.cs
    *   Purpose:        An oil test object
    *   Last Updated:   15/05/16
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;
using SQLiteNetExtensions.Extensions;

namespace MachineMaintenance.ObjectModel
{
    public class Oil
    {
        public bool test { get; set; }
        public object lower { get; set; }
        public object upper { get; set; }
    }
}
