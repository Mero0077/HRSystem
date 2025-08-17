using FluentValidation;

namespace HRSystem.Features.FeatureScope.RemoveFeatureScope.VMs
{
    public record RemoveFeatureScopeRequestVM(Guid FeatureId);
    public class RemoveFeatureScopeRequestVMValidator:AbstractValidator<RemoveFeatureScopeRequestVM>
    {
    }
}
