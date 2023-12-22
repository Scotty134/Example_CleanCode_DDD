using ExampleDDD.Domain.Common.Models;

namespace ExampleDDD.Domain.Common.ValueObjects
{
    public sealed class AverageRating : ValueObject
    {
        public Guid Value { get; }

        private AverageRating(Guid value)
        {
            Value = value;
        }

        public static AverageRating CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
