using Microsoft.AspNetCore.Mvc;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Services.Interfaces;

namespace WatchWise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestrictionsController : ControllerBase
    {
        private readonly IRestrictionService _restrictionService;

        public RestrictionsController(IRestrictionService restrictionService)
        {
            _restrictionService = restrictionService;
        }

        // GET: api/Restrictions
        [HttpGet]
        public ActionResult<List<RestrictionResponse>> GetRestrictions(bool includeMedia = false)
        {
            return Ok(_restrictionService.GetAllRestrictionResponses(includeMedia));
        }

        // GET: api/Restrictions/5
        [HttpGet("{id}")]
        public ActionResult<RestrictionResponse> GetRestriction(byte id, bool includeMedia = false)
        {
            RestrictionResponse? restrictionResponse = _restrictionService.GetRestrictionResponseById(id, includeMedia);
            if (restrictionResponse == null)
            {
                return NotFound();
            }
            return restrictionResponse;
        }

        // PUT: api/Restrictions/5
        [HttpPut("{id}")]
        public ActionResult PutRestriction(byte id, RestrictionRequest restrictionRequest)
        {
            int updateResponse = _restrictionService.UpdateRestriction(id, restrictionRequest);
            if (updateResponse == 0)
            {
                return Conflict("There is a Restriction with same id, can not update");
            } else if (updateResponse == -1)
            {
                return NotFound();
            }
            return Ok();
        }

        // POST: api/Restrictions
        [HttpPost]
        public ActionResult PostRestriction(RestrictionRequest restrictionRequest)
        {
            int postResponse = _restrictionService.PostRestriction(restrictionRequest);
            if (postResponse == 0)
            {
                return Conflict("There is a Restriction with same id");
            }
            return Ok();
        }

    }
}
