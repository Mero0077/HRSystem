namespace HRSystem.Features.RoleFeature.AssignListFeaturesToRoleCommandHandler
{
    public class AssignListFeaturesToRoleRequestViewModel
    {
        public Guid RoleId { get; set; }
        public ICollection<Guid> FeatureIds { get; set; }
    }
}
