using ExampleDDD.Application.Common.Interfaces.Authentication;
using ExampleDDD.Application.Common.Interfaces.Persistence;
using ExampleDDD.Application.Common.Interfaces.Services;
using ExampleDDD.Infrastructure.Authentication;
using ExampleDDD.Infrastructure.Persistence;
using ExampleDDD.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExampleDDD.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
