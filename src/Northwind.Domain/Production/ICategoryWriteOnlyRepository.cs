namespace Northwind.Domain.Production
{
    public interface ICategoryWriteOnlyRepository
    {
        Task<int> Add(Category category);

        Task Update(Category category);

        Task Remove(int id);
    }
}