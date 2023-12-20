using ExampleDDD.Application.Common.Interfaces.Services;

namespace ExampleDDD.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
