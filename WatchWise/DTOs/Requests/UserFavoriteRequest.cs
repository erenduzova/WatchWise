using System;
namespace WatchWise.DTOs.Requests
{
	public class UserFavoriteRequest
    {
        public long UserId { get; set; }
        public int MediaId { get; set; }
    }
}

