using leave_management_system_api.Data;
using leave_management_system_api.Dtos.Employee;
using leave_management_system_api.Helpers;
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


        public async Task<IEnumerable<Employee>?> GetAllAsync(QueryObject query)
        {


            var employees =  _context.Employees.Include(e => e.Department).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.EmployeeName))
            {
                employees = employees.Where(e => e.Firstname.Contains(query.EmployeeName) || e.Lastname.Contains(query.EmployeeName));
            }

            return await employees.ToListAsync();

            //var employeesWithDepartmentInfo = await _context.Employees
            //    .Select(e => new
            //    {
            //        e.Id,
            //        e.Lastname,
            //        e.Firstname,
            //        DepartmentId = e.Department.Id,
            //        DepartmentName = e.Department.DepartmentName
            //    })
            //    .ToListAsync();
            //return employeesWithDepartmentInfo

        }    

        public async Task<Employee?> GetByIdAsync(int id)
        {
            return await _context.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.Id == id);
        }
      

        public void Update(Employee model, UpdateEmployeeDto updatedEmployee)
        {
            model.Firstname = updatedEmployee.Firstname;
            model.Lastname = updatedEmployee.Lastname;
            model.DepartmentId = updatedEmployee.DepartmentId;
        }

        public void Delete(Employee model)
        {
            _context.Employees.Remove(model);
        }

    }
}
