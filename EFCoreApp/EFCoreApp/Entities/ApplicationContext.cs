using Microsoft.EntityFrameworkCore;

namespace EFCoreApp.Entities
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) 
            : base(options) 
        {
        }
        public DbSet<Student> Students { get; set; }
    }
}
