using System;
using System.Collections.Generic;
using DMG.Models;

namespace DMG.Business.Dtos
{
    public class CreateSettlementDto
    {
        public string UserVat { get; set; }
        public double DownPayment { get; set; }
        public int Installements { get; set; }
        public double Interest { get; set; }
        public SettlementType Type { get; set; }
        public DateTime DateRequested { get; set; }
        public ICollection<Bill> BillsInSettlement { get; set; } // we have to change this to DillDto instead of Bill
        
    }
}