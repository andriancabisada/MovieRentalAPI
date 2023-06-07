namespace MovieRentalAPI.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime RentalDate { get; set; }
        public int CustomerId { get; set; }
        public Customers? Customer { get; set; }
        public List<RentalDetail>? RentalDetails { get; set; }
    }

    public class RentalDetail
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movies Movie { get; set; }
        public int Quantity { get; set; }
        // Additional rental detail properties
    }

}
