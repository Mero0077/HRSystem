using HRSystem.Common.Enums;

namespace HRSystem.Features.RoleScope.AssignRoleScope
{
    public class AssignRoleScopeResponseViewModel
    {
        public Guid RoleId { get; set; }
        public NodeLevel NodeLevel { get; set; }
        public Guid AssignedToId { get; set; }

    }
}
