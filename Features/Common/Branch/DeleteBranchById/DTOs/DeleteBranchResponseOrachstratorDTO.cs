namespace HRSystem.Features.Common.Branch.DeleteBranchById.DTOs
{
    public class DeleteBranchResponseOrachstratorDTO
    {
        public Guid BranchId { get; set; }
        public List<Guid> DeletedDepartmentIds { get; set; } = new();
    }
}
