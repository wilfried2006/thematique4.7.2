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


[assembly: OwinStartup(typeof(LamyThematique.Web.Startup))]
namespace LamyThematique.Web
{
    public partial class Startup
    {
        private IAppBuilder _appBuilder;
      
        public void Configuration(IAppBuilder app)
        {
            _appBuilder = app;
            //ConfigureAuth(app);
            var services = new ServiceCollection();
            //app.Use(services);
            ConfigureServices(services);

            var resolver = new DefaultDependencyResolver(services.BuildServiceProvider());
            DependencyResolver.SetResolver(resolver);
        }

        public void ConfigureServices(IServiceCollection services)
        {

            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.RegisterLamyThemeInfrastructure();
            services.RegisterLamyThemeInfrastructureMailingServices();
            services.RegisterLamyThemeInfrastructureLoggingServices();
            services.RegisterLamyThemeTransformersWebServices();
            services.RegisterLamyThemeApplicationWebServices();
            services.RegisterLamyThemeInfrastructureRepositoryServices();

            var dbConnectionString = ConfigurationManager.ConnectionStrings["thematiqueConnectionString"].ConnectionString;

            services.RegisterLamyThemeInfrastructureDatabaseServices(dbConnectionString);

            var appSettings = new AppSettings()
            {
                Settings = new AppSettingsClass()
                {
                    AuthApiIpAddress = ConfigurationManager.AppSettings.Get("TestMigrationFra")
                }
            };

            services.AddSingleton(appSettings);
            
            services.AddControllersAsServices(typeof(Startup).Assembly.GetExportedTypes()
                .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
                .Where(t => typeof(IController).IsAssignableFrom(t)
                            || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));
        }
    }
}
