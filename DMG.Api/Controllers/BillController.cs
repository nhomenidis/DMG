using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DMG.Business.Dtos;
using DMG.Business.Mappers;
using DMG.Business.Services;
using DMG.Models;
using Microsoft.AspNetCore.Mvc;

namespace DMG.Api.Controllers
{
    [Route("api/bills")]
    public class BillController : Controller
    {
        private readonly IBillService _billService;
        private readonly IUserService _userService;

        public BillController(IBillService billService, IUserService userService) 
        {
            _billService = billService;
            _userService = userService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(Guid id)
        {
            var billdto = await _billService.GetBill(id);
            if (billdto == null)
            {
                return NotFound("Bill not found");
            }

            return Ok(billdto);

        }

        [HttpGet("User")]
        public async Task<IActionResult> GetByUser(UserDto userDto)
        {
            var user = await _userService.GetUserNoDto(userDto.Vat);
            var bills = await _billService.GetBillsbyUser(user);
            return Ok(bills);
        }

        [HttpGet("User/Vat")] // get bills by User's Vat
        public async Task<IActionResult> GetByUserVat(string Vat)
        {
            var bills = await _billService.GetBillsbyUserVat(Vat);
            return Ok(bills);
        }


        [HttpPost] // create a new bill
        public async Task<IActionResult> CreateBill([FromBody] CreateBillDto newBill)
        {
            var result = await _billService.CreateBill(newBill);

            return Ok(result);
        }
    }
}