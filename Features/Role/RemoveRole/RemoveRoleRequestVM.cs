using FluentValidation;

namespace HRSystem.Features.Role.RemoveRole
{
    public record RemoveRoleRequestVM ( Guid RoleId);
    public class RemoveRoleRequestVMValidator:AbstractValidator<RemoveRoleRequestVM>
    {
        public RemoveRoleRequestVMValidator()
        {
            RuleFor(e=>e.RoleId).NotEmpty().WithMessage("You need to enetr a Role id");
        }
    }
}
