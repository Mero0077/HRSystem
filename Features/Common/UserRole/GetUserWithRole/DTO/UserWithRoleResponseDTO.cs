namespace HRSystem.Features.Common.UserRole.GetUserWithRole.DTO
{
    public class UserWithRoleResponseDTO
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public List<Guid> RoleIds { get; set; }
        public Guid OrganizationId { get; set; }
    }
}
