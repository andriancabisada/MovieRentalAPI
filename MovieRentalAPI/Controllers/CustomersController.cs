using Microsoft.AspNetCore.Mvc;
using MovieRentalAPI.Interface;
using MovieRentalAPI.Models;

namespace MovieRentalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomer _ICustomer;

        public CustomersController(ICustomer iCustomer)
        {

            _ICustomer = iCustomer;

        }

        [HttpGet(Name = "GetCustomers")]
        public async Task<List<Customers>> GetCustomers()
        {
            return await Task.FromResult(_ICustomer.GetAll());

        }

        [HttpGet("{id}",Name = "GetCustomer")]
        public IActionResult GetCustomerById(int id)
        {

            Customers customer = _ICustomer.GetCustomerData(id);
            if (customer == null) return NotFound();
            
            return Ok(customer);
            
            
        }

        [HttpPut(Name = "UpdateCustomer")]
        public IActionResult UpdateMovie(Customers customer)
        {

            _ICustomer.Update(customer);
            return Ok(customer);
        }

        [HttpPost(Name = "SaveCustomer")]
        public IActionResult SaveCustomer(Customers customer)
        {
            _ICustomer.Add(customer);
            return Ok(customer);
        }


        [HttpDelete("{id}", Name = "DeleteCustomer")]
        public IActionResult DeleteCustomer(int id)
        {
            Customers found = _ICustomer.GetCustomerData(id);
            if (found == null) return NotFound();

            _ICustomer.Delete(id);
            return Ok();
        }
    }
}
