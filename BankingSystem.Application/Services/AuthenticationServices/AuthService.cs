

using BankingSystem.Application.DTOs.UserDto;
using BankingSystem.Application.IRepository.ICommand.IAuthentication;
using BankingSystem.Application.IRepository.IQuery.IAuthentication;
using BankingSystem.Application.IServices.IAuthentication;
using BankingSystem.Application.IServices.ISecurity;
using BankingSystem.Domain.Models;

namespace BankingSystem.Application.Services.AuthenticationServices
{
    public class AuthService(IRegisterCommand _register, IUserRepository _user, ICryptoService _crypto) : IAuthService
    {
        public async Task<ResponseRegistryDto> RegisterAsync(RequestRegistryDto user)
        {
            //Prepare Model
            var userData = new UserModel(user.FirstName,
                user.MiddleName ?? "",
                user.LastName, user.Contact, user.Email, user.Password, user.Role);
            var hashPwd = _crypto.GenerateHasPassword(userData, user.Password);
            userData.PasswordHash = hashPwd;
            _ = await _register.RegisterUserCommand(userData);

            return new ResponseRegistryDto { Email = userData.Email };
        }
        public async Task<bool> LoginAsync(RequestLoginDto userData)
        {

            var userHashedPassword = await _user.GetUserCredentialByEmail(userData.Email);

            var result = _crypto.IsPasswordValid(user: null!, hashedPassword: userHashedPassword.PasswordHash, toBeComparedPassword: userData.Password);
            return result;

        }
    }
}
