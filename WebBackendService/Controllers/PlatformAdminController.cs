using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebBackendService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformAdminController : ControllerBase
    {
        private readonly ILogger _logger;
        public PlatformAdminController(ILogger<PlatformAdminController> Logger)
        {
            _logger = Logger;
        }

    }
}
