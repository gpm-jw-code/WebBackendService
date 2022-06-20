using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebBackendService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformAdminController : ControllerBase
    {
        private readonly ILogger _logger;
        public PlatformAdminController()
        {
        }

        [HttpGet("Login", Name = "")]
        public async Task<IActionResult> Login()
        {
            return Ok("fuck u");
        }
    }
}
