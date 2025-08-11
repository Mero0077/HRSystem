using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Auth.Jwt.interfaces;
using HRSystem.Features.Organization.AddOrganization.Commands;
using HRSystem.Features.Organization.AddOrganization.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.Organization.AddOrganization
{
    public class AddOrganizationEndPoint:BaseEndPoint<AddOrganizationRequestVM,AddOrganizationReponseVM>
    {
        private IJwtGenerateHandler _jwtGenerateHandler;
        public AddOrganizationEndPoint(IJwtGenerateHandler jwtGenerateHandler, EndPointBaseParameters<AddOrganizationRequestVM> parameters):base(parameters) 
        {
            _jwtGenerateHandler = jwtGenerateHandler;
        }

        [HttpPost]
        public async Task<EndPointResponse<AddOrganizationReponseVM>> AddOrganization([FromBody] AddOrganizationRequestVM addOrganizationRequestVM)
        {
         var res= await  mediator.Send(new AddOrganizationCommand(mapper.Map<AddOrganizationDTO>(addOrganizationRequestVM)));
            return (res==null || res.Data==null || !res.IsSuccess)?
            EndPointResponse<AddOrganizationReponseVM>.Failure("Organization could not bed added!"):
            EndPointResponse<AddOrganizationReponseVM>.Success(res.Data, "Organization added!");
        }
        
    }
}
