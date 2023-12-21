using ErrorOr;
using ExampleDDD.Application.Authentication.Common;
using MediatR;

namespace ExampleDDD.Application.Authentication.Queries.Login
{
    public record LoginQuery(
        string Email,
        string Password) : IRequest<ErrorOr<AuthenticationResult>>;
}
