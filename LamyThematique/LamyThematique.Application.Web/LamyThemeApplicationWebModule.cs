using LamyThematique.Application.Web.Implementations;
using LamyThematique.Domain.User.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LamyThematique.Application.Web
{
    public static class LamyThemeApplicationWebModule
    {
        public static void RegisterLamyThemeApplicationWebServices(this IServiceCollection services)
        { 
            services.AddTransient<IGetUserPageService, GetUserPageService>();
            services.AddTransient<IUserAuthenticationService, UserAuthenticationService>();
        }
    }
}
