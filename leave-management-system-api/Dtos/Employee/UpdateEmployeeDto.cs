using System.ComponentModel.DataAnnotations;

namespace leave_management_system_api.Dtos.Employee
{
    public class UpdateEmployeeDto
    {

        [Required]
        public int Id { get; set; }

        [Required]
        public string Lastname { get; set; } = string.Empty;

        [Required]
        public string Firstname { get; set; } = string.Empty;

        [Required]
        public int? DepartmentId { get; set; }

    }
}
