using BankingSystem.Application.DTOs.UserDto;
using BankingSystem.Application.IRepository.IQuery.IAuthentication;
using BankingSystem.Infrastructure.InfraExceptionHandler;
using BankingSystem.Infrastructure.Persistence;
using Dapper;
namespace BankingSystem.Infrastructure.Repository.Query.AuthenticationQuery
{
    public class AuthenticationRepository(MyDapperContext _context) : IUserRepository
    {
        public async Task<LoginResponseDto?> GetUserCredentialByEmail(string Email)
        {
            using var conn = _context.CreateConnection();
            var query = """SELECT PasswordHash FROM Users WHERE Email = @Email""";
            var userHashPassword = await conn.QueryFirstOrDefaultAsync<LoginResponseDto>(query,
                    new { Email }
                );
            return userHashPassword?.PasswordHash is not null? userHashPassword : throw new PasswordDoesnotExistException("User don't Exist");
        }
    }
}
