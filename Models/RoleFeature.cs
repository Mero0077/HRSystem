namespace HRSystem.Models
{
    public class RoleFeature : BaseModel
    {
        public Guid RoleId { get; set; }
        public  Guid FeatureId { get; set; }
        public virtual Feature Feature { get; set; }
        public virtual Role Role { get; set; }
    }
}
