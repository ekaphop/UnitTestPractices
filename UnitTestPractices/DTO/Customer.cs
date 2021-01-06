using System;
using UnitTestPractices.Enums;

namespace UnitTestPractices.DTO
{
    public class Customer
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Nationality { get; set; }

        public string Country { get; set; }

        public MaritalStatus MaritalStatus { get; set; }
    }
}
