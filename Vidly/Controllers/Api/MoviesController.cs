using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/movies
        public IHttpActionResult GetMovies(string query=null)
        {
            var moviesQuery = _context.Movies
                .Include(m=>m.Genre)
                .Where(m=>m.AvailableStock > 0);

            if (!string.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(x => x.Name.Contains(query));

            var movies = moviesQuery.ToList();

            var movieList = movies.Select(Mapper.Map<Movie, MovieDto>);

            //return _context.Movies.ToList().Select(Mapper.Map<Movie,MovieDto>);
            return Ok(movieList);
        }

        //GET /api/movie/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movie == null)
                return BadRequest();

            var movieDto = Mapper.Map<Movie, MovieDto>(movie);
            return Ok(movieDto);
        }

        //POST /api/movie
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            movie.AddedDate = DateTime.Now;
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        //PUT /api/movie/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieFromDb = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movieFromDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(movieDto, movieFromDb);

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/movie/1
        public IHttpActionResult DeleteMovie(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var movieFromDb = _context.Movies.SingleOrDefault(x => x.Id == id);
            if (movieFromDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Movies.Remove(movieFromDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
