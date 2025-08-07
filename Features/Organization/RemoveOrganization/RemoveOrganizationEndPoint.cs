using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Organization.RemoveOrganization.Commands;
using HRSystem.Features.Organization.RemoveOrganization.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.Organization.RemoveOrganization
{
    public class RemoveOrganizationEndPoint : BaseEndPoint<RemoveOrganizationRequestVM, RemoveOrganizationResponseVM>
    {
        public RemoveOrganizationEndPoint(EndPointBaseParameters<RemoveOrganizationRequestVM> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndPointResponse<RemoveOrganizationResponseVM>> RemoveOrganization([FromQuery] RemoveOrganizationRequestVM removeOrganizationRequestVM)
        {
          var res= await mediator.Send(new RemoveOrganizationCommand(mapper.Map<RemoveOrganizationDTO>(removeOrganizationRequestVM)));
            if (!res.IsSuccess) return EndPointResponse<RemoveOrganizationResponseVM>.Failure(HRSystem.Common.Enums.ErrorCodes.AlreadyDeleted);
            else return EndPointResponse<RemoveOrganizationResponseVM>.Success(res.Data, "Deleted");
        }
    }
}
