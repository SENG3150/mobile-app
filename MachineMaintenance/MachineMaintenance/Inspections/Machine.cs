/*
    *   Title:          Machine.cs
    *   Purpose:        A machine object
    *   Last Updated:   20/05/16
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMaintenance.Inspections
{
    public class Machine
    {
        public int id { get; set; }
        public string name { get; set; }
        public Model model { get; set; }
    }
}
