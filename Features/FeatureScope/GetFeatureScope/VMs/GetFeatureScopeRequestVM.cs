using FluentValidation;

namespace HRSystem.Features.FeatureScope.GetFeatureScope.VMs
{
    public record GetFeatureScopeRequestVM(Guid FeatureId);
    public class GetFeatureScopeRequestVMValidator:AbstractValidator<GetFeatureScopeRequestVM>
    {
    }
}
