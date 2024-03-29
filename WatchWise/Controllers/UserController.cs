using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchWise.Data;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;
using WatchWise.Services;

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
        [Authorize("Administrator")]
        public ActionResult<List<WatchWiseUserResponse>> GetUsers(bool passiveUser = true)
        {
            return Ok(_userService.GetAllUsersResponses(passiveUser));
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<WatchWiseUserResponse> GetWatchWiseUser(long id)
        {
            if (User.IsInRole("Administrator")==false)
            {
                if (User.FindFirstValue(ClaimTypes.NameIdentifier) != id.ToString())
                {
                    return Unauthorized();
                }
            }
            WatchWiseUserResponse? foundUserResponse = _userService.GetWatchWiseUserResponse(id);
            if (foundUserResponse == null)
            {
                return NotFound();
            }
            return Ok(foundUserResponse);
        }

        // PUT: api/Users/5
        [HttpPut]
        [Authorize]
        public ActionResult PutWatchWiseUser(long id, WatchWiseUserUpdateRequest watchWiseUserUpdateRequest)
        {
            if (User.IsInRole("CustomerRepresentative") == false)
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
            if (User.Identity!.IsAuthenticated == true)
            {
                return BadRequest();
            }
            IdentityResult identityResult = _userService.PostUser(watchWiseUserRequest);
            if (!identityResult.Succeeded)
            {
                return BadRequest(identityResult.Errors.FirstOrDefault()!.Description);
            }
            return Ok();
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public ActionResult DeleteWatchWiseUser(long id)
        {
            if (User.IsInRole("CustomerRepresentative") == false)
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
            return Ok("Deleted");
        }

    }
}
