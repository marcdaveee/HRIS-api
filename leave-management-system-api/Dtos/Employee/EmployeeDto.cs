using leave_management_system_api.Dtos.Department;
using leave_management_system_api.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace leave_management_system_api.Dtos.Employee
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Lastname { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;

        public int? DepartmentId { get; set; }
        public DepartmentDto? Department { get; set; } = new DepartmentDto();

    }
}
