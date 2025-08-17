namespace HRSystem.Models
{
    public class Organization:BaseModel
    {
        public string Name { get; set; }
        public string? Logo { get; set; }
        public string? Description { get; set; }
        public string? Industry { get; set; }

        public virtual ICollection<Company> companies { get; set; }
    }
}
