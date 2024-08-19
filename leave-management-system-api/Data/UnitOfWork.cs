using leave_management_system_api.Controllers;
using leave_management_system_api.Interfaces;
using leave_management_system_api.Repository;

namespace leave_management_system_api.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IEmployeeRepository EmployeeRepository => new EmployeeRepository(_context);

        public IDepartmentRepository DepartmentRepository => new DepartmentRepository(_context);

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
