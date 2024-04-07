using Microsoft.AspNetCore.Mvc;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
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
        public ActionResult<List<PlanResponse>> GetPlans()
        {
            return Ok(_planService.GetAllPlanResponses());
        }

        // GET: api/Plans/5
        [HttpGet("{id}")]
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
        public ActionResult PostPlan(PlanRequest planRequest)
        {
            _planService.PostPlan(planRequest);
            return Ok();
        }

    }
}
