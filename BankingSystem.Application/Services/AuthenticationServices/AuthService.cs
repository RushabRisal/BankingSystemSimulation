

using BankingSystem.Application.DTOs.UserDto;
using BankingSystem.Application.IRepository.ICommand.IAuthentication;
using BankingSystem.Application.IServices.IAuthentication;
using BankingSystem.Domain.Models;
using System.Security.Cryptography.X509Certificates;

namespace BankingSystem.Application.Services.AuthenticationServices
{
    public class AuthService(IRegisterCommand register) : IAuthService
    {
        private readonly IRegisterCommand _register = register;
        public async Task<ResponseRegistry> RegisterAsync(RequestRegistry user)
        {
            //Prepare Model
            var userData = new UserModel(user.FirstName,
                user.MiddleName,
                user.LastName, user.Contact, user.Email, user.Password, user.Role);
            _ = await _register.RegisterUserCommand(userData);

            return new ResponseRegistry { Email = userData.Email };
        }
    }
}
