using ExampleDDD.Domain.Common.Models;
using ExampleDDD.Domain.MenuAggregate.ValueObjects;

namespace ExampleDDD.Domain.MenuReviewAggregate.ValueObjects
{
    public sealed class MenuReviewId : ValueObject
    {
        public Guid Value { get; private set; }

        private MenuReviewId(Guid value)
        {
            Value = value;
        }

        public MenuReviewId()
        {
            
        }

        public static MenuReviewId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static MenuReviewId Create(Guid id)
        {
            return new(id);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
