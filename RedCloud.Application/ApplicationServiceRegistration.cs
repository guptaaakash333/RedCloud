using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace RedCloud.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly())
            );
            return services;
        }

        //public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        //{
        //    services.AddAutoMapper(Assembly.GetExecutingAssembly());
        //    services.AddMediatR(Assembly.GetExecutingAssembly());

        //    return services;
        //}
    }
}
