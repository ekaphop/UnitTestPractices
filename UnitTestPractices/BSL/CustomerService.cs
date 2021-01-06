using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestPractices.Data;
using UnitTestPractices.DTO;
using UnitTestPractices.Exceptions;

namespace UnitTestPractices.BSL
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepo;

        public CustomerService(ICustomerRepository customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        public Customer GetCustomerById(int id)
        {
            if (id < 1)
            {
                throw new ArgumentException(nameof(id));
            }

            var customer = customerRepo.GetCustomer(id);

            if (customer == null)
            {
                throw new DataNotFoundException();
            }
            return customer;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            var customers = customerRepo.GetCustomers();

            if (customers == null)
            {
                return Enumerable.Empty<Customer>();
            }

            return customers;
        }
    }
}
