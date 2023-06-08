using Microsoft.AspNetCore.Mvc;
using MovieRentalAPI.Interface;
using MovieRentalAPI.Models;

namespace MovieRentalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalsController : ControllerBase
    {
        private readonly IRentals _IRentals;

        public RentalsController(IRentals iRentals)
        {

            _IRentals = iRentals;

        }

        [HttpGet(Name = "GetRentals")]
        public async Task<List<Rentals>> GetRentals()
        {
            return await Task.FromResult(_IRentals.GetRentals());

        }

        [HttpGet("{id}", Name = "GetRentalById")]
        public IActionResult GetRentalById(int id)
        {

            Rentals rental = _IRentals.GetRentalsById(id);
            if (rental == null) return NotFound();

            return Ok(rental);


        }

        [HttpPut(Name = "UpdateRental")]
        public IActionResult UpdateRental(Rentals rental)
        {

            _IRentals.Update(rental);
            return Ok(rental);
        }

        [HttpPost(Name = "SaveRental")]
        public IActionResult SaveRental(Rentals rental)
        {
            _IRentals.Add(rental);
            return Ok(rental);
        }


        [HttpDelete("{id}", Name = "DeleteRental")]
        public IActionResult DeleteRental(int id)
        {
            Rentals found = _IRentals.GetRentalsById(id);
            if (found == null) return NotFound();

            _IRentals.Delete(id);
            return Ok();
        }
    }


    [ApiController]
    [Route("[controller]")]

    public class RentalDetailsController : ControllerBase
    {
        private readonly IRentalDetails _IRentalDetails;

        public RentalDetailsController(IRentalDetails iRentalDetails)
        {

            _IRentalDetails = iRentalDetails;

        }

       

        [HttpGet("{RentalId}", Name = "GetRentalDetailsByRentalId")]
        public async Task<List<RentalDetails>> GetRentalDetailsByRentalId(int id)
        {
            return await Task.FromResult(_IRentalDetails.GetRentalDetailsByRentalId(id));

        }

        

        [HttpPut(Name = "UpdateRentalDetails")]
        public IActionResult UpdateRentalDetails(RentalDetails rentalDetails)
        {

            _IRentalDetails.Update(rentalDetails);
            return Ok(rentalDetails);
        }

        [HttpPost(Name = "SaveRentalDetails")]
        public IActionResult SaveRental(RentalDetails rentalDetails)
        {
            _IRentalDetails.Add(rentalDetails);
            return Ok(rentalDetails);
        }


        [HttpDelete("{RentalId}", Name = "DeleteRentalDetails")]
        public IActionResult DeleteRentalDetails(int id)
        {
            List<RentalDetails> found = _IRentalDetails.GetRentalDetailsByRentalId(id);
            if (found == null) return NotFound();

            _IRentalDetails.DeleteRentalDetailsByRentalId(id);
            return Ok();
        }
    }
}
