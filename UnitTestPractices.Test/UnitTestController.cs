using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using UnitTestPractices.BSL;
using UnitTestPractices.Controllers;
using UnitTestPractices.Data;
using Xunit;

namespace UnitTestPractices.Test
{
    public class UnitTestController
    {
        private Mock<ILogger<CustomerProfileController>> logger = new Mock<ILogger<CustomerProfileController>>();
        private CustomerService service = new CustomerService(new Mock<CustomerRepository>().Object);

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ControllerCustomerOK(int parameter)
        {
            var controller = new CustomerProfileController(logger.Object ,service);

            var result = controller.Customer(parameter);

            Assert.IsType<OkObjectResult>(result);
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-500)]
        public void ControllerCustomerBadRequest(int parameter)
        {
            var controller = new CustomerProfileController(logger.Object, service);

            var result = controller.Customer(parameter);

            Assert.IsType<BadRequestResult>(result);
        }


        [Theory]
        [InlineData(4)]
        [InlineData(2000)]
        [InlineData(3000000)]
        public void ControllerCustomerNoContent(int parameter)
        {
            var controller = new CustomerProfileController(logger.Object, service);

            var result = controller.Customer(parameter);

            Assert.IsType<NoContentResult>(result);
        }


        //[Fact]
        //public void ControllerCustomerInternalServerError()
        //{
        //    var controller = new CustomerProfileController(logger.Object, service);

        //    var result = controller.Customer(parameter);

        //    var status = result.Result as StatusCodeResult;

        //    Assert.Equal(500 ,status.StatusCode);
        //}


        [Fact]
        public void ControllerCustomersOK()
        {
            var controller = new CustomerProfileController(logger.Object, service);

            var result = controller.Customers();

            Assert.IsType<OkObjectResult>(result.Result);
        }

        //[Fact]
        //public void ControllerCustomersInternalServerError()
        //{
        //    var controller = new CustomerProfileController(logger.Object, service);

        //    var result = controller.Customers();

        //    var status = result.Result as StatusCodeResult;

        //    Assert.Equal(500 ,status.StatusCode);
        //}
    }
}
