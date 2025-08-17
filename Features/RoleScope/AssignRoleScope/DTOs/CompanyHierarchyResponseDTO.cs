namespace HRSystem.Features.RoleScope.AssignRoleScope.DTOs
{
    public class CompanyHierarchyResponseDTO
    {
        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Guid> BranchIds { get; set; } = new();
        public List<BranchHierarchyResponseDTO> Branches { get; set; } = new();
    }
}
