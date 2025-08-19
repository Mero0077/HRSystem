namespace HRSystem.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; }= DateTime.UtcNow;
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public Guid OrganizationId { get; set; }
    }
}
