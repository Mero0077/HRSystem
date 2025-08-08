using FluentValidation;

namespace HRSystem.Features.UserRole.AssignRoleToUser
{
    public record AssignRoleToUserRequestVM (List<Guid> RoleIds, Guid UserId);
    public class AssignRoleToUserRequestVMValidator : AbstractValidator<AssignRoleToUserRequestVM>
    {
        public AssignRoleToUserRequestVMValidator()
        {
            RuleFor(e => e.UserId).NotEmpty().WithMessage("you must choose a user id");
            RuleFor(e => e.RoleIds).NotEmpty().WithMessage("you must choose a role id");
        }
    }
}
