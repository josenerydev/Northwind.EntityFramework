namespace Northwind.Domain.HR
{
    public interface IEmployeeReadOnlyRepository
    {
        Task<Employee> Get(int id);
    }
}