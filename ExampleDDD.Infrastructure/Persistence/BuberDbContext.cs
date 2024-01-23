using ExampleDDD.Domain.Common.Models;
using ExampleDDD.Domain.MenuAggregate;
using ExampleDDD.Infrastructure.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace ExampleDDD.Infrastructure.Persistence
{
    public class BuberDbContext: DbContext
    {
        private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;

        public BuberDbContext(DbContextOptions<BuberDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor) : base(options)
        {
            _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
        }

        public DbSet<Menu> Menus { get; set; } = null!;
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Ignore<List<IDomainEvent>>()
                .ApplyConfigurationsFromAssembly(typeof(BuberDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
