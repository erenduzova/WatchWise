using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Services.Interfaces;

namespace WatchWise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFavoritesController : ControllerBase
    {
        private readonly IUserFavoriteService _userFavoriteService;

        public UserFavoritesController(IUserFavoriteService userFavoriteService)
        {
            _userFavoriteService = userFavoriteService;
        }

        // GET: api/UserFavorites
        [HttpGet]
        [Authorize(Roles = "ContentManager")]
        public ActionResult<List<UserFavoriteResponse>> GetUserFavorites()
        {
            return Ok(_userFavoriteService.GetAllUserFavoriteResponses());
        }

        // GET: api/UserFavorites/User/5
        [HttpGet("User/{userId}")]
        [Authorize(Roles = "Subscriber")]
        public ActionResult<List<UserFavoriteResponse>> GetUserFavoritesByUserId(long userId)
        {
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != userId.ToString())
            {
                return Unauthorized();
            }
            return Ok(_userFavoriteService.GetUserFavoriteResponsesByUserId(userId));
        }

        // GET: api/UserFavorites/Media/5
        [HttpGet("Media/{mediaId}")]
        [Authorize(Roles = "ContentManager")]
        public ActionResult<List<UserFavoriteResponse>> GetUserFavoritesByMediaId(int mediaId)
        {
            return Ok(_userFavoriteService.GetUserFavoriteResponsesByMediaId(mediaId));
        }

        // POST: api/UserFavorites
        [HttpPost]
        [Authorize(Roles = "Subscriber")]
        public ActionResult PostUserFavorite(UserFavoriteRequest userFavoriteRequest)
        {
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != userFavoriteRequest.UserId.ToString())
            {
                return Unauthorized();
            }
            int addFavoriteResult = _userFavoriteService.AddUserFavorite(userFavoriteRequest);
            if (addFavoriteResult == -1)
            {
                return Conflict("Already added");
            }
            return Ok();
        }

        // DELETE: api/UserFavorites
        [HttpDelete]
        [Authorize(Roles = "Subscriber")]
        public ActionResult DeleteUserFavorite(UserFavoriteRequest userFavoriteRequest)
        {
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) != userFavoriteRequest.UserId.ToString())
            {
                return Unauthorized();
            }
            int deleteResponse = _userFavoriteService.DeleteUserFavorite(userFavoriteRequest);
            if (deleteResponse == -1)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
