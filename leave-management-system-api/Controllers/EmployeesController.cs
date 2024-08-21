using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using leave_management_system_api.Interfaces;
using leave_management_system_api.Mappers;
using leave_management_system_api.Dtos.Employee;
using leave_management_system_api.Helpers;

namespace leave_management_system_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            var employees = await _unitOfWork.EmployeeRepository.GetAllAsync(query);

            if (employees != null)
            {
                var employeeDto = employees.Select(e => e.toEmployeeDto());
                return Ok(employeeDto);
            }
            else
            {
                return NotFound("No data found");
            }            
                                    
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> GetById([FromRoute] int id)
        {            
            var employee = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);

            if(employee == null)
            {
                return NotFound();
            }

            var employeeDto = employee.toEmployeeDto();

            return Ok(employeeDto);   
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateEmployeeDto newEmployeeDto)
         {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var employeeModel = newEmployeeDto.toEmployeeFromCreateDto();

            _unitOfWork.EmployeeRepository.Add(employeeModel);
            var result = await _unitOfWork.SaveChangesAsync();

            if (result)
            {
                var departmentModel = await _unitOfWork.DepartmentRepository.GetByIdAsync(newEmployeeDto.DepartmentId);
                employeeModel.Department = departmentModel;
                return CreatedAtAction(nameof(GetById), new { id = employeeModel.Id }, employeeModel.toEmployeeDto());
            }
            else
            {
                return BadRequest("Error occured.");
            }            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateEmployeeDto updatedEmployee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Return if id matches the employee to be updated
            if(id != updatedEmployee.Id)
            {
                return BadRequest("Invalid Request");
            }

            var employeeModel = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);

            if(employeeModel == null)
            {
                return NotFound("Employee Not Found");
            }

            _unitOfWork.EmployeeRepository.Update(employeeModel, updatedEmployee);

            var result = await _unitOfWork.SaveChangesAsync();

            if (result)
            {
                return Ok(employeeModel.toUpdateEmployeeDto());
            }
            else
            {
                return BadRequest("Error occured");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var employeeModel = await _unitOfWork.EmployeeRepository.GetByIdAsync(id);

            if(employeeModel == null)
            {
                return NotFound("Employee Not Found");
            }

            _unitOfWork.EmployeeRepository.Delete(employeeModel);

            var result = await _unitOfWork.SaveChangesAsync();

            if (result)
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Error occured");
            }
        }
    }
}
    