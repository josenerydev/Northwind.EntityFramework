namespace Northwind.Application.HR.Employees
{
    public interface IEmployeeAppService
    {
        Task<EmployeeDetailsDto> Add(CreateEmployeeDto employeeDto);

        Task<EmployeeDetailsDto> Get(int id);

        Task Remove(int id);

        Task Update(UpdateEmployeeDto employeeDto);
    }
}