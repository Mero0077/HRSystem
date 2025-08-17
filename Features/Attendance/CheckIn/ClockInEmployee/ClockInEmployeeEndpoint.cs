using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Attendance.CheckIn.CheckInFilterInterceptor;
using HRSystem.Features.Attendance.CheckIn.ClockInEmployee.Command;
using HRSystem.Features.Attendance.CheckIn.ClockInEmployee.DTOs;
using HRSystem.Features.Attendance.CheckIn.ClockInEmployee.VMs;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.Attendance.CheckIn.ClockInEmployee
{
    public class ClockInEmployeeEndpoint : BaseEndPoint<ClockInEmployeeRequestVM, ClockInEmployeeResponseVm>
    {
        public ClockInEmployeeEndpoint(EndPointBaseParameters<ClockInEmployeeRequestVM> parameters) : base(parameters)
        {
        }

        [HttpPost]
        [ServiceFilter(typeof(TimeZoneFilter))]
        public async Task<EndPointResponse<ClockInEmployeeResponseVm>> ClockIn([FromBody] ClockInEmployeeRequestVM request)
        {
            var res = await mediator.Send(new ClockInEmployeeCommand(mapper.Map<ClockInEmployeeRequestDTO>(request)));

            return res.IsSuccess ?
                    EndPointResponse<ClockInEmployeeResponseVm>.Success(mapper.Map<ClockInEmployeeResponseVm>(res.Data), res.Message) :
                    EndPointResponse<ClockInEmployeeResponseVm>.Failure(res.Message);
        }
    }
}
