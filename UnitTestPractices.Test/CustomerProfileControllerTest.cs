using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using UnitTestPractices.BSL;
using UnitTestPractices.Controllers;
using Xunit;
using Moq;
using System.Collections.Generic;
using UnitTestPractices.Data;
using UnitTestPractices.DTO;

namespace UnitTestPractices.Test
{
    public class CustomerProfileControllerTest
    {

        private Mock<ILogger<CustomerProfileController>> logger;
        private Mock<ICustomerService> customer;


        [Fact]
        public void Case_GatAll_OK()
        {
            // Arrange
            logger = new Mock<ILogger<CustomerProfileController>>();
            ICustomerService customer = new CustomerService(new CustomerRepository());
            CustomerProfileController controller = new CustomerProfileController(logger.Object, customer);
            int expect = 200;

            // Act
            ActionResult<IEnumerable<Customer>> actionResult = controller.Customers();

            // Assert
            var actual = Assert.IsType<OkObjectResult>(actionResult.Result);
            Assert.Equal(expect, actual.StatusCode);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void Case_OK(int value,int expect)
        {
            // Arrange
            logger = new Mock<ILogger<CustomerProfileController>>();
            ICustomerService customer = new CustomerService(new CustomerRepository());
            CustomerProfileController controller = new CustomerProfileController(logger.Object, customer);

            // Act
            ActionResult actionResult = controller.Customer(value);

            // Assert
            var actual = Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(expect, actual.StatusCode);
        }

        [Theory]
        [MemberData(nameof(DataBad))]
        public void Case_Bad(int value, int expect)
        {
            // Arrange
            logger = new Mock<ILogger<CustomerProfileController>>();
            ICustomerService customer = new CustomerService(new CustomerRepository());
            CustomerProfileController controller = new CustomerProfileController(logger.Object, customer);

            // Act
            ActionResult actionResult = controller.Customer(value);

            // Assert
            var actual = Assert.IsType<BadRequestResult>(actionResult);
            Assert.Equal(expect, actual.StatusCode);
        }

        [Theory]
        [MemberData(nameof(DataNoContent))]
        public void Case_NoContent(int value, int expect)
        {
            // Arrange
            logger = new Mock<ILogger<CustomerProfileController>>();
            ICustomerService customer = new CustomerService(new CustomerRepository());
            CustomerProfileController controller = new CustomerProfileController(logger.Object, customer);

            // Act
            ActionResult actionResult = controller.Customer(value);

            // Assert
            var actual = Assert.IsType<NoContentResult>(actionResult);
            Assert.Equal(expect, actual.StatusCode);
        }

        [Theory]
        [MemberData(nameof(DataMock))]
        public void Case_Mock(int value, int expect)
        {
            // Arrange
            logger = new Mock<ILogger<CustomerProfileController>>();
            customer = new Mock<ICustomerService>();
            CustomerProfileController controller = new CustomerProfileController(logger.Object, customer.Object);

            // Act
            ActionResult actionResult = controller.Customer(value);

            // Assert
            var actual = Assert.IsType<OkObjectResult>(actionResult);
            Assert.Equal(expect, actual.StatusCode);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { 1, 200 },
            new object[] { 2, 200 },
            new object[] { 3, 200 },
        };

        public static IEnumerable<object[]> DataBad =>
        new List<object[]>
        {
            new object[] { -1, 400 },
            new object[] { 0, 400 },
        };

        public static IEnumerable<object[]> DataNoContent =>
        new List<object[]>
        {
            new object[] { 4, 204 },
        };

        public static IEnumerable<object[]> DataMock =>
        new List<object[]>
        {
            new object[] { 1, 200 },
            new object[] { 2, 200 },
            new object[] { 3, 200 },
            new object[] { 4, 200 },
            new object[] { -1, 200 },
            new object[] { 0, 200 },
        };
    }
}
