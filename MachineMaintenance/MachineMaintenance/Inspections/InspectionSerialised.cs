/*
    *   Title:          InspectionSerilised.cs
    *   Purpose:        A inspection that has been serialised for storage
    *   Last Updated:   20/05/16
*/

using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMaintenance.Inspections
{
    class InspectionSerialised
    {
        [PrimaryKey]
        public string inspection { get; set; }
    }
}
