using Xunit;
using Moq;
using UnitTestPractices.Data;
using UnitTestPractices.DTO;
using System.Collections.Generic;
using System;
using System.Linq;

namespace UnitTestPractices.Test
{
    public class CustomerRepositoryTest
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Case_GetCustomer(int value, Customer expect)
        {
            // Arrange
            CustomerRepository customerRepository = new CustomerRepository();
            Customer actual = null;
            // Act
            actual = customerRepository.GetCustomer(value);

            // Assert

            if (actual != null)
            {
                Assert.Equal(expect.Id, actual.Id);
                Assert.Equal(expect.FirstName, actual.FirstName);
                Assert.Equal(expect.LastName, actual.LastName);
                Assert.Equal(expect.MaritalStatus, actual.MaritalStatus);
                Assert.Equal(expect.Country, actual.Country);
                Assert.Equal(expect.Nationality, actual.Nationality);
                Assert.Equal(expect.BirthDate, actual.BirthDate);
            }
            else
            {
                Assert.Equal(expect, actual);
            }
        }

        [Theory]
        [MemberData(nameof(AllData))]
        public void Case_GetCustomers(List<Customer> expect)
        {
            // Arrange
            CustomerRepository customerRepository = new CustomerRepository();
            List<Customer> actual = null;

            // Act
            var result = customerRepository.GetCustomers();
            actual = result.ToList();

            // Assert
            Assert.Equal(expect[0].Id, actual[0].Id);
            Assert.Equal(expect[1].Id, actual[1].Id);
            Assert.Equal(expect[2].Id, actual[2].Id);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { 1,
                new Customer
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Xenon",
                    MaritalStatus = Enums.MaritalStatus.Single,
                    Country= "TH",
                    Nationality = "US",
                    BirthDate = new DateTime(1999, 10, 9)
                }, },

            new object[] { 2,
                new Customer
                {
                    Id = 2,
                    FirstName = "Zoe",
                    LastName = "Chen",
                    MaritalStatus = Enums.MaritalStatus.Married,
                    Country= "VN",
                    Nationality = "AU",
                    BirthDate = new DateTime(1970, 1, 20)
                }, },

            new object[] { 3,
                new Customer
                {
                    Id = 3,
                    FirstName = "Helena",
                    LastName = "Watson",
                    MaritalStatus = Enums.MaritalStatus.Divorced,
                    Country= "CA",
                    Nationality = "CA",
                    BirthDate = new DateTime(2005, 6, 1)
                } },
            new object[] { 4, null },
            new object[] { 0, null },
            new object[] { -1, null }
        };

        public static IEnumerable<object[]> AllData =>
        new List<object[]>
        {
            new object[] {
                new List<Customer>
                {
                    new Customer
                    {
                        Id = 1,
                        FirstName = "John",
                        LastName = "Xenon",
                        MaritalStatus = Enums.MaritalStatus.Single,
                        Country= "TH",
                        Nationality = "US",
                        BirthDate = new DateTime(1999, 10, 9)
                    },

                    new Customer
                    {
                        Id = 2,
                        FirstName = "Zoe",
                        LastName = "Chen",
                        MaritalStatus = Enums.MaritalStatus.Married,
                        Country= "VN",
                        Nationality = "AU",
                        BirthDate = new DateTime(1970, 1, 20)
                    },

                    new Customer
                    {
                        Id = 3,
                        FirstName = "Helena",
                        LastName = "Watson",
                        MaritalStatus = Enums.MaritalStatus.Divorced,
                        Country = "CA",
                        Nationality = "CA",
                        BirthDate = new DateTime(2005, 6, 1)
                    }
                }
            }
        };
    }
}
