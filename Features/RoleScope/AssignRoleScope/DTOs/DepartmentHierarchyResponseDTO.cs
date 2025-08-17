namespace HRSystem.Features.RoleScope.AssignRoleScope.DTOs
{
    public class DepartmentHierarchyResponseDTO
    {
        public Guid Id { get; set; }
        public Guid OrganizationId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid BranchId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
