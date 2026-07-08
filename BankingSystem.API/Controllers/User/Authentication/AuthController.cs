using BankingSystem.Application.DTOs.UserDto;
using BankingSystem.Application.IServices.IAuthentication;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.API.Controllers.User.Authentication
{
    [Route("api/v1/auth")]
    [ApiController]
    public class Auth(IAuthService auth) : ControllerBase
    {
        private readonly IAuthService _auth = auth;
        [Route("/regiter")]
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RequestRegistryDto user)
        {
            var response = await _auth.RegisterAsync(user);

            return Ok(response);
        }

        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> LoginUser([FromBody] RequestLoginDto user)
        {
            var response = await _auth.LoginAsync(user);
            return response ? Ok(response) : NotFound();
        }

    }
}
