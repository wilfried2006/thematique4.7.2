using LamyThematique.Application.Web.Implementations;
using LamyThematique.Domain.User.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LamyThematique.Application.Web
{
    public static class LamyThematiqueApplicationWebModule
    {
        public static void RegisterLamyThematiqueApplicationWebServices(this IServiceCollection services)
        { 
            services.AddTransient<IGetUserPageService, GetUserPageService>();
            services.AddTransient<IUserAuthenticationService, UserAuthenticationService>();
        }
    }
}
