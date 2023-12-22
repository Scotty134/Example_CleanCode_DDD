using ExampleDDD.Domain.Common.Models;

namespace ExampleDDD.Domain.Common.ValueObjects
{
    public sealed class Rating : ValueObject
    {
        public Guid Value { get; }

        private Rating(Guid value)
        {
            Value = value;
        }

        public static Rating CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
