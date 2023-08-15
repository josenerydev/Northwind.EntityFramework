using Microsoft.AspNetCore.Mvc;
using Northwind.Application.HR.Employees;

namespace Northwind.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeAppService _employeeAppService;
        private readonly IEmployeeQueries _employeeQueries;

        public EmployeesController(IEmployeeAppService employeeAppService, IEmployeeQueries employeeQueries)
        {
            _employeeAppService = employeeAppService ?? throw new ArgumentNullException(nameof(employeeAppService));
            _employeeQueries = employeeQueries ?? throw new ArgumentNullException(nameof(employeeQueries));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateEmployeeDto employee)
        {
            var createdEmployee = await _employeeAppService.Add(employee);
            return CreatedAtRoute("GetEmployee", new { id = createdEmployee.Id }, createdEmployee);
        }

        [HttpGet(Name = "GetEmployees")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _employeeQueries.GetEmployees());
        }

        [HttpGet("{id}", Name = "GetEmployee")]
        public async Task<IActionResult> Get(int id)
        {
            var employee = await _employeeAppService.Get(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateEmployeeDto employee)
        {
            if (await _employeeAppService.Get(id) == null)
            {
                return NotFound();
            }

            await _employeeAppService.Update(employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var employee = await _employeeAppService.Get(id);
            if (employee == null)
            {
                return NotFound();
            }

            await _employeeAppService.Remove(id);
            return NoContent();
        }
    }
}