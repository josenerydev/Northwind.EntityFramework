namespace Northwind.Domain.HR
{
    public interface IEmployeeWriteOnlyRepository
    {
        Task<int> Add(Employee category);

        Task Update(Employee category);

        Task Remove(int id);
    }
}