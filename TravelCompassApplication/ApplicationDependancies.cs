using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace TravelCompassApplication
{
    public static class ApplicationDependancies
    {
        public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
        {
            services.AddMediatR(x => x.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            return services;
        }

    }
}
