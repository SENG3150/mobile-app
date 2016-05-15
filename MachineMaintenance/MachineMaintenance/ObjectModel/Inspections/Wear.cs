using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMaintenance.ObjectModel.Inspections
{
    public class Wear
    {
        public bool test { get; set; }
        public object lower { get; set; }
        public object upper { get; set; }
    }
}
