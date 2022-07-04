namespace WebBackendService.Models.DistributionSystem
{
    public class clsNetworkConfig
    {
        public string ControlCenterWsHost { get; set; } = "ws://192.168.0.201:8090";
        public string IDMSWsHost { get; set; } = "ws://192.168.0.201:44332";
    }
}
