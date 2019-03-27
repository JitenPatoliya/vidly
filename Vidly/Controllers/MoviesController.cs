using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity.Validation;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            //var model = _context.Movies.Include(m => m.GenreType).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            
            return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            var model = _context.Movies.Include(m => m.Genre).SingleOrDefault(x => x.Id == id);
            if (model == null)
                return HttpNotFound();

            return View(model);
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var vm = new MovieFormViewModel {
                GenreTypes = _context.Genres.ToList()
            };
            return View("MovieForm", vm);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();
            var vm = new MovieFormViewModel() {
                Movie = movie,
                GenreTypes = _context.Genres.ToList()
            };

            return View("MovieForm", vm);
        }

        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
            {
                movie.AddedDate = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieDb.Name = movie.Name;
                movieDb.ReleaseDate = movie.ReleaseDate;
                movieDb.GenreId = movie.GenreId;
                movieDb.Stock = movie.Stock;
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                Console.WriteLine(ex);
            }

            return RedirectToAction("Index");
        }
    }
}