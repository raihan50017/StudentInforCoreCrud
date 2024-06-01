using app.web.Models;
using Microsoft.EntityFrameworkCore;

namespace app.web.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}
