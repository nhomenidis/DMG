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
                DateRequested = DateTime.Now,
                Installements = settlementDto.Installements,
                UserVat = settlementDto.UserVat,
            };
        }

        public IEnumerable<Settlement> Map(IEnumerable<CreateSettlementDto> settlementDtos)
        {
            throw new NotImplementedException();
        }
    }
}
