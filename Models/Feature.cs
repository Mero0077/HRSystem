namespace HRSystem.Models
{
    public class Feature : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Code { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<EndPointFeature> endPointFeature { get; set; }
        public virtual ICollection<UserFeature> UserFeatures { get; set; }


    }
}
