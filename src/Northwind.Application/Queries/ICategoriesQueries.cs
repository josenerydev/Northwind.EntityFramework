using Northwind.Application.Production;

namespace Northwind.Application.Queries
{
    public interface ICategoriesQueries
    {
        Task<List<CategoryDetailsDto>> GetCategories();
    }
}