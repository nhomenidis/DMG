using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMG.Models
{
    public class SettlementBill
    {

        public int SettlementBillID { set; get; }


        public Bill Bill { get; set; }
        public Settlement Settlement { get; set; }
    }
}
