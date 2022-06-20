using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebBackendService.Models.UI;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebBackendService.Controllers
{
    [Route("api/[controller]")]
    public class UIInitializeController : Controller
    {
        [HttpGet]
        public async Task<clsStartupPageMode> GetStartUpPageMode()
        {
            return Utilities.platformConfigs.startupPageMode;
        }
        //[HttpPost(Name ="F")]
        //public async Task<IActionResult> SetStartUpPageModeFromBody( [ FromBody] clsStartupPageMode mode)
        //{
        //    Utilities.platformConfigs.startupPageMode = mode;
        //    Utilities.SavePlotformConfig();
        //    return Ok();
        //}

        [HttpPost]
        public async Task<IActionResult> SetStartUpPageMode(clsStartupPageMode mode)
        {
            Utilities.platformConfigs.startupPageMode = mode;
            Utilities.SavePlotformConfig();
            return Ok();
        }
    }
}

