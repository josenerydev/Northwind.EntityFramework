using AutoMapper;

using Northwind.Application.Dtos;
using Northwind.Domain.Production;

namespace Northwind.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}