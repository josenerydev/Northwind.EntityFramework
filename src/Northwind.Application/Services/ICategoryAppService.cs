using Northwind.Application.Production;

namespace Northwind.Application.Services
{
    public interface ICategoryAppService
    {
        Task<CategoryDetailsDto> Add(CreateCategoryDto category);

        Task<CategoryDetailsDto> Get(int id);

        Task Update(UpdateCategoryDto category);

        Task Remove(int id);
    }
}