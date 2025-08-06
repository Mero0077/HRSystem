namespace HRSystem.Models
{
    public class Branch:BaseModel
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public string TimeZone { get; set; }

        public Company Company { get; set; }
        public Guid CompanyId { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
