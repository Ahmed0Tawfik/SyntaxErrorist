using MediatR;
using SyntaxErrorist.Core.APIResponse;
using SyntaxErrorist.Core.IService;
using SyntaxErrorist.Shared.Models;

namespace SyntaxErrorist.Core.MediatRHandlers.Auth.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ApiResponse<AuthResultDTO>>
    {

        private readonly IAuthService _authService;
        private readonly ApiResponseHandler apiResponseHandler;

        public RegisterUserCommandHandler(IAuthService authService, ApiResponseHandler apiResponseHandler)
        {
            _authService = authService;
            this.apiResponseHandler = apiResponseHandler;
        }

        public async Task<ApiResponse<AuthResultDTO>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser
            {
                Email = request.Email,
                UserName = request.Email,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now

            };

            var result = await _authService.RegisterUserAsync(user, request.Password,"User");

            if (result.Succeeded)
            {
                var response = new AuthResultDTO
                {
                    Token = result.Token,
                };

                return apiResponseHandler.Success(response);
            }


            var errors = result.Errors.ToList(); 

            return apiResponseHandler.BadRequest<AuthResultDTO>(errors);




        }
    }
}
