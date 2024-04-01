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
    public class DirectorsController : ControllerBase
    {
        private readonly IDirectorService _directorService;

        public DirectorsController(IDirectorService directorService)
        {
            _directorService = directorService;
        }

        // GET: api/Directors
        [HttpGet]
        public ActionResult<List<DirectorResponse>> GetDirectors()
        {
            return Ok(_directorService.GetAllDirectorResponses());
        }

        // GET: api/Directors/5
        [HttpGet("{id}")]
        public ActionResult<DirectorResponse> GetDirector(int id)
        {
            DirectorResponse? directorResponse = _directorService.GetDirectorResponseById(id);
            if (directorResponse == null)
            {
                return NotFound();
            }

            return directorResponse;
        }

        // PUT: api/Directors/5
        [HttpPut("{id}")]
        public ActionResult PutDirector(int id, DirectorRequest directorRequest)
        {

            int updateResponse = _directorService.UpdateDirector(id, directorRequest);
            if (updateResponse == -1)
            {
                return NotFound();
            }

            return Ok();
        }

        // POST: api/Directors
        [HttpPost]
        public ActionResult PostDirector(DirectorRequest directorRequest)
        {
            _directorService.PostDirector(directorRequest);
            return Ok();
        }

        // DELETE: api/Directors/5
        [HttpDelete("{id}")]
        public ActionResult DeleteDirector(int id)
        {
            int deleteResponse = _directorService.DeleteDirector(id);
            if (deleteResponse == -1)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
