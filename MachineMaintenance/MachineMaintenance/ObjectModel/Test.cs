﻿/*
    *   Title:          Test.cs
    *   Purpose:        An test object containing information on what tests are needed
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
    public class Test
    {
        public int id { get; set; }
        public MachineGeneral machineGeneral { get; set; }
        public Oil oil { get; set; }
        public Wear wear { get; set; }
    }
}
