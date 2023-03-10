using LamyThematique.Infrastructure.Authentication.Implementations;
using LamyThematique.Infrastructure.Authentication.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace LamyThematique.Infrastructure.Authentication
{
    public static class LamyThematiqueInfrastructureAuthenticationModule
    {
        public static void RegisterLamyThematiqueInfrastructure(this IServiceCollection services)
        {
            //services.AddTransient<IMaboOnlineOrderService, MaboOnlineOrderService>();
            //services.AddTransient<IMaboSearchService, MaboSearchService>();
            //services.AddTransient<IMaboUserService, MaboUserService>();

            services.AddTransient<IUserAuthenticationInfrastructure, UserAuthenticationInfrastructure>();
            services.AddTransient<IUserAuthenticationMaboInfrastructure, UserAuthenticationMaboInfrastructure>();
        }
    }
}
