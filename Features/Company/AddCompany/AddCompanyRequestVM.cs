using FluentValidation;

namespace HRSystem.Features.Company.AddCompany
{
    public record AddCompanyRequestVM(string Name, string Description, string Location, string Email, string Phone);
    public class AddCompanyRequestVMValidator:AbstractValidator<AddCompanyRequestVM>
    {
        public AddCompanyRequestVMValidator()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("Name must be entered!");
            RuleFor(e => e.Description).NotEmpty().WithMessage("Description must be entered!");
            RuleFor(e => e.Location).NotEmpty().WithMessage("Location must be entered!");
            RuleFor(e => e.Email).NotEmpty().WithMessage("Email must be entered!");
            RuleFor(e => e.Phone).NotEmpty().WithMessage("Phone must be entered!");
        }
    }
}
