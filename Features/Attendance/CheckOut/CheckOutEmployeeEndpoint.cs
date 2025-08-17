using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Attendance.CheckIn.CheckInFilterInterceptor;
using HRSystem.Features.Attendance.CheckOut.Command;
using HRSystem.Features.Attendance.CheckOut.DTOs;
using HRSystem.Features.Attendance.CheckOut.VMs;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.Attendance.CheckOut
{
    public class CheckOutEmployeeEndpoint : BaseEndPoint<CheckOutEmployeeRequestVM, CheckOutEmployeeResponseVM>
    {
        public CheckOutEmployeeEndpoint(EndPointBaseParameters<CheckOutEmployeeRequestVM> parameters) : base(parameters)
        {
        }

        [HttpPost]
        [ServiceFilter(typeof(TimeZoneFilter))]
        public async Task<EndPointResponse<CheckOutEmployeeResponseVM>> CheckOut([FromBody] CheckOutEmployeeRequestVM request)
        {
            var validate = ValidateRequest(request);
            if (!validate.IsSuccess) return validate;

            var res = await mediator.Send(new CheckOutEmployeeCommand(mapper.Map<CheckOutEmployeeRequestDTO>(request)));
            return res.IsSuccess ?
                    EndPointResponse<CheckOutEmployeeResponseVM>.Success(mapper.Map<CheckOutEmployeeResponseVM>(res.Data),res.Message) :
                    EndPointResponse<CheckOutEmployeeResponseVM>.Failure(res.Message);
        }
    }
}
