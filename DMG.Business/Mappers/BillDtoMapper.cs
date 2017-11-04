using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DMG.Business.Dtos;
using DMG.Models;

namespace DMG.Business.Mappers
{
   public class BillDtoMapper : IMapper<BillDto,Bill>
    {
        interface IBillDtoMapper
        {
            Bill Map(BillDto billdto);
            IEnumerable<Bill> Map(IEnumerable<BillDto> bills);
        }

       
        public Bill Map(BillDto billdto)
        {
            var bill = new Bill();
            {
                bill.UserId = billdto.UserId;
                bill.Amount = billdto.Amount;
                bill.User.FirstName = billdto?.UserFirstName;
                bill.User.LastName = billdto?.UserLastName;
                bill.Description = billdto.Description;
                bill.IsPayed = billdto.IsPayed;
                bill.DateDue = billdto.DateDue;
                bill.DatePayed = billdto.DatePayed;
                bill.UserVat = billdto.Vat;
            }

            return bill;

        }

        public IEnumerable<Bill> Map(IEnumerable<BillDto> billDtos)
        {
            var billstoList = new List<Bill>();
            foreach(var billdto in billDtos)
            {
              var bill = Map(billdto); // Maps each billdto in billDtos to bill
              billstoList.Add(bill);  
            }
            return billstoList;
        }
    }
}
