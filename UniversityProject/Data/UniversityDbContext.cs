using Microsoft.EntityFrameworkCore;

namespace UniversityProject.Data
{
    public class UniversityDbContext : DbContext
    {
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options) : base(options)
        {

        }
    }
}
