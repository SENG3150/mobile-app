using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMaintenance.ObjectModel.Inspections
{
    class Comment
    {
        public int id { get; set; }
        public string timeCommented { get; set; }
        public string authorType { get; set; }
        public string text { get; set; }
        public Author author { get; set; }
    }
}
