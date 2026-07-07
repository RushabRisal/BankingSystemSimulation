

using BankingSystem.Application.IRepository.ICommand.IAuthentication;
using BankingSystem.Application.IServices.IAuthentication;
using BankingSystem.Application.Services.AuthenticationServices;
using BankingSystem.Infrastructure.Persistence;
using BankingSystem.Infrastructure.Repository.Command.AuthRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BankingSystem.Infrastructure.DbConfig
{
    public static class Config
    {
        public static IServiceCollection GetSerives(this IServiceCollection service, IConfiguration config)
        {
            service.AddDbContext<MyContext>(option =>
            {
                option.UseSqlServer(config.GetConnectionString("ConnectionString"));
            });
            service.AddScoped<IRegisterCommand, RegisterCommand>();
            service.AddScoped<IAuthService, AuthService>();
            return service;
        }

    }
}


