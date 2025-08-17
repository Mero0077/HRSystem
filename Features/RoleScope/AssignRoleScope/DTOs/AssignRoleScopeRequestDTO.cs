using HRSystem.Common.Enums;

namespace HRSystem.Features.RoleScope.AssignRoleScope.DTOs
{
    public class AssignRoleScopeRequestDTO
    {
        public Guid RoleId { get; set; }
        public NodeLevel NodeLevel { get; set; }
        public Guid TargetId { get; set; }
        public bool IsActive { get; set; } = true;

    }
}
