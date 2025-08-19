namespace HRSystem.Features.Common.User.GetUserById.DTOs
{
    public class GetUserByIdResponseDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

        public ICollection<Guid> RoleIds { get; set; }

        public Guid OrganizationId { get; set; }
    }
}
