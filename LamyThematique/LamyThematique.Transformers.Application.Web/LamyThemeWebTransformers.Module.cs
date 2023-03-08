using LamyThematique.Domain.User.Interfaces.Transformers;
using LamyThematique.Transformers.Application.Web.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace LamyThematique.Transformers.Application.Web
{
    public static class LamyThemeTransformersWebModule
    {
        public static void RegisterLamyThemeTransformersWebServices(this IServiceCollection services)
        {
            services.AddTransient<IUserAuthenticationTransformer, UserAuthenticationTransformer>();
        }
    }
}
