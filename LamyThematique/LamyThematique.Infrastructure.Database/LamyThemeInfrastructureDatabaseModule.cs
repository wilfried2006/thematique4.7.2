using System;
using System.Data.SqlClient;
using System.Reflection;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace LamyThematique.Infrastructure.Database
{
    public static class LamyThemeInfrastructureDatabaseModule
    {
        /// <summary>
        /// AddSqlServer
        /// </summary>
        /// <param name="services"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterLamyThemeInfrastructureDatabaseServices(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton(new AzureServiceTokenProvider());

            //services.AddDbContext<ThematiqueDbContext>()

            //services.AddScoped<ThematiqueDbContext>(
            ////options => options.UseSqlSer
            //);

            //services.AddScoped(_ => new ThematiqueDbContext(connectionString));

            services.AddDbContext<ThematiqueDbContext>(options =>
            {
                var connection = new SqlConnection(connectionString);

                //var azureProvider = new AzureServiceTokenProvider();

                //if (!"Development".Equals(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), StringComparison.CurrentCultureIgnoreCase)

                //&& Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != null)

                //    connection.AccessToken = azureProvider.GetAccessTokenAsync("https://database.windows.net/").Result;

                //options.UseSqlServer(connection);

                options.UseSqlServer(connection,
                    optionsSqlServer => { optionsSqlServer.MigrationsAssembly(Assembly.GetExecutingAssembly().ToString()); });

            });

            return services;
        }
    }
}