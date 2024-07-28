using Microsoft.AspNetCore.Identity.Data;
using System.Security.Claims;
using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Model;

namespace WebApplication1.Services
{
    public interface IAuthService
    {
        public bool CreateUser(CreateUserRequest createUserRequest);
        public LoginResponse Authenticate(DTO.Request.LoginRequest loginRequest);
        public UserAccount ParseToken(ClaimsPrincipal userPrincipal);
        public string GenerateJwtToken(UserLoginDetails user);
    }
}
