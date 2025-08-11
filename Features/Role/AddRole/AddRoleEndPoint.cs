using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Role.AddRole.Commands;
using HRSystem.Features.Role.AddRole.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.Role.AddRole
{
    public class AddRoleEndPoint : BaseEndPoint<AddRoleRequestVM, AddRoleResponseVM>
    {
        public AddRoleEndPoint(EndPointBaseParameters<AddRoleRequestVM> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndPointResponse<AddRoleResponseVM>> AddRole([FromBody] AddRoleRequestVM request)
        {
            var validate = ValidateRequest(request);
            if (!validate.IsSuccess) return validate;

            var res= await mediator.Send(new AddRoleCommand(mapper.Map<AddRoleDTO>(request)));
            return (res.IsSuccess) ?
                  EndPointResponse<AddRoleResponseVM>.Success(res.Data) :
                  EndPointResponse<AddRoleResponseVM>.Failure("Could not add Role!");

        }
    }
}
