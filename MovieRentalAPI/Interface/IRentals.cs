using MovieRentalAPI.Models;

namespace MovieRentalAPI.Interface
{
    public interface IRentals
    {

        public Rentals Add(Rentals rental);
        public Rentals Update(Rentals rental);
        public void Delete(int id);

        public List<Rentals> GetRentals();

        public Rentals GetRentalsById(int id);
    }

    public interface IRentalDetails
    {
        public RentalDetails Add(RentalDetails rentaldetails);
        public RentalDetails Update(RentalDetails rentaldetails);
        public void DeleteRentalDetailsByRentalId(int id);

        public List<RentalDetails> GetRentalDetailsByRentalId(int id);
    }
}
