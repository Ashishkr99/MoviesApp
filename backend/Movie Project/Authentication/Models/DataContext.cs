using Microsoft.EntityFrameworkCore;

namespace Authentication.Models
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {

        }
        public DbSet<UserRegistration> registration { get; set; }

    }
}
