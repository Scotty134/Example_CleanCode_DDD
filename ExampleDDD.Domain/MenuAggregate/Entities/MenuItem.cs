using ExampleDDD.Domain.Common.Models;
using ExampleDDD.Domain.MenuAggregate.ValueObjects;

namespace ExampleDDD.Domain.MenuAggregate.Entities
{
    public sealed class MenuItem : Entity<MenuItemId>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        private MenuItem(MenuItemId menuItemId, string name, string description)
            : base(menuItemId)
        {
            Name = name;
            Description = description;
        }

#pragma warning disable CS8618
        public MenuItem()
        {
            
        }
#pragma warning disable CS8618

        public static MenuItem Create(string name, string description)
        {
            return new(MenuItemId.CreateUnique(), name, description);
        }
    }
}
