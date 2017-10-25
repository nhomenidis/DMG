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
        public SettlementType Type { get; set; } //we enumerate the 5 concrete types of settlements

        //navigation properties
        public ICollection<Bill> Bills { get; set; }

        public Guid UserId { get; set; } // foreign key
        public User User { get; set; }
    }

    public enum SettlementType : short
    {
        Type1 = 1,
        Type2 = 2,
        Type3 = 3,
        Type4 = 4,
        Type5 = 5
    }
}
