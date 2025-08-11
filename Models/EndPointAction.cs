namespace HRSystem.Models
{
    public class EndPointAction:BaseModel
    {
        public string Key { get; set; }
        public string Path { get; set; }
        public string HttpMethod { get; set; }


        public virtual ICollection<EndPointFeature> endPointFeature { get; set; }
    }
}
