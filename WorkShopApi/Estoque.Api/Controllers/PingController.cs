using Microsoft.AspNetCore.Mvc;

namespace Estoque.Api.Controllers
{
    [Route("api")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet]
        [Route("ping")]
        public IActionResult Ping()
        {
            return Ok("Pingou");
        }
    }
}