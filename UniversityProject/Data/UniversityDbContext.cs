using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using UniversityProject.Models;

namespace UniversityProject.Data
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
        {
        }

        public DbSet<Course> Course { get; set; }
    }
}
