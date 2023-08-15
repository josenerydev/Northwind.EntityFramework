using AutoMapper;

using Northwind.Domain.HR;

namespace Northwind.Application.HR.Employees
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IEmployeeReadOnlyRepository _readOnlyRepository;
        private readonly IEmployeeWriteOnlyRepository _writeOnlyRepository;
        private readonly IMapper _mapper;

        public EmployeeAppService(IEmployeeReadOnlyRepository readOnlyRepository,
                                  IEmployeeWriteOnlyRepository writeOnlyRepository,
                                  IMapper mapper)
        {
            _readOnlyRepository = readOnlyRepository ?? throw new ArgumentNullException(nameof(readOnlyRepository));
            _writeOnlyRepository = writeOnlyRepository ?? throw new ArgumentNullException(nameof(writeOnlyRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<EmployeeDetailsDto> Add(CreateEmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _writeOnlyRepository.Add(employee);
            return _mapper.Map<EmployeeDetailsDto>(employee);
        }

        public async Task<EmployeeDetailsDto> Get(int id)
        {
            var employee = await _readOnlyRepository.Get(id);
            return _mapper.Map<EmployeeDetailsDto>(employee);
        }

        public async Task Remove(int id)
        {
            await _writeOnlyRepository.Remove(id);
        }

        public async Task Update(UpdateEmployeeDto employeeDto)
        {
            var existingEmployee = await _readOnlyRepository.Get(employeeDto.Id);
            if (existingEmployee == null) throw new ArgumentException("Employee not found");

            _mapper.Map(employeeDto, existingEmployee);
            await _writeOnlyRepository.Update(existingEmployee);
        }
    }
}