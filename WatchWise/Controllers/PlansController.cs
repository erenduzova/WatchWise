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
    public class PlansController : ControllerBase
    {
        private readonly IPlanService _planService;

        public PlansController(IPlanService planService)
        {
            _planService = planService;
        }

        // GET: api/Plans
        [HttpGet]
        [Authorize]
        public ActionResult<List<PlanResponse>> GetPlans()
        {
            return Ok(_planService.GetAllPlanResponses());
        }

        // GET: api/Plans/5
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<PlanResponse> GetPlan(short id)
        {
            PlanResponse? planResponse = _planService.GetPlanResponseById(id);
            if (planResponse == null)
            {
                return NotFound();
            }
            return planResponse;
        }

        // PUT: api/Plans/5
        [HttpPut("{id}")]
        [Authorize(Roles = "UserManager")]
        public ActionResult PutPlan(short id, PlanRequest planRequest)
        {
            int updateResponse = _planService.UpdatePlan(id, planRequest);
            if (updateResponse == -1)
            {
                return NotFound();
            }
            return Ok();
        }

        // POST: api/Plans
        [HttpPost]
        [Authorize(Roles = "UserManager")]
        public ActionResult PostPlan(PlanRequest planRequest)
        {
            int addResponse = _planService.PostPlan(planRequest);
            if (addResponse == -1)
            {
                return Conflict();
            }
            return Ok();
        }

    }
}
