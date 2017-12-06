using AutoMapper;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.Models;
using Vidly.Models.Dtos;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        #region Context
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        #endregion
        
        //GET /api/movies
        [HttpGet]
        public IHttpActionResult GetMovies()
        {
            var moviesDtos = _context.Movies
                .Include(m => m.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);

            return Ok(moviesDtos);
        }


        //GET /api/movies/{id}
        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        //POST /api/movies
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movieInDb = Mapper.Map<MovieDto, Movie>(movieDto);
            movieInDb.AddedDate = DateTime.Now;
            _context.Movies.Add(movieInDb);
            _context.SaveChanges();

            movieDto.Id = movieInDb.Id;
            return Created(new Uri(Request.RequestUri + "/" + movieInDb.Id), movieDto);
        }

        //PUT /api/movies/{id}
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPut]
        public void UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieInDb);

            _context.SaveChanges();
        }

        //DELETE /api/movies/{id}
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
        }
    }
}
