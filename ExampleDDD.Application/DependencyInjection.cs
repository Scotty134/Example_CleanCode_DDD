using ErrorOr;
using ExampleDDD.Application.Authentication.Commands.Register;
using ExampleDDD.Application.Authentication.Common;
using ExampleDDD.Application.Common.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ExampleDDD.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            services.AddScoped(
                typeof (IPipelineBehavior<,>), 
                typeof(ValidationBehavior<,>));
            
            //services.AddScoped<IValidator<RegisterCommand>, RegisterCommandValidator>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
