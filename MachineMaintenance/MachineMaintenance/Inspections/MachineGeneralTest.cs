using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMaintenance.Inspections
{
    public class MachineGeneralTest
    {
        public int id { get; set; }
        public string testType { get; set; }
        public string docLink { get; set; }
        public List<Comment> comments { get; set; }
        public ActionItem actionItem { get; set; }
    }
}
