using Northwind.Application.Dtos;

namespace Northwind.Application.Services
{
    public interface ICategoryAppService
    {
        Task<CategoryDto> Add(CategoryDto category);

        Task<CategoryDto> Get(int id);

        Task Update(CategoryDto category);

        Task Remove(int id);
    }
}