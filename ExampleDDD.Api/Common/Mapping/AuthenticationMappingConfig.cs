using ExampleDDD.Application.Authentication.Commands.Register;
using ExampleDDD.Application.Authentication.Common;
using ExampleDDD.Application.Authentication.Queries.Login;
using ExampleDDD.Contracts.Authentication;
using Mapster;

namespace ExampleDDD.Api.Common.Mapping
{
    public class AuthenticationMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();
            config.NewConfig<AuthenticationResult, AuthenticationResponse>()
                .Map(dest => dest.Token, src => src.Token)
                .Map(dest => dest, src => src.User);
        }
    }
}
