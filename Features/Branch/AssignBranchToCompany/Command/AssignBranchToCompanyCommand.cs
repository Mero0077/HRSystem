using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Branch.AssignBranchToCompany.DTOs;
using HRSystem.Features.Branch.AssignBranchToCompany.VMs;
using HRSystem.Features.Company.AddCompany.Command;
using HRSystem.Features.Company.AddCompany;
using MediatR;
using HRSystem.Features.Common.Branch.IsBrancAlreadyAssignedToCompany.Query;
using HRSystem.Features.Common.Branch.IsBranchAlreadyAssignedToCompany.DTOs;

namespace HRSystem.Features.Branch.AssignBranchToCompany.Command
{
    public record AssignBranchToCompanyCommand(AssignBranchToCompanyRequestDTO AssignBranchToCompanyRequestDTO) :IRequest<RequestResult<AssignBranchToCompanyResponseDTO>>;
    public class AssignBranchToCompanyCommandHandler : RequestHandlerBase<AssignBranchToCompanyCommand, AssignBranchToCompanyResponseDTO>
    {
        public IGeneralRepository<Models.Branch> _BranchRepository { get; set; }
        public AssignBranchToCompanyCommandHandler(IGeneralRepository<Models.Branch> generalRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            _BranchRepository = generalRepository;
        }

        public override async Task<RequestResult<AssignBranchToCompanyResponseDTO>> Handle(AssignBranchToCompanyCommand request, CancellationToken cancellationToken)
        {
            var exists= await mediator.Send(new IsBranchAlreadyAssignedToCompanyQuery(mapper.Map<IsBranchAlreadyAssignedToCompanyRequestDTO>(request.AssignBranchToCompanyRequestDTO)));
            if (exists.IsSuccess) return RequestResult<AssignBranchToCompanyResponseDTO>.Failure("Branch already assigned!");

           var branch= await _BranchRepository.GetOneWithTrackingAsync(e=>e.Id==request.AssignBranchToCompanyRequestDTO.BranchId && e.CompanyId==request.AssignBranchToCompanyRequestDTO.CompanyId);
           branch.CompanyId= request.AssignBranchToCompanyRequestDTO.CompanyId;
           await _BranchRepository.SaveChangesAsync();

            return RequestResult<AssignBranchToCompanyResponseDTO>.Success(mapper.Map<AssignBranchToCompanyResponseDTO>(branch), "Branch assigned to company");
        }
    }
}
