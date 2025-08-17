namespace HRSystem.Features.Attendance.CheckOut.VMs
{
    public class CheckOutEmployeeResponseVM
    {
        public Guid EmpId { get; set; }
        public DateTimeOffset? CheckOutTime { get; set; }
    }
}
