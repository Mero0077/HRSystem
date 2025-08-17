namespace HRSystem.Features.Attendance.CheckIn.ClockInEmployee.VMs
{
    public class ClockInEmployeeResponseVm
    {
        public Guid EmpId { get; set; }
        public DateTimeOffset CheckInTime { get; set; }
        public DateTimeOffset? CheckOutTime { get; set; }
    }
}
