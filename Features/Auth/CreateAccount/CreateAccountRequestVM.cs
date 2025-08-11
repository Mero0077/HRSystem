using FluentValidation;

namespace HRSystem.Features.Auth.CreateAccount
{
    public record CreateAccountRequestVM(string UserName,string FirstName,string LastName, string Phone, string Country, string Email, string Password, string ConfirmedPassword);
    public class CreateAccountRequestVMValidator : AbstractValidator<CreateAccountRequestVM>
    {
        public CreateAccountRequestVMValidator()
        {
            RuleFor(e => e.UserName).NotEmpty();
        }

    }
}
