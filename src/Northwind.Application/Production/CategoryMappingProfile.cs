using AutoMapper;

using Northwind.Domain.Production;

namespace Northwind.Application.Production
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<Category, CategoryDetailsDto>().ReverseMap();

            CreateMap<Category, CreateCategoryDto>().ReverseMap();

            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
        }
    }
}