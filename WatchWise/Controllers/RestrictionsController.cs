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
    public class RestrictionsController : ControllerBase
    {
        private readonly IRestrictionService _restrictionService;

        public RestrictionsController(IRestrictionService restrictionService)
        {
            _restrictionService = restrictionService;
        }

        // GET: api/Restrictions
        [HttpGet]
        [Authorize]
        public ActionResult<List<RestrictionResponse>> GetRestrictions()
        {
            return Ok(_restrictionService.GetAllRestrictionResponses());
        }

        // GET: api/Restrictions/5
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<RestrictionResponse> GetRestriction(byte id)
        {
            RestrictionResponse? restrictionResponse = _restrictionService.GetRestrictionResponseById(id);
            if (restrictionResponse == null)
            {
                return NotFound();
            }
            return restrictionResponse;
        }

        // PUT: api/Restrictions/5
        [HttpPut("{id}")]
        [Authorize(Roles = "RestrictionManager")]
        public ActionResult PutRestriction(byte id, RestrictionRequest restrictionRequest)
        {
            int updateResponse = _restrictionService.UpdateRestriction(id, restrictionRequest);
            if (updateResponse == 0)
            {
                return Conflict("There is a Restriction with same id, can not update");
            }
            else if (updateResponse == -1)
            {
                return NotFound();
            }
            return Ok();
        }

        // POST: api/Restrictions
        [HttpPost]
        [Authorize(Roles = "RestrictionManager")]
        public ActionResult PostRestriction(RestrictionRequest restrictionRequest)
        {
            int addResponse = _restrictionService.PostRestriction(restrictionRequest);
            if (addResponse == -1)
            {
                return Conflict();
            }
            return Ok();
        }

    }
}
