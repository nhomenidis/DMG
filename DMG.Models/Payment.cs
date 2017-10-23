using System;
using System.Collections.Generic;
using System.Text;

namespace DMG.Models
{
    public class Payment : EntityBase
    {

        public DateTime DatePerformed { set; get; }
        public DateTime DateDue { get; set; }
        public double Amount { get; set; }
        public string Method { set; get; }
        public string BillId { get; set; } // foreign key

        //navigation properties
        public Bill Bill { get; set; }
    }
}
