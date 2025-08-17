using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Company.AssignCompanyToOrganization.Command;
using HRSystem.Features.Company.AssignCompanyToOrganization.DTOs;
using HRSystem.Features.Company.AssignCompanyToOrganization.VMs;
using HRSystem.Features.UserFeature.AssignFeatureToUser;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.Company.AssignCompanyToOrganization
{
    public class AssignCompanyToOrganizationEndpoint : BaseEndPoint<AssignCompanyToOrganizationRequestVM, AssignCompanyToOrganizationResponseVM>
    {
        public AssignCompanyToOrganizationEndpoint(EndPointBaseParameters<AssignCompanyToOrganizationRequestVM> parameters) : base(parameters)
        {
        }

        [HttpPatch]
        public async Task<EndPointResponse<AssignCompanyToOrganizationResponseVM>> AssignCompanyToOrganization([FromBody] AssignCompanyToOrganizationRequestVM request)
        {
            var validate = ValidateRequest(request);
            if (!validate.IsSuccess) return validate;

            var res= await mediator.Send(new AssignCompanyToOrganizationCommand(mapper.Map<AssignCompanyToOrganizationRequestDTO>(request)));
            return res.IsSuccess ?
                    EndPointResponse<AssignCompanyToOrganizationResponseVM>.Success(mapper.Map<AssignCompanyToOrganizationResponseVM>(res)) :
                    EndPointResponse<AssignCompanyToOrganizationResponseVM>.Failure(res.Message);
        }
    }
}
