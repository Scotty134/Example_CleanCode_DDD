using ExampleDDD.Domain.Entities;

namespace ExampleDDD.Application.Services.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token
    );
}
