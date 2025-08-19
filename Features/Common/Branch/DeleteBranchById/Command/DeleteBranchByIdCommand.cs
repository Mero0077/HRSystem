using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Branch.Delete_Branch.DTOs;
using HRSystem.Features.Common.Branch.GetBranchByIdQuery.DTOs;
using HRSystem.Features.Common.Branch.GetBranchByIdQuery.Queries;
using MediatR;

namespace HRSystem.Features.Branch.Delete_Branch.Command
{
    public record DeleteBranchByIdCommand(Guid branchId) : IRequest<RequestResult<DeleteBranchResponseDTO>>;
    public class DeleteBranchCommandHandler : RequestHandlerBase<DeleteBranchByIdCommand, DeleteBranchResponseDTO>
    {
        private readonly IGeneralRepository<Models.Branch> _branchRepository;

        public DeleteBranchCommandHandler(IGeneralRepository<Models.Branch> branchRepository, RequestHandlerBaseParameters parameters) : base(parameters)
        {
            this._branchRepository = branchRepository;
        }

        public override async Task<RequestResult<DeleteBranchResponseDTO>> Handle(DeleteBranchByIdCommand request, CancellationToken cancellationToken)
        {
            var userStateOrganizationId = userState.OrganizationId;

            var result = await mediator.Send(new GetBranchByIdQuery(new
            GetBranchByIdQueryRequestDTO{ BranchId = request.branchId }
            ));
            if (!result.IsSuccess)
                return RequestResult<DeleteBranchResponseDTO>.Failure(result.Message,result.ErrorCodes);
            await _branchRepository.DeleteAsync(result.Data.Id, userStateOrganizationId);
            await _branchRepository.SaveChangesAsync(cancellationToken);
            return RequestResult<DeleteBranchResponseDTO>.Success(mapper.Map<DeleteBranchResponseDTO>(result.Data));
        }
    }

}
