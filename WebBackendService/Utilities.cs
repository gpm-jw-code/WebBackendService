using System;
using Newtonsoft.Json;
using WebBackendService.Models.Platform;

namespace WebBackendService
{
	public class Utilities
	{
		public static clsConfigs platformConfigs = new clsConfigs();

        #region Internal

        internal static void LoadPlatformConfig()
        {
            if (File.Exists(clsConfigs.CONFIG_FILE_NAME))
            {
                platformConfigs = JsonConvert.DeserializeObject<clsConfigs>(File.ReadAllText(clsConfigs.CONFIG_FILE_NAME));
            }
            else
            {
                SavePlotformConfig();
            }
        }

        internal static void SavePlotformConfig()
        {
            File.WriteAllText(clsConfigs.CONFIG_FILE_NAME, JsonConvert.SerializeObject(platformConfigs, Formatting.Indented));

        }

        #endregion
    }
}

