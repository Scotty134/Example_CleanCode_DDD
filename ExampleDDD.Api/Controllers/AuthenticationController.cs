using ErrorOr;
using ExampleDDD.Application.Authentication.Commands.Register;
using ExampleDDD.Application.Authentication.Common;
using ExampleDDD.Application.Authentication.Queries.Login;
using ExampleDDD.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExampleDDD.Api.Controllers
{
    [Route("auth")]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(ISender mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            //var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.Password);
            var command = _mapper.Map<RegisterCommand>(request);
            ErrorOr <AuthenticationResult> registerResult = await _mediator.Send(command);
                        
            return registerResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors)
                );            
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            //var query = new LoginQuery(request.Email, request.Password);
            var query = _mapper.Map<LoginQuery>(request);
            var registerResult = await _mediator.Send(query);

            return registerResult.Match(
                authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
                errors => Problem(errors)
                );
        }
    }
}
