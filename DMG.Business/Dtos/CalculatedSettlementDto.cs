using System;
using System.Collections.Generic;
using System.Text;

namespace DMG.Business.Dtos
{
    public class CalculatedSettlementDto
    {
        public double DownPayment { get; set; }
        public int Installements { get; set; }
        public double Interest { get; set; }
        public double InstallementAmount { get; set; }  
    }
}
