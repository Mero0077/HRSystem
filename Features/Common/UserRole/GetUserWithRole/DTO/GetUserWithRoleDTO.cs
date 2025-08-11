namespace HRSystem.Features.Common.UserRole.GetUserWithRole.DTO
{
    public class GetUserWithRoleDTO
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<Guid> RoleIds { get; set; }

    }
}
