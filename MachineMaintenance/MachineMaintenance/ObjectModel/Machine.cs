using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMaintenance.ObjectModel
{
    public class Machine
    {
        public int id { get; set; }
        public string name { get; set; }
        public Model model { get; set; }
    }
}
