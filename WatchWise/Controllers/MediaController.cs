using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchWise.Data;
using WatchWise.DTOs.Requests;
using WatchWise.DTOs.Responses;
using WatchWise.Models;
using WatchWise.Services.Interfaces;

namespace WatchWise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }

        // GET: api/Media
        [HttpGet]
        public ActionResult<List<MediaResponse>> GetMedias()
        {
            return Ok(_mediaService.GetAllMediaResponses());
        }

        // GET: api/Media/5
        [HttpGet("{id}")]
        public ActionResult<MediaResponse> GetMedia(int id)
        {
            MediaResponse? mediaResponse = _mediaService.GetMediaResponseById(id);
            if (mediaResponse == null)
            {
                return NotFound();
            }
            return mediaResponse;
        }

        // PUT: api/Media/5
        [HttpPut("{id}")]
        public ActionResult PutMedia(int id, MediaRequest mediaRequest)
        {
            int updateResponse = _mediaService.UpdateMedia(id, mediaRequest);
            if (updateResponse == -1)
            {
                return NotFound();
            }
            return Ok();
        }

        // POST: api/Media
        [HttpPost]
        public ActionResult PostMedia(MediaRequest mediaRequest)
        {
            _mediaService.PostMedia(mediaRequest);
            return Ok();
        }

        // DELETE: api/Media/5
        [HttpDelete("{id}")]
        public ActionResult DeleteMedia(int id)
        {
            int deleteResponse = _mediaService.DeleteMedia(id);
            if (deleteResponse == -1)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
