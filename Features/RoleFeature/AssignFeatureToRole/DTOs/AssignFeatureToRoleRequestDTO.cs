namespace HRSystem.Features.RoleFeature.AssignFeatureToRole.DTOs
{
    public class AssignFeatureToRoleRequestDTO
    {
        public Guid FeatureId { get; set; }
        public Guid RoleId { get; set; }
    }
}
