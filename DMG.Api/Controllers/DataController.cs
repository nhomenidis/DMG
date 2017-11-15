using System.Threading.Tasks;
using DMG.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace DMG.Api.Controllers
{
    [Route("api/data")]
    public class DataController : Controller
    {
        private readonly IParser _parser;

        public DataController(IParser parser)
        {
            _parser = parser;
        }

        [HttpPost] //fills database with data
        public async Task<IActionResult> Write([FromForm]string filePath, [FromForm] int batchSize)
        {
                await _parser.ParseFile(filePath, batchSize);
                return Ok();
        }
    }
}
