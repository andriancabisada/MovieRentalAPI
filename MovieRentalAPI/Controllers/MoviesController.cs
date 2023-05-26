using Microsoft.AspNetCore.Mvc;
using MovieRentalAPI.Models;
using MovieRentalAPI.Repository;
using System.Net;
using System.Web.Http;
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace MovieRentalAPI.Controllers
{
    public class MoviesController : ApiController
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly UnitOfWork _unitOfWork;

        public MoviesController()
        {
            _unitOfWork = new UnitOfWork(new VideoShopContext());
            _movieRepository = new Repository<Movie>(_unitOfWork.Context);
        }

        // GET: api/movies
        public IHttpActionResult GetMovies()
        {
            var movies = _movieRepository.GetAll();
            return Ok(movies);
        }

        // GET: api/movies/{id}
        [Route("{id}")]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

        // POST: api/movies
        public IHttpActionResult PostMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _movieRepository.Add(movie);
            _unitOfWork.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = movie.Id }, movie);
        }

        // PUT: api/movies/{id}
        [Route("{id}")]
        public IHttpActionResult PutMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingMovie = _movieRepository.GetById(id);
            if (existingMovie == null)
                return NotFound();

            existingMovie.Title = movie.Title;
            existingMovie.Genre = movie.Genre;

            _movieRepository.Update(existingMovie);
            _unitOfWork.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/movies/{id}
        [Route("{id}")]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null)
                return NotFound();

            _movieRepository.Delete(movie);
            _unitOfWork.SaveChanges();

            return Ok(movie);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }

}
