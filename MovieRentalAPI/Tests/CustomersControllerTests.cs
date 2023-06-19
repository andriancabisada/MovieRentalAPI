using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRentalAPI.Controllers;
using MovieRentalAPI.Interface;
using MovieRentalAPI.Models;
using Microsoft.AspNetCore.Routing;

namespace MovieRentalAPI.Tests
{
    [TestFixture]
    public class CustomersControllerTests
    {
        private CustomersController _controller;
        private Mock<ICustomer> _mockCustomerService;

        [SetUp]
        public void Setup()
        {
            _mockCustomerService = new Mock<ICustomer>();
            _controller = new CustomersController(_mockCustomerService.Object);
        }

        [Test]
        public async Task GetCustomers_ReturnsListOfCustomers()
        {
            // Arrange
            var customers = new List<Customers>()
            {
                new Customers { Id = 1, Name = "John Doe", Email = "john@example.com" },
                new Customers { Id = 2, Name = "Jane Smith", Email = "jane@example.com" }
            };
            _mockCustomerService.Setup(service => service.GetAll()).Returns(customers);

            // Act
            var result = await _controller.GetCustomers();

            // Assert
            Assert.IsInstanceOf<List<Customers>>(result);
            Assert.AreEqual(customers.Count, result.Count);
        }

        [Test]
        public void GetCustomerById_WithValidId_ReturnsCustomer()
        {
            // Arrange
            int customerId = 1;
            var customer = new Customers { Id = customerId, Name = "John Doe", Email = "john@example.com" };
            _mockCustomerService.Setup(service => service.GetCustomerData(customerId)).Returns(customer);

            // Act
            var result = _controller.GetCustomerById(customerId);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.IsInstanceOf<Customers>(okResult.Value);
            Assert.AreEqual(customerId, (okResult.Value as Customers).Id);
        }

        [Test]
        public void GetCustomerById_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            int customerId = 1;
            _mockCustomerService.Setup(service => service.GetCustomerData(customerId)).Returns((Customers)null);

            // Act
            var result = _controller.GetCustomerById(customerId);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        // Similar tests for UpdateMovie, SaveCustomer, and DeleteCustomer actions can be added as needed.
    }
}
