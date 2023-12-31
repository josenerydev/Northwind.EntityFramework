﻿namespace Northwind.Application.HR.Employees
{
    public class EmployeeDetailsDto
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string TitleOfCourtesy { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public int? ManagerId { get; set; }
        public EmployeeDetailsDto? Manager { get; set; }
        public List<EmployeeDetailsDto>? Subordinates { get; set; }
    }
}