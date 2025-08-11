namespace HRSystem.Features.UserRole.AssignRoleToUser.DTOs
{
    public class AssignRoleToUserDTO
    {
        public List<Guid> RoleIds { get; set; }
        public Guid UserId { get; set; }
    }
}
