using System;
using System.Collections.Generic;

namespace DMG.Business.Dtos
{
    public class SettlementsDto
    {
        public Guid Id { get; set; }
        public DateTime DateRequeste { get; set; }
        public IEnumerable<BillDto> Bills { get; set; }
        public double TotalAmount { get; set; }
        public double DownPayment { get; set; }
        public int Installements { get; set; }
        public double Interest { get; set; }
        public string Vat { get; set; }

    }
}