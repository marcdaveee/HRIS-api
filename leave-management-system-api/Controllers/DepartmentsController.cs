using leave_management_system_api.Data;
using leave_management_system_api.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace leave_management_system_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<DepartmentsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var departments = await _unitOfWork.DepartmentRepository.GetAllAsync();
            return Ok(departments);
        }
     

    
    }
}
