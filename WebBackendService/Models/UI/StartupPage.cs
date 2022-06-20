using System;
namespace WebBackendService.Models.UI
{
	public class clsStartupPageMode
	{
		public enum STARTUP_PAGE_MODE
        {
			/// <summary>
            /// 可以選擇Edge
            /// </summary>
			SELECT_EDGE,
			/// <summary>
            /// 直接使用指定的Edge
            /// </summary>
			SPEFIC_EDGE
        }

		public clsStartupPageMode()
		{

		}

		public STARTUP_PAGE_MODE PAGE_MODE { get; set; } = STARTUP_PAGE_MODE.SELECT_EDGE;
		public string page_mode => PAGE_MODE.ToString();
		public string spefic_edge_name { get; set; } = "iRobot";
	}
}

