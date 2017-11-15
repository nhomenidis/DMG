using System;
using System.Collections.Generic;
using DMG.Models;

namespace DMG.Business.Dtos
{
    public class CreateSettlementDto
    {
        public string UserVat { get; set; }
        public int Installements { get; set; }
        public SettlementType Type { get; set; }
        public ICollection<Guid> Bills { get; set; } // we have to change this to DillDto instead of Bill
    }
}