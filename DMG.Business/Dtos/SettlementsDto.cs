using System;
using System.Collections.Generic;
using DMG.Models;

namespace DMG.Business.Dtos
{
    public class SettlementsDto
    {
        public Guid Id { get; set; }
        public DateTime DateRequested { get; set; }
        public IEnumerable<BillDto> Bills { get; set; }
        public SettlementType Type { get; set; }
        public double TotalAmount { get; set; }
        public double DownPayment { get; set; }
        public int Installements { get; set; }
        public double Interest { get; set; }
        public string Vat { get; set; }
    }
}