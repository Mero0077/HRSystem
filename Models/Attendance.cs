namespace HRSystem.Models
{
    public class Attendance:BaseModel
    {
        public Guid EmpId { get; set; }
        public DateTimeOffset? CheckInTime { get; set; }
        public DateTimeOffset? CheckOutTime { get; set; }
    }
}
