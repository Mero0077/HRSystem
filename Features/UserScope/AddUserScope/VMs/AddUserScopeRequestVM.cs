using FluentValidation;

namespace HRSystem.Features.UserScope.AddUserScope.VMs
{
    public record AddUserScopeRequestVM(Guid UserId,Guid FeatureId, Guid OrganizationId,
                                        Guid CompanyId, Guid DepartmentId, Guid BranchId, Guid TeamId);
    public class AddUserScopeRequestVMValdiator:AbstractValidator<AddUserScopeResponseVM>
    {
        public AddUserScopeRequestVMValdiator()
        {
            
        }
    }
}
