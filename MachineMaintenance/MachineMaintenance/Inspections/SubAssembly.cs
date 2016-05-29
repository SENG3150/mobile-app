/*
    *   Title:          SubAssembly.cs
    *   Purpose:        A sub assembly object
    *   Last Updated:   20/05/16
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMaintenance.Inspections
{
    public class SubAssembly
    {
        public int id { get; set; }
        public List<Comment> comments { get; set; }
        public List<object> photos { get; set; }
        public MachineGeneralTest machineGeneralTest { get; set; }
        public OilTest oilTest { get; set; }
        public WearTest wearTest { get; set; }
        public ObjectModel.SubAssembly subAssembly { get; set; }
    }
}
