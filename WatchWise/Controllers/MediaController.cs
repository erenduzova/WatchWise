using Microsoft.AspNetCore.Mvc;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Services.Implementations;
using WatchWise.Services.Interfaces;

namespace WatchWise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        // GET: api/Media
        [HttpGet]
        public ActionResult<List<MediaResponse>> GetMedias(bool includeMediaGenres = false
            , bool includeMediaStars = false
            , bool includeMediaDirectors = false
            , bool includeMediaRestrictions = false)
        {
            return Ok(_mediaService.GetAllMediaResponses(includeMediaGenres
                , includeMediaStars
                , includeMediaDirectors
                , includeMediaRestrictions));
        }

        // GET: api/Media/5
        [HttpGet("{id}")]
        public ActionResult<MediaResponse> GetMedia(int id
            , bool includeMediaGenres = false
            , bool includeMediaStars = false
            , bool includeMediaDirectors = false
            , bool includeMediaRestrictions = false)
        {
            MediaResponse? mediaResponse = _mediaService.GetMediaResponseById(id, includeMediaGenres
                , includeMediaStars
                , includeMediaDirectors
                , includeMediaRestrictions);
            if (mediaResponse == null)
            {
                return NotFound();
            }
            return mediaResponse;
        }

        // PUT: api/Media/5
        [HttpPut("{id}")]
        public ActionResult PutMedia(int id, MediaRequest mediaRequest)
        {
            int updateResponse = _mediaService.UpdateMedia(id, mediaRequest);
            if (updateResponse == -1)
            {
                return NotFound();
            }
            return Ok();
        }

        // POST: api/Media
        [HttpPost]
        public ActionResult PostMedia(MediaRequest mediaRequest)
        {
            int addResponse = _mediaService.PostMedia(mediaRequest);
            if (addResponse == -1)
            {
                return Conflict();
            }
            return Ok();
        }

        // DELETE: api/Media/5
        [HttpDelete("{id}")]
        public ActionResult DeleteMedia(int id)
        {
            int deleteResponse = _mediaService.DeleteMedia(id);
            if (deleteResponse == -1)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
