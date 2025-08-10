using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.RoleFeature.AssignListFeaturesToRoleCommandHandler.Commands;
using HRSystem.Features.RoleFeature.AssignListFeaturesToRoleCommandHandler.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.RoleFeature.AssignListFeaturesToRoleCommandHandler.Endpoint
{
 
    public class AssignListFeaturesToRoleController : BaseEndPoint<AssignListFeaturesToRoleRequestViewModel, bool>
    {
        public AssignListFeaturesToRoleController(EndPointBaseParameters<AssignListFeaturesToRoleRequestViewModel> parameters) : base(parameters)
        {
        }

        [HttpPost]

        public async Task<EndPointResponse<bool>> AssignListFeaturesToRole(AssignListFeaturesToRoleRequestViewModel assignListFeaturesToRoleViewModel)
        {
            var requestDTOMapped = mapper.Map<AssignListFeaturesToRoleRequestDTO>(assignListFeaturesToRoleViewModel);
            var result =await mediator.Send(new AssignListFeaturesToRoleCommand(requestDTOMapped));
            if (!result.IsSuccess)
                return EndPointResponse<bool>.Failure(result.ErrorCodes);

            return EndPointResponse<bool>.Success(result.Data);

        }

    }
}
