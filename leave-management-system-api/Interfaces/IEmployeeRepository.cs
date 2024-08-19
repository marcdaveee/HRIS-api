using leave_management_system_api.Models;

namespace leave_management_system_api.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>?> GetAllAsync();

        Task<Employee?> GetByIdAsync(int id);

        void Add(Employee model);

        void Update(Employee model);
        

    }
}
