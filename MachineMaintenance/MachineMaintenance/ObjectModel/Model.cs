using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMaintenance.ObjectModel
{
    public class Model
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<MajorAssembly> majorAssemblies { get; set; }
    }
}
