using FluentValidation;

namespace HRSystem.Features.UserRole.DeleteUserRole
{
    public record DeleteUserRoleRequestVM(Guid RoleId,Guid UserId);
    public class DeleteUserRoleRequestVMValidator:AbstractValidator<DeleteUserRoleRequestVM>
    {
        public DeleteUserRoleRequestVMValidator()
        {
            RuleFor(e=>e.RoleId).NotEmpty();
            RuleFor(e=>e.RoleId).NotEmpty();
        }
    }
}
