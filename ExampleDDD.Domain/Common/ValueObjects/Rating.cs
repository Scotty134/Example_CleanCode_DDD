using ExampleDDD.Domain.Common.Models;

namespace ExampleDDD.Domain.Common.ValueObjects
{
    public sealed class Rating : ValueObject
    {
        public int Value { get; }

        private Rating(int value)
        {
            Value = value;
        }

        public static Rating CreateNew(int rating = 0)
        {
            return new(rating);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
