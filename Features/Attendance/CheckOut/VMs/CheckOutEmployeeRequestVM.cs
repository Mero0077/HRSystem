using FluentValidation;
using HRSystem.Common.Interfaces;

namespace HRSystem.Features.Attendance.CheckOut.VMs
{
    public record CheckOutEmployeeRequestVM(Guid EmpId, DateTimeOffset? CheckInTime, DateTimeOffset? CheckOutTime) : ITimeZoneUTC
    {
        public Guid EmpId { get; init; } = EmpId;
        public DateTimeOffset? CheckInTime { get; set; } = CheckInTime;
        public DateTimeOffset? CheckOutTime { get; set; } = CheckOutTime;
        public class CheckOutEmployeeRequestVMValidator : AbstractValidator<CheckOutEmployeeRequestVM>
        {
            public CheckOutEmployeeRequestVMValidator()
            {

            }
            //public Guid EmpId { get; set; }
            //public DateTimeOffset? CheckOutTime { get; set; }
        }
    }
}
