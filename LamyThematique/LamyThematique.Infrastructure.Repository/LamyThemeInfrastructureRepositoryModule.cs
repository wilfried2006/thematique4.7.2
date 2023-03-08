using LamyThematique.Domain.User.Interfaces;
using LamyThematique.Infrastructure.Repository.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace LamyThematique.Infrastructure.Repository
{
    public static class LamyThemeInfrastructureRepositoryModule
    {
        public static void RegisterLamyThemeInfrastructureRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}