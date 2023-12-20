using ErrorOr;
using ExampleDDD.Application.Services.Authentication.Common;

namespace ExampleDDD.Application.Services.Authentication.Queries
{
    public interface IAuthenticationQueryService
    {
        public ErrorOr<AuthenticationResult> Login(string email, string password);
    }
}
