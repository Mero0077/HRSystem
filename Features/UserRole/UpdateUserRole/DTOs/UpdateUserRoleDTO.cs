namespace HRSystem.Features.UserRole.UpdateUserRole.DTOs
{
    public class UpdateUserRoleDTO
    {
        public Guid UserId { get; set; }
        public List<Guid> RoleIds { get; set; }
    }
}
