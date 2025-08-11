namespace HRSystem.Features.Common.User
{
    public class GetUserByIdRequestViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }

        public ICollection<Guid> RoleIds { get; set; }
    }
}
