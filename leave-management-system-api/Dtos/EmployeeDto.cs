using leave_management_system_api.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace leave_management_system_api.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Lastname { get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;

        [ForeignKey("DepartmentId")]
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
