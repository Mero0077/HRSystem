namespace HRSystem.Features.UserRole.UpdateUserRole
{
    public class UpdateUserRoleResponseVM
    {
        public Guid UserId { get; set; }
        public List<Guid> RoleIds { get; set; }
    }
}
