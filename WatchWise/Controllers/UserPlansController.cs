using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WatchWise.DTOs.Responses;
using WatchWise.Services.Interfaces;

namespace WatchWise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPlansController : ControllerBase
    {
        private readonly IUserPlanService _userPlanService;

        public UserPlansController(IUserPlanService userPlanService)
        {
            _userPlanService = userPlanService;
        }

        // GET: api/UserPlans
        [HttpGet]
        public ActionResult<List<UserPlanResponse>> GetUserPlans()
        {
            return Ok(_userPlanService.GetAllUserPlanResponses());
        }

        // GET: api/UserPlans/5
        [HttpGet("{id}")]
        public ActionResult<List<UserPlanResponse>> GetUserPlansById(long id)
        {
            UserPlanResponse? userPlanResponse = _userPlanService.GetUserPlanResponsesById(id);
            if (userPlanResponse == null)
            {
                return NotFound();
            }
            return Ok(_userPlanService.GetUserPlanResponsesById(id));
        }

        // GET: api/UserPlans/User/5
        [HttpGet("User/{userId}")]
        public ActionResult<List<UserPlanResponse>> GetUserPlansByUserId(long userId)
        {
            return Ok(_userPlanService.GetUserPlanResponsesByUserId(userId));
        }

        // GET: api/UserPlans/Plan/5
        [HttpGet("Plan/{planId}")]
        public ActionResult<List<UserPlanResponse>> GetUserPlansByPlanId(short planId)
        {
            return Ok(_userPlanService.GetUserPlanResponsesByPlanId(planId));
        }

        // POST: api/UserPlans/BuyPlan/5
        [HttpPost("BuyPlan/{planId}")]
        public ActionResult PostUserPlan(short planId)
        {
            long userId = long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            _userPlanService.AddUserPlan(userId, planId);
            return Ok();
        }
    }
}
