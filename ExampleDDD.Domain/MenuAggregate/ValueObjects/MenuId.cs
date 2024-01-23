using ExampleDDD.Domain.Common.Models;

namespace ExampleDDD.Domain.MenuAggregate.ValueObjects
{
    public sealed class MenuId : AggregateRootId<Guid>
    {
        public override Guid Value { get; protected set; }

        private MenuId(Guid value)
        {
            Value = value;
        }

        public static MenuId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static MenuId Create(Guid id)
        {
            return new(id);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
