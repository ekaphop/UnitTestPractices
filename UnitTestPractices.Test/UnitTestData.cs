using System;
using Moq;
using UnitTestPractices.Data;
using Xunit;

namespace UnitTestPractices.Test
{
    public class UnitTestData
    {

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void DataGetCustomerSuccess(int parameter)
        {
            var repo = new CustomerRepository();

            var result = repo.GetCustomer(parameter);

            Assert.NotNull(result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        [InlineData(6)]
        public void DataGetCustomerNoData(int parameter)
        {
            var repo = new CustomerRepository();

            var result = repo.GetCustomer(parameter);

            Assert.Null(result);
        }

        [Fact]
        public void DataGetCustomersSuccess()
        {
            var repo = new CustomerRepository();

            var result = repo.GetCustomers();

            Assert.NotNull(result);
        }
    }
}
