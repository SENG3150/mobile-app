using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMaintenance.Inspections
{
    class LoginDetails
    {
        public string id { get; set; }
        public string type { get; set; }
        public ObjectModel.User primary { get; set; }
        public Technician technician { get; set; }
    }
}
