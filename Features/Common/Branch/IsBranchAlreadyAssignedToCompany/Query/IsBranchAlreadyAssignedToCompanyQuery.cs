using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Branch.AssignBranchToCompany.Command;
using HRSystem.Features.Branch.AssignBranchToCompany.DTOs;
using HRSystem.Features.Common.Branch.IsBranchAlreadyAssignedToCompany.DTOs;
using MediatR;

namespace HRSystem.Features.Common.Branch.IsBrancAlreadyAssignedToCompany.Query
{
    public record IsBranchAlreadyAssignedToCompanyQuery(IsBranchAlreadyAssignedToCompanyRequestDTO IsBranchAlreadyAssignedToCompanyRequestDTO):IRequest<RequestResult<bool>>;
    public class IsBrancAlreadyAssignedToCompanyQuerydHandler : RequestHandlerBase<IsBranchAlreadyAssignedToCompanyQuery, bool>
    {
        private IGeneralRepository<Models.Branch> _BranchRepository;
        public IsBrancAlreadyAssignedToCompanyQuerydHandler(IGeneralRepository<Models.Branch> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _BranchRepository = generalRepository;
        }

        public override async Task<RequestResult<bool>> Handle(IsBranchAlreadyAssignedToCompanyQuery request, CancellationToken cancellationToken)
        {
            var assigned = await _BranchRepository.AnyAsync(e => e.Id == request.IsBranchAlreadyAssignedToCompanyRequestDTO.BranchId && e.CompanyId == request.IsBranchAlreadyAssignedToCompanyRequestDTO.CompanyId);
            return assigned?
                    RequestResult<bool>.Success(true, "already assigned") :
                    RequestResult<bool>.Failure("not assigned");
        }
    }
}
