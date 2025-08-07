using FluentValidation;

namespace HRSystem.Features.Role.AddRole
{
    public record AddRoleRequestVM(string Name);
    public class AddRoleRequestVMValidator:AbstractValidator<AddRoleRequestVM>
    {
        public AddRoleRequestVMValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Role must be entered");
        }
    }
}
