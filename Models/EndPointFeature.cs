namespace HRSystem.Models
{
    public class EndPointFeature:BaseModel
    {
        public virtual Feature Feature { get; set; }
        public virtual EndPointAction EndPointAction { get; set; }

        public Guid FeatureId { get; set; }
        public Guid EndPointActionId { get; set; }
    }
}
