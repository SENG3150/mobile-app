/*
    *   Title:          ActionItem.cs
    *   Purpose:        An ActionItem object
    *   Last Updated:   20/05/16
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMaintenance.Inspections
{
    public class ActionItem
    {
        public int id { get; set; }
        public string status { get; set; }
        public string issue { get; set; }
        public string action { get; set; }
        public string timeActioned { get; set; }
        public ObjectModel.User technician { get; set; }
    }
}
