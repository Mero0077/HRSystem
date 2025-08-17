using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Department.AddDepartment.Command;
using HRSystem.Features.Department.AddDepartment.DTOs;
using HRSystem.Features.Department.AddDepartment.VMs;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.Department.AddDepartment
{
    public class AddDepartmentEndpoint : BaseEndPoint<AddDepartmentRequestVM, AddDepartmentResponseVM>
    {
        public AddDepartmentEndpoint(EndPointBaseParameters<AddDepartmentRequestVM> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndPointResponse<AddDepartmentResponseVM>> AddDepartment([FromBody] AddDepartmentRequestVM request)
        {
            var validate = ValidateRequest(request);
            if (!validate.IsSuccess) return validate;

            var res= await mediator.Send(new AddDepartmentCommand(mapper.Map<AddDepartmentRequestDTO>(request)));
            return res.IsSuccess ?
                    EndPointResponse<AddDepartmentResponseVM>.Success(mapper.Map<AddDepartmentResponseVM>(res.Data), res.Message) :
                    EndPointResponse<AddDepartmentResponseVM>.Failure(res.Message);
        }
    }
}
