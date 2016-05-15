using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMaintenance.Inspections
{
    public class MajorAssembly
    {
        public int id { get; set; }
        public List<SubAssembly> subAssemblies { get; set; }
        public List<object> comments { get; set; }
    }
}
