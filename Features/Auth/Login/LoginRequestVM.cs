using FluentValidation;

namespace HRSystem.Features.Auth.Login
{
    public record LoginRequestVM(string UserName,string Password);
    public class LoginRequestVMValidator:AbstractValidator<LoginRequestVM>
    {
        public LoginRequestVMValidator()
        {
            
        }
    }
}
