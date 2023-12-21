using ErrorOr;
using ExampleDDD.Application.Authentication.Common;
using MediatR;

namespace ExampleDDD.Application.Authentication.Commands.Register
{
    public record RegisterCommand(
        string FirstName,
        string LastName,
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
