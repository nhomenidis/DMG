using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMG.Business.Dtos;
using DMG.DatabaseContext.Repositories;
using DMG.Models;

namespace DMG.Business.Services
{
    public interface ISettlementService
    {
        IEnumerable<SettlementTypeDto> GetSettlementTypes();
        Task<CalculatedSettlementDto> CalculateSettlement(CreateSettlementDto settlement);
    }

    public class SettlementService : ISettlementService
    {
        private readonly IBillRepository _billRepository;
        private ISettlementCalculator _settlementCalculator;


        public SettlementService(IBillRepository billRepository, ISettlementCalculator settlementCalculator)
        {
            _billRepository = billRepository;
            _settlementCalculator = settlementCalculator;
        }

        public async Task<CalculatedSettlementDto> CalculateSettlement(CreateSettlementDto settlement)
        {
            var bills = new List<Bill>(settlement.Bills.Count);
            foreach (var billid in settlement.Bills)
            {
                var bill = await _billRepository.GetById(billid);
                bills.Add(bill);
            }
            var s = new Settlement()
            {
                Bills = bills,
                Type = settlement.Type,
                Installements = settlement.Installements
            };

            return _settlementCalculator.CalculateSettlement(s);
        }

        public IEnumerable<SettlementTypeDto> GetSettlementTypes()
        {
            var values = Enum.GetValues(typeof(SettlementType)).Cast<SettlementType>();
            return values.Select(value =>
            {
                var type = typeof(SettlementType);
                var memInfo = type.GetMember(value.ToString());
                var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                var description = ((DescriptionAttribute)attributes[0]).Description;

                return new SettlementTypeDto()
                {
                    TypeName = value.ToString(),
                    TypeNumber = (short) value,
                    Formula = description
                };
            });
        }
    }
}
