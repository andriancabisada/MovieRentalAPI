using MovieRentalAPI.Models;

namespace MovieRentalAPI.Interface
{
    public interface ICustomer
    {
        public Customers GetCustomerData(int id);
        public List<Customers> GetAll();
        public Customers Add(Customers customer);
        public Customers Update(Customers customer);
        public void Delete(int id);
    }
}
