namespace HRSystem.Features.RoleScope.AssignRoleScope.DTOs
{
    public class OrganizationHierarchyResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<CompanyHierarchyResponseDTO> Companies { get; set; } = new();
    }
}
