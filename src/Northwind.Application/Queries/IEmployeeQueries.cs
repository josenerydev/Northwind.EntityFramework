using Northwind.Application.HR;

namespace Northwind.Application.Queries
{
    public interface IEmployeeQueries
    {
        Task<List<EmployeeDetailsDto>> GetEmployees();
    }
}