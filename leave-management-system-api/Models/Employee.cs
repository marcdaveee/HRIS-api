using System.ComponentModel.DataAnnotations.Schema;

namespace leave_management_system_api.Models
{
    public class Employee
    {
        public int Id{ get; set; }
        public string Lastname{ get; set; } = string.Empty;
        public string Firstname { get; set; } = string.Empty;

        [ForeignKey("DepartmentId")]
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

    }
}
