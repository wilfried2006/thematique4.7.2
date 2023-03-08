using LamyThematique.Domain;
using LamyThematique.Infrastructure.Mailing.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace LamyThematique.Infrastructure.Mailing
{
    public static class LamyThemeInfrastructureMailingModule
    {
        public static void RegisterLamyThemeInfrastructureMailingServices(this IServiceCollection services)
        {
            services.AddTransient<IMailer, Mailer>();
        }

        public static void RegisterLamyThemeInfrastructureMailingForTestingServices(this IServiceCollection services)
        {
            services.AddTransient<IMailer, FakeMailer>();
        }
    }
}
