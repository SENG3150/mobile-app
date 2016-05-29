/*
    *   Title:          MachineSerialised.cs
    *   Purpose:        A machine object that has been serialised for storage
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
    public class MachineSerialised
    {
        [PrimaryKey]
        public string machine { get; set; }
    }
}
