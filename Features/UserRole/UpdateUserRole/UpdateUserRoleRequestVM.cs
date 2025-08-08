using FluentValidation;

namespace HRSystem.Features.UserRole.UpdateUserRole
{
    public record UpdateUserRoleRequestVM(List<Guid> RoleIds, Guid UserId);
    public class UpdateRoleRequestVMValidator : AbstractValidator<UpdateUserRoleRequestVM>
    {
        public UpdateRoleRequestVMValidator()
        {
            RuleFor(x => x.RoleIds).NotEmpty().WithMessage("You must enter role id to update it!");
        }
    }
}
