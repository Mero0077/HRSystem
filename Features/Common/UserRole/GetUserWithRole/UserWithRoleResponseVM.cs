namespace HRSystem.Features.Common.UserRole.GetUserWithRole
{
    public class UserWithRoleResponseVM
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public List<Guid> RoleIds { get; set; }

    }
}
