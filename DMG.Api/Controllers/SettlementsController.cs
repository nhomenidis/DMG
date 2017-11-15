using System.Collections.Generic;
using System.Threading.Tasks;
using DMG.Business.Dtos;
using DMG.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace DMG.Api.Controllers
{
    [Route("api/settlements")]
    public class SettlementsController : Controller
    {
        private readonly ISettlementService _settlementService;

        public SettlementsController(ISettlementService settlementService)
        {
            _settlementService = settlementService;
        }

        [HttpGet]
        [Route("types")]
        public IActionResult GetSettlementTypes()
        {
            return Ok(_settlementService.GetSettlementTypes());
        }

        [HttpPost]
        [Route("calculate")]
        public async Task<IActionResult> CalculateByType([FromBody] CreateSettlementDto settlement)
        {
            return Ok(await _settlementService.CalculateSettlement(settlement));
        }

        [HttpPost]
        public IActionResult CreateSettlement()
        {
            return Ok();
        }

    }
}
