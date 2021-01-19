using System;
using System.Collections.Generic;
using System.Text;
using UnitTestPractices.Data;
using Xunit;

namespace UnitTestPractices.Test
{
    public class UnitTestRepo
    {
        private CustomerRepository repo = new CustomerRepository();

        [Fact(DisplayName = "Get customers, Success")]
        public void GetCustomersIsSuccess()
        {
            var result = repo.GetCustomers();
            Assert.NotNull(result);
        }

        [Theory(DisplayName = "Get customer by id, Success")]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void GetCustomerByIdIsSuccess(int cusIt)
        {
            var result = repo.GetCustomer(cusIt);
            Assert.NotNull(result);
            Assert.Equal(result.Id, cusIt);
        }

        [Theory(DisplayName = "Get customer by id, Fail")]
        [InlineData(-1)]
        [InlineData(0)]
        public void GetCustomerByIdIsFail(int cusIt)
        {
            var result = repo.GetCustomer(cusIt);
            Assert.Null(result);
        }
    }
}
