using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.UserRole.AssignRoleToUser.Commands;
using HRSystem.Features.UserRole.AssignRoleToUser.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace HRSystem.Features.UserRole.AssignRoleToUser
{
    public class AssignRoleToUserEndPoint : BaseEndPoint<AssignRoleToUserRequestVM, AssignRoleToUserResponseVM>
    {
        public AssignRoleToUserEndPoint(EndPointBaseParameters<AssignRoleToUserRequestVM> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndPointResponse<AssignRoleToUserResponseVM>> AssignRoleToUser([FromBody] AssignRoleToUserRequestVM request)
        {
            var res = await mediator.Send(new AssignRoleToUserCommand(mapper.Map<AssignRoleToUserDTO>(request)));

            return res.IsSuccess ?
                    EndPointResponse<AssignRoleToUserResponseVM>.Success(res.Data, "Role Assigned To user successfylly1") :
                    EndPointResponse<AssignRoleToUserResponseVM>.Failure("Role was not Assigned To user!", ErrorCodes.NoError);
        }
    }
}
