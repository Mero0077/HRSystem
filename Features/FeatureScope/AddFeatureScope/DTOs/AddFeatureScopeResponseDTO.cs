namespace HRSystem.Features.FeatureScope.AddFeatureScope.DTOs
{
    public class AddFeatureScopeResponseDTO
    {
        public Guid FeatureId { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid BranchId { get; set; }
        public Guid TeamId { get; set; }
    }
}
