namespace HRSystem.Features.RoleFeature.UnAssignFeatureToRole.cs.DTOs
{
    public class UnAssignFeatureToRoleRequestDTO
    {
        public Guid RoleId { get; set; }
        public Guid FeatureId { get; set; }
    }
}
