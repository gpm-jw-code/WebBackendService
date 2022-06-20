using System;
using WebBackendService.Models.UI;

namespace WebBackendService.Models.Platform
{
	public class clsConfigs
	{
		public const string CONFIG_FILE_NAME = "Platform-Configs.config";

		public clsStartupPageMode startupPageMode = new clsStartupPageMode { PAGE_MODE = clsStartupPageMode.STARTUP_PAGE_MODE.SPEFIC_EDGE, spefic_edge_name = "iRobot" };
	}
}

