using FluentValidation;
using HRSystem.Common.Interfaces;

namespace HRSystem.Features.Attendance.CheckIn.ClockInEmployee.VMs
{
    public record ClockInEmployeeRequestVM(Guid EmpId, DateTimeOffset? CheckInTime, DateTimeOffset? CheckOutTime):ITimeZoneUTC
    {
        public Guid EmpId { get; init; } = EmpId;
        public DateTimeOffset? CheckInTime { get; set; } = CheckInTime;
        public DateTimeOffset? CheckOutTime { get; set; } = CheckOutTime;
        public class ClockInEmployeeRequestVMValidator : AbstractValidator<ClockInEmployeeRequestVM>
        {
            public ClockInEmployeeRequestVMValidator()
            {
                RuleFor(x => x.EmpId).NotEmpty();
                RuleFor(x => x.CheckInTime).NotEmpty();
            }
        }
    }

}
