using Microsoft.AspNetCore.Mvc;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
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
        public ActionResult<List<UserWatchedEpisodeResponse>> GetUserWatchedEpisodes()
        {
            return Ok(_userWatchedEpisodeService.GetAllUserWatchedEpisodeResponses());
        }

        // GET: api/UserWatchedEpisodes/User/5
        [HttpGet("User/{userId}")]
        public ActionResult<List<UserWatchedEpisodeResponse>> GetUserWatchedEpisodesByUserId(long userId)
        {
            return Ok(_userWatchedEpisodeService.GetUserWatchedEpisodeResponsesByUserId(userId));
        }

        // GET: api/UserWatchedEpisodes/Episode/5
        [HttpGet("Episode/{episodeId}")]
        public ActionResult<List<UserWatchedEpisodeResponse>> GetUserWatchedEpisodesByEpisodeId(long episodeId)
        {
            return Ok(_userWatchedEpisodeService.GetUserWatchedEpisodeResponsesByEpisodeId(episodeId));
        }

        // POST: api/UserWatchedEpisodes
        [HttpPost]
        public ActionResult PostUserWatchedEpisode(UserWatchedEpisodeRequest userWatchedEpisodeRequest)
        {
            _userWatchedEpisodeService.AddUserWatchedEpisode(userWatchedEpisodeRequest);
            return Ok();
        }

        // DELETE: api/UserWatchedEpisodes
        [HttpDelete]
        public IActionResult DeleteUserWatchedEpisode(UserWatchedEpisodeRequest userWatchedEpisodeRequest)
        {
            int deleteResponse = _userWatchedEpisodeService.RemoveUserWatchedEpisode(userWatchedEpisodeRequest);
            if (deleteResponse == -1)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
