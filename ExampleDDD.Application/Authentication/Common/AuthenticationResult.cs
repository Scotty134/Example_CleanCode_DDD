using ExampleDDD.Domain.Entities;

namespace ExampleDDD.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token
    );
}
