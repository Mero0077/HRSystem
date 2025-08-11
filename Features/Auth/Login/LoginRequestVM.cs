using FluentValidation;
using HRSystem.Common.Constants;

namespace HRSystem.Features.Auth.Login
{
    public record LoginRequestVM(string UserName, string Password);
    public class LoginRequestVMValidator : AbstractValidator<LoginRequestVM>
    {
        public LoginRequestVMValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage(Constants.UserNameNotEmptyLogin);
            RuleFor(x => x.Password).NotEmpty().WithMessage(Constants.PasswordNotEmptyLogin);

        }
    }
}