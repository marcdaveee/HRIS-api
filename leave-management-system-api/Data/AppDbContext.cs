using leave_management_system_api.Models;
using Microsoft.EntityFrameworkCore;

namespace leave_management_system_api.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department).WithMany(e => e.Employees).HasForeignKey(e => e.DepartmentId).OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                Lastname = "Hernandez",
                Firstname = "Gian Mico",
                DepartmentId = 1
            },
            new Employee
            {
                Id = 2,
                Lastname = "Dimaculangan",
                Firstname = "Lea",
                DepartmentId = 1
            },
            new Employee
            {
                Id = 3,
                Lastname = "John",
                Firstname = "Doe",
                DepartmentId = 3,
            });


            modelBuilder.Entity<Department>().HasData(new Department
            {
                Id = 1,
                DepartmentName = "Human Resource",
            }, new Department
            {
                Id = 2,
                DepartmentName = "MENRO",
            },
            new Department
            {
                Id = 3,
                DepartmentName = "Agriculture",
            });

        }
    }
}
