using System;
using System.Linq;
using DMG.Business.Dtos;
using DMG.Models;

namespace DMG.Business.Services
{
    public interface ISettlementCalculator
    {
        CalculatedSettlementDto CalculateSettlement(Settlement settlement);
    }

    public class SettlementCalculator : ISettlementCalculator
    {
        private double _totalamount;
        private double _downPayment;
        private double _interest;
        private int _installements;


        public CalculatedSettlementDto CalculateSettlement(Settlement settlement)
        {
            _totalamount = settlement.Bills.Sum(bill => bill.Amount);

            switch (settlement.Type)
            {
                case SettlementType.Type1:
                    _downPayment = _totalamount * 0.1;
                    _interest = 4.1 / 100;
                    break;
                case SettlementType.Type2:
                    _downPayment = _totalamount * 0.2;
                    _interest = 3.9 / 100;
                    break;

                case SettlementType.Type3:
                    _downPayment = _totalamount * 0.3;
                    _interest = 3.6 / 100;
                    break;

                case SettlementType.Type4:
                    _downPayment = _totalamount * 0.4;
                    _interest = 3.2 / 100;
                    break;

                case SettlementType.Type5:
                    _downPayment = _totalamount * 0.5;
                    _interest = 2.6 / 100;
                    break;
            }


            var installementAmmount = Calculator(settlement);
            return new CalculatedSettlementDto()
            {
                DownPayment = _downPayment,
                InstallementAmount = installementAmmount,
                Interest = _interest,
                Installements = _installements
            };
        }

        public double Calculator(Settlement settlement)
        {
            _totalamount = settlement.Bills.Sum(bill => bill.Amount);
            _installements = settlement.Installements;


            double installement = ((_totalamount - _downPayment) * _interest *
                                  Math.Pow(1 + _interest, _installements)) /
                                  ((Math.Pow(1 + _interest, _installements)) - 1);

            return installement;
        }
    }
}