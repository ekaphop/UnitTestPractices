using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using UnitTestPractices.BSL;
using UnitTestPractices.Data;
using UnitTestPractices.DTO;
using UnitTestPractices.Exceptions;
using Xunit;

namespace UnitTestPractices.Test
{
    public class UnitTestService
    {
        private Mock<CustomerRepository> repo = new Mock<CustomerRepository>();

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void ServiceGetCustomerByIdSuccess(int parameter)
        {
            var service = new CustomerService(repo.Object);

            var result = service.GetCustomerById(parameter);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-100)]
        [InlineData(0)]
        public void ServiceGetCustomerByIdThrowArgumentException(int parameter)
        {
            var service = new CustomerService(repo.Object);

            Assert.ThrowsAny<ArgumentException>(()=> service.GetCustomerById(parameter));
        }

        [Theory]
        [InlineData(4)]
        [InlineData(2000)]
        [InlineData(500)]
        public void ServiceGetCustomerByIdThrowDataNotFoundException(int parameter)
        {
            var service = new CustomerService(repo.Object);

            Assert.ThrowsAny<DataNotFoundException>(() => service.GetCustomerById(parameter));
        }

        [Fact]
        public void ServiceGetCustomersSuccess()
        {
            var service = new CustomerService(repo.Object);

            var result = service.GetCustomers();

            Assert.NotNull(result);
        }

        //[Fact]
        //public void ServiceGetCustomersEmpty()
        //{
        //    var service = new CustomerService(repo.Object);

        //    var result = service.GetCustomers();

        //    Assert.Equal(Enumerable.Empty<Customer>(), result);
        //}
    }
}
