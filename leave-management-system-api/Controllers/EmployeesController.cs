using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using leave_management_system_api.Interfaces;
using leave_management_system_api.Mappers;
using leave_management_system_api.Dtos.Employee;

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
        public async Task<IActionResult> GetAll()
        {
            var employees = await _unitOfWork.EmployeeRepository.GetAllAsync();

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
    }
}
    