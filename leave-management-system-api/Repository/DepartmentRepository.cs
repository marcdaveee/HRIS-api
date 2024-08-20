using leave_management_system_api.Data;
using leave_management_system_api.Interfaces;
using leave_management_system_api.Models;
using Microsoft.EntityFrameworkCore;

namespace leave_management_system_api.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Department model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Department>?> GetAllAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department?> GetByIdAsync(int id)
        {
            return await _context.Departments.FirstOrDefaultAsync(d => d.Id == id);
        }

        public void Update(Department model)
        {
            throw new NotImplementedException();
        }
    }
}
