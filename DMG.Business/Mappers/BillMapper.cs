using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DMG.Business.Dtos;
using DMG.Models;

namespace DMG.Business.Mappers
{
    class BillMapper : IMapper<Bill,BillDto>
    {
        public BillDto Map(Bill bill)
        {
            var billDto = new BillDto();
            billDto.Name = bill.User.FirstName + " " + bill.User.LastName  + " " + bill.Description;
            billDto.Amount = bill.Amount;
            billDto.DueDateTime = bill.DueDate;

            return billDto;

        }

        public IEnumerable<BillDto> Map(IEnumerable<Bill> bills)
        {
            var billsdtoList = new List<BillDto>();
            foreach(var bill in bills)
            {
              var billdto = new BillDto();
                billdto.Id = bill.Id.ToString();
                billdto.Amount = bill.Amount;
                billdto.Name = bill.User.FirstName + " " + bill.User.LastName + " " + bill.Description;
                billdto.IsPayed = bill.IsPayed;
                billdto.DueDateTime = bill.DueDate;
              billsdtoList.Add(billdto);  
            }

            return billsdtoList;



        }
    }
}
