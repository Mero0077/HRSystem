namespace HRSystem.Models
{
    public class Company:BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual Guid OrganizationId { get; set; }
        public virtual ICollection<Branch> Branches { get; set; }
    }
}
