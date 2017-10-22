﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMG.AuthProvider;
using DMG.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace DMG.Api.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        [HttpGet("{vat}")]
        public IActionResult Get(string vat)
        {
            var userservice = new UserService();
            var userdto = userservice.GetUser(vat);
            return Ok(userdto);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var userservice = new UserService();
            var usersdto = userservice.GetAll();
            return Ok(usersdto);
        }

        [HttpPatch("{changePass}")]
        public IActionResult UpdateAccount(PasswordReset newpass)
        {
            var userservice = new UserService();

            return Ok();

        }

    }
}
