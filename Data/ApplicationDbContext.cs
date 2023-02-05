using EmployeeCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCRUD.Data
{
    public class ApplicationDbContext : DbContext
    {
        // We pass context configuration from AddDbContext to DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // This helps us to do LINQ querys
        // in some cases it can be evaluated in memory rather than being translated in query
        public DbSet<Employee> Employees { get; set; }  


    }
}
