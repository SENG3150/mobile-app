/*
    *   Title:          Token.cs
    *   Purpose:        A login token object
    *   Last Updated:   15/05/16
*/

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
