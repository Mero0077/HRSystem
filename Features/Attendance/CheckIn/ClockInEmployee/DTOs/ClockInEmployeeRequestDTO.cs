namespace HRSystem.Features.Attendance.CheckIn.ClockInEmployee.DTOs
{
    public class ClockInEmployeeRequestDTO
    {
        public Guid EmpId { get; set; }
        public DateTimeOffset? CheckInTime { get; set; }
        public DateTimeOffset? CheckOutTime { get; set; }
    }
}
