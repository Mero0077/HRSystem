namespace HRSystem.Features.Attendance.CheckOut.DTOs
{
    public record CheckOutEmployeeRequestDTO(Guid EmpId, DateTimeOffset? CheckOutTime);
    public class CheckOutEmployeeRequestDTOValida
    {
        public Guid EmpId { get; set; }
        public DateTimeOffset? CheckOutTime { get; set; }
    }
}
