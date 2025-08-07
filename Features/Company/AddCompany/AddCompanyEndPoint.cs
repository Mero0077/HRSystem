using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Company.AddCompany.Command;
using HRSystem.Features.Company.AddCompany.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.Company.AddCompany
{
    public class AddCompanyEndPoint : BaseEndPoint<AddCompanyRequestVM, AddCompanyResponseVM>
    {
        public AddCompanyEndPoint(EndPointBaseParameters<AddCompanyRequestVM> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndPointResponse<AddCompanyResponseVM>> AddCompany([FromBody] AddCompanyRequestVM request)
        {
           var res= await mediator.Send(new AddCompanyCommand(mapper.Map<AddCompanyDTO>(request)));
           return !res.IsSuccess?
                EndPointResponse<AddCompanyResponseVM>.Failure("Cant add", ErrorCodes.AlreadyExists):
                EndPointResponse<AddCompanyResponseVM>.Success(res.Data, "Company added!");
        }
    }
}
