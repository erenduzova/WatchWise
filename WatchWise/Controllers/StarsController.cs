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
    public class StarsController : ControllerBase
    {
        private readonly IStarService _starService;

        public StarsController(IStarService starService)
        {
            _starService = starService;
        }

        // GET: api/Stars
        [HttpGet]
        [Authorize]
        public ActionResult<List<StarResponse>> GetStars(bool includeMedia = false)
        {
            return Ok(_starService.GetAllStarResponses(includeMedia));
        }

        // GET: api/Stars/5
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<StarResponse> GetStar(int id, bool includeMedia = false)
        {
            StarResponse? starResponse = _starService.GetStarResponseById(id, includeMedia);
            if (starResponse == null)
            {
                return NotFound();
            }
            return starResponse;
        }

        // PUT: api/Stars/5
        [HttpPut("{id}")]
        [Authorize(Roles = "ContentManager")]
        public ActionResult PutStar(int id, StarRequest starRequest)
        {
            int updateResponse = _starService.UpdateStar(id, starRequest);
            if (updateResponse == -1)
            {
                return NotFound();
            }
            return Ok();
        }

        // POST: api/Stars
        [HttpPost]
        [Authorize(Roles = "ContentManager")]
        public ActionResult PostStar(StarRequest starRequest)
        {
            int addResponse = _starService.PostStar(starRequest);
            if (addResponse == -1)
            {
                return Conflict();
            }
            return Ok();
        }

        // DELETE: api/Stars/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "ContentManager")]
        public ActionResult DeleteStar(int id)
        {
            int deleteResponse = _starService.DeleteStar(id);
            if (deleteResponse == -1)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
