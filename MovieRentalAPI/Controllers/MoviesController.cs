using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRentalAPI.Models;
using MovieRentalAPI.Interface;

namespace MovieRentalAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMovies _IMovies;
       

        public MoviesController(IMovies iMovies)
        {

           _IMovies = iMovies;

        }

       

        [HttpGet(Name = "GetMovies")]
        public async Task<List<Movies>> GetMovies()
        {
            return await Task.FromResult(_IMovies.GetAll());

        }

        
        [HttpGet("{id}", Name = "GetMovieById")]
        public IActionResult GetMovieById(int id)
        {

            Movies movie =  _IMovies.GetMovieData(id);
            if(movie != null)
            {
                return Ok(movie);
            }
            return NotFound();
        }

        [HttpGet("{name}", Name = "GetMovieByName")]
        public async Task<List<Movies>> GetMovieByName(string name)
        {
            return await Task.FromResult(_IMovies.GetMovieByName(name));

        }


        [HttpPut(Name = "UpdateMovie")]
        public IActionResult UpdateMovie(Movies movie)
        {
            

            _IMovies.Update(movie);
            return Ok(movie);
        }

        
        [HttpPost(Name = "SaveMovie")]
        public IActionResult SaveMovie(Movies movie)
        {
            _IMovies.Add(movie);
            return Ok(movie);
        }

        
        [HttpDelete("{id}",Name = "DeleteMovie")]
        public IActionResult DeleteMovie(int id)
        {
            Movies found = _IMovies.GetMovieData(id);
            if (found == null) return NotFound();

            _IMovies.Delete(id);
            return Ok();
        }

    }

}
