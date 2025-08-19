using HRSystem.Common;
using HRSystem.Common.Enums;
using HRSystem.Common.Views;
using MediatR;

namespace HRSystem.Features.Common.Branch.IsBranchExistsQuery.Queries
{
    public record IsBranchExistsQuery(Guid branchId) : IRequest<RequestResult<bool>>;
    public class IsBranchExistsQueryHandler : RequestHandlerBase<IsBranchExistsQuery, bool>
    {
        private readonly IGeneralRepository<Models.Branch> _branchRepository;

        public IsBranchExistsQueryHandler(IGeneralRepository<Models.Branch> branchRepository,RequestHandlerBaseParameters parameters) : base(parameters)
        {
            this._branchRepository = branchRepository;
        }

        public override async Task<RequestResult<bool>> Handle(IsBranchExistsQuery request, CancellationToken cancellationToken)
        {
            var result = await _branchRepository.AnyAsync(e=>e.Id ==request.branchId);
            if (!result)
                return RequestResult<bool>.Failure("Branch Not Found",ErrorCodes.NotFound);
            return RequestResult<bool>.Success(result);
        }
    }
}
