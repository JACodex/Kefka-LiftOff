using Microsoft.EntityFrameworkCore;
using KEFKA.Models;
namespace KEFKA.Data
{
    public class KefkaDbContext : DbContext
    {
        public DbSet<Story> Stories { get; set; }

        //public KefkaDbContext() : base() { }
        public KefkaDbContext(DbContextOptions<KefkaDbContext> options) : base(options)
        {

        }
    }
}
