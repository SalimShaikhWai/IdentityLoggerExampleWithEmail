using Demo63Assignment.Models;
using Demo63Assignment.Models.DataModel;
using IdentityLogger.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityLogger.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationIdentityUser, IdentityRole, string>
    {
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Employee> Employees { get; set; } = null!;

        public DbSet<Department> Departments { get; set; }=null!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}