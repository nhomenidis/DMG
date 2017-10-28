using System;
using System.Collections.Generic;
using DMG.Models;

namespace DMG.Business.Dtos
{
    public class CreateSettlementDto
    {
        public SettlementType Type { get; set; }
        public int Installements { get; set; }
        public string Vat { get; set; }
        public IEnumerable<BillDto> BillsInSettlement { get; set; }
        
    }
}