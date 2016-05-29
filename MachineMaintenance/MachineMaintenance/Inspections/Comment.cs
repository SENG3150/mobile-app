/*
    *   Title:          Comment.cs
    *   Purpose:        An comment object
    *   Last Updated:   20/05/16
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineMaintenance.Inspections
{
    public class Comment
    {
        public int id { get; set; }
        public string timeCommented { get; set; }
        public string authorType { get; set; }
        public string text { get; set; }
        public ObjectModel.User author { get; set; }
    }
}
