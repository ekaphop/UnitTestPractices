using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestPractices.BSL;
using UnitTestPractices.Controllers;
using UnitTestPractices.Data;
using Xunit;

namespace UnitTestPractices.Test
{
    public class UnitTestController
    {
        private Mock<ILogger<CustomerProfileController>> logger = new Mock<ILogger<CustomerProfileController>>();
        private ICustomerService customer = new CustomerService(new CustomerRepository());

        [Fact(DisplayName ="Get Customers, Success")]
        public void GetCustomersIsSuccess()
        {
            var controller = new CustomerProfileController(logger.Object, customer);
            var result = controller.Customers();
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Theory(DisplayName = "Get Customer by id, OkObjectResult")]
        [InlineData(1)]
        public void GetCustomerByIdSuccess(int cusId)
        {
            var controller = new CustomerProfileController(logger.Object, customer);
            var result = controller.Customer(cusId);
            //Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Theory(DisplayName = "Get Customer by id, BadRequestResult")]
        [InlineData(0)]
        public void GetCustomerByIdBadRequest(int cusId)
        {
            var controller = new CustomerProfileController(logger.Object, customer);
            var result = controller.Customer(cusId);
            Assert.IsType<BadRequestResult>(result);
        }

        [Theory(DisplayName = "Get Customer by id, NoContentResult")]
        [InlineData(7)]
        public void GetCustomerByIdNoContentResult(int cusId)
        {
            var controller = new CustomerProfileController(logger.Object, customer);
            var result = controller.Customer(cusId);
            Assert.IsType<NoContentResult>(result);
        }
    }
}
