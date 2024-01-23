using ExampleDDD.Domain.Common.Models;

namespace ExampleDDD.Domain.MenuAggregate.Events
{
    public record MenuCreated(Menu Menu) : IDomainEvent;
}
