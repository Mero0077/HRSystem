using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.RoleScope.AssignRoleScope.Commands;
using HRSystem.Features.RoleScope.AssignRoleScope.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.RoleScope.AssignRoleScope.Endpoint
{

    public class AssignRoleScopeController : BaseEndPoint<AssignRoleScopeRequestViewModel, AssignRoleScopeResponseViewModel>
    {
        public AssignRoleScopeController(EndPointBaseParameters<AssignRoleScopeRequestViewModel> parameters) : base(parameters)
        {
        }
        [HttpPost]
        public async Task<EndPointResponse<AssignRoleScopeResponseViewModel>> AssignRoleScope([FromBody] AssignRoleScopeRequestViewModel assignRoleScopeRequestViewModel)
        {
            var requestDTO = mapper.Map<AssignRoleScopeRequestDTO>(assignRoleScopeRequestViewModel);
            var result = await mediator.Send(new AssignRoleScopeCommand(requestDTO));
            if (!result.IsSuccess)
                return EndPointResponse<AssignRoleScopeResponseViewModel>.Failure(result.Message,result.ErrorCodes);
            var responseViewModel =mapper.Map<AssignRoleScopeResponseViewModel>(result.Data);
            return EndPointResponse<AssignRoleScopeResponseViewModel>.Success(responseViewModel);
        }
    }
}
