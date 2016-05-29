/*
    *   Title:          MachineGeneralTest.cs
    *   Purpose:        A machine general test object for some assemblies
    *   Last Updated:   20/05/16
*/

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
        public List<object> photos { get; set; }
        public ActionItem actionItem { get; set; }
        public bool isCompleted { get; set; }
    }
}
