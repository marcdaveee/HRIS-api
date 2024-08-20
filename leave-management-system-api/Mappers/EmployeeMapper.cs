using leave_management_system_api.Dtos.Employee;
using leave_management_system_api.Models;

namespace leave_management_system_api.Mappers
{
    public static class EmployeeMapper
    {
        public static EmployeeDto toEmployeeDto(this Employee employeeModel)
        {

            return new EmployeeDto
            {
                Id = employeeModel.Id,
                Lastname = employeeModel.Lastname,
                Firstname = employeeModel.Firstname,
                DepartmentId = employeeModel.DepartmentId,
                Department = employeeModel.Department.ToDepartmentDto()
            };
        }

        public static Employee toEmployeeFromCreateDto(this CreateEmployeeDto createEmployeeDto)
        {
            return new Employee
            {
                Firstname = createEmployeeDto.Firstname,
                Lastname = createEmployeeDto.Lastname,
                DepartmentId = createEmployeeDto.DepartmentId,
            };
        }

    }
}
