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
using LamyThematique.Web.Extensions;
using Microsoft.EntityFrameworkCore;


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
            var dbConnectionString = ConfigurationManager.ConnectionStrings["thematiqueConnectionString"].ConnectionString;
            
            var services = new ServiceCollection();
            services.AddControllersAsServices(typeof(Startup).Assembly.GetExportedTypes()
                .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
                .Where(t => typeof(IController).IsAssignableFrom(t)
                            || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));


            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.RegisterLamyThemeInfrastructure();
            services.RegisterLamyThemeInfrastructureMailingServices();
            services.RegisterLamyThemeInfrastructureLoggingServices();
            services.RegisterLamyThemeTransformersWebServices();
            services.RegisterLamyThemeApplicationWebServices();
            services.RegisterLamyThemeInfrastructureRepositoryServices();

            services.RegisterLamyThemeInfrastructureDatabaseServices(dbConnectionString);
            
            var appSettings = new AppSettings()
            {
                Settings = new AppSettingsClass()
                {
                    AuthApiIpAddress = ConfigurationManager.AppSettings.Get("TestMigrationFra")
                }
            };

            services.AddSingleton(appSettings);


            return services;
        }
    }
}
