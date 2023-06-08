namespace MovieRentalAPI.Models
{
    public class Rentals
    {
        public int Id { get; set; }
        public DateTime RentalDate { get; set; }

        public DateTime DueDate { get; set; }   
        public int CustomerId { get; set; }
        public Customers? Customer { get; set; }
        public List<RentalDetails>? RentalDetails { get; set; }
    }

    public class RentalDetails
    {
        public int Id { get; set; }

        public Rentals Rental { get; set; }

        public int RentalId { get; set; }
        public int MovieId { get; set; }
        public Movies Movie { get; set; }
        public int Quantity { get; set; }
        // Additional rental detail properties
    }

}
