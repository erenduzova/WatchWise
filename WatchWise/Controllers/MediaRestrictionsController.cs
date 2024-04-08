using Microsoft.AspNetCore.Mvc;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Services.Interfaces;

namespace WatchWise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaRestrictionsController : ControllerBase
    {
        private readonly IMediaRestrictionService _mediaRestrictionService;

        public MediaRestrictionsController(IMediaRestrictionService mediaRestrictionService)
        {
            _mediaRestrictionService = mediaRestrictionService;
        }

        // GET: api/MediaRestrictions
        [HttpGet]
        public ActionResult<List<MediaRestrictionResponse>> GetMediaRestrictions()
        {
            return Ok(_mediaRestrictionService.GetAllMediaRestrictionResponses());
        }

        // GET: api/MediaRestrictions/Media/5
        [HttpGet("Media/{id}")]
        public ActionResult<List<MediaRestrictionResponse>> GetMediaRestrictionsByMediaId(int id)
        {
            return Ok(_mediaRestrictionService.GetMediaRestrictionResponsesByMediaId(id));
        }

        // GET: api/MediaRestrictions/Restriction/5
        [HttpGet("Restriction/{id}")]
        public ActionResult<List<MediaRestrictionResponse>> GetMediaRestrictionsByRestrictionId(byte id)
        {
            return Ok(_mediaRestrictionService.GetMediaRestrictionResponsesByRestrictionId(id));
        }

        // POST: api/MediaRestrictions
        [HttpPost]
        public ActionResult PostMediaRestriction(MediaRestrictionRequest mediaRestrictionRequest)
        {
            _mediaRestrictionService.PostMediaRestriction(mediaRestrictionRequest);
            return Ok();
        }

        // DELETE: api/MediaRestrictions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMediaRestriction(MediaRestrictionRequest mediaRestrictionRequest)
        {
            int deleteResponse = _mediaRestrictionService.DeleteMediaRestriction(mediaRestrictionRequest);
            if (deleteResponse == -1)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
