namespace HRSystem.Models
{
    public class RoleFeature : BaseModel
    {
        public Guid RoleId { get; set; }
        public Guid FeatureId { get; set; }
        public Feature Feature { get; set; }
        public Role Role { get; set; }
    }
}
