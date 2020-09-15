using System;

namespace MyApi.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Guid ComapanyId { get; set; }
        public string EmployeeNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public Company Company { get; set; }
    }
}