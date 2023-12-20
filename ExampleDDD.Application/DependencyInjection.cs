using ExampleDDD.Application.Services.Authentication.Commands;
using ExampleDDD.Application.Services.Authentication.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleDDD.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
            services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();

            return services;
        }
    }
}
