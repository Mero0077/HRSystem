using FluentValidation;

namespace HRSystem.Features.Organization.AddOrganization
{

    public record AddOrganizationRequestVM(string Name,string Description,string Industry);
    public class AddOrganizationRequestVMValidator:AbstractValidator<AddOrganizationRequestVM>
    {
        public AddOrganizationRequestVMValidator()
        {
            RuleFor(e => e.Name).NotEmpty().WithMessage("Org Name is required");
            RuleFor(e=>e.Description).NotEmpty().WithMessage("Description is required");
            RuleFor(e=>e.Industry).NotEmpty().WithMessage("Industry is required");
        }
    }
}
