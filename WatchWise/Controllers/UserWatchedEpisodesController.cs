using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Services.Implementations;
using WatchWise.Services.Interfaces;

namespace WatchWise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserWatchedEpisodesController : ControllerBase
    {
        private readonly IUserWatchedEpisodeService _userWatchedEpisodeService;

        public UserWatchedEpisodesController(IUserWatchedEpisodeService userWatchedEpisodeService)
        {
            _userWatchedEpisodeService = userWatchedEpisodeService;
        }

        // GET: api/UserWatchedEpisodes
        [HttpGet]
        [Authorize(Roles = "ContentManager")]
        public ActionResult<List<UserWatchedEpisodeResponse>> GetUserWatchedEpisodes()
        {
            return Ok(_userWatchedEpisodeService.GetAllUserWatchedEpisodeResponses());
        }

        // GET: api/UserWatchedEpisodes/User/5
        [HttpGet("User/{userId}")]
        [Authorize(Roles = "ContentManager,Subscriber")]
        public ActionResult<List<UserWatchedEpisodeResponse>> GetUserWatchedEpisodesByUserId(long userId)
        {
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != userId.ToString() || User.IsInRole("ContentManager") == false)
            {
                return Unauthorized();
            }
            return Ok(_userWatchedEpisodeService.GetUserWatchedEpisodeResponsesByUserId(userId));
        }

        // GET: api/UserWatchedEpisodes/Episode/5
        [HttpGet("Episode/{episodeId}")]
        [Authorize(Roles = "ContentManager")]
        public ActionResult<List<UserWatchedEpisodeResponse>> GetUserWatchedEpisodesByEpisodeId(long episodeId)
        {
            return Ok(_userWatchedEpisodeService.GetUserWatchedEpisodeResponsesByEpisodeId(episodeId));
        }

        // POST: api/UserWatchedEpisodes
        [HttpPost]
        [Authorize(Roles = "Subscriber")]
        public ActionResult PostUserWatchedEpisode(UserWatchedEpisodeRequest userWatchedEpisodeRequest)
        {
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != userWatchedEpisodeRequest.UserId.ToString())
            {
                return Unauthorized();
            }
            int addResponse = _userWatchedEpisodeService.AddUserWatchedEpisode(userWatchedEpisodeRequest);
            if (addResponse == -1)
            {
                return Conflict();
            }
            return Ok();
        }

        // DELETE: api/UserWatchedEpisodes
        [HttpDelete]
        [Authorize(Roles = "Subscriber")]
        public ActionResult DeleteUserWatchedEpisode(UserWatchedEpisodeRequest userWatchedEpisodeRequest)
        {
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != userWatchedEpisodeRequest.UserId.ToString())
            {
                return Unauthorized();
            }
            int deleteResponse = _userWatchedEpisodeService.RemoveUserWatchedEpisode(userWatchedEpisodeRequest);
            if (deleteResponse == -1)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
