using WebBackendService.Models.DistributionSystem;
using WebBackendService.Models.UI;

namespace WebBackendService.Models.Platform
{
    public class clsConfigs
    {
        private clsNetworkConfig _networkConfigs = new clsNetworkConfig();

        public const string CONFIG_FILE_NAME = "Platform-Configs.config";
        public clsStartupPageMode startupPageMode { get; set; } = new() { PAGE_MODE = clsStartupPageMode.STARTUP_PAGE_MODE.SPEFIC_EDGE, spefic_edge_name = "iRobot" };

        public clsNetworkConfig networkConfigs
        {
            get => _networkConfigs;
            set
            {
                _networkConfigs = value;
                Utilities.SavePlotformConfig();
            }
        }
    }
}

