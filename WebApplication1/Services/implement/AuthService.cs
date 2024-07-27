using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication1.Data;
using WebApplication1.DTO.Request;
using WebApplication1.DTO.Response;
using WebApplication1.Model;

namespace WebApplication1.Services.implement
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public LoginResponse Authenticate(LoginRequest loginRequest)
        {
            var user = _context.UserLoginDetails.FirstOrDefault(u => u.LoginID == loginRequest.LoginID);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginRequest.LoginPassword, user.LoginPassword))
            {
                return new LoginResponse { Message = "Invalid credentials" };
            }
            var tokenString = GenerateJwtToken(user);
            var loginHistory = new UserLoginHistory
            {
                UserID_FK = user.UserID_FK,
                UserLoginID_FK = user.UserLoginID,
                LoginName = user.LoginID,
                Timestamp = DateTime.UtcNow,
                IpAddress = "127.0.0.1",
                IsSuccess = true,
                AccessToken = tokenString,
                Message = "Login successful"
            };
            _context.UserLoginHistory.Add(loginHistory);
            _context.SaveChanges();

            return new LoginResponse { Token = tokenString, Message = "Login successful" };
        }

        public bool CreateUser(CreateUserRequest createUserRequest)
        {
            if (createUserRequest.Password != createUserRequest.ConfirmPassword)
            {
                throw new ArgumentException("Password and Confirm Password do not match.");
            }

            if (_context.UserAccounts.Any(u => u.EmailAddress == createUserRequest.Email))
            {
                return false;
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(createUserRequest.Password);

            var newUserAccount = new UserAccount
            {
                FirstName = string.Empty,
                LastName = string.Empty,
                DateCreated = DateTime.UtcNow,
                DateDeleted = DateTime.MinValue,
                AvatarPath = string.Empty,
                EmailAddress = createUserRequest.Email,
                ContactNumber = string.Empty,
                MobileNumber = string.Empty,
                StripeRef = string.Empty,
                IsActive = true,
                IsDeleted = false,
                AccountType = 3,
                AccountTimeZone = 0,
                IsVerified = false
            };

            _context.UserAccounts.Add(newUserAccount);
            _context.SaveChanges();

            int newUserId = newUserAccount.UserId;

            var newUserLoginDetails = new UserLoginDetails
            {
                UserID_FK = newUserId,
                LoginID = createUserRequest.Email,
                LoginPassword = hashedPassword,
                IsFirstTimeLogin = true,
                FailAttempts = 0,
                IsLocked = false
            };

            _context.UserLoginDetails.Add(newUserLoginDetails);
            _context.SaveChanges();

            return true;
        }

        public string GenerateJwtToken(UserLoginDetails user)
        {
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.LoginID),
                new Claim(ClaimTypes.NameIdentifier, user.UserLoginID.ToString())
            };
            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Issuer"],
                expires: DateTime.Now.AddHours(1),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha512Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public UserAccount ParseToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            try
            {
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = _configuration["Jwt:Issuer"],
                    ValidateLifetime = true
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
                Console.WriteLine(userIdClaim);
                if (userIdClaim == null)
                {
                    throw new SecurityTokenException("Invalid token");
                }

                var user = _context.UserAccounts.FirstOrDefault(u => u.UserId == int.Parse(userIdClaim));

                if (user == null)
                {
                    throw new Exception("User not found");
                }

                return user;
            }
            catch (Exception ex)
            {
                throw new SecurityTokenException("Invalid token", ex);
            }
        }
    }
}
