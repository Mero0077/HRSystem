namespace HRSystem.Features.Branch.Create_Branch.DTOS
{
    public class CreateBranchRequestDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string TimeZone { get; set; }
    }
}
