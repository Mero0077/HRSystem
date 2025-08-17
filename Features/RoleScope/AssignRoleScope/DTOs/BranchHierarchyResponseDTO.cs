namespace HRSystem.Features.RoleScope.AssignRoleScope.DTOs
{
    public class BranchHierarchyResponseDTO
    {
        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Guid> DepartmentIds { get; set; } = new();
        public List<DepartmentHierarchyResponseDTO> Departments { get; set; } = new();
    }
}
