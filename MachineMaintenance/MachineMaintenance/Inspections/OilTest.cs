/*
    *   Title:          OilTest.cs
    *   Purpose:        An oil test object
    *   Last Updated:   20/05/16
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMaintenance.Inspections
{
    public class OilTest
    {
        public int id { get; set; }
        public int lead { get; set; }
        public int copper { get; set; }
        public int tin { get; set; }
        public int iron { get; set; }
        public int pq90 { get; set; }
        public int silicon { get; set; }
        public int sodium { get; set; }
        public int aluminium { get; set; }
        public string water { get; set; }
        public int viscosity { get; set; }
        public List<Comment> comments { get; set; }
        public List<object> photos { get; set; }
        public ActionItem actionItem { get; set; }
        public bool isCompleted { get; set; }
    }
}
