using System;
namespace WebBackendService.Models.USER
{
	public class User
	{
		public User()
		{
		}
		public string AccountName { get; set; } = "visitor";
		public string UserName { get; set; } = "visitor";
		public string Password { get; set; }
		public int Level { get; set; } = 0;
	}


	public class ResultBase
    {
		public bool Success { get; set; } = false;
		public string Message { get; set; } = "";
		public string UserName { get; set; }

	}

	public class LoginResult:ResultBase
    {
		public int Level { get; set; } = 0;
	}

	public class RegistResult : ResultBase
    {

    }

}

