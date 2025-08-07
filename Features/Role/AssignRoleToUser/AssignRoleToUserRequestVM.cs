using FluentValidation;

namespace HRSystem.Features.Role.AssignRoleToUser
{
    public record AssignRoleToUserRequestVM(Guid RoleId,Guid UserId);
    public class AssignRoleToUserRequestVMValidator:AbstractValidator<AssignRoleToUserRequestVM>
    {
        public AssignRoleToUserRequestVMValidator()
        {
            RuleFor(e=>e.UserId).NotEmpty().WithMessage("you must choose a user id");
            RuleFor(e=>e.RoleId).NotEmpty().WithMessage("you must choose a role id");
        }
    }
}
