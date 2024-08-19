using leave_management_system_api.Data;
using leave_management_system_api.Repository;

namespace leave_management_system_api.Interfaces
{
    public interface IUnitOfWork
    {        

        IEmployeeRepository EmployeeRepository { get; }

        IDepartmentRepository DepartmentRepository { get; }

        Task<bool> SaveChangesAsync();
    }
}
