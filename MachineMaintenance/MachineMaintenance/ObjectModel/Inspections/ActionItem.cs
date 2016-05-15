using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMaintenance.ObjectModel.Inspections
{
    class ActionItem
    {
        public int id { get; set; }
        public string status { get; set; }
        public string issue { get; set; }
        public string action { get; set; }
        public string timeActioned { get; set; }
        public Technician technician { get; set; }
    }
}
