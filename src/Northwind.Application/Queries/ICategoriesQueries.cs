using Northwind.Application.Dtos;

namespace Northwind.Application.Queries
{
    public interface ICategoriesQueries
    {
        Task<List<CategoryDto>> GetCategories();
    }
}