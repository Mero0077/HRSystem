using HRSystem.Common;
using HRSystem.Common.Views;
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

        }
    }
}
