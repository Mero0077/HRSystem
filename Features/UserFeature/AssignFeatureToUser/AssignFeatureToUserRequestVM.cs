using FluentValidation;

namespace HRSystem.Features.UserFeature.AssignFeatureToUser
{
    public record AssignFeatureToUserRequestVM(Guid UserId,Guid FeatureId);
    public class AssignFeatureToUserRequestVMValidator:AbstractValidator<AssignFeatureToUserRequestVM>
    {
        public AssignFeatureToUserRequestVMValidator()
        {
            
        }
    }
}
