using System.Collections.Generic;
using System.Threading.Tasks;
using DMG.AuthProvider;
using DMG.Business.Dtos;
using DMG.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace DMG.Api.Controllers
{
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{vat}")] // gets user info by VAT
        [ProducesResponseType(typeof(IEnumerable<UserDto>), 200)]
        [ProducesResponseType(typeof(ErrorDto), 404)]
        public async Task<IActionResult> Get(string vat)
        {
            var userdto = await _userService.GetUser(vat);
            if (userdto == null)
            {
                return NotFound(
                    new ErrorDto()
                    {
                        Description = "User not found",
                        StatusCode = 404
                    }
                );
            }
            return Ok(userdto);
        }

        [HttpGet] // get all users
        public async Task<IActionResult> GetAll()
        {
            var usersdto = await _userService.GetAll();
            return Ok(usersdto);
        }

        [HttpPatch("{vat}/password")] // change password
        public async Task<IActionResult> UpdateAccount(string vat, [FromBody]PasswordReset resetRequest)
        {
            var oldPassword = resetRequest.OldPassword;
            var newPassword = resetRequest.NewPassword;
            var result = await _userService.ChangePassword(vat, oldPassword, newPassword);
            if (result)
            {
                return Ok();
            }
            return Unauthorized();
        }

        [HttpPost] // create a new user
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto newUser)
        {
            var result = await _userService.CreateUser(newUser);

            return Ok(result);
        }

        //[HttpPatch("{newEmail}")] //change email
        //public IActionResult ChangeMail(string newEmail)
        //{
        //    var userservice = new UserService();


        //}

    }
}
