using ExampleDDD.Domain.MenuAggregate;

namespace ExampleDDD.Application.Common.Interfaces.Persistence
{
    public interface IMenuRepository
    {
        void Add(Menu menu);
    }
}
