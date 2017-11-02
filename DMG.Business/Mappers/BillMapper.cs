using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DMG.Business.Dtos;
using DMG.Models;

namespace DMG.Business.Mappers
{
   public class BillMapper : IMapper<Bill,BillDto>
    {
        interface IBillMapper
        {
            BillDto Map(Bill bill);
            IEnumerable<BillDto> Map(IEnumerable<Bill> bills);
        }

       
        public BillDto Map(Bill bill)
        {
            var billDto = new BillDto();
            {
                billDto.UserId = bill.UserId;
                billDto.Amount = bill.Amount;
                billDto.UserFirstName = bill.User?.FirstName;
                billDto.UserLastName = bill.User?.LastName;
                billDto.Description = bill.Description;
                billDto.IsPayed = bill.IsPayed;
                billDto.DateDue = bill.DateDue;
                billDto.DatePayed = bill.DatePayed;
                billDto.Vat = bill.UserVat;
            }

            return billDto;

        }

        public IEnumerable<BillDto> Map(IEnumerable<Bill> bills)
        {
            var billsdtoList = new List<BillDto>();
            foreach(var bill in bills)
            {
              var billDto = Map(bill); // Maps each bill in bills
              billsdtoList.Add(billDto);  
            }
            return billsdtoList;
        }
    }
}
