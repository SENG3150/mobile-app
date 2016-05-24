using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMaintenance.Inspections
{
    public class Inspection
    {
        public int id { get; set; }
        public string timeCreated { get; set; }
        public string timeScheduled { get; set; }
        public object timeStarted { get; set; }
        public object timeCompleted { get; set; }
        public List<MajorAssembly> majorAssemblies { get; set; }
        public List<object> photos { get; set; }
        public List<Comment> comments { get; set; }
        public Machine machine { get; set; }
    }
}
