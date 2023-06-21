using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CQRSAkademiPlusPostgres.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options):base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
