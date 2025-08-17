using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Attendance.CheckIn.ClockInEmployee.DTOs;
using HRSystem.Features.Attendance.CheckIn.ClockInEmployee.Query;
using MediatR;

namespace HRSystem.Features.Attendance.CheckIn.ClockInEmployee.Command
{
    public record ClockInEmployeeCommand(ClockInEmployeeRequestDTO ClockInEmployeeRequestDTO) : IRequest<RequestResult<ClockInEmployeeResponseDTO>>;
    public class ClockInEmployeeCommandHandler : RequestHandlerBase<ClockInEmployeeCommand, ClockInEmployeeResponseDTO>
    {
        private IGeneralRepository<Models.Attendance> _attendanceRepository;
        public ClockInEmployeeCommandHandler(IGeneralRepository<Models.Attendance> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _attendanceRepository = generalRepository;
        }

        public override async Task<RequestResult<ClockInEmployeeResponseDTO>> Handle(ClockInEmployeeCommand request, CancellationToken cancellationToken)
        {
            var exists = await mediator.Send(new CheckIfEmpHasAlreadyClockedInQuery(request.ClockInEmployeeRequestDTO));
            if(exists != null) return RequestResult<ClockInEmployeeResponseDTO>.Failure(exists.Message);

            var res= await _attendanceRepository.AddAsync(mapper.Map<Models.Attendance>(request.ClockInEmployeeRequestDTO));
            await _attendanceRepository.SaveChangesAsync();

            return res != null ?
                    RequestResult<ClockInEmployeeResponseDTO>.Success(mapper.Map<ClockInEmployeeResponseDTO>(res),"Clockin successfull") :
                    RequestResult<ClockInEmployeeResponseDTO>.Failure("Could not add clock in!");
        }
    }
}
