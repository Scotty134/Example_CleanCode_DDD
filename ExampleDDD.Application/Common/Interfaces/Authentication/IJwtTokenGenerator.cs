using ExampleDDD.Domain.Entities;

namespace ExampleDDD.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        public string GenerateToken(User user);
    }
}
