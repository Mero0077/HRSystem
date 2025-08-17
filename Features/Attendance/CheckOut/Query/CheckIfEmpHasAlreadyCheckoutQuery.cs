using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Attendance.CheckOut.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HRSystem.Features.Attendance.CheckOut.Query
{
    public record CheckIfEmpHasAlreadyCheckoutQuery(CheckOutEmployeeRequestDTO CheckOutEmployeeRequestDTO):IRequest<RequestResult<bool>>;
    public class CheckIfEmpHasAlreadyCheckoutQueryHandler : RequestHandlerBase<CheckIfEmpHasAlreadyCheckoutQuery, bool>
    {
        private IGeneralRepository<Models.Attendance> _AttendanceRepo;
        public CheckIfEmpHasAlreadyCheckoutQueryHandler(IGeneralRepository<Models.Attendance> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _AttendanceRepo = generalRepository;
        }

        public override async Task<RequestResult<bool>> Handle(CheckIfEmpHasAlreadyCheckoutQuery request, CancellationToken cancellationToken)
        {
            var Today = DateTime.UtcNow.Date;
            var Tmw = DateTime.UtcNow.AddDays(1).Date;
            var exists = await _AttendanceRepo.Get(e => e.EmpId == request.CheckOutEmployeeRequestDTO.EmpId && e.CheckOutTime != null && e.CheckInTime >= Today && e.CheckInTime < Tmw)
                .AnyAsync();

            return exists ?
                    RequestResult<bool>.Success(true, "Emp already clocked out!") :
                    RequestResult<bool>.Failure( "Emp has not clocked out!");
        }
    }
}
