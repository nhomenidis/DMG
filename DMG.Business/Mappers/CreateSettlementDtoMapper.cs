using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using DMG.Business.Dtos;
using DMG.Business;
using DMG.Models;

namespace DMG.Business.Mappers
{
    class CreateSettlementDtoMapper : IMapper<CreateSettlementDto,Settlement>
    {
        public Settlement Map(CreateSettlementDto settlementDto)
        {
            return new Settlement
            {
                Type = settlementDto.Type,
                DateRequested = settlementDto.DateRequested,
                DownPayment = settlementDto.DownPayment,
                Installements = settlementDto.Installements,
                Interest = settlementDto.Interest,
                UserVat = settlementDto.UserVat,
                Bills = settlementDto.BillsInSettlement
            };
        }

        public IEnumerable<Settlement> Map(IEnumerable<CreateSettlementDto> settlementDtos)
        {
            throw new NotImplementedException();
        }
    }
}
