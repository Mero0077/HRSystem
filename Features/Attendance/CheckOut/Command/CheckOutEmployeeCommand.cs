using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Attendance.CheckOut.DTOs;
using MediatR;

namespace HRSystem.Features.Attendance.CheckOut.Command
{
    public record CheckOutEmployeeCommand(CheckOutEmployeeRequestDTO CheckOutEmployeeRequestDTO):IRequest<RequestResult<CheckOutEmployeeResponseDTO>>;
    public class CheckOutEmployeeCommandHandler : RequestHandlerBase<CheckOutEmployeeCommand, CheckOutEmployeeResponseDTO>
    {
        private IGeneralRepository<Models.Attendance> _AttendanceRepo;
        public CheckOutEmployeeCommandHandler(IGeneralRepository<Models.Attendance> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _AttendanceRepo = generalRepository;
        }

        public override async Task<RequestResult<CheckOutEmployeeResponseDTO>> Handle(CheckOutEmployeeCommand request, CancellationToken cancellationToken)
        {
            var TodayTime = DateTime.UtcNow.Date;
            var Tmw = DateTime.UtcNow.AddDays(1).Date;
            var attendance = await _AttendanceRepo.GetOneWithTrackingAsync(e => e.EmpId == request.CheckOutEmployeeRequestDTO.EmpId
             && e.CheckInTime>=TodayTime && e.CheckInTime<Tmw);
            if (attendance == null) return RequestResult<CheckOutEmployeeResponseDTO>.Failure("emp has not checked in ");

            if (attendance.CheckOutTime != null) return RequestResult<CheckOutEmployeeResponseDTO>.Failure("Employee has already checked out today.");

            attendance.CheckOutTime = request.CheckOutEmployeeRequestDTO.CheckOutTime;
            await _AttendanceRepo.SaveChangesAsync();
            return RequestResult<CheckOutEmployeeResponseDTO>.Success(mapper.Map<CheckOutEmployeeResponseDTO>(attendance), "emp checkout");
               
        }
    }
}
