using HRSystem.Common.Enums;

namespace HRSystem.Features.RoleScope.AssignRoleScope.DTOs
{
    public class AssignRoleScopeResponseDTO
    {
        public Guid RoleId { get; set; }
        public NodeLevel NodeLevel { get; set; }
        public Guid AssignedToId { get; set; }

    }
}
