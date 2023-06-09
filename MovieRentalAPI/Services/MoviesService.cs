﻿using MovieRentalAPI.Models;
using MovieRentalAPI.Interface;
using Microsoft.EntityFrameworkCore;


namespace MovieRentalAPI.Services
{
    public class MoviesService : IMovies
    {
        readonly VideoShopContext _dbContext = new();

        public MoviesService(VideoShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Movies> GetMovieByName(string name)
        {
            try
            {
               return _dbContext.Movies.Where(a => a.Title.Contains(name)).ToList();
            }
            catch
            {

                throw;
            }
        }
        //To Get all user details
        public List<Movies> GetAll()
        {
            try
            {
                return _dbContext.Movies.ToList();
            }
            catch
            {
                throw;
            }
        }
        //To Add new user record
        public Movies Add(Movies movie)
        {
            try
            {
                _dbContext.Movies.Add(movie);
                _dbContext.SaveChanges();
                return movie;
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar user
        public Movies Update(Movies movie)
        {

                try
                {
                    _dbContext.Entry(movie).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return movie;
                }
                catch
                {
                    throw;
                }
            
           
        }
        //Get the details of a particular user
        public Movies GetMovieData(int id)
        {
            try
            {
                Movies? movie = _dbContext.Movies.Find(id);
                if (movie == null) throw new ArgumentNullException();
               
                return movie;
            }
            catch
            {
                throw;
            }
        }
        //To Delete the record of a particular user
        public void Delete(int id)
        {
            try
            {
                Movies? movie = _dbContext.Movies.Find(id);
                if (movie != null)
                {
                    _dbContext.Movies.Remove(movie);
                    _dbContext.SaveChanges();
                    
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        
    }
}
