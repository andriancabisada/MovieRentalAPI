using Microsoft.EntityFrameworkCore;
using MovieRentalAPI.Interface;
using MovieRentalAPI.Models;
using System.Data.Entity;
using System.Linq;

namespace MovieRentalAPI.Services
{
    public class RentalsService : IRentals
    {
        readonly VideoShopContext _dbContext = new();

        public RentalsService(VideoShopContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Rentals Add(Rentals rental)
        {
            try
            {
                _dbContext.Rentals.Add(rental);
                _dbContext.SaveChanges();
                return rental;
            }
            catch
            {
                throw;
            }
        }
        public Rentals Update(Rentals rental)
        {
            try
            {
                _dbContext.Entry(rental).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges();
                return rental;
            }
            catch
            {
                throw;
            }
        }
        public void Delete(int id)
        {
            try
            {
                Rentals? rental = _dbContext.Rentals.Find(id);
                if (rental == null) throw new ArgumentNullException();

                _dbContext.Rentals.Remove(rental);
                _dbContext.SaveChanges();

            }
            catch
            {
                throw;
            }
        }
        public List<Rentals> GetAllRentals()
        {
            try
            {
                return _dbContext.Rentals.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Rentals GetRentalsById(int id)
        {
            try
            {
                Rentals? rental = _dbContext.Rentals.Find(id);
                if (rental == null) throw new ArgumentNullException();

                return rental;
            }
            catch
            {
                throw;
            }
        }
    }

    public class RentalDetailsService : IRentalDetails
    {
        readonly VideoShopContext _dbContext = new();
        public RentalDetailsService(VideoShopContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public RentalDetails Add(RentalDetails rentaldetails)
        {
            try
            {
                _dbContext.RentalDetails.Add(rentaldetails);
                _dbContext.SaveChanges();
                return rentaldetails;
            }
            catch
            {
                throw;
            }
        }
        public RentalDetails Update(RentalDetails rentaldetails)
        {
            try
            {
                _dbContext.Entry(rentaldetails).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _dbContext.SaveChanges();
                return rentaldetails;
            }
            catch
            {
                throw;
            }
        }
        public void DeleteRentalDetailsByRentalId(int id)
        {
            try
            {
                List<RentalDetails> rentaldetails = _dbContext.RentalDetails.Where(a => a.RentalId == id).ToList();
                if (rentaldetails == null) throw new ArgumentNullException();

                _dbContext.RentalDetails.RemoveRange(rentaldetails);
                _dbContext.SaveChanges();

            }
            catch
            {
                throw;
            }
        }

        public  List<RentalDetails> GetRentalDetailsByRentalId(int RentalId)
        {
           
          return  _dbContext.RentalDetails.Where(a => a.RentalId == RentalId).ToList();
                
            
        }
    }
}
