using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<List<UserFavoriteResponse>> GetUserFavorites()
        {
            return Ok(_userFavoriteService.GetAllUserFavoriteResponses());
        }

        // GET: api/UserFavorites/User/5
        [HttpGet("User/{userId}")]
        public ActionResult<List<UserFavoriteResponse>> GetUserFavoritesByUserId(long userId)
        {
            return Ok(_userFavoriteService.GetUserFavoriteResponsesByUserId(userId));
        }

        // GET: api/UserFavorites/Media/5
        [HttpGet("Media/{mediaId}")]
        public ActionResult<List<UserFavoriteResponse>> GetUserFavoritesByMediaId(int mediaId)
        {
            return Ok(_userFavoriteService.GetUserFavoriteResponsesByMediaId(mediaId));
        }

        // POST: api/UserFavorites
        [HttpPost]
        public ActionResult PostUserFavorite(UserFavoriteRequest userFavoriteRequest)
        {
            _userFavoriteService.AddUserFavorite(userFavoriteRequest);
            return Ok();
        }

        // DELETE: api/UserFavorites
        [HttpDelete]
        public IActionResult DeleteUserFavorite(UserFavoriteRequest userFavoriteRequest)
        {
            int deleteResponse = _userFavoriteService.DeleteUserFavorite(userFavoriteRequest);
            if (deleteResponse == -1)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
