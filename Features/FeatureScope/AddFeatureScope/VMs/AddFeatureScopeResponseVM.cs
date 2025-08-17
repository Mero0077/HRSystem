using FluentValidation;

namespace HRSystem.Features.FeatureScope.AddFeatureScope.VMs
{
    public record AddFeatureScopeResponseVM(Guid FeatureId, Guid OrganizationId, Guid CompanyId,
                                            Guid DepartmentId, Guid BranchId, Guid TeamId);
    public class AddFeatureScopeResponseVMValidator:AbstractValidator<AddFeatureScopeResponseVM>
    {
        public AddFeatureScopeResponseVMValidator()
        {
            RuleFor(e=>e.FeatureId).NotEmpty();
        }
    }
}