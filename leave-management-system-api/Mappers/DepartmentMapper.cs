using leave_management_system_api.Dtos.Department;
using leave_management_system_api.Models;

namespace leave_management_system_api.Mappers
{
    public static class DepartmentMapper
    {
        public static DepartmentDto ToDepartmentDto (this Department DepartmentModel)
        {
            return new DepartmentDto
            {
                Id = DepartmentModel.Id,
                DepartmentName = DepartmentModel.DepartmentName
            };
        }
    }
}
