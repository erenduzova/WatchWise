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
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        // GET: api/Genres
        [HttpGet]
        [Authorize]
        public ActionResult<List<GenreResponse>> GetGenres(bool includeMedia = false)
        {
            return Ok(_genreService.GetAllGenreResponses(includeMedia));
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<GenreResponse> GetGenre(short id, bool includeMedia = false)
        {
            GenreResponse? genreResponse = _genreService.GetGenreResponseById(id, includeMedia);
            if (genreResponse == null)
            {
                return NotFound();
            }
            return genreResponse;
        }

        // PUT: api/Genres/5
        [HttpPut("{id}")]
        [Authorize(Roles = "ContentManager")]
        public ActionResult PutGenre(short id, GenreRequest genreRequest)
        {
            int updateResponse = _genreService.UpdateGenre(id, genreRequest);
            if (updateResponse == -1)
            {
                return NotFound();
            }
            return Ok();
        }

        // POST: api/Genres
        [HttpPost]
        [Authorize(Roles = "ContentManager")]
        public ActionResult PostGenre(GenreRequest genreRequest)
        {
            int addResponse = _genreService.PostGenre(genreRequest);
            if (addResponse == -1)
            {
                return Conflict();
            }
            return Ok();
        }

    }
}
