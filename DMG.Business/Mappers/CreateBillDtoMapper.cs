using System;
using System.Collections.Generic;
using System.Text;
using DMG.Business.Dtos;
using DMG.Models;

namespace DMG.Business.Mappers
{
    public class CreateBillDtoMapper : IMapper<CreateBillDto, Bill>
    {
        public Bill Map(CreateBillDto billDto)
        {
            return new Bill
            {
                Description = billDto.Description,
                Amount = billDto.Amount,
                DueDate = billDto.DueDate,
                IsPayed = billDto.IsPayed,
                UserId = billDto.UserId
            };
        }

        public IEnumerable<Bill> Map(IEnumerable<CreateBillDto> billDtos)
        {
            throw new NotImplementedException();
        }
    }
}
