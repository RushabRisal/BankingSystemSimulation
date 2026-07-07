using BankingSystem.Domain.DomainException;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Testing : ControllerBase
    {
        [HttpGet]
        public string GetHello()
        {
            throw new InvalidEmailFormat("The email is not in Standard Format");
        }
    }
}
