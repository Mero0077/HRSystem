namespace HRSystem.Features.Attendance.CheckOut.DTOs
{
    public class CheckOutEmployeeRequestDTO
    {
        public Guid EmpId { get; set; }
        public DateTimeOffset? CheckOutTime { get; set; }
    }
}
