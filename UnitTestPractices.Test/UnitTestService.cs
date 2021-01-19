using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTestPractices.BSL;
using UnitTestPractices.Data;
using UnitTestPractices.Exceptions;
using Xunit;

namespace UnitTestPractices.Test
{
    public class UnitTestService
    {
        private Mock<CustomerRepository> repo = new Mock<CustomerRepository>();

        [Theory(DisplayName = "Get customer by id, Throw DataNotFoundException")]
        [InlineData(57)]
        public void GetCustomerByIdThrowDataNotFoundException(int cusId)
        {
            var service = new CustomerService(repo.Object);
            Assert.ThrowsAny<DataNotFoundException>(() => service.GetCustomerById(cusId));
        }


        [Theory(DisplayName = "Get customer by id, Throw ArgumentException")]
        [InlineData(0)]
        public void GetCustomerByIdThrowArgumentException(int cusId)
        {
            var service = new CustomerService(repo.Object);

            Assert.Throws<ArgumentException>(() => service.GetCustomerById(cusId));
        }

        [Theory(DisplayName ="Get customer by id, Success")]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetCustomerByIdSuccess(int cusId)
        {
            var service = new CustomerService(repo.Object);

            Assert.NotNull(service.GetCustomerById(cusId));
        }

        [Fact(DisplayName = "Get customer all")]
        public void GetCustomerAll()
        {
            var service = new CustomerService(repo.Object);

            Assert.NotNull(service.GetCustomers());
        }
    }
}
