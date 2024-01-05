using ExampleDDD.Domain.MenuAggregate;
using Microsoft.EntityFrameworkCore;

namespace ExampleDDD.Infrastructure.Persistence
{
    public class BuberDbContext: DbContext
    {
        public BuberDbContext(DbContextOptions<BuberDbContext> options) : base(options)
        {            
        }

        public DbSet<Menu> Menus { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BuberDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
