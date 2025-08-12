namespace HRSystem.Features.UserFeature.AssignFeatureToUser.DTO
{
    public class AssignFeatureToUserRequestDTO
    {
        public Guid UserId { get; set; }
        public Guid FeatureId { get; set; }
    }
}
