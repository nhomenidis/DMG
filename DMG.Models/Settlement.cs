using System;
using System.Collections.Generic;
using System.Text;

namespace DMG.Models
{
   public class Settlement : EntityBase
    {
        public double DownPayment { get; set; }
        public int Installements { get; set; }
        public double Interest { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; } // foreign key
        public string TypeofSettlement { get; set; } // how can we enumerate the 5 concrete types of settlements?


        //navigation properties
        public IEnumerable<Bill> Bills { get; set; }
        public User User { get; set; }
    }
}
