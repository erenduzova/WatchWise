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
    public class EpisodesController : ControllerBase
    {
        private readonly IEpisodeService _episodeService;

        public EpisodesController(IEpisodeService episodeService)
        {
            _episodeService = episodeService;
        }

        // GET: api/Episodes
        [HttpGet]
        [Authorize]
        public ActionResult<List<EpisodeResponse>> GetEpisodes()
        {
            return _episodeService.GetAllEpisodeResponses();
        }

        // GET: api/Episodes/5
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<EpisodeResponse> GetEpisode(long id)
        {
            EpisodeResponse? episodeResponse = _episodeService.GetEpisodeResponseById(id);
            if (episodeResponse == null)
            {
                return NotFound();
            }
            return episodeResponse;
        }

        // PUT: api/Episodes/5
        [HttpPut("{id}")]
        [Authorize(Roles = "ContentManager")]
        public ActionResult PutEpisode(long id, EpisodeUpdateRequest episodeUpdateRequest)
        {
            int updateResponse = _episodeService.UpdateEpisode(id, episodeUpdateRequest);
            if (updateResponse == -1)
            {
                return NotFound();
            }
            return Ok();
        }

        // POST: api/Episodes
        [HttpPost]
        [Authorize(Roles = "ContentManager")]
        public ActionResult PostEpisode(EpisodeRequest episodeRequest)
        {
            int addResponse = _episodeService.PostEpisode(episodeRequest);
            if (addResponse == -1)
            {
                return Conflict();
            }
            return Ok();
        }

        // DELETE: api/Episodes/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "ContentManager")]
        public ActionResult DeleteEpisode(long id)
        {
            int deleteResponse = _episodeService.DeleteEpisode(id);
            if (deleteResponse == -1)
            {
                return NotFound();
            }
            return NoContent();
        }

        // PUT: api/Episodes/Watch/5
        [HttpPut("Watch/{id}")]
        [Authorize(Roles = "Subscriber")]
        public ActionResult Watch(long id)
        {
            long userId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            int watchResult = _episodeService.Watch(id, userId);
            if (watchResult == -1)
            {
                return NotFound();
            }
            return Ok();
        }

    }
}
