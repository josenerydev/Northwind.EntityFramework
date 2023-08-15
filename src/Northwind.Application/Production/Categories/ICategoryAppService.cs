namespace Northwind.Application.Production.Categories
{
    public interface ICategoryAppService
    {
        Task<CategoryDetailsDto> Add(CreateCategoryDto category);

        Task<CategoryDetailsDto> Get(int id);

        Task Update(UpdateCategoryDto category);

        Task Remove(int id);
    }
}