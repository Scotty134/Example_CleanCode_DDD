using ExampleDDD.Api.Common.Errors;
using ExampleDDD.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ExampleDDD.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddMapping();
            services.AddControllers();
            //builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
            services.AddSingleton<ProblemDetailsFactory, ExampleDDDProblemDetailsFactory>();

            return services;
        }
    }
}
