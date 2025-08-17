namespace HRSystem.Features.Common.Organization.GetOrganizationWithChildren.DTOs
{
    public class CompanyResponseDTO
    {
        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Guid> BranchIds { get; set; } = new();
    }
}
