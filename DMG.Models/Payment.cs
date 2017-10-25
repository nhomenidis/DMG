using System;
using System.Collections.Generic;
using System.Text;

namespace DMG.Models
{
    public class Payment : EntityBase
    {
        public DateTime DatePerformed { set; get; }
        public double Amount { get; set; }
        public PaymentMethod Method { set; get; }

        public Guid BillId { get; set; } // foreign key
        public Bill Bill { get; set; } //navigation properties
    }

    public enum PaymentMethod
    {
        CreditCard = 0,
        Other = 1
    }
}
