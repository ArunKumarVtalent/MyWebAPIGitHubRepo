using Microsoft.EntityFrameworkCore;
using WebAPIPro.Models;

namespace WebAPIPro.DBContext
{
    public class ProjectDBContext : DbContext
    {
        // Dependency Injection Process. [.Net Core By Default Provides DI]
        // Loosly Couppled App Dev
        public ProjectDBContext(DbContextOptions<ProjectDBContext> options) : base(options) { }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
