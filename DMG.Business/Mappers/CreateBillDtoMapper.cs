using System;
using System.Collections.Generic;
using System.Text;
using DMG.Business.Dtos;
using DMG.Models;

namespace DMG.Business.Mappers
{
    public class CreateBillDtoMapper : IMapper<CreateBillDto, Bill>
    {
        public Bill Map(CreateBillDto billdto)
        {
            return new Bill
            {
                BillId = billdto.BillId,
                Description = billdto.Description,
                Amount = billdto.Amount,
                DateDue = billdto.DateDue,
                DatePayed = billdto.DatePayed,
                IsPayed = billdto.IsPayed,
                UserId = billdto.UserId
            };
        }

        public IEnumerable<Bill> Map(IEnumerable<CreateBillDto> billDtos)
        {
            var billsList = new List<Bill>();
            foreach (var billdto in billDtos)
            {
                var bill = Map(billdto);
                billsList.Add(bill);
            }
            return billsList;
        }
    }
}
