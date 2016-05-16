using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMaintenance.Inspections
{
    public class WearTest
    {
        public int id { get; set; }
        public string description { get; set; }
        public string @new { get; set; }
        public string limit { get; set; }
        public string lifeLower { get; set; }
        public string lifeUpper { get; set; }
        public string timeStart { get; set; }
        public List<String> uniqueDetails { get; set; }
        public List<Comment> comments { get; set; }
        public ActionItem actionItem { get; set; }
    }
}
