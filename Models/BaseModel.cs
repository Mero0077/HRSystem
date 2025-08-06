namespace HRSystem.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
