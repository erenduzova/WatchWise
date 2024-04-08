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
    public class MediaGenresController : ControllerBase
    {
        private readonly IMediaGenreService _mediaGenreService;

        public MediaGenresController(IMediaGenreService mediaGenreService)
        {
            _mediaGenreService = mediaGenreService;
        }

        // GET: api/MediaGenres
        [HttpGet]
        [Authorize]
        public ActionResult<List<MediaGenreResponse>> GetMediaGenres()
        {
            return Ok(_mediaGenreService.GetAllMediaGenreResponses());
        }

        // GET: api/MediaGenres/Media/5
        [HttpGet("Media/{id}")]
        [Authorize]
        public ActionResult<List<MediaGenreResponse>> GetMediaGenresByMediaId(int id)
        {
            return Ok(_mediaGenreService.GetMediaGenreResponsesByMediaId(id));
        }

        // GET: api/MediaGenres/Genre/5
        [HttpGet("Genre/{id}")]
        [Authorize]
        public ActionResult<List<MediaGenreResponse>> GetMediaGenresByGenreId(short id)
        {
            return Ok(_mediaGenreService.GetMediaGenreResponsesByGenreId(id));
        }

        // POST: api/MediaGenres
        [HttpPost]
        [Authorize(Roles = "ContentManager")]
        public ActionResult PostMediaGenre(MediaGenreRequest mediaGenreRequest)
        {
            int addResponse = _mediaGenreService.PostMediaGenre(mediaGenreRequest);
            if (addResponse == -1)
            {
                return Conflict();
            }
            return Ok();
        }

        // DELETE: api/MediaGenres
        [HttpDelete]
        [Authorize(Roles = "ContentManager")]
        public IActionResult DeleteMediaGenre(MediaGenreRequest mediaGenreRequest)
        {
            int deleteResponse = _mediaGenreService.DeleteMediaGenre(mediaGenreRequest);
            if (deleteResponse == -1)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
