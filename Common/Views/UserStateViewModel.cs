namespace HRSystem.Common.Views
{
    public class UserStateViewModel
    {
        public string UserID { set; get; }
        public string Email { get; set; }
        public string Name { get; set; }

        public List<string> RoleIds { get; set; }
        public Guid OrganizationId { get; set; }
    }
}
