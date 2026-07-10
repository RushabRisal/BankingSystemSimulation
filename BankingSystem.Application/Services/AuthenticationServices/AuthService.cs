

using BankingSystem.Application.DTOs.UserDto;
using BankingSystem.Application.IRepository.ICommand.IAuthentication;
using BankingSystem.Application.IRepository.IQuery.IAuthentication;
using BankingSystem.Application.IServices.IAuthentication;
using BankingSystem.Application.IServices.ISecurity;
using BankingSystem.Application.IServices.IValidation;
using BankingSystem.Domain.DomainException;
using BankingSystem.Domain.Models;
using Microsoft.AspNetCore.Http;
namespace BankingSystem.Application.Services.AuthenticationServices
{
    public class AuthService(IRegisterCommand _register, IUserRepository _user, ICryptoService _crypto, IValidatorServices _validate, IJwtServices _jwt) : IAuthService
    {
        public async Task<ResponseRegistryDto> RegisterAsync(RequestRegistryDto user)
        {
            //Prepare Model
            var userData = new UserModel
            {
                FirstName = user.FirstName,
                MiddleName = user.MiddleName ?? string.Empty,
                LastName = user.LastName,
                Email = _validate.IsValidEmail(user.Email).Result ? user.Email : throw new InvalidEmailFormat("Email is not in Standard"),
                Contact = user.Contact,
                PasswordHash = "",
                Role = user.Role
            };
            var hashPwd = _crypto.GenerateHasPassword(userData, user.Password);
            userData.PasswordHash = hashPwd;
            _ = await _register.RegisterUserCommand(userData);

            return new ResponseRegistryDto { Email = userData.Email };
        }
        public async Task<TokenResponse?> LoginAsync(RequestLoginDto userData)
        {

            var user = await _user.GetUserCredentialByEmail<UserModel>(userData.Email);
            string userHashedPassword = user.PasswordHash;
            var result = _crypto.IsPasswordValid(user: null!, hashedPassword: userHashedPassword, toBeComparedPassword: userData.Password);
            return !result ? null : await _jwt.CreateTokens(user, user.Email);

        }
        public void SetCookie(TokenResponse request, HttpContext context)
        {
            context.Response.Cookies.Append("accessToken", request.AccessToken,
                    new CookieOptions
                    {
                        Expires = DateTime.UtcNow.AddMinutes(5),
                        IsEssential = true,
                        HttpOnly = true,
                        SameSite = SameSiteMode.Strict,
                        Secure = true
                    }
                );
            context.Response.Cookies.Append("refreshToken", request.RefreshToken,
                    new CookieOptions
                    {
                        Expires = DateTime.UtcNow.AddDays(7),
                        IsEssential = true,
                        HttpOnly = true,
                        SameSite = SameSiteMode.Strict,
                        Secure = true
                    }
                );
        }
    }
}
