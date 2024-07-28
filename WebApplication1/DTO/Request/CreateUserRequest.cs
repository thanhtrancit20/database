namespace WebApplication1.DTO.Request
{
    public class CreateUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Avatar { get; set; }
    }

}
