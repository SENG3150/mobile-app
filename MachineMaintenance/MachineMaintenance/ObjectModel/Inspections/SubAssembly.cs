using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMaintenance.ObjectModel.Inspections
{
    class SubAssembly
    {
        public int id { get; set; }
        public List<object> comments { get; set; }
        public MachineGeneralTest machineGeneralTest { get; set; }
        public OilTest oilTest { get; set; }
        public WearTest wearTest { get; set; }
    }
}
