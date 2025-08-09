using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.UserRole.UpdateUserRole.Orchestrator;
using HRSystem.Features.UserRole.UpdateUserRole.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.UserRole.UpdateUserRole
{
    public class UpdateUserRoleEndPoint : BaseEndPoint<UpdateUserRoleRequestVM, UpdateUserRoleResponseVM>
    {
        public UpdateUserRoleEndPoint(EndPointBaseParameters<UpdateUserRoleRequestVM> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndPointResponse<UpdateUserRoleResponseVM>> UpdateRole([FromBody] UpdateUserRoleRequestVM updateRoleRequestVM)
        {
            var res= await mediator.Send(new UpdateUserRoleCommand(mapper.Map<UpdateUserRoleDTO>(updateRoleRequestVM)));
            return !res.IsSuccess ?
                    EndPointResponse<UpdateUserRoleResponseVM>.Failure("Could not update role!") :
                    EndPointResponse<UpdateUserRoleResponseVM>.Success(res.Data, "Role updated!");
                
        }
    }
}
