using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DMG.Models;
using Microsoft.AspNetCore.Mvc;

namespace DMG.Api.Controllers
{
    [Route("api/users")]

    public class BillsController : Controller
    {

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(string id)
        {
            try
            {
                var bill = await db.DebtRepository.GetById(id);

                return Ok(debt);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}