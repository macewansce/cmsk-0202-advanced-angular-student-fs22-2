using Microsoft.EntityFrameworkCore;
using PersonManagerApi.Models.Entities;

namespace PersonManagerApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<GenderType> GenderTypes { get; set; }
    }
}
