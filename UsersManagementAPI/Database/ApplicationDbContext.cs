using Microsoft.EntityFrameworkCore;
using UsersManagementAPI.Models;

namespace UsersManagementAPI.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserReport> UsersReports { get; set; }
    }

}
