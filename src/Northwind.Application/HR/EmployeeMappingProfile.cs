using AutoMapper;

using Northwind.Domain.HR;

namespace Northwind.Application.HR
{
    public class EmployeeMappingProfile : Profile
    {
        public EmployeeMappingProfile()
        {
            CreateMap<Employee, EmployeeDetailsDto>()
                .ForMember(dest => dest.Manager, opt => opt.MapFrom(src => src.Manager))
                .ForMember(dest => dest.Subordinates, opt => opt.MapFrom(src => src.Subordinates))
                .ReverseMap();

            CreateMap<Employee, CreateEmployeeDto>().ReverseMap();

            CreateMap<Employee, UpdateEmployeeDto>().ReverseMap();
        }
    }
}