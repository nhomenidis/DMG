using System;
using System.Linq;
using DMG.Models;

namespace DMG.Business.Services
{
    public class CalculateSettlements
    {
        private double _totalamount;
        private double _downPayment;
        private double _interest;
        private int _installements;


        public double CalculateInstallement(Settlement settlement)
        {
            _totalamount = settlement.Bills.Sum(bill => bill.Amount);

            if (settlement.Type == SettlementType.Type1)
            {
                _downPayment = _totalamount * 0.1;
            }
            if (settlement.Type == SettlementType.Type2)
            {
                _downPayment = _totalamount * 0.2;
            }
            if (settlement.Type == SettlementType.Type3)
            {
                _downPayment = _totalamount * 0.3;
            }
            if (settlement.Type == SettlementType.Type4)
            {
                _downPayment = _totalamount * 0.4;
            }
            if (settlement.Type == SettlementType.Type5)
            {
                _downPayment = _totalamount * 0.5;
            }
            return Calculator(settlement);
        }

        public double Calculator(Settlement settlement)
        {
            _totalamount = settlement.Bills.Sum(bill => bill.Amount);
            _interest = settlement.Interest;
            _installements = settlement.Installements;
            
            
            double installement = (_totalamount - _downPayment) * _interest *
                                  Math.Pow(1 + _interest, _installements) /
                                  Math.Pow(1 + _interest, _installements- 1);

            return installement;
        }
    }
}