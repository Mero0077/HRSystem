using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.UserRole.DeleteUserRole.Commands;
using HRSystem.Features.UserRole.DeleteUserRole.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.UserRole.DeleteUserRole
{
    public class DeleteUserRoleEndPoint: BaseEndPoint<DeleteUserRoleRequestVM, bool>
    {
        public DeleteUserRoleEndPoint(EndPointBaseParameters<DeleteUserRoleRequestVM> parameters)
        : base(parameters)
        {
        }


        [HttpPost]
        public async Task<EndPointResponse<bool>> DeleteUserRoles([FromBody] DeleteUserRoleRequestVM request)
        {
            var validate = ValidateRequest(request);
            if (!validate.IsSuccess) return validate;

            var res= await mediator.Send(new DeleteUserRoleCommand(mapper.Map<DeleteUserRoleDTO>(request)));
            return res.IsSuccess ?
                     EndPointResponse<bool>.Success(true, "Role deleted!") :
                     EndPointResponse<bool>.Failure("Role not deleted!");
        }
    }
}
