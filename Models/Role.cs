namespace HRSystem.Models
{
    public class Role:BaseModel
    {
        public string Name { get; set; }

        public ICollection<UserRole> UserRole { get; set; }
    }
}
