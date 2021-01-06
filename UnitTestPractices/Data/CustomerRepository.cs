using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestPractices.DTO;

namespace UnitTestPractices.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// Mock data set that simulates real database connection
        /// </summary>
        private readonly IEnumerable<Customer> mockCustomers =
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
                    Country= "CA",
                    Nationality = "CA",
                    BirthDate = new DateTime(2005, 6, 1)
                }
            };

        public Customer GetCustomer(int id)
        {
            return mockCustomers.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return mockCustomers;
        }
    }
}
