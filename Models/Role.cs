namespace HRSystem.Models
{
    public class Role:BaseModel
    {
        public string Name { get; set; }

        public virtual ICollection<UserRole> UserRole { get; set; }
    }
}
