﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DMG.Api.Controllers
{
    [Route("api/bills")]

    public class BillController : Controller
    {

        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(string id)
        {
            try
            {
               var bill = await db.BillRepository.GetById(id);

                return Ok(bill);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("{UserId")]
        public async Task<IActionResult> GetAll(string UserId)
        {
            try
            {
                var bills = await db.BillRepository.GetAll(UserId);

                return Ok(bills);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}