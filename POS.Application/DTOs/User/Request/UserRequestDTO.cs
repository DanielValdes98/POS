namespace POS.Application.DTOs.User.Request
{
    public class UserRequestDTO
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Image { get; set; }
        public int? State { get; set; }
    }
}
