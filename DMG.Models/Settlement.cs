using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DMG.Models
{
    public class Settlement : EntityBase
    {
        public double DownPayment { get; set; }
        public int Installements { get; set; }
        public double Interest { get; set; }
        public DateTime DateRequested { get; set; }
        public SettlementType Type { get; set; } //we enumerate the 5 concrete types of settlements

        //navigation properties
        public ICollection<Bill> Bills { get; set; }

        public Guid UserId { get; set; } // foreign key
        public string UserVat { get; set; }
    }

    public enum SettlementType : short
    {
        [Description("10% Down payment, up to 24 installments, 4.1% interest")]
        Type1 = 1,
        [Description("10% Down payment, up to 24 installments, 4.1% interest")]
        Type2 = 2,
        [Description("10% Down payment, up to 24 installments, 4.1% interest")]
        Type3 = 3,
        [Description("10% Down payment, up to 24 installments, 4.1% interest")]
        Type4 = 4,
        [Description("10% Down payment, up to 24 installments, 4.1% interest")]
        Type5 = 5
    }
}
