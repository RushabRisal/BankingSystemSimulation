using BankingSystem.Application.DTOs.UserDto;
using BankingSystem.Application.IRepository.IQuery.IAuthentication;
using BankingSystem.Domain.Models;
using BankingSystem.Infrastructure.InfraExceptionHandler;
using BankingSystem.Infrastructure.Persistence;
using Dapper;
using Microsoft.AspNetCore.Identity;
namespace BankingSystem.Infrastructure.Repository.Query.AuthenticationQuery
{
    public class AuthenticationRepository(MyDapperContext _context) : IUserRepository
    {
        public async Task<T?> GetUserCredentialByEmail<T>(string Email)
        {
            using var conn = _context.CreateConnection();
            var query = """SELECT * FROM Users WHERE Email = @Email""";
            var user = await conn.QueryFirstOrDefaultAsync<T>(query,
                    new { Email }
                );
            return user;
        }
    }
}
