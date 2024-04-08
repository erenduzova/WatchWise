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
    public class MediaDirectorsController : ControllerBase
    {
        private readonly IMediaDirectorService _mediaDirectorService;

        public MediaDirectorsController(IMediaDirectorService mediaDirectorService)
        {
            _mediaDirectorService = mediaDirectorService;
        }

        // GET: api/MediaDirectors
        [HttpGet]
        public ActionResult<List<MediaDirectorResponse>> GetMediaDirectors()
        {
            return Ok(_mediaDirectorService.GetAllMediaDirectorResponses());
        }

        // GET: api/MediaDirectors/Media/5
        [HttpGet("Media/{id}")]
        [Authorize]
        public ActionResult<List<MediaDirectorResponse>> GetMediaDirectorsByMediaId(int id)
        {
            return Ok(_mediaDirectorService.GetMediaDirectorResponsesByMediaId(id));
        }

        // GET: api/MediaDirectors/Director/5
        [HttpGet("Director/{id}")]
        [Authorize]
        public ActionResult<List<MediaDirectorResponse>> GetMediaDirectorsByDirectorId(short id)
        {
            return Ok(_mediaDirectorService.GetMediaDirectorResponsesByDirectorId(id));
        }

        // POST: api/MediaDirectors
        [HttpPost]
        [Authorize(Roles = "ContentManager")]
        public ActionResult PostMediaDirector(MediaDirectorRequest mediaDirectorRequest)
        {
            int addResponse = _mediaDirectorService.PostMediaDirector(mediaDirectorRequest);
            if (addResponse == -1)
            {
                return Conflict();
            }
            return Ok();
        }

        // DELETE: api/MediaDirectors/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "ContentManager")]
        public IActionResult DeleteMediaDirector(MediaDirectorRequest mediaDirectorRequest)
        {
            int deleteResponse = _mediaDirectorService.DeleteMediaDirector(mediaDirectorRequest);
            if (deleteResponse == -1)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
