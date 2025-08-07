namespace HRSystem.Models
{
    public class UserRole:BaseModel
    {
        public User user { get; set; }
        public Guid UserId { get; set; }

        public Role Role { get; set; }
        public Guid RoleId { get; set; }
    }
}
