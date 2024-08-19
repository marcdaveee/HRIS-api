using leave_management_system_api.Models;

namespace leave_management_system_api.Interfaces
{
    public interface IDepartmentRepository
    {

        Task<IEnumerable<Department>?> GetAllAsync();

        Task<Department?> GetByIdAsync(int id);

        void Add(Department model);

        void Update(Department model);



    }
}
