using Microsoft.EntityFrameworkCore;
using PersonManagerApi.Models;

namespace PersonManagerApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CourseType> CourseTypes { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<GenderType> GenderTypes { get; set; }
    }
}
