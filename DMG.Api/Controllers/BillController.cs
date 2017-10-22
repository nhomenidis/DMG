using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DMG.Business.Dtos;
using DMG.Business.Services;
using DMG.Models;
using Microsoft.AspNetCore.Mvc;

namespace DMG.Api.Controllers
{
    [Route("api/bills")]

    public class BillController : Controller
    {

        [HttpGet("{id}")]
        public IActionResult GetbyId(string id)
        {
            var billservice = new BillService();
            var billdto = billservice.GetBill(id);
            return Ok(billdto);

        }

        [HttpGet]
        public IActionResult GetByUser(User user)
        {
            var billservice = new BillService();
            var billdto = billservice.GetBillsbyUser(user);
            return Ok(billdto);
        }
    }
}