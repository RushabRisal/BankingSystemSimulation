

using BankingSystem.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankingSystem.Infrastructure.DbConfig
{
    public static class Config
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<MyContext>(option =>
            {
                option.UseSqlServer(config.GetConnectionString("ConnectionString"));
            });
            return service;
        }

    }
}


