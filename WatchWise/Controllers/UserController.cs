using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;
using WatchWise.Services.Interfaces;

namespace WatchWise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        [Authorize(Roles = "Admin,UserManager")]
        public ActionResult<List<WatchWiseUserResponse>> GetUsers(bool includePassive = false, bool includePlans = false, bool includeWatchedEpisodes = false, bool includeFavorites = false)
        {
            return Ok(_userService.GetAllUsersResponses(includePassive, includePlans, includeWatchedEpisodes, includeFavorites));
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin,UserManager,Guest")]
        public ActionResult<WatchWiseUserResponse> GetWatchWiseUser(long id, bool includePlans = false, bool includeWatchedEpisodes = false, bool includeFavorites = false)
        {
            if (User.IsInRole("Admin") == false || User.IsInRole("UserManager") == false)
            {
                if (User.FindFirstValue(ClaimTypes.NameIdentifier) != id.ToString())
                {
                    return Unauthorized();
                }
            }
            WatchWiseUserResponse? foundUserResponse = _userService.GetWatchWiseUserResponseById(id, includePlans, includeWatchedEpisodes, includeFavorites);
            if (foundUserResponse == null)
            {
                return NotFound();
            }
            return Ok(foundUserResponse);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        [Authorize(Roles = "UserManager,Guest")]
        public ActionResult PutWatchWiseUser(long id, WatchWiseUserUpdateRequest watchWiseUserUpdateRequest)
        {
            if (User.IsInRole("UserManager") == false)
            {
                if (User.FindFirstValue(ClaimTypes.NameIdentifier) != id.ToString())
                {
                    return Unauthorized();
                }
            }
            int updateResponse = _userService.UpdateUser(id, watchWiseUserUpdateRequest);
            if (updateResponse == -1)
            {
                return NotFound();
            }
            return Ok();
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult PostWatchWiseUser(WatchWiseUserRequest watchWiseUserRequest)
        {
            IdentityResult identityResult = _userService.PostUser(watchWiseUserRequest);
            if (!identityResult.Succeeded)
            {
                return BadRequest(identityResult.Errors.FirstOrDefault()!.Description);
            }
            return Ok("New user created");
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin,UserManager,Guest")]
        public ActionResult DeleteWatchWiseUser(long id)
        {
            if (User.IsInRole("UserManager") == false || User.IsInRole("Admin") == false)
            {
                if (User.FindFirstValue(ClaimTypes.NameIdentifier) != id.ToString())
                {
                    return Unauthorized();
                }
            }
            int deleteResponse = _userService.DeleteUser(id);
            if (deleteResponse == -1)
            {
                return NotFound("User not found");
            }
            if (deleteResponse == 0)
            {
                return Problem("Can not delete Admin User");
            }
            return Ok("Deleted");
        }

        [HttpPost("LogIn")]
        public ActionResult<List<MediaResponse>> LogIn(LogInRequest logInRequest)
        {
            Microsoft.AspNetCore.Identity.SignInResult signInResult = _userService.LogIn(logInRequest);
            if (signInResult.Succeeded)
            {
                return Ok(_userService.GetSuggestedMedias(long.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!)));
            }
            else if (signInResult.IsLockedOut)
            {
                return BadRequest("Your account is locked out. Please try again later.");
            }
            else if (signInResult.IsNotAllowed)
            {
                return BadRequest("Login is not allowed for this user.");
            }
            else if (signInResult.RequiresTwoFactor)
            {
                return BadRequest("Two-factor authentication is required for this user.");
            }
            else
            {
                return BadRequest("An unknown error occurred during login.");
            }
        }

        [HttpPost("LogOut")]
        [Authorize]
        public void Logout()
        {
            _userService.LogOut();
        }

        [HttpGet("Roles")]
        [Authorize(Roles = "Admin,UserManager")]
        public List<WatchWiseRole> GetAllRoles()
        {
            return _userService.GetAllRoles();
        }
    }
}
