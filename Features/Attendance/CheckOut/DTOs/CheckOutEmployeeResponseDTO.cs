namespace HRSystem.Features.Attendance.CheckOut.DTOs
{
    public class CheckOutEmployeeResponseDTO
    {
        public Guid EmpId { get; set; }
        public DateTimeOffset? CheckOutTime { get; set; }
    }
}
