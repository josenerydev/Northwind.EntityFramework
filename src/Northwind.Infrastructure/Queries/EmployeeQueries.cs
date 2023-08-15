using Microsoft.EntityFrameworkCore;
using Northwind.Application.HR.Employees;

namespace Northwind.Infrastructure.Queries
{
    public class EmployeeQueries : IEmployeeQueries
    {
        private readonly Context _context;

        public EmployeeQueries(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<EmployeeDetailsDto>> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            foreach (var employee in employees)
            {
                if (employee.ManagerId.HasValue)
                {
                    await _context.Entry(employee).Reference(e => e.Manager).LoadAsync();
                }
                await _context.Entry(employee).Collection(e => e.Subordinates).LoadAsync();
            }

            return employees.Select(e => new EmployeeDetailsDto
            {
                Id = e.Id,
                LastName = e.LastName,
                FirstName = e.FirstName,
                Title = e.Title,
                TitleOfCourtesy = e.TitleOfCourtesy,
                BirthDate = e.BirthDate,
                HireDate = e.HireDate,
                Address = e.Address,
                City = e.City,
                Region = e.Region,
                PostalCode = e.PostalCode,
                Country = e.Country,
                Phone = e.Phone,
                ManagerId = e.ManagerId,
                Manager = e.Manager == null ? null : new EmployeeDetailsDto
                {
                    Id = e.Manager.Id,
                    LastName = e.Manager.LastName,
                    FirstName = e.Manager.FirstName,
                    Title = e.Manager.Title,
                    TitleOfCourtesy = e.Manager.TitleOfCourtesy,
                    BirthDate = e.Manager.BirthDate,
                    HireDate = e.Manager.HireDate,
                    Address = e.Manager.Address,
                    City = e.Manager.City,
                    Region = e.Manager.Region,
                    PostalCode = e.Manager.PostalCode,
                    Country = e.Manager.Country,
                    Phone = e.Manager.Phone,
                    ManagerId = e.Manager.ManagerId
                },
                Subordinates = e.Subordinates.Select(s => new EmployeeDetailsDto
                {
                    Id = s.Id,
                    LastName = s.LastName,
                    FirstName = s.FirstName,
                    Title = s.Title,
                    TitleOfCourtesy = s.TitleOfCourtesy,
                    BirthDate = s.BirthDate,
                    HireDate = s.HireDate,
                    Address = s.Address,
                    City = s.City,
                    Region = s.Region,
                    PostalCode = s.PostalCode,
                    Country = s.Country,
                    Phone = s.Phone,
                    ManagerId = s.ManagerId
                }).ToList()
            }).ToList();
        }
    }
}