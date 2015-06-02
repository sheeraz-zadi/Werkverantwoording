using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Werkverantwoording.Models
{
    public class Progress
    {
        public int ID { get; set; }
        public int taskID { get; set; }
        public int dayID { get; set; }
    }
}