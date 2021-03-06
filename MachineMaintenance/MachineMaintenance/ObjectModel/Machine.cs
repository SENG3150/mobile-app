﻿/*
    *   Title:          Machine.cs
    *   Purpose:        A machine object
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
    public class Machine
    {
        public int id { get; set; }
        public string name { get; set; }
        public Model model { get; set; }
    }
}
