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
    public class StarsController : ControllerBase
    {
        private readonly IStarService _starService;

        public StarsController(IStarService starService)
        {
            _starService = starService;
        }

        // GET: api/Stars
        [HttpGet]
        public ActionResult<List<StarResponse>> GetStars()
        {
            return Ok(_starService.GetAllStarResponses());
        }

        // GET: api/Stars/5
        [HttpGet("{id}")]
        public ActionResult<StarResponse> GetStar(int id)
        {
            StarResponse? starResponse = _starService.GetStarResponseById(id);
            if (starResponse == null)
            {
                return NotFound();
            }

            return starResponse;
        }

        // PUT: api/Stars/5
        [HttpPut("{id}")]
        public ActionResult PutStar(int id, StarRequest starRequest)
        {
            int updateResponse = _starService.UpdateStar(id, starRequest);
            if (updateResponse == -1)
            {
                return NotFound();
            }

            return Ok();
        }

        // POST: api/Stars
        [HttpPost]
        public ActionResult PostStar(StarRequest starRequest)
        {
            _starService.PostStar(starRequest);
            return Ok();
        }

        // DELETE: api/Stars/5
        [HttpDelete("{id}")]
        public ActionResult DeleteStar(int id)
        {
            int deleteResponse = _starService.DeleteStar(id);
            if (deleteResponse == -1)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
