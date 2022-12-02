using Microsoft.EntityFrameworkCore;
using ProjectsBlogWebAPI.Models;

namespace ProjectsBlogWebAPI.Data
{
    public class ProjectsBlogDbContext : DbContext
    {
        public ProjectsBlogDbContext(DbContextOptions<ProjectsBlogDbContext> options) : base
            (options)
        {
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Project> Projects { get; set; }
    }
}
