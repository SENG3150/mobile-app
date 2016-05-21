using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MachineMaintenance.ObjectModel
{
    public class Token
    {
        [PrimaryKey]
        public string token { get; set; }
    }
}
