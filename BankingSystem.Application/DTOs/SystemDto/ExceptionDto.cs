

using System.Text.Json;

namespace BankingSystem.Application.DTOs.SystemDto
{
    public class ExceptionDto
    {
        public int StatusCode { get; set; }
        public required string Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
