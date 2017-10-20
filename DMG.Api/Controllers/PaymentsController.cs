using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DMG.Api.Controllers
{
    [Route("api/payments")]

    public class PaymentController : Controller
    {

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(string id)
        {
            try
            {
                var payment = await db.PaymentRepository.GetById(id);

                return Ok(payment);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{UserId")]
        public async Task<IActionResult> GetAll(string id)
        {
            try
            {
                var payments = await db.PaymentRepository.GetAll(id);

                return Ok(payments);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}