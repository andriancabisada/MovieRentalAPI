using Microsoft.AspNetCore.Mvc;
using MovieRentalAPI.Models;

namespace MovieRentalAPI.Interface
{
    public interface IMovies
    {
        public Movies GetMovieData(int id);
        public List <Movies> GetAll();
        public Movies Add(Movies movie);
        public Movies Update(Movies movie);
        public void Delete(int id);
    }

}
