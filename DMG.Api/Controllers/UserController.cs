using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DMG.DatabaseContext;

namespace DMG.Api.Controllers
{
    [Route("api/users")]
    public class UserController : Controller
    {
        private UnitOfWork db;

        public UserController(UnitOfWork u)
        {
            db = u;
        }

        [HttpGet("{vat}")]
        public async Task<IActionResult> GetbyId(string id)
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

    
