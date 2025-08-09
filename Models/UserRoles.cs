namespace HRSystem.Models
{
    public class UserRole:BaseModel
    {
        public virtual User user { get; set; }
        public  Guid UserId { get; set; }

        public virtual Role Role { get; set; }
        public  Guid RoleId { get; set; }
    }
}
