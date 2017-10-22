using System;
using System.Collections.Generic;
using System.Text;

namespace DMG.Models
{
    public class Payment : EntityBase
    {

        public DateTime DatePerformed { set; get; }
        public double Amount { get; set; }
        public string Method { set; get; }

        public string BillID { get; set; }
        public Bill Bill { get; set; }
    }
}
