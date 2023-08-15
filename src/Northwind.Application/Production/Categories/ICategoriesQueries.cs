namespace Northwind.Application.Production.Categories
{
    public interface ICategoriesQueries
    {
        Task<List<CategoryDetailsDto>> GetCategories();
    }
}