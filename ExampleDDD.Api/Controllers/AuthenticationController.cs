using ErrorOr;
using ExampleDDD.Application.Services.Authentication.Commands;
using ExampleDDD.Application.Services.Authentication.Common;
using ExampleDDD.Application.Services.Authentication.Queries;
using ExampleDDD.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ExampleDDD.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly IAuthenticationCommandService _authenticationCommandService;
        private readonly IAuthenticationQueryService _authenticationQueryService;

        public AuthenticationController(IAuthenticationCommandService authenticationCommandService, IAuthenticationQueryService authenticationQueryService)
        {
            _authenticationCommandService = authenticationCommandService;
            _authenticationQueryService = authenticationQueryService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            ErrorOr<AuthenticationResult> registerResult = _authenticationCommandService.Register(
                request.FirstName, 
                request.LastName, 
                request.Email, 
                request.Password);
                        
            return registerResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
                );            
        }

        private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
        {
            return new AuthenticationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token
                );
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var registerResult = _authenticationQueryService.Login(request.Email, request.Password);

            return registerResult.Match(
                authResult => Ok(MapAuthResult(authResult)),
                errors => Problem(errors)
                );
        }
    }
}
