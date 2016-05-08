using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMaintenance.ObjectModel
{
    class MajorAssemblies
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<SubAssembly> subAssemblies { get; set; }
    }
}
