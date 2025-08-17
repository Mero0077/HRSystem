namespace HRSystem.Features.Common.Organization.GetOrganizationWithChildren.DTOs
{
    public class GetOrganizationWithChildrenResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<CompanyResponseDTO> Companies { get; set; } = new();
    }
}
