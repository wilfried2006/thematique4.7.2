using LamyThematique.Domain;
using LamyThematique.Infrastructure.Logging.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace LamyThematique.Infrastructure.Logging
{
    public static class LamyThematiqueInfrastructureLoggingModule
    {
        public static void RegisterLamyThematiqueInfrastructureLoggingServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        }

        public static void RegisterLamyThematiqueInfrastructureLoggingForTestingServices(this IServiceCollection services)
        {
            services.AddTransient(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        }
    }
}
