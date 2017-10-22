using System;
using System.Collections.Generic;
using System.Text;

namespace DMG.Models
{
    public class SettlementType : EntityBase
    {
        public double DownpaymentPct { get; set; }
        public int MaxNoOfInstallments { get; set; }
        public double Interest { get; set; }
    }
}



