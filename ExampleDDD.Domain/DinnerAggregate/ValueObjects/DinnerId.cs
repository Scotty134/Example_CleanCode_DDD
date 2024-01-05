using ExampleDDD.Domain.Common.Models;

namespace ExampleDDD.Domain.DinnerAggregate.ValueObjects
{
    public sealed class DinnerId : ValueObject
    {
        public Guid Value { get; private set; }

        private DinnerId(Guid value)
        {
            Value = value;
        }

#pragma warning disable CS8618
        public DinnerId()
        {
            
        }
#pragma warning disable CS8618

        public static DinnerId CreateUnique()
        {
            return new(Guid.NewGuid());
        }

        public static DinnerId Create(Guid id)
        {
            return new(id);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
