using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBackendService.Models.DistributionSystem;

namespace WebBackendService.Controllers.Networks
{
    [Route("api/[controller]")]
    [ApiController]
    public class NetworkController : ControllerBase
    {
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(Utilities.platformConfigs.networkConfigs);
        }

        [HttpGet("Control_Center_Websocket_Host")]
        public async Task<IActionResult> Control_Center_Websocket_Host()
        {
            return Ok(Utilities.platformConfigs.networkConfigs.ControlCenterWsHost);
        }

        [HttpGet("IDMS_Websocket_Host")]
        public async Task<IActionResult> IDMS_Websocket_Host()
        {
            return Ok(Utilities.platformConfigs.networkConfigs.IDMSWsHost);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]clsNetworkConfig networkConfig)
        {
            Utilities.platformConfigs.networkConfigs = networkConfig;
            return Ok();
        }

    }
}
