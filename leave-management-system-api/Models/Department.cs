namespace leave_management_system_api.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string DepartmentName{ get; set; } = string.Empty;

        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
