using Microsoft.EntityFrameworkCore;
using MovieRentalAPI.Interface;
using MovieRentalAPI.Models;

namespace MovieRentalAPI.Services
{
    public class CustomerManager : ICustomer
    {
        readonly VideoShopContext _dbContext = new();
        public CustomerManager(VideoShopContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Customers GetCustomerData(int id)
        {

            try
            {
                Customers? customer = _dbContext.Customers.Find(id);
                if (customer == null) throw new ArgumentNullException();

                return customer;
            }
            catch
            {
                throw;
            }

        }
        public List<Customers> GetAll()
        {
            try
            {
                return _dbContext.Customers.ToList();
            }
            catch
            {
                throw;
            }
        }
        public Customers Add(Customers customer)
        {
            try
            {
                _dbContext.Customers.Add(customer);
                _dbContext.SaveChanges();
                return customer;
            }
            catch
            {
                throw;
            }
        }
        public Customers Update(Customers customer)
        {
            try
            {
                _dbContext.Entry(customer).State = EntityState.Modified;
                _dbContext.SaveChanges();
                return customer;
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
                Customers? customer = _dbContext.Customers.Find(id);
                if (customer == null) throw new ArgumentNullException();
               
                _dbContext.Customers.Remove(customer);
                _dbContext.SaveChanges();

            }
            catch
            {
                throw;
            }
        }
    }
}
