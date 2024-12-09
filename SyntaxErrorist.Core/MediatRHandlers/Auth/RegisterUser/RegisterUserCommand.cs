using MediatR;
using SyntaxErrorist.Core.APIResponse;

namespace SyntaxErrorist.Core.MediatRHandlers.Auth.RegisterUser
{
    public class RegisterUserCommand : IRequest<ApiResponse<AuthResultDTO>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
