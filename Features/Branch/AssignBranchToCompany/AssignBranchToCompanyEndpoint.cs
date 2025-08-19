using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Branch.AssignBranchToCompany.Command;
using HRSystem.Features.Branch.AssignBranchToCompany.DTOs;
using HRSystem.Features.Branch.AssignBranchToCompany.VMs;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Features.Branch.AssignBranchToCompany
{
    public class AssignBranchToCompanyEndpoint : BaseEndPoint<AssignBranchToCompanyRequestVM, AssignBranchToCompanyResponseVM>
    {
        public AssignBranchToCompanyEndpoint(EndPointBaseParameters<AssignBranchToCompanyRequestVM> parameters) : base(parameters)
        {
        }

        [HttpPost]
        public async Task<EndPointResponse<AssignBranchToCompanyResponseVM>> AssignBranchToCompany([FromBody] AssignBranchToCompanyRequestVM requestVM)
        {
            var res= await mediator.Send(new AssignBranchToCompanyCommand(mapper.Map<AssignBranchToCompanyRequestDTO>(requestVM)));
            return res.IsSuccess ?
                    EndPointResponse<AssignBranchToCompanyResponseVM>.Success(mapper.Map<AssignBranchToCompanyResponseVM>(res), res.Message) :
                    EndPointResponse<AssignBranchToCompanyResponseVM>.Failure(res.Message);
        }
    }
}
