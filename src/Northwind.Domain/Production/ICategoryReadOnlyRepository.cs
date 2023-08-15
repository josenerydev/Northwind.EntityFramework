namespace Northwind.Domain.Production
{
    public interface ICategoryReadOnlyRepository
    {
        Task<Category> Get(int id);
    }
}