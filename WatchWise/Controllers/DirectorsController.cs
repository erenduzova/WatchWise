using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Services.Interfaces;

namespace WatchWise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorService _directorService;

        public DirectorsController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        // GET: api/Directors
        [HttpGet]
        [Authorize]
        public ActionResult<List<DirectorResponse>> GetDirectors(bool includeMedia = false)
        {
            return Ok(_directorService.GetAllDirectorResponses(includeMedia));
        }

        // GET: api/Directors/5
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<DirectorResponse> GetDirector(int id, bool includeMedia = false)
        {
            DirectorResponse? directorResponse = _directorService.GetDirectorResponseById(id, includeMedia);
            if (directorResponse == null)
            {
                return NotFound();
            }
            return directorResponse;
        }

        // PUT: api/Directors/5
        [HttpPut("{id}")]
        [Authorize(Roles = "ContentManager")]
        public ActionResult PutDirector(int id, DirectorRequest directorRequest)
        {
            int updateResponse = _directorService.UpdateDirector(id, directorRequest);
            if (updateResponse == -1)
            {
                return NotFound();
            }
            return Ok();
        }

        // POST: api/Directors
        [HttpPost]
        [Authorize(Roles = "ContentManager")]
        public ActionResult PostDirector(DirectorRequest directorRequest)
        {
            int addResponse = _directorService.PostDirector(directorRequest);
            if (addResponse == -1)
            {
                return Conflict();
            }
            return Ok();
        }

        // DELETE: api/Directors/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "ContentManager")]
        public ActionResult DeleteDirector(int id)
        {
            int deleteResponse = _directorService.DeleteDirector(id);
            if (deleteResponse == -1)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
