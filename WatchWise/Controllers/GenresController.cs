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
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        // GET: api/Genres
        [HttpGet]
        public ActionResult<List<GenreResponse>> GetGenres()
        {
            return Ok(_genreService.GetAllGenreResponses());
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public ActionResult<GenreResponse> GetGenre(short id)
        {
            GenreResponse? genreResponse = _genreService.GetGenreResponseById(id);
            if (genreResponse == null)
            {
                return NotFound();
            }
            return genreResponse;
        }

        // PUT: api/Genres/5
        [HttpPut("{id}")]
        public ActionResult PutGenre(short id, GenreRequest genreRequest)
        {
            int updateResponse = _genreService.UpdateGenre(id, genreRequest);
            if (updateResponse == -1)
            {
                return NotFound();
            }
            return Ok();
        }

        // POST: api/Genres
        [HttpPost]
        public ActionResult PostGenre(GenreRequest genreRequest)
        {
            _genreService.PostGenre(genreRequest);
            return Ok();
        }
    }
}
