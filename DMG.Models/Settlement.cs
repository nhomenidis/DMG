using System;
using System.Collections.Generic;
using System.Text;

namespace DMG.Models
{
   public class Settlement:EntityBase
    {
      
        public string AllBills { set; get; }
        public string SettlementType { set; get; }
        public float DownPayment { set; get; }
        public int Installements { set; get; }
        public float Interest { set; get; }
        public float InstallmentAmount { set; get; }
        
        public User User { get; set; }
        //public ICollection<SettlementBill> SettlementBills { get; set; }
    }
}
