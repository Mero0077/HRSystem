using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Attendance.CheckIn.ClockInEmployee.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Features.Attendance.CheckIn.ClockInEmployee.Query
{
    public record CheckIfEmpHasAlreadyClockedInQuery(ClockInEmployeeRequestDTO ClockInEmployeeRequestDTO):IRequest<RequestResult<bool>>;
    public class CheckIfEmpHasAlreadyClockedInHandler : RequestHandlerBase<CheckIfEmpHasAlreadyClockedInQuery, bool>
    {
        private IGeneralRepository<Models.Attendance> _AttendanceRepository;
        public CheckIfEmpHasAlreadyClockedInHandler(IGeneralRepository<Models.Attendance> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _AttendanceRepository = generalRepository;
        }

        public override async Task<RequestResult<bool>> Handle(CheckIfEmpHasAlreadyClockedInQuery request, CancellationToken cancellationToken)
        {
            var TodayTime = DateTime.UtcNow.Date;
            var Tmw= DateTime.UtcNow.AddDays(1).Date;
            var exists = await _AttendanceRepository.Get(e => e.EmpId == request.ClockInEmployeeRequestDTO.EmpId && e.CheckInTime >= TodayTime
            && e.CheckInTime < Tmw && e.CheckOutTime==null).FirstOrDefaultAsync();

            return exists != null ?
                    RequestResult<bool>.Success(true, "Emp already clocked in and not checked out") :
                    RequestResult<bool>.Failure("Emp is not clocked in");
        }
    }
}
