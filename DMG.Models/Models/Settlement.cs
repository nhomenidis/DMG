using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMG.Models
{
    public class Settlement
    {
        
        public int SettlementID { set; get; }
        
        public string AllBills { set; get; }
        public string SettlementType { set; get;}
        public float DownPayment { set; get; }
        public int Installements { set; get; }
         public float Interest { set; get; }
        public float InstallmentAmount { set; get; }


        public User User { get; set; }
        public ICollection<SettlementBill> SettlementBills { get; set; }
       
    }
}
