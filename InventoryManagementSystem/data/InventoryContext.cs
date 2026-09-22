using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.data
{
    public class InventoryContext : IdentityDbContext<ApplicationUser>
    {
        private IConfiguration config;

        public InventoryContext(IConfiguration _config)
        {
            config = _config;
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Item> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("InventoryConn"));
            base.OnConfiguring(optionsBuilder);
        }
    }
}