using System.Collections.Generic;
using UnitTestPractices.DTO;

namespace UnitTestPractices.Data
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int id);
        IEnumerable<Customer> GetCustomers();
    }
}
