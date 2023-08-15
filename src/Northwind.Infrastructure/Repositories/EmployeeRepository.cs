using Microsoft.EntityFrameworkCore;

using Northwind.Domain.HR;

namespace Northwind.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeReadOnlyRepository, IEmployeeWriteOnlyRepository
    {
        private readonly Context _context;

        public EmployeeRepository(Context context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<int> Add(Employee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee));

            await _context.Employees.AddAsync(employee);
            return await _context.SaveChangesAsync();
        }

        public async Task<Employee> Get(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task Remove(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) throw new ArgumentNullException(nameof(employee));

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Employee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee));

            _context.Employees.Update(employee); // Explicitly marking the entity as modified
            await _context.SaveChangesAsync();
        }
    }
}