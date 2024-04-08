using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Services.Implementations;
using WatchWise.Services.Interfaces;

namespace WatchWise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaStarsController : ControllerBase
    {
        private readonly IMediaStarService _mediaStarService;

        public MediaStarsController(IMediaStarService mediaStarService)
        {
            _mediaStarService = mediaStarService;
        }

        // GET: api/MediaStars
        [HttpGet]
        [Authorize]
        public ActionResult<List<MediaStarResponse>> GetMediaStars()
        {
            return Ok(_mediaStarService.GetAllMediaStarResponses());
        }

        // GET: api/MediaStars/Media/5
        [HttpGet("Media/{id}")]
        [Authorize]
        public ActionResult<List<MediaStarResponse>> GetMediaStarsByMediaId(int id)
        {
            return Ok(_mediaStarService.GetMediaStarResponsesByMediaId(id));
        }

        // GET: api/MediaStars/Star/5
        [HttpGet("Star/{id}")]
        [Authorize]
        public ActionResult<List<MediaStarResponse>> GetMediaStarsByStarId(short id)
        {
            return Ok(_mediaStarService.GetMediaStarResponsesByStarId(id));
        }

        // POST: api/MediaStars
        [HttpPost]
        [Authorize(Roles = "ContentManager")]
        public ActionResult PostMediaStar(MediaStarRequest mediaStarRequest)
        {
            int addResponse = _mediaStarService.PostMediaStar(mediaStarRequest);
            if (addResponse == -1)
            {
                return Conflict();
            }
            return Ok();
        }

        // DELETE: api/MediaStars/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "ContentManager")]
        public IActionResult DeleteMediaStar(MediaStarRequest mediaStarRequest)
        {
            int deleteResponse = _mediaStarService.DeleteMediaStar(mediaStarRequest);
            if (deleteResponse == -1)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
