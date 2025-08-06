using HRSystem.Common;
using HRSystem.Common.Views;
using HRSystem.Features.Branch.Create_Branch.DTOS;
using MediatR;

namespace HRSystem.Features.Branch.Create_Branch.Command
{

    public record CreateBranchCommand (CreateBranchRequestDTO  CreateBranchRequestDTO): IRequest<RequestResult<CreateBranchResponseDTO>>;
    public class CreateBranchCommandHandler : RequestHandlerBase<CreateBranchCommand, CreateBranchResponseDTO>
    {
        private readonly IGeneralRepository<Models.Branch> _branchRepository;

        public CreateBranchCommandHandler(RequestHandlerBaseParameters parameters,IGeneralRepository<Models.Branch> branchRepository) : base(parameters)
        {
            this._branchRepository = branchRepository;
        }
        public async override Task<RequestResult<CreateBranchResponseDTO>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var result = await _branchRepository.AddAsync(mapper.Map<Models.Branch>(request.CreateBranchRequestDTO));
            await _branchRepository.SaveChangesAsync();
            return RequestResult<CreateBranchResponseDTO>.Success(mapper.Map<CreateBranchResponseDTO>(result));
        }
    }
}
