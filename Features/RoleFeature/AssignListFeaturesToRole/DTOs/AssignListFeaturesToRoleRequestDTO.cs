namespace HRSystem.Features.RoleFeature.AssignListFeaturesToRoleCommandHandler.DTOs
{
    public class AssignListFeaturesToRoleRequestDTO
    {
        public Guid RoleId { get; set; }
        public ICollection<Guid> FeatureIds { get; set; }
    }
}
