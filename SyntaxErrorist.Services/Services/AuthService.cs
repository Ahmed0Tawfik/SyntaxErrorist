using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using SyntaxErrorist.Core;
using SyntaxErrorist.Core.IService;
using SyntaxErrorist.Shared.Models;
using System.Security.Claims;

namespace SyntaxErrorist.Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IEmailSenderService _emailService;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<ApplicationUser> userManager, ITokenService tokenService, IEmailSenderService emailService, IConfiguration configuration)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _emailService = emailService;
            _configuration = configuration;
        }
        public Task<AuthResult> ChangePasswordAsync(string username, string currentPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResult> ConfirmEmailAsync(string userId, string token)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResult> ForgotPasswordAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResult> LoginAsync(string username, string password)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResult> RefreshTokenAsync(string accessToken, string refreshToken)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResult> RegisterUserAsync(ApplicationUser user, string password, string? role = "User")
        {
            var exists = await _userManager.FindByEmailAsync(user.Email);

            if (exists != null)
            {
                return new AuthResult
                {
                    Message = "User with this email address already exists",
                    Succeeded = false
                };
            }

            var result = await _userManager.CreateAsync(user, password);

            if(result.Succeeded)
            {
                return new AuthResult
                {
                    Token = _tokenService.GenerateAccessToken(new List<Claim>
                    {
                        new Claim("Email", user.Email),
                        new Claim(ClaimTypes.NameIdentifier, user.Id)
                    }),
                    Message = "User created successfully",
                    Succeeded = true
                };
            }

            return new AuthResult
            {
                Message = "User creation failed",
                Succeeded = false,
                Errors = result.Errors.Select(e => e.Description)
            };


        }

        public Task<AuthResult> ResendEmailConfirmationAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<AuthResult> ResetPasswordAsync(string email, string token, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task RevokeTokenAsync(string username)
        {
            throw new NotImplementedException();
        }
    }
}
