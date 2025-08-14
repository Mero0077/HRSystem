using FluentValidation;

namespace HRSystem.Features.UserScope.GetUserScope.VMs
{
    public record GetUserScopeRequestVM(Guid Id);
    public class GetUserScopeRequestVMValidator:AbstractValidator<GetUserScopeRequestVM>
    {
        public GetUserScopeRequestVMValidator()
        {
            RuleFor(e=>e.Id).NotEmpty().WithMessage("Enter Id");
        }
    }
}
