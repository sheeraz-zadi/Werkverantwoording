using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Werkverantwoording.Models
{
    public class Progress
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public int TaskID { get; set; }
        public bool Completed { get; set; }
    }
}