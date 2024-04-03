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
using WatchWise.Services.Implementations;
using WatchWise.Services.Interfaces;

namespace WatchWise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EpisodesController : ControllerBase
    {
        private readonly IEpisodeService _episodeService;

        public EpisodesController(IEpisodeService episodeService)
        {
            _episodeService = episodeService;
        }

        // GET: api/Episodes
        [HttpGet]
        public ActionResult<List<EpisodeResponse>> GetEpisodes()
        {
            return _episodeService.GetAllEpisodeResponses();
        }

        // GET: api/Episodes/5
        [HttpGet("{id}")]
        public ActionResult<EpisodeResponse> GetEpisode(long id)
        {
            EpisodeResponse? episodeResponse = _episodeService.GetEpisodeResponseById(id);
            if (episodeResponse == null)
            {
                return NotFound();
            }
            return episodeResponse;
        }

        // PUT: api/Episodes/5
        [HttpPut("{id}")]
        public  ActionResult PutEpisode(long id, EpisodeUpdateRequest episodeUpdateRequest)
        {
            int updateResponse = _episodeService.UpdateEpisode(id, episodeUpdateRequest);
            if (updateResponse == -1)
            {
                return NotFound();
            }
            return Ok();
        }

        // POST: api/Episodes
        [HttpPost]
        public ActionResult PostEpisode(EpisodeRequest episodeRequest)
        {
            _episodeService.PostEpisode(episodeRequest);
            return Ok();
        }

        // DELETE: api/Episodes/5
        [HttpDelete("{id}")]
        public ActionResult DeleteEpisode(long id)
        {
            int deleteResponse = _episodeService.DeleteEpisode(id);
            if (deleteResponse == -1)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
