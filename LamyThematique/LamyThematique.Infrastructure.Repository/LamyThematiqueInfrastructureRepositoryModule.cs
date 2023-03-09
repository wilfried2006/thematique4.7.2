using LamyThematique.Domain.User.Interfaces;
using LamyThematique.Infrastructure.Repository.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace LamyThematique.Infrastructure.Repository
{
    public static class LamyThematiqueInfrastructureRepositoryModule
    {
        public static void RegisterLamyThematiqueInfrastructureRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}