using LamyThematique.Domain.Document.Interfaces.Transformers;
using LamyThematique.Domain.User.Interfaces.Transformers;
using LamyThematique.Transformers.Application.Web.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace LamyThematique.Transformers.Application.Web
{
    public static class LamyThematiqueTransformersWebModule
    {
        public static void RegisterLamyThematiqueTransformersWebServices(this IServiceCollection services)
        {
            services.AddTransient<IUserAuthenticationTransformer, UserAuthenticationTransformer>();
            services.AddTransient<ISearchResultPageTransformer, SearchResultPageTransformer>();
        }
    }
}
