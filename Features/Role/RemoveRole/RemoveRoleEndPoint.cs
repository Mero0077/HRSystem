using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Role.RemoveRole.Command;
using HRSystem.Features.Role.RemoveRole.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.Role.RemoveRole
{
    public class RemoveRoleEndPoint:BaseEndPoint<RemoveRoleRequestVM,RemoveRoleResponseVM>
    {
        public RemoveRoleEndPoint(EndPointBaseParameters<RemoveRoleRequestVM> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndPointResponse<RemoveRoleResponseVM>> RemoveRole([FromQuery] RemoveRoleRequestVM request)
        {
            var validate = ValidateRequest(request);
            if (!validate.IsSuccess) return validate;

            var res = await mediator.Send(new RemoveRoleCommand(mapper.Map<RemoveRoleDTO>(request)));

            return res.IsSuccess ?
                        EndPointResponse<RemoveRoleResponseVM>.Success(res.Data, "Role removed") :
                        EndPointResponse<RemoveRoleResponseVM>.Failure("Role was not removed");
        }
    }
}
