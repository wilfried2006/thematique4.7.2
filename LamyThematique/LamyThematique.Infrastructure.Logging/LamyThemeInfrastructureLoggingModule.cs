using LamyThematique.Domain;
using LamyThematique.Infrastructure.Logging.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace LamyThematique.Infrastructure.Logging
{
    public static class LamyThemeInfrastructureLoggingModule
    {
        public static void RegisterLamyThemeInfrastructureLoggingServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        }

        public static void RegisterLamyThemeInfrastructureLoggingForTestingServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        }
    }
}
