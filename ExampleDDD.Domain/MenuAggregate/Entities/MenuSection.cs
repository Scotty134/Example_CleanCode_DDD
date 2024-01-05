using ExampleDDD.Domain.Common.Models;
using ExampleDDD.Domain.MenuAggregate.ValueObjects;

namespace ExampleDDD.Domain.MenuAggregate.Entities
{
    public sealed class MenuSection : Entity<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();

        private MenuSection(MenuSectionId menuSectionId, string name, string description, List<MenuItem> items)
            : base(menuSectionId)
        {
            Name = name;
            Description = description;
            _items = items;
        }

#pragma warning disable CS8618
        public MenuSection()
        {
            
        }
#pragma warning disable CS8618

        public static MenuSection Create(string name, string description, IEnumerable<MenuItem> items)
        {
            return new(MenuSectionId.CreateUnique(), name, description, items.ToList());
        }
    }
}
