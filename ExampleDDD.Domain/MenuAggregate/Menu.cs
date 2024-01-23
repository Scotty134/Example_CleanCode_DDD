using ExampleDDD.Domain.Common.Models;
using ExampleDDD.Domain.Common.ValueObjects;
using ExampleDDD.Domain.DinnerAggregate.ValueObjects;
using ExampleDDD.Domain.HostAggregate.ValueObjects;
using ExampleDDD.Domain.MenuAggregate.Entities;
using ExampleDDD.Domain.MenuAggregate.ValueObjects;
using ExampleDDD.Domain.MenuReviewAggregate.ValueObjects;

namespace ExampleDDD.Domain.MenuAggregate
{
    public sealed class Menu : AggregateRoot<MenuId, Guid>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public AverageRating AverageRating { get; private set; }
        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds => _menuReviewIds.AsReadOnly();
        public HostId HostId { get; private set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private Menu(
            MenuId menuId,
            string name,
            string description,
            HostId hostId,
            AverageRating rating,
            DateTime createdDateTime,
            DateTime updatedDateTime,
            List<MenuSection>? sections)
            : base(menuId)
        {
            Name = name;
            Description = description;
            HostId = hostId;
            AverageRating = rating;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
            _sections = sections;
        }

#pragma warning disable CS8618
        public Menu()
        {

        }
#pragma warning disable CS8618

        public static Menu Create(string name, string description, HostId hostId, AverageRating rating, List<MenuSection>? sections)
        {
            return new(
                MenuId.CreateUnique(),
                name,
                description,
                hostId,
                rating,
                DateTime.UtcNow,
                DateTime.UtcNow,
                sections?? new());
        }
    }
}
