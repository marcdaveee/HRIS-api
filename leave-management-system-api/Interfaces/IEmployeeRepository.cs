using leave_management_system_api.Dtos.Employee;
using leave_management_system_api.Helpers;
using leave_management_system_api.Models;

namespace leave_management_system_api.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>?> GetAllAsync(QueryObject query);

        Task<Employee?> GetByIdAsync(int id);

        void Add(Employee model);

        void Update(Employee model, UpdateEmployeeDto updatedEmployee);
        
        void Delete(Employee model);

    }
}
