using System;
namespace WatchWise.DTOs.Requests
{
	public class LogInRequest
	{
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}

