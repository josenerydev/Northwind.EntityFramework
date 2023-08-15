using Northwind.Application.HR;

namespace Northwind.Application.Services
{
    public interface IEmployeeAppService
    {
        Task<EmployeeDetailsDto> Add(CreateEmployeeDto employeeDto);

        Task<EmployeeDetailsDto> Get(int id);

        Task Remove(int id);

        Task Update(UpdateEmployeeDto employeeDto);
    }
}