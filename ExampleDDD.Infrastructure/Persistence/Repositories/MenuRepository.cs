using ExampleDDD.Application.Common.Interfaces.Persistence;
using ExampleDDD.Domain.MenuAggregate;

namespace ExampleDDD.Infrastructure.Persistence.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly BuberDbContext _context;

        public MenuRepository(BuberDbContext context)
        {
            _context = context;
        }

        public void Add(Menu menu)
        {
            _context.Add(menu);
            _context.SaveChanges();
        }
    }
}
