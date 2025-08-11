using FluentValidation;

namespace HRSystem.Features.UserRole.UpdateUserRole
{
    public record UpdateUserRoleRequestVM(Guid RoleId, Guid UserId);
    public class UpdateRoleRequestVMValidator : AbstractValidator<UpdateUserRoleRequestVM>
    {
        public UpdateRoleRequestVMValidator()
        {
            RuleFor(x => x.RoleId).NotEmpty().WithMessage("You must enter role id to update it!");
        }
    }
}
