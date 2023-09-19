using Microsoft.EntityFrameworkCore;

namespace Api_with_dev_creed.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }


        public DbSet<Gener> Geners { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
