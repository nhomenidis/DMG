using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DMG.Models;

namespace DMG.Api.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        [HttpGet("{vat}")]
        public async Task<IActionResult> GetbyId(string vat)
        {
            try
            {
                var user = await db.UserRepository.GetById(id);


                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest();

            }

        }

    

        [HttpPatch("{oldpass}/{newpass}")]
        public IActionResult UpdateAccount(string oldpass, string newpass)
        {
            try
            {


             return Ok(true);

            }
            catch (Exception ex)
            {
                return BadRequest();

            }
         }
    
    }
}

    
