namespace HRSystem.Features.Branch.Create_Branch.DTOS
{
    public class CreateBranchResponseDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}
