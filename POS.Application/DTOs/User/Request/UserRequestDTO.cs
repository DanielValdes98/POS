using Microsoft.AspNetCore.Http;

namespace POS.Application.DTOs.User.Request
{
    public class UserRequestDTO
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public IFormFile? Image { get; set; }
        public int? State { get; set; }
    }
}
