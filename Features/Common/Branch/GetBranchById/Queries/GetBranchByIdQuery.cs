using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using HRSystem.Features.Common.Branch.GetBranchByIdQuery.DTOs;
using MediatR;

namespace HRSystem.Features.Common.Branch.GetBranchByIdQuery.Queries
{
    public record GetBranchByIdQuery(GetBranchByIdQueryRequestDTO GetBranchByIdQueryRequestDTO) : IRequest<RequestResult<GetBranchByIdQueryResponseDTO>>;
    public class GetBranchByIdQueryHandler : RequestHandlerBase<GetBranchByIdQuery, GetBranchByIdQueryResponseDTO>
    {
        private readonly IGeneralRepository<Models.Branch> _branchRepository;

        public GetBranchByIdQueryHandler(IGeneralRepository<Models.Branch> branchRepository,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            this._branchRepository = branchRepository;
        }

        public override async Task<RequestResult<GetBranchByIdQueryResponseDTO>> Handle(GetBranchByIdQuery request, CancellationToken cancellationToken)
        {
            var branch = await _branchRepository.GetOneByIdAsync(request.GetBranchByIdQueryRequestDTO.BranchId, request.GetBranchByIdQueryRequestDTO.OrganizationId);
            if (branch == null)
                return RequestResult<GetBranchByIdQueryResponseDTO>.Failure("branch is not found", ErrorCodes.NotFound);
            var responseDTO =mapper.Map<GetBranchByIdQueryResponseDTO>(branch);
            if(request.GetBranchByIdQueryRequestDTO.CompanyId.HasValue && request.GetBranchByIdQueryRequestDTO.CompanyId != responseDTO.CompanyId )
                return RequestResult<GetBranchByIdQueryResponseDTO>.Failure("Branch doesn't belong to this company", ErrorCodes.NotFound);
     
            return RequestResult<GetBranchByIdQueryResponseDTO>.Success(responseDTO);

        }
    }
}
