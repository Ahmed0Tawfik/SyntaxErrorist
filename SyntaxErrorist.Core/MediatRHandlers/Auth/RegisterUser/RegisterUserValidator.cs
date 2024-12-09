using FluentValidation;

namespace SyntaxErrorist.Core.MediatRHandlers.Auth.RegisterUser
{
    public class RegisterUserValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is Required").EmailAddress();
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is Required").MinimumLength(8);
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password);
        }
    }
}
