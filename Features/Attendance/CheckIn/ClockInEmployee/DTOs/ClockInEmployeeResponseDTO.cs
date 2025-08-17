namespace HRSystem.Features.Attendance.CheckIn.ClockInEmployee.DTOs
{
    public class ClockInEmployeeResponseDTO
    {
        public Guid EmpId { get; set; }
        public DateTimeOffset? CheckInTime { get; set; }
        public DateTimeOffset? CheckOutTime { get; set; }
    }
}
