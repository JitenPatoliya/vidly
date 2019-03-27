using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/rental
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {

            var customer = _context.Customers.Single(x => x.Id == newRental.CustomerId);
            var movies = _context.Movies.Where(x => newRental.MovieIds.Contains(x.Id)).ToList();

            foreach (var movie in movies)
            {
                if (movie.AvailableStock <= 0)
                    return BadRequest("Movie is not available.");

                movie.AvailableStock--;

                var rental = new Rental
                {
                    Movie = movie,
                    Customer = customer,
                    DateRented = DateTime.Now,
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }

        //OR - Other way to implement (Recommended for public api)

        //// GET /api/rental
        //[HttpPost]
        //public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        //{
        //    if (newRental.MovieIds?.Count <= 0 )
        //        return BadRequest("No Movie Ids have been given.");

        //    var customer = _context.Customers.SingleOrDefault(x => x.Id == newRental.CustomerId);
        //    if (customer == null)
        //        return BadRequest("CustomerID is not valid.");

        //    var movies = _context.Movies.Where(x => newRental.MovieIds.Contains(x.Id)).ToList();
        //    if (movies.Count != newRental.MovieIds?.Count)
        //        return BadRequest("One or movieIds are invalid.");

        //    foreach (var movie in movies)
        //    {
        //        if (movie.AvailableStock <= 0)
        //            return BadRequest("Movie is not available.");

        //        movie.AvailableStock--;

        //        var rental = new Rental
        //        {
        //            Movie = movie,
        //            Customer = customer,
        //            DateRented = DateTime.Now,
        //        };

        //        _context.Rentals.Add(rental);
        //    }

        //    _context.SaveChanges();

        //    return Ok();
        //}
    }
}
