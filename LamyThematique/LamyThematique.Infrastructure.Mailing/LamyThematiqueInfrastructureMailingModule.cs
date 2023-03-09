using LamyThematique.Domain;
using LamyThematique.Infrastructure.Mailing.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace LamyThematique.Infrastructure.Mailing
{
    public static class LamyThematiqueInfrastructureMailingModule
    {
        public static void RegisterLamyThematiqueInfrastructureMailingServices(this IServiceCollection services)
        {
            services.AddTransient<IMailer, Mailer>();
        }

        public static void RegisterLamyThematiqueInfrastructureMailingForTestingServices(this IServiceCollection services)
        {
            services.AddTransient<IMailer, FakeMailer>();
        }
    }
}
