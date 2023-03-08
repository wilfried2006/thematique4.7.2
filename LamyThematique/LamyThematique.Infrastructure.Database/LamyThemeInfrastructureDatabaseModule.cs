using System;
using System.Data.SqlClient;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

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
        public static IServiceCollection RegisterLamyThemeInfrastructureDatabaseServices(this IServiceCollection services, string conn)
        {
            services.AddSingleton(new AzureServiceTokenProvider());

            services.AddDbContext<ThematiqueDbContext>(options =>
            {
                var azureProvider = new AzureServiceTokenProvider();

                var connection = new SqlConnection() { ConnectionString = conn };

                if (!"Development".Equals(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"), StringComparison.CurrentCultureIgnoreCase)
                    && Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") != null)
                    connection.AccessToken = azureProvider.GetAccessTokenAsync("https://database.windows.net/").Result;

                options.UseSqlServer(connection);
            });

            return services;
        }
    }
}