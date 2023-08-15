namespace Northwind.Application.HR.Employees
{
    public interface IEmployeeQueries
    {
        Task<List<EmployeeDetailsDto>> GetEmployees();
    }
}