using CardapioOnlineAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardapioOnlineAPI.Db
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        {
        }

        public DbSet<MenuItem> MenuItems { get; set; }

    }
}
