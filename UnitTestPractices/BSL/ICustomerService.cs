using System.Collections.Generic;
using UnitTestPractices.DTO;

namespace UnitTestPractices.BSL
{
    public interface ICustomerService
    {
        Customer GetCustomerById(int id);
        IEnumerable<Customer> GetCustomers();
    }
}
