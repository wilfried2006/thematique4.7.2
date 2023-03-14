using System;
using System.Data.SqlClient;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace LamyThematique.Infrastructure.Database
{
    public static class LamyThematiqueInfrastructureDatabaseModule
    {
        /// <summary>
        /// AddSqlServer
        /// </summary>
        /// <param name="services"></param>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static IServiceCollection RegisterLamyThematiqueInfrastructureDatabaseServices(this IServiceCollection services)
        {
            services.AddSingleton(new AzureServiceTokenProvider());

            services.AddDbContext<ThematiqueDbContext>();

            return services;
        }
    }
}