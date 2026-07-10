

using BankingSystem.Application.IRepository.ICommand.IAuthentication;
using BankingSystem.Application.IRepository.IQuery.IAuthentication;
using BankingSystem.Application.IServices.IAuthentication;
using BankingSystem.Application.IServices.ISecurity;
using BankingSystem.Application.IServices.IValidation;
using BankingSystem.Application.Services.AuthenticationServices;
using BankingSystem.Application.Services.Security;
using BankingSystem.Application.Services.Validator;
using BankingSystem.Domain.Models;
using BankingSystem.Infrastructure.Persistence;
using BankingSystem.Infrastructure.Repository.Command.AuthRepository;
using BankingSystem.Infrastructure.Repository.Query.AuthenticationQuery;
using Microsoft.AspNetCore.Identity;
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
                option.UseSqlServer(config.GetConnectionString("ConnectionString"),
                    x => x.MigrationsAssembly("BankingSystem.Infrastructure")

                    );
            });
            service.AddSingleton<MyDapperContext>();
            service.Configure<PasswordHasherOptions>(options =>
            {
                options.IterationCount = 500_000;
                options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV3;
            });
            service.AddSingleton<PasswordHasher<UserModel>>();
            service.AddSingleton<ICryptoService, CryptoServices>();
            service.AddScoped<IRegisterCommand, RegisterCommand>();
            service.AddScoped<IUserRepository, AuthenticationRepository>();
            service.AddScoped<IAuthService, AuthService>();
            service.AddScoped<IJwtServices, JwtServices>();
            service.AddScoped<ILoginCommandRepository, LoginCommand>();
            service.AddScoped<IValidatorServices, ValidationServices>();
            return service;
        }

    }
}


