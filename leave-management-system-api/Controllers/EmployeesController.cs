using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using leave_management_system_api.Models;
using Microsoft.Identity.Client;
using leave_management_system_api.Data;
using leave_management_system_api.Interfaces;

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
        public async Task <IActionResult> GetAll()
        {
            var employees = await _unitOfWork.EmployeeRepository.GetAllAsync();
            await _unitOfWork.SaveChangesAsync();

            return Ok(employees);
        }
    }
}
