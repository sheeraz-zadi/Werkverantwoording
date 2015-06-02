using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Werkverantwoording.Models
{
    public class Day
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int ProgressID { get; set; }
        public bool Completed { get; set; }
        public DateTime Submitted { get; set; }
    }
}