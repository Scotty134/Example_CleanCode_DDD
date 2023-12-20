using ErrorOr;
using ExampleDDD.Application.Services.Authentication.Common;

namespace ExampleDDD.Application.Services.Authentication.Commands
{
    public interface IAuthenticationCommandService
    {
        public ErrorOr<AuthenticationResult> Register(string firstName, string lastName, string email, string password);
    }
}
