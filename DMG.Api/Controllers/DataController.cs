using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMG.AuthProvider;
using DMG.Business.Dtos;
using DMG.Business.Services;
using DMG.DatabaseContext;
using DMG.DatabaseContext.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite.Internal.IISUrlRewrite;

namespace DMG.Api.Controllers
{
    [Route("api/data")]
    public class DataController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly IParser _parser;
        private readonly IBillRepository _billRepository;

        public DataController(IUserRepository userRepository, IParser parser)
        {
            _userRepository = userRepository;
            _parser = parser;
        }

        [HttpPost] //fills database with data
        public async Task<IActionResult> Write()
        {
            var users = _parser.ParseFile();
            await _userRepository.InsertMany(users);

            
            return Ok();
        }
    }
}
