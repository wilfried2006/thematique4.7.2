using Microsoft.Owin;
using Owin;
using Microsoft.Extensions.DependencyInjection;
using ServiceCollection = Microsoft.Extensions.DependencyInjection.ServiceCollection;
using System;
using System.Configuration;
using System.Linq;
using LamyThematique.Application.Web;
using LamyThematique.Domain.Common;
using LamyThematique.Infrastructure.Authentication;
using LamyThematique.Infrastructure.Database;
using LamyThematique.Infrastructure.Logging;
using LamyThematique.Infrastructure.Mailing;
using LamyThematique.Infrastructure.Repository;
using LamyThematique.Transformers.Application.Web;
using System.Web.Mvc;
using LamyThematique.Domain;
using LamyThematique.Infrastructure.ReadRepository;
using LamyThematique.Web.Extensions;


[assembly: OwinStartup(typeof(LamyThematique.Web.Startup))]
namespace LamyThematique.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
            //app.Use(services);

            var services = ConfigureServices();
            var resolver = new DefaultDependencyResolver(services.BuildServiceProvider());
            DependencyResolver.SetResolver(resolver);
        }

        public IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddControllersAsServices(typeof(Startup).Assembly.GetExportedTypes()
                .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
                .Where(t => typeof(IController).IsAssignableFrom(t)
                            || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));
           
            var appSettings = new AppSettings()
            {
                Settings = new AppSettingsClass()
                {
                    AuthApiIpAddress = ConfigurationManager.AppSettings.Get("TestMigrationFra")
                },
                DatabaseConnectionString = ConfigurationManager.ConnectionStrings["thematiqueConnectionString"].ConnectionString
            };

            services.AddSingleton(appSettings);


            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.RegisterLamyThematiqueInfrastructure();
            services.RegisterLamyThematiqueInfrastructureMailingServices();
            services.RegisterLamyThematiqueInfrastructureLoggingServices();
            services.RegisterLamyThematiqueTransformersWebServices();
            services.RegisterLamyThematiqueApplicationWebServices();
            services.RegisterLamyThematiqueInfrastructureRepositoryServices();
            services.RegisterLamyThematiqueInfrastructureReadRepositoryServices();

            services.RegisterLamyThematiqueInfrastructureDatabaseServices();

     

            return services;
        }
    }
}
