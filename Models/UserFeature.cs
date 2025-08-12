namespace HRSystem.Models
{
    public class UserFeature:BaseModel
    {
        public virtual Feature Feature { get; set; }
        public virtual User User { get; set; }
        public Guid UserId { get; set; }
        public Guid FeatureId { get; set; }
    }
}
