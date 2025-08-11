namespace HRSystem.Features.Common.User.DTOs
{
    public class GetUserByIdResponseDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

        public ICollection<Guid> RoleIds { get; set; }
    }
}
