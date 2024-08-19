using leave_management_system_api.Data;
using leave_management_system_api.Interfaces;
using leave_management_system_api.Models;
using Microsoft.EntityFrameworkCore;

namespace leave_management_system_api.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Employee model)
        {
            _context.Employees.Add(model);
        }

        public async Task<IEnumerable<Employee>?> GetAllAsync()
        {
            return await _context.Employees.Include(e => e.Department).ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }
      

        public void Update(Employee model)
        {
          _context.Update(model);
        }
        
    }
}
